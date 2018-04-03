using System;
using System.Collections.Generic;
using System.Text;

namespace VehIC_WF.Device
{
    public enum CardReaderUseType
    {
        室内,
        进门,
        出门
    }

    public class CardReader
    {
        private int portid = 0;

        public int Portid
        {
            get { return portid; }
            set { portid = value; }
        }
        private int baudrate = 9200;

        public int Baudrate
        {
            get { return baudrate; }
            set { baudrate = value; }
        }
        private int controlid = 0;

        public int Controlid
        {
            get { return controlid; }
            set { controlid = value; }
        }

        private PortDeviceType portDeviceType = PortDeviceType.FixRFIDReader;

        public PortDeviceType PortDeviceType
        {
            get { return portDeviceType; }
            set { portDeviceType = value; }
        }

        private CardReaderUseType useTyp = CardReaderUseType.室内;

        public CardReaderUseType UseType
        {
            get
            {
                return useTyp;
            }
        }
       
        public CardReader()
        {

        }

        public CardReader(int portid, int baudrate, int controlid, int addr, PortDeviceType portDeviceType, CardReaderUseType useTyp)
        {
            this.portid = portid;
            this.baudrate = baudrate;
            this.controlid = controlid;
            this.useTyp = useTyp;
            this.portDeviceType = portDeviceType;
            DeviceManager.Instance.GetPortDevice(portid, baudrate, portDeviceType);
        }

        private bool _CanUse=true;

        public bool CanUse
        {
            get { return _CanUse; }
            set { _CanUse = value; }
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

        private string lastCardId = "";
        private DateTime lastReadTime = DateTime.Now;

        public string Excute()
        {
            if (!CanUse) return "";
            IPortDevice device = DeviceManager.Instance.GetPortDevice(portid, baudrate, portDeviceType);
            if (device != null)
            {
                string cardid = device.Excute(this.controlid);
                if (!string.IsNullOrEmpty(cardid))
                {
                    lastReadTime = DateTime.Now;
                    if (lastCardId != cardid)
                    {
                        lastCardId = cardid;
                        return cardid;
                    }
                }
            }
            if (DateTime.Now - lastReadTime > TimeSpan.FromSeconds(2))
            {
                lastCardId = "";
            }
            return "";
        }

    }
}
