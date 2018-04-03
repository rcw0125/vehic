namespace VehIC_WF
{
    using System;
    using VehIC_Device;

    public class LocalInfo
    {
        //public bool device_reader_status;
        //public bool device_RoadBrake1_status;
        //public bool device_RoadBrake2_status;
        //public DeviceList Devices;
        //public IRoadBrake RoadBrake;
        public bool ISLocked = false;
        public string ServerUrl = "";
        public UserInfo user;
        public WorkPointInfo workpoint;
        public WorkPointList workpointlist;

        public static LocalInfo Current
        {
            get {
                return FrmMain.localinfo;
            }
        }
    }
}

