using System;
using System.Collections.Generic;
using System.Text;

namespace VehIC_WF.Device
{
    public class RoadBrake
    {
        private int portid = 0;
        private int baudrate = 9200;
        private int controlid = 0;
        private int addr = 0;
        private PortDeviceType portDeviceType;

        public RoadBrake(int portid, int baudrate, int controlid,int addr, PortDeviceType type)
        {
            this.portid = portid;
            this.baudrate = baudrate;
            this.controlid = controlid;
            this.addr = addr;
            this.portDeviceType = type;
            DeviceManager.Instance.GetPortDevice(portid, baudrate, type);
        }

        public bool Available()
        {
            IPortDevice device = DeviceManager.Instance.GetPortDevice(portid, baudrate, portDeviceType);
            if (device != null)
            {
                return device.Available();
            }
            return false;
        }

        public bool KZ()
        {
            IPortDevice device = DeviceManager.Instance.GetPortDevice(portid,baudrate,portDeviceType);
            if (device != null)
            {
                return device.Kz(this.controlid, addr);
            }
            return false;
        }
    }
}
