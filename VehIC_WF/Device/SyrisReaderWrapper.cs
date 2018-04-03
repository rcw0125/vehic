using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text;

namespace VehIC_WF.Device
{
    public class SyrisReaderWrapper:IPortDevice
    {
        private SerialPort comm = new SerialPort();
        
        public bool torun = true;

        private int port = 5;
        private int baudrate = 19200;

        public SyrisReaderWrapper(int port, int baudrate)
        {
            this.port = port;
            this.baudrate = baudrate;
           
        }

        public bool Available()
        {
            return (this.torun && this.ISConnected());
        }
     
        public bool ISConnected()
        {
            return comm.IsOpen;
        }
  
        public bool OpenDevice()
        {
            bool result = false;
            if (comm.IsOpen) comm.Close();
            comm.PortName = "COM" + port.ToString();
            comm.BaudRate = baudrate;
            comm.NewLine = "/r/n";
            comm.RtsEnable = true;
            comm.Parity = Parity.Even;
            comm.DataBits = 8;
            comm.StopBits = StopBits.One;
            comm.ReadTimeout = 1000;
            comm.WriteTimeout = 1000;
            try
            {
                comm.Open();
                result = true;
            }
            catch
            {
                comm = new SerialPort();
            }
            return result;
        }

        public bool CloseDevice()
        {
            try
            {
                comm.Close();
            }
            catch
            {
            }
            return true;
        }

        public void Dispose()
        {
            this.CloseDevice();
        }

        public string Excute(int controlid)
        {
            string CardNo = string.Empty;
            if (this.Available())
            {
                byte[] buf = SY230NT.CommPakage(string.Format("A{0}F", controlid));
                comm.Write(buf, 0, buf.Length);
                byte[] rbuf = new byte[255];
                int cnt = comm.Read(rbuf, 0, 255);
                if (cnt > 0)
                {
                    byte[] rbuf2 = new byte[cnt];
                    for (int i = 0; i < cnt; i++)
                    {
                        rbuf2[i] = rbuf[i];
                    }
                    string msg = SY230NT.GetPakageData(rbuf2);
                    if (!string.IsNullOrEmpty(msg))
                    {
                        StringBuilder sb = new StringBuilder();
                        if (msg.Length == 8)
                        {
                            sb.Append(msg[6]);
                            sb.Append(msg[7]);
                            sb.Append(msg[4]);
                            sb.Append(msg[5]);
                            sb.Append(msg[2]);
                            sb.Append(msg[3]);
                            sb.Append(msg[0]);
                            sb.Append(msg[1]);
                            CardNo = sb.ToString();
                        }
                    }
                }
            }
            return CardNo;
        }

        public bool Kz(int controlid, int addr)
        {
            throw new NotImplementedException();
        }

        public PortDeviceType GetDeviceType()
        {
            return PortDeviceType.SyrisReader;
        }
    }
}
