namespace VehIC_WF.Utility
{
    using Microsoft.Win32;
    using System;
    using System.Configuration;
    using System.Windows.Forms;

    public class Regedit
    {
        private static string company = "VehIC";

        public static string Read(string paraclass, string paraname)
        {
            try
            {
                return Registry.LocalMachine.OpenSubKey("SOFTWARE", true).CreateSubKey(company).CreateSubKey(paraclass).GetValue(paraname).ToString();
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static int ReadInt(string paraclass, string paraname,int defaultVal)
        {
            string strVal = Read(paraclass, paraname);
            if (strVal != null)
            {
                int result = 0;
                if (int.TryParse(strVal, out result))
                {
                    return result;
                }
            }
            return defaultVal;
        }

        public static string ReadDevicePara(string devicename, string paraname)
        {
            try
            {
                return Registry.LocalMachine.OpenSubKey("SOFTWARE", true).CreateSubKey(company).CreateSubKey("Devices").CreateSubKey(devicename).GetValue(paraname).ToString();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static int ReadDeviceIntPara(string devicename, string paraname,int defaultVal)
        {
            string strVal = ReadDevicePara(devicename, paraname);
            if (strVal != null)
            {
                int result=0;
                if (int.TryParse(strVal, out result))
                {
                    return result;
                }
            }
            return defaultVal;
        }

        public static void Save(string paraclass, string paraname, string paravalue)
        {
            try
            {
                
                Registry.LocalMachine.OpenSubKey("SOFTWARE", true).CreateSubKey(company).CreateSubKey(paraclass).SetValue(paraname, paravalue);
            }
            catch (Exception)
            {
                MessageBox.Show("创建注册表键值失败！");
            }
        }

        public static void SaveDevicePara(string devicename, string paraname, string paravalue)
        {
            try
            {
                Registry.LocalMachine.OpenSubKey("SOFTWARE", true).CreateSubKey(company).CreateSubKey("Devices").CreateSubKey(devicename).SetValue(paraname, paravalue);
            }
            catch (Exception)
            {
                MessageBox.Show("创建注册表键值失败！");
            }
        }
        public static void SaveDevicePara(string devicename, string paraname, string paravalue, int defaultvalue)
        {
            if (!string.IsNullOrEmpty(paravalue))
            {
                int result = 0;
                if (int.TryParse(paravalue.Trim(), out result))
                {
                    SaveDevicePara(devicename, paraname, result.ToString());
                    return;
                }
            }
            SaveDevicePara(devicename, paraname, defaultvalue.ToString());
        }
    }
}

