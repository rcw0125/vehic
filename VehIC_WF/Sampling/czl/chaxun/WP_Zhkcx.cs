using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Xg.Lab.Sample;
using Zhc.Data;
using VehIC_WF.Sampling.czl.Class;
using VehIC_WF.Class;

namespace VehIC_WF.Sampling.czl.WorkPoint
{
    public partial class WP_Zhkcx : UserControl
    {
        public WP_Zhkcx()
        {
            InitializeComponent();
        }
        private DbEntityTable<QC_Sample_Mix> zyMixSamples = new DbEntityTable<QC_Sample_Mix>();
        private DbEntityTable<QC_Zhkcx> cxs = new DbEntityTable<QC_Zhkcx>();
        private DbEntityTable<QC_Sample_Veh> vehs = new DbEntityTable<QC_Sample_Veh>();
        DbEntityTable<BD_INVBASDOC> wl = new DbEntityTable<BD_INVBASDOC>();
        private void WP_Zhkcx_Load(object sender, EventArgs e)
        {
            this.gridControl1.DataSource = cxs;
            List<String> wl = new List<String>();
            wl.Add("全部");
            vehs.LoadDataBySql("select distinct (h.INVNAME) as MatName from QC_Sample_Veh t ,BD_INVBASDOC h where h.PK_INVBASDOC=t.MatPK");
            foreach (var item in vehs)
            {
                if (!wl.Contains(item.MatName) && item.MatName != "")
                    wl.Add(item.MatName);
            }
            vehs.Clear();
            comboBox2.DataSource = wl;
        }

        private void 查询_Click(object sender, EventArgs e)
        {
            cxs.Clear();

            zyMixSamples.LoadDataByWhere("main.Mix_Time>=@Kssj and main.Mix_Time<=@Jssj and (main.LocalQcLevel<> ''or main.Sample_Cylx='管理抽样' or main.Sample_Cylx='普通抽样' ) order by  main.Mix_Time ", DateTime.Parse(this.dateEdit1.Text.Trim()), DateTime.Parse(this.dateEdit2.Text.Trim()));
       
            for (int i = 0; i < zyMixSamples.Count;i++ )
            {
                string cph = txtCph.Text.Trim();
                if (comboBox2.Text == "全部")
                {
                    vehs.LoadDataByWhere(string.Format("VehNo like  '%{0}%' and (Sample_Mix_ID=@Sample_Mix_ID or NoticeBillId=@NoticeBillId) ", cph), zyMixSamples[i].Sample_Mix_ID, zyMixSamples[i].NoticeBillId);
                }

                else vehs.LoadDataByWhere(string.Format("VehNo like  '%{0}%' and (Sample_Mix_ID=@Sample_Mix_ID or NoticeBillId=@NoticeBillId) and  dhd.INVNAME=@MatName ", cph), zyMixSamples[i].Sample_Mix_ID, zyMixSamples[i].NoticeBillId, comboBox2.Text);
                    zyMixSamples[i].CheckVals.LoadDataBySampleMixId(zyMixSamples[i].Sample_Mix_ID);
                    for (int j = 0; j < vehs.Count; j++)
                    {
                        QC_Zhkcx cx = new QC_Zhkcx();
                        cx.Tempid = zyMixSamples[i].TempID;
                        cx.Sjsl = vehs[j].Sjsl;
                        cx.Xh = i + 1;
                        cx.Ch = vehs[j].VehNo;
                        cx.Wlmc = zyMixSamples[i].MatName;
                        cx.Qysj = vehs[j].FetchTime;
                        cx.Gysmc = zyMixSamples[i].SupplierName;
                        cx.Pddj = zyMixSamples[i].LocalQcLevel;
                        cx.FetchPlace = zyMixSamples[i].FetchPlace;
                        cx.FetchPerson = zyMixSamples[i].FetchPerson;
                        cx.Zyd = zyMixSamples[i].WpCode;
                        if (zyMixSamples[i].Sample_Cylx == "" || zyMixSamples[i].Sample_Cylx == null)
                        { cx.Yplx = zyMixSamples[i].LeiXing; }
                        else cx.Yplx = zyMixSamples[i].Sample_Cylx;
                        cx.Ks = vehs[j].KouShui;
                        cx.Kz = vehs[j].KouZa;
                        foreach (var item in zyMixSamples[i].CheckVals)
                        {
                            if (item.CheckItemName == "水分")
                            {
                                cx.Sf = item.ReportVal;

                            }
                            else if (item.CheckItemName == "灰分")
                            {
                                cx.Hf = item.ReportVal;

                            }
                            else if (item.CheckItemName == "挥发分")
                            {
                                cx.Hff = item.ReportVal;

                            }
                            else if (item.CheckItemName == "硫分")
                            {
                                cx.Lf = item.ReportVal;
                            }
                            else if (item.CheckItemName == "X")
                            {
                                cx.X = item.ReportVal;
                            }
                            else if (item.CheckItemName == "Y")
                            {
                                cx.Y = item.ReportVal;
                            }
                            else if (item.CheckItemName == "G")
                            {
                                cx.G = item.ReportVal;
                            }
                            else if (item.CheckItemName == "标准差S")
                            {
                                cx.Bzc = item.ReportVal;
                            }
                            else if (item.CheckItemName == "Rmax")
                            {
                                cx.Rmax = item.ReportVal;
                            }
                            else if (item.CheckItemName == "可磨性")
                            {
                                cx.Kmx = item.ReportVal;
                            }
                            else if (item.CheckItemName == "发热量")
                            {
                                cx.Rz = item.ReportVal;
                            }
                            else if (item.CheckItemName == "P")
                            {
                                cx.P = item.ReportVal;
                            }
                            else if (item.CheckItemName == "S")
                            {
                                cx.S = item.ReportVal;
                            }

                        }
                        cxs.Add(cx);
                    }
                
            }
        
        
        
        }

        private void 导出ExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.gridView1.Export(DevExpress.XtraPrinting.ExportTarget.Xls, saveFileDialog1.FileName);
            }

        }
    }
}
