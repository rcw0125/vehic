using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text;
using VehIC_Device;

namespace VehIC_WF.Device
{
    public class SyrisReader:VehIC_Device.Device
    {
        private SerialPort comm = new SerialPort();
        
        private int iHANDLEID = -1;
        public bool torun = true;
        public DeviceType m_type;

        private int port = 5;
        private int baudrate = 19200;
        private int deviceId = 1;
   
        public SyrisReader(int port,int baudrate,int macno,VehIC_Device.DeviceType m_type)
        {
            this.port = port;
            this.baudrate = baudrate;
            this.deviceId = macno;
        }
        public bool Available()
        {
            return (this.ToRun() && this.ISConnected());
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

        public string Excute()
        {
            string CardNo = string.Empty;
            if (this.Available())
            {
                byte[] buf = SY230NT.CommPakage(string.Format("A{0}F",deviceId));
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
                        CardNo = msg;
                    }
                }
            }
            return CardNo;
        }

        public DeviceType GetType()
        {
            return this.m_type;
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

        public bool ToRun()
        {
            return this.torun;
        }
    }
}
