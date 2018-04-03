using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Zhc.Data;
using Xg.Lab.Sample;
using System.Net;
using Xg.Tools;

namespace VehIC_WF.Sampling
{
    public partial class WP_Tbzd : UserControl
    {
        DbEntityTable<QC_IC_Info> xycards = new DbEntityTable<QC_IC_Info>();
        DbEntityTable<QC_Sample_Veh> vehs = new DbEntityTable<QC_Sample_Veh>();
       
        public WP_Tbzd()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            vehs.Save();
        }

        private void WP_Tbzd_Load(object sender, EventArgs e)
        {
            vehs.LoadDataByWhere("main.FetchTime>=@FetchTime", DateTime.Now.AddHours(-24));
            this.qCSampleVehBindingSource.DataSource=vehs;
        }

        private void 删除错误车辆ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QC_Sample_Veh veh = (QC_Sample_Veh)this.qCSampleVehBindingSource.Current;
            //string strURL = "http://192.168.2.42:7080/MeasureService/qualityInterface/cancelSampleFlag.do?matchid=" + veh.NoticeBillId  + "&samplercode=" + LocalInfo.Current.user.ID + "&samplername=" + LocalInfo.Current.user.Name;
            //System.Net.HttpWebRequest request;
            //request = (System.Net.HttpWebRequest)WebRequest.Create(strURL);
            //System.Net.HttpWebResponse response;
            //response = (System.Net.HttpWebResponse)request.GetResponse();
            //System.IO.StreamReader myreader = new System.IO.StreamReader(response.GetResponseStream(), Encoding.UTF8);
            //string responseText = myreader.ReadToEnd();
            //myreader.Close();
            //String str = responseText.Split(',')[0].Substring(responseText.Split(',')[0].Length - 4);
            //if (str == "true")
            MessageBox.Show("删除成功");
            xycards.LoadDataByWhere("CardID=@CardID and CardType=@CardType", veh.CardID, QC_IC_Info.CardUseType_Veh);
            foreach (var xy in xycards)
            {
                xy.SampleId = 0;
                xy.Save();
            }
            this.qCSampleVehBindingSource.RemoveCurrent();
            vehs.Save();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            vehs.LoadDataByWhere("main.SAMPLE_MIX_ID=0 and main.FetchTime>=@FetchTime", DateTime.Now.AddHours(-24));
            this.qCSampleVehBindingSource.DataSource = vehs;
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void 回传取样信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QC_Sample_Veh veh = (QC_Sample_Veh)this.qCSampleVehBindingSource.Current;
            string strURL = "http://192.168.2.42:7080/MeasureService/qualityInterface/returnsampleflag.do?matchid=" + veh.NoticeBillId + "&sampleunitcode=" + FrmMain.localinfo.workpoint.Code + "&sampleunitname=" + FrmMain.localinfo.workpoint.Name + "&cph=" + veh.VehNo + "&icno=&samplercode=" + LocalInfo.Current.user.ID + "&samplername=" + LocalInfo.Current.user.Name + "&deduction=" + StringTool.FNumVal(veh.KouShui.ToString()) + "&deduction2=" + StringTool.FNumVal(veh.KouZa.ToString());
                    System.Net.HttpWebRequest request;
                    request = (System.Net.HttpWebRequest)WebRequest.Create(strURL);
                    System.Net.HttpWebResponse response;
                    response = (System.Net.HttpWebResponse)request.GetResponse();
                    System.IO.StreamReader myreader = new System.IO.StreamReader(response.GetResponseStream(), Encoding.UTF8);
                    string responseText = myreader.ReadToEnd();
                    myreader.Close();
                    String str = responseText.Split(',')[0].Substring(responseText.Split(',')[0].Length - 4);
                    if (str == "true")
                    {
                        DbContext.ExeSql("update tb_noticebill_head set status=2 where status=0 and noticebillid=@noticebillid",veh.NoticeBillId); 
                        MessageBox.Show("取样信息回传成功");
                    }
        }
    }
}
