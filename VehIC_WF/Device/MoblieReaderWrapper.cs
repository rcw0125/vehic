using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace VehIC_WF.Device
{
    public class MoblieReaderWrapper : VehIC_Device.CommBase,IPortDevice
    {
        public string errmsg;
        public bool Immediate;
       // private InvokeDelegate invoke;
        public bool isopen;
        public string outputdata;
        private string recvstr;
        public VehIC_Device.CommBase.CommBaseSettings settings;
        public bool torun;

        public MoblieReaderWrapper(int portid, int bautrate)
        {
            this.outputdata = string.Empty;
            this.torun = true;
            this.isopen = false;
            this.errmsg = string.Empty;
            this.recvstr = string.Empty;
            this.Immediate = false;
            this.settings = new VehIC_Device.CommBase.CommBaseSettings();
            this.settings.baudRate = 9600;
            this.settings.port = "COM" + portid;
        }

        public bool Available()
        {
            return (this.ToRun() && this.ISConnected());
        }
     
        public bool OpenDevice()
        {
            this.CloseDevice();
            try
            {
                bool flag = base.Open();
                return (this.isopen = flag);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool CloseDevice()
        {
            try
            {
                base.Close();
                this.isopen = false;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        protected override VehIC_Device.CommBase.CommBaseSettings CommSettings()
        {
            return this.settings;
        }

        public new  void Dispose()
        {
            this.CloseDevice();
            base.Dispose();
        }

        public string Excute()
        {
            string outputdata = this.outputdata;
            this.outputdata = string.Empty;
            return outputdata;
        }

        public new VehIC_Device.CommBase.QueueStatus GetQueueStatus()
        {
            return base.GetQueueStatus();
        }

        public new bool IsCongested()
        {
            return base.IsCongested();
        }

        public bool ISConnected()
        {
            return this.isopen;
        }

        protected override void OnRxChar(byte c)
        {
            if (c == 10)
            {
                this.outputdata = this.recvstr;
                this.recvstr = string.Empty;
            }
            else
            {
                this.recvstr = this.recvstr + ((char) c);
            }
        }

        public void SendChar(byte c)
        {
            if (this.Immediate)
            {
                base.SendImmediate(c);
            }
            else
            {
                base.Send(c);
            }
        }

        public bool SendCtrl(string s)
        {
            VehIC_Device.CommBase.ASCII nULL = VehIC_Device.CommBase.ASCII.NULL;
            try
            {
                nULL = (VehIC_Device.CommBase.ASCII)Enum.Parse(nULL.GetType(), s, true);
            }
            catch
            {
                return false;
            }
            this.SendChar((byte) nULL);
            return true;
        }

        public void SendFile(FileStream fs)
        {
            byte[] buffer = new byte[fs.Length];
            fs.Read(buffer, 0, (int) fs.Length);
            base.Send(buffer);
        }

        public bool ToRun()
        {
            return this.torun;
        }

        public string Excute(int controlid)
        {
            return Excute();
        }

        public bool Kz(int controlid, int addr)
        {
            throw new NotImplementedException();
        }

        public PortDeviceType GetDeviceType()
        {
            return PortDeviceType.Mobile;
        }
    }
}
