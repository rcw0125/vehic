using System;
using System.Collections.Generic;
using System.Text;
using VehIC_Device;

namespace VehIC_WF.Device
{
    public class SyrisControl : VehIC_Device.Device,IRoadBrake
    {
        private int iHANDLEID = -1;
        public bool torun = true;
        public DeviceType m_type;

        private int port = 5;
        private int baudrate = 19200;
        private int controlid = 1;
        private int roadbrake1 = 1;
        private int roadbrake2 = 2;
      
        public SyrisControl(int port, int baudrate, int controlid, int roadbrake1, int roadbrake2,DeviceType m_type)
        {
            this.port = port;
            this.baudrate = baudrate;
            this.controlid = controlid;
            this.roadbrake1 = roadbrake1;
            this.roadbrake2 = roadbrake2;
            this.m_type = m_type;
        }

        public bool Available()
        {
            return (this.ToRun() && this.ISConnected());
        }

        public bool CloseDevice()
        {
            return SY230NT.Close_COMMS(iHANDLEID) == 1;
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
                int ModuleID = 0;
                int YYYY = 0, MM = 0, DD = 0, hh = 0, nn = 0, ss = 0;
                StringBuilder No = new StringBuilder(100);
                StringBuilder Status = new StringBuilder(100);
                int result = SY230NT.GetOneInOut(iHANDLEID,controlid, ref ModuleID, ref YYYY, ref MM, ref DD, ref hh, ref nn, ref ss, No, Status);
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

        public bool KZ(int door)
        {
            if (Available())
            {
                if (door == 1)
                {
                    return SY230NT.RemoteOpenDoorControl(iHANDLEID, controlid, roadbrake1, 3) == 1;
                }
                else
                {
                    return SY230NT.RemoteOpenDoorControl(iHANDLEID, controlid, roadbrake2, 3) == 1;
                }
            }
            return false;
        }

        public DeviceType GetType()
        {
            return this.m_type;
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

        public bool ToRun()
        {
            return this.torun;
        }
    }
}
