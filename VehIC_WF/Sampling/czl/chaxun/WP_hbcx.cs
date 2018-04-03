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
using VehIC_WF.Sampling.czl.chaxun;

namespace VehIC_WF.Sampling.czl.WorkPoint
{
    public partial class WP_hbcx : UserControl
    {
        public WP_hbcx()
        {
            InitializeComponent();
        }
        private DbEntityTable<QC_Sample_Mix> zyMixSamples = new DbEntityTable<QC_Sample_Mix>();
        private DbEntityTable<QC_Sample_Mix> zyMixSamples1 = new DbEntityTable<QC_Sample_Mix>();
        private DbEntityTable<QC_Hbcx> cxs = new DbEntityTable<QC_Hbcx>();
        private void WP_Zhkcx_Load(object sender, EventArgs e)
        {
            this.gridControl1.DataSource = cxs;
        }

        private void 查询_Click(object sender, EventArgs e)
        {
         
            cxs.Clear();
            QC_Sample_Mix mix=new QC_Sample_Mix ();
            zyMixSamples.LoadDataByWhere("main.Mix_Time>=@Kssj and main.Mix_Time<=@Jssj and main.samplestate=9 and main.WLLX='煤' and main.Mix_Time>@Mix_Time order by  main.Mix_Time ", DateTime.Parse(this.dateEdit1.Text.Trim()), DateTime.Parse(this.dateEdit2.Text.Trim()), Convert.ToDateTime("2017-09-30 18:00:00"));
           
            for (int i = 0; i < zyMixSamples.Count; i++)
            {
                zyMixSamples[i].CheckVals.LoadDataBySampleMixId(zyMixSamples[i].Sample_Mix_ID);
                bool cunzai = false;
                for (int j = 0; j < zyMixSamples1.Count; j++)
                {

                    if (zyMixSamples[i].MatPK == zyMixSamples1[j].MatPK && zyMixSamples[i].SupplierCode == zyMixSamples1[j].SupplierCode && zyMixSamples[i].Riqi == zyMixSamples1[j].Riqi)
                    {
                        cunzai = true;
                        foreach (var item in zyMixSamples1[j].CheckVals)
                        {
                            if (item.CheckItemName == "S" || item.CheckItemName == "硫分")
                            { 
                           
                             foreach (var it in zyMixSamples[i].CheckVals)
                             {
                                 if (it.CheckItemName == "S" || it.CheckItemName == "硫分")
                                 {
                                     if (Convert.ToDouble(it.ReportVal) < Convert.ToDouble(item.ReportVal))
                                     {
                                         zyMixSamples1.Remove(zyMixSamples1[j]);
                                         zyMixSamples1.Add(zyMixSamples[i]);
                                     }
                                 }
                             }
                            }
                        
                        }
                        }

                     } 
                if (cunzai == false)
                {
                    zyMixSamples1.Add(zyMixSamples[i]);
                }
            
            }






















            for (int i = 0; i < zyMixSamples1.Count; i++)
                {
                

                    QC_Hbcx cx = new QC_Hbcx();
                    cx.Xh = i + 1;

                    cx.Wlmc = zyMixSamples1[i].MatName;
                    cx.Riqi = zyMixSamples1[i].Mix_Time.Value.ToString("yyyy-MM-dd");
                    cx.Gysmc = zyMixSamples1[i].SupplierName;
                    cx.Pddj = zyMixSamples1[i].LocalQcLevel;
                    foreach (var item in zyMixSamples1[i].CheckVals)
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
                        else if (item.CheckItemName == "S")
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

                        else if (item.CheckItemName == "发热量")
                        {
                            cx.Frl = item.ReportVal;
                        }


                    }
                    cxs.Add(cx);


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
