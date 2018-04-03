namespace VehIC_WF
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using VehIC;
    using VehIC_WF.Utility;
    using Xg.Lab.Sample;

    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Zhc.Data.DbContext.AddDataSource("vehic", Zhc.Data.DbContext.DbType_SqlServer, "192.168.2.34", "VehIc", "sa", "vehic0901");
            Zhc.Data.DbContext.DefaultDataSourceName = "vehic";
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("zh-CN");
            DevExpress.XtraEditors.Controls.Localizer.Active = new XtraControlLocalizer();
            DevExpress.XtraGrid.Localization.GridLocalizer.Active = new XtraGridLocalizer();

            SingleApplication.Run(new FrmMain());

        }


    }
}

