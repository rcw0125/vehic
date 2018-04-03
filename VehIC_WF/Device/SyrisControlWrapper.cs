using System;
using System.Collections.Generic;
using System.Text;

namespace VehIC_WF.Device
{
    public class SyrisControlWrapper:IPortDevice
    {
        private int iHANDLEID = -1;
        public bool torun = true;

        private int port = 5;
        private int baudrate = 19200;
        
        public SyrisControlWrapper(int port, int baudrate)
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
            return iHANDLEID >= 0;
        }
     
        public bool OpenDevice()
        {
            iHANDLEID = SY230NT.Open_COMMS(0, port, baudrate.ToString() + ",e,8,1", "", 0, 1000);
            return iHANDLEID >= 0;
        }

        public bool CloseDevice()
        {
            return SY230NT.Close_COMMS(iHANDLEID) == 1;
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
                int ModuleID = 0;
                int YYYY = 0, MM = 0, DD = 0, hh = 0, nn = 0, ss = 0;
                StringBuilder No = new StringBuilder(100);
                StringBuilder Status = new StringBuilder(100);
                int result = SY230NT.GetOneInOut(iHANDLEID, controlid, ref ModuleID, ref YYYY, ref MM, ref DD, ref hh, ref nn, ref ss, No, Status);
                if (result == 1)
                {
                    StringBuilder cardId = new StringBuilder(50);
                    if (No.ToString().Contains("XX"))
                    {
                        try
                        {
                            int n = Convert.ToInt32(No.ToString().Replace("XX", ""));
                            if (SY230NT.GetInvalidCardID(iHANDLEID, controlid, n, cardId) == 1)
                            {
                                CardNo = cardId.ToString();
                                if (CardNo.Length >= 8)
                                {
                                    CardNo = CardNo.Substring(CardNo.Length - 8);
                                }
                            }
                        }
                        catch
                        {
                        }
                    }
                }
                SY230NT.DeleteAllInOut(iHANDLEID, controlid);
            }
            return CardNo;
        }

        public bool Kz(int controlid, int door)
        {
            if (Available())
            {
                int count = DeviceConfigManager.Instance.config.SyrisKZCount;
                int time = DeviceConfigManager.Instance.config.SyrisKZTime;
                int interval = DeviceConfigManager.Instance.config.SyrisKZInterval;
                if (time < 1) time = 0;
                if (time > 60) time = 60;
                if (interval < 0) interval = 0;
                for (int i = 1; i < count; i++)
                {
                    SY230NT.RemoteOpenDoorControl(iHANDLEID, controlid, door, time);
                   System.Threading.Thread.Sleep(time * 1000 + interval);
                }
                SY230NT.RemoteOpenDoorControl(iHANDLEID, controlid, door, time);
                return true;
            }
            return false;
        }


        public PortDeviceType GetDeviceType()
        {
            return PortDeviceType.SyrisControl;
        }
    }
}
