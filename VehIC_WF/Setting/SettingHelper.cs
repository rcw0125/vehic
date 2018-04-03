namespace VehIC_WF.Setting
{
    using System;

    public class SettingHelper
    {
        public static string path = @"\Flash File Store\SWMS\Bill\";
        private static string Path = @"D:\VehIC\Setting";

        public static string CheckDirExist()
        {
            return Path;
        }

        public static string GetExcelConn(string filename)
        {
            return ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " + filename + ";Extended Properties=Excel 8.0;HDR=Yes;");
        }
    }
}

