using System;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace VehIC_WF.Device
{

    [Serializable]
    public class DeviceInfo
    {
        public string FuncType { get; set; }
        public string Port { get; set; }

        private int baudrate = 9600;
        public int Baudrate
        {
            get
            {
                if (baudrate <= 0) baudrate = 9600;
                return baudrate;
            }
            set
            {
                baudrate = value;
            }
        }

        public int ControlId { get; set; }
        public int Addr { get; set; }
        public string DeviceType { get; set; }
        public string UseType { get; set; }

        [XmlIgnore]
        public int PortId
        {
            get
            {
                try
                {
                    string s = Port.Trim().Substring(3);
                    int num = int.Parse(s);
                    return num;
                }
                catch (Exception)
                {
                }
                return 0;
            }
        }

        public PortDeviceType PortDeviceType
        {
            get
            {
                switch (DeviceType)
                {
                    case "固定读卡器":
                        return PortDeviceType.FixRFIDReader;
                    //   break;
                    case "移动读卡器":
                        return PortDeviceType.Mobile;
                    //   break;
                    case "原有道闸控制器":
                    case "道闸读卡器":
                        return PortDeviceType.RoadBrake;
                    //   break;
                    case "玺瑞道闸读卡器":
                    case "玺瑞道闸控制器":
                        return PortDeviceType.SyrisControl;
                    //   break;
                    case "玺瑞独立读卡器":
                        return PortDeviceType.SyrisReader;
                    //  break;
                }
                if (FuncType == "RoadBrake")
                    return PortDeviceType.RoadBrake;
                else
                    return PortDeviceType.FixRFIDReader;
            }
        }

        public CardReaderUseType CardReaderUseType
        {
            get
            {
                switch (UseType)
                {
                    case "室内":
                        return CardReaderUseType.室内;
                    case "进门":
                        return CardReaderUseType.进门;
                    case "出门":
                        return CardReaderUseType.出门;
                }
                return CardReaderUseType.室内;
            }
        }

        private bool _InUse = false;
        public bool InUse { get { return _InUse; } set { _InUse = value; } }
    }

    [Serializable]
    public class DeviceConfig
    {
        public List<DeviceInfo> Devices = new List<DeviceInfo>();

        public void Add(DeviceInfo deviceInfo)
        {
            Devices.Add(deviceInfo);
        }

        public DeviceInfo Get(int idx)
        {
            int cnt = Devices.Count;
            if (cnt < idx + 1)
            {
                for (int i = cnt; i < idx + 1; i++)
                {
                    Devices.Add(new DeviceInfo());
                }
            }
            return Devices[idx];
        }
        private int syrisKZCount = 1;
        /// <summary>
        /// 希瑞开闸次数
        /// </summary>
        public int SyrisKZCount
        {
            get { return syrisKZCount; }
            set { syrisKZCount = value; }
        }

        private int syrisKZTime = 3;
        /// <summary>
        /// 开闸持续时间 单位（秒）
        /// </summary>
        public int SyrisKZTime
        {
            get { return syrisKZTime; }
            set { syrisKZTime = value; }
        }

        private int syrisKZInterval = 500;
        /// <summary>
        /// 开闸指令间隔 单位（毫秒）
        /// </summary>
        public int SyrisKZInterval
        {
            get { return syrisKZInterval; }
            set { syrisKZInterval = value; }
        }


        private int printType = 0;
        /// <summary>
        /// 打印类型 0为原始 1：周转，只使用票据打印机
        /// </summary>
        public int PrintType
        {
            get { return printType; }
            set { printType = value; }
        }

        private string  _Jysb ;
        /// <summary>
        /// 打印类型 0为原始 1：周转，只使用票据打印机
        /// </summary>
        public string Jysb
        {
            get { return _Jysb; }
            set { _Jysb = value; }
        }

        private string _Jysbsjk;
        /// <summary>
        /// 打印类型 0为原始 1：周转，只使用票据打印机
        /// </summary>
        public string Jysbsjk
        {
            get { return _Jysbsjk; }
            set { _Jysbsjk = value; }
        }
    }

    public class DeviceConfigManager
    {
        public static readonly DeviceConfigManager Instance = new DeviceConfigManager();

        public DeviceConfig config = new DeviceConfig();

        private string configFileName = "DeviceConfig.xml";
        private int maxCount = 8;

        public int GetDeviceCount
        {
            get
            {
                return maxCount;
            }
        }

        private DeviceConfigManager()
        {
            Load();
        }

        public void Load()
        {
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(DeviceConfig));
                XmlReader sr = XmlReader.Create(configFileName);
                config = (DeviceConfig)ser.Deserialize(sr);
                sr.Close();
            }
            catch
            {
            }
            if (config == null) config = new DeviceConfig();
        }

        public void Save()
        {
            try
            {
                XmlWriter wr = XmlWriter.Create(configFileName);
                XmlSerializer ser = new XmlSerializer(typeof(DeviceConfig));
                ser.Serialize(wr, config);
                wr.Close();
            }
            catch (Exception e)
            {
            }
        }

        public DeviceInfo GetDeviceInfo(int idx)
        {
            if (idx < 0) return null;
            if (idx >= maxCount) return null;
            return config.Get(idx);
        }
    }

}
