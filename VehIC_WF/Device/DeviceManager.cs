using System;
using System.Collections.Generic;
using System.Text;

namespace VehIC_WF.Device
{
    public interface IPortDevice : IDisposable
    {
        bool OpenDevice();
        bool CloseDevice();
        bool Available();
        PortDeviceType GetDeviceType();

        string Excute(int controlid);
        bool Kz(int controlid, int addr);
    }

    public enum PortDeviceType
    {
        FixRFIDReader = 0,
        Mobile = 1,
        RoadBrake = 2,
        SyrisControl = 3,
        SyrisReader = 4,
        Usb=5
    }

    public class DeviceManager:IDisposable
    {
        public static readonly DeviceManager Instance = new DeviceManager();

        private Dictionary<int, IPortDevice> devices = new Dictionary<int, IPortDevice>();

        public List<CardReader> CardReaders = new List<CardReader>();

        public RoadBrake InRoadBrake = null;
        public RoadBrake OutRoadBrake = null;

        private DeviceManager()
        {

        }
     
        /// <summary>
        /// 进门指令
        /// </summary>
        /// <returns></returns>
        public bool InDoor()
        {
            if (InRoadBrake != null)
            {
                return InRoadBrake.KZ();
            }
            return false;
        }

        /// <summary>
        /// 出门指令
        /// </summary>
        /// <returns></returns>
        public bool OutDoor()
        {
            if (OutRoadBrake != null)
            {
                return OutRoadBrake.KZ();
            }
            return false;
        }

        public void Init()
        {
            for (int i = 0; i < DeviceConfigManager.Instance.GetDeviceCount; i++)
            {
                DeviceInfo device = DeviceConfigManager.Instance.GetDeviceInfo(i);
                if (device != null)
                {
                    if (device.InUse)
                    {
                        if (device.FuncType == "CardReader")
                        {
                            CardReaders.Add(new CardReader(device.PortId, device.Baudrate, device.ControlId, device.Addr, device.PortDeviceType, device.CardReaderUseType));
                        }
                        else if (device.FuncType == "RoadBrake")
                        {
                            if (device.UseType == "进门")
                            {
                                InRoadBrake = new RoadBrake(device.PortId, device.Baudrate, device.ControlId, device.Addr, device.PortDeviceType);
                            }
                            else if (device.UseType == "出门")
                            {
                                OutRoadBrake = new RoadBrake(device.PortId, device.Baudrate, device.ControlId, device.Addr, device.PortDeviceType);
                            }
                        }
                    }
                }
            }
        }
        
        public IPortDevice GetPortDevice(int port, int baudrate, PortDeviceType type)
        {
            if (!devices.ContainsKey(port))
            {
                switch (type)
                {
                    case PortDeviceType.FixRFIDReader:
                        FixRFIDReaderWrapper d1 = new FixRFIDReaderWrapper(port, baudrate);
                        devices.Add(port, d1);
                        break;
                    case PortDeviceType.Mobile:
                        MoblieReaderWrapper d2 = new MoblieReaderWrapper(port, baudrate);
                        devices.Add(port, d2);
                        break;
                    case PortDeviceType.RoadBrake:
                        CommonRoadBrakeWrapper d3 = new CommonRoadBrakeWrapper(port, baudrate);
                        devices.Add(port, d3);
                        break;
                    case PortDeviceType.SyrisControl:
                        SyrisControlWrapper d4 = new SyrisControlWrapper(port, baudrate);
                        devices.Add(port, d4);
                        break;
                    case PortDeviceType.SyrisReader:
                        SyrisReaderWrapper d5 = new SyrisReaderWrapper(port, baudrate);
                        devices.Add(port, d5);
                        break;
                    default:
                        throw new Exception("未知设备类型");
                }
            }
            else
            {
                //if (devices[port].GetDeviceType() != type)
                //{
                //    throw new Exception("同一端口出现不同类型的设备");
                //}
            }
            return devices[port];
        }

        public void OpenAllDevice()
        {
            foreach (var item in devices)
            {
                item.Value.OpenDevice();
            }
        }

        public void CloseAllDevice()
        {
            foreach (var item in devices)
            {
                item.Value.CloseDevice();
            }
        }

        public bool HaveAvailableCardReader()
        {
            bool result = false;
            foreach (var item in CardReaders)
            {
                if (item.Available())
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        public bool HaveAvailableInRoadBrake()
        {
            if (InRoadBrake != null)
            {
                if (InRoadBrake.Available())
                    return true;
            }
            return false;
        }
      
        public bool HaveAvailableOutRoadBrake()
        {
            if (OutRoadBrake != null)
            {
                if (OutRoadBrake.Available())
                    return true;
            }
            return false;
        }

        public void Dispose()
        {
            CloseAllDevice();
        }
    }
}
