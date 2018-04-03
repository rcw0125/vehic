namespace VehIC_WF.Device
{
    using LFY;
    using System;
    using System.Windows.Forms;
    using VehIC_Device;
    using VehIC_Device.Scales;
    using VehIC_WF.Utility;

    public class ScalesAsst
    {
        public static IrdaDevice Irda;
        public static ScalesDevice Scale;

        public static void CloseDevice()
        {
            try
            {
                Irda.CloseDevice();
            }
            catch
            {
            }
            try
            {
                Scale.CloseDevice();
            }
            catch
            {
            }
        }

        public static void Dispose()
        {
            try
            {
                CloseDevice();
                Scale.Dispose();
                Irda = null;
                Scale = null;
            }
            catch
            {
            }
        }

        private static bool LoadPara()
        {
            try
            {
                string str = Regedit.ReadDevicePara("Irda", "InUse");
                string str2 = Regedit.ReadDevicePara("Irda", "DeviceType");
                string s = Regedit.ReadDevicePara("Scale", "Type");
                string str4 = Regedit.ReadDevicePara("Scale", "Port");
                string str5 = Regedit.ReadDevicePara("Scale", "BaudRate");
                string str6 = Regedit.ReadDevicePara("Scale", "DataBits");
                string str7 = Regedit.ReadDevicePara("Scale", "StopBits");
                string str8 = Regedit.ReadDevicePara("Scale", "Parity");
                if ((((str == null) || (s == null)) || (str4 == null)) || (str5 == null))
                {
                    MessageBox.Show("请先进行参数设置！");
                    return false;
                }
                if (Irda == null)
                {
                    Irda = new IrdaDevice((str2 == "1") ? IrdaType.AC6652 : IrdaType.PCL730);
                }
                if (Scale == null)
                {
                    Scale = new ScalesDevice();
                }
                Irda.InUse = str == "1";
                Irda.IrdaType = (str2 == "1") ? IrdaType.AC6652 : IrdaType.PCL730;
                Scale.TypeOfScale = (ScaleType) int.Parse(s);
                Scale.COM_Port = "COM" + str4 + ":";
                Scale.COM_BautRate = int.Parse(str5);
                Scale.COM_DataBits = int.Parse(str6);
                Scale.COM_StopBits = (CommBase.StopBits) int.Parse(str7);
                Scale.COM_Parity = (CommBase.Parity) int.Parse(str8);
                return true;
            }
            catch (Exception exception)
            {
                MessageBox.Show("加载或设置参数时出错！\r\n" + exception.ToString());
                return false;
            }
        }

        public static bool OpenDevice()
        {
            CloseDevice();
            Dispose();
            if (!LoadPara())
            {
                return false;
            }
            if (Irda.InUse && !Irda.OpenDevice())
            {
                MessageBox.Show("打开红外设备失败！\r\n" + Irda.LastErrMsg);
            }
            if (!Scale.OpenDevice())
            {
                MessageBox.Show("打开地磅设备失败！\r\n" + Scale.ErrMsg);
                CloseDevice();
                return false;
            }
            return true;
        }

        public static void SetGaugePara(AGauge aGauge)
        {
            switch (Scale.Type)
            {
                case ScaleType.Scale_50t:
                    aGauge.MaxValue = 50f;
                    aGauge.ScaleLinesMajorStepValue = 10f;
                    break;

                case ScaleType.Scale_50tex:
                    aGauge.MaxValue = 50f;
                    aGauge.ScaleLinesMajorStepValue = 10f;
                    break;

                case ScaleType.Scale_80t:
                    aGauge.MaxValue = 80f;
                    aGauge.ScaleLinesMajorStepValue = 10f;
                    break;

                case ScaleType.Scale_100t:
                    aGauge.MaxValue = 100f;
                    aGauge.ScaleLinesMajorStepValue = 10f;
                    break;

                case ScaleType.Scale_150t:
                    aGauge.MaxValue = 150f;
                    aGauge.ScaleLinesMajorStepValue = 25f;
                    break;
            }
        }
    }
}

