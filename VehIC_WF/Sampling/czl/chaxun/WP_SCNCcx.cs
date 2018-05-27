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
using Xg.Lab.Sample.View;

namespace VehIC_WF.Sampling.czl.WorkPoint
{
    public partial class WP_SCNCcx : UserControl
    {
        public WP_SCNCcx()
        {
            InitializeComponent();
        }
        private DbEntityTable<QC_Sample_Mix> zyMixSamples = new DbEntityTable<QC_Sample_Mix>();

        private DbEntityTable<QC_SCNCcx> cxs = new DbEntityTable<QC_SCNCcx>();
        private void WP_Zhkcx_Load(object sender, EventArgs e)
        {
            this.qCSCNCcxBindingSource.DataSource = cxs;
        }
      
        public static int InspectSampleParentId(int InpsectSampleMixId)
        {
            object parentId = DbContext.ExecuteScalar("select veh.Sample_Mix_ID from QC_Sample_Veh veh INNER JOIN QC_Sample_Mix mix on mix.NoticeBillId=veh.NoticeBillId and mix.SampleType=" + Convert.ToInt32(SampleType.抽查样) + " Where mix.Sample_Mix_ID=@Sample_Mix_ID", InpsectSampleMixId);
            if (parentId != null)
            {
                return Convert.ToInt32(parentId);
            }
            return 0;
        }
        private void 查询_Click(object sender, EventArgs e)
        {
         
            cxs.Clear();
            QC_Sample_Mix mix=new QC_Sample_Mix ();
            zyMixSamples.LoadDataByWhere("main.Mix_Time>=@Kssj and main.Mix_Time<=@Jssj and main.samplestate=11 and main.WLLX='煤'  order by  main.ZyDanHao ", DateTime.Parse(this.dateEdit1.Text.Trim()), DateTime.Parse(this.dateEdit2.Text.Trim()));
      
            
     
            for (int i = 0; i < zyMixSamples.Count; i++)
            {
                if (zyMixSamples[i].SampleType == SampleType.抽查样)
                {
                    zyMixSamples[i].VehSamples.LoadDataByNoticeBillId(zyMixSamples[i].NoticeBillId);
                      int parentId = InspectSampleParentId(zyMixSamples[i].Sample_Mix_ID);
               
                    if (zyMixSamples[i].daycheck() == 0)
                    {
                        zyMixSamples[i].CheckVals.LoadInspectSampleAllData(zyMixSamples[i].Sample_Mix_ID, parentId);
                    }
                    else
                    {
                        zyMixSamples[i].CheckVals.LoadInspectHotAllData(zyMixSamples[i].Sample_Mix_ID, parentId, zyMixSamples[i].daycheck(), "发热量1");
                    }
                }
                else if (zyMixSamples[i].SampleType == SampleType.普通样)
                {
                    zyMixSamples[i].VehSamples.LoadDataBySampleMixId(zyMixSamples[i].Sample_Mix_ID);
                
                    if (zyMixSamples[i].daycheck() == 0)
                    {
                        zyMixSamples[i].CheckVals.LoadZhengSampleAllData(zyMixSamples[i].Sample_Mix_ID);
                    }
                    else
                    {
                        zyMixSamples[i].CheckVals.LoadHotData(zyMixSamples[i].daycheck(), zyMixSamples[i].Sample_Mix_ID, "发热量1");
                    }
                  
                }


                DbEntityTable<QC_MatAllCheckItem> matcheckitems = new DbEntityTable<QC_MatAllCheckItem>();

                matcheckitems.LoadDataByWhere("MATNCID=@MATNCID", zyMixSamples[i].MatPK);

            if (matcheckitems.Count > 0)
            {
                foreach (var item in matcheckitems)
                {
                    if (item.CheckGroupName == "可磨样")
                    {
                        bool czkm = false;
                        foreach (var it in zyMixSamples[i].CheckGroupLabs)
                        {
                            if (it.CheckGroupName == "可磨样")
                            { czkm = true; }


                        }
                        if (!czkm)
                        {
                            DbEntityTable<QC_Sample_Mix> lishimixs = new DbEntityTable<QC_Sample_Mix>();
                            string SQL = "select * from QC_Sample_Mix where MatCode='" + zyMixSamples[i].MatCode + "' and SupplierCode='" + zyMixSamples[i].SupplierCode + "' and mix_time>='" + zyMixSamples[i].ZyRecvTime.Value.Date + "'  and mix_time<'" + zyMixSamples[i].ZyRecvTime + "' order by ZyRecvTime desc";
                            lishimixs.LoadDataBySql(SQL);
                            foreach (var li in lishimixs)
                            {
                                bool czkmy = false;
                                DbEntityTable<QC_Sample_Lab> labs = new DbEntityTable<QC_Sample_Lab>();
                                labs.LoadDataByWhere("main.Sample_Mix_ID=@Sample_Mix_ID", li.Sample_Mix_ID);
                                foreach (var it in labs)
                                {
                                    if (it.CheckGroupName == "可磨样")
                                    {
                                        DbEntityTable<QC_Sample_Value> vals = new DbEntityTable<QC_Sample_Value>();
                                        vals.LoadDataByWhere("main.Sample_Lab_ID=@Sample_Lab_ID", it.Sample_Lab_ID);
                                        foreach (var va in vals)
                                        {
                                            va.ValSource = "前样";
                                            zyMixSamples[i].CheckVals.Add(va);
                                        }
                                        czkmy = true;
                                        break;
                                    }
                                }
                                if (czkmy) break;

                            }

                        }



                    }



                }
            }












                zyMixSamples[i].CheckVals.DefaultSort();
                if (zyMixSamples[i].SampleType == SampleType.普通样)
                { zyMixSamples[i].CheckVals.DaoxuSort(); }
                    DbEntityTable<QC_MatQualityLevel_View> levels = new DbEntityTable<QC_MatQualityLevel_View>();
                    levels.LoadDataByWhere("QUALITYLEVELID=@QUALITYLEVELID", zyMixSamples[i].QualityLevelID);
                    for (int j = 0; j < zyMixSamples[i].VehSamples.Count; j++)
                    {
                        QC_SCNCcx cx = new QC_SCNCcx();
                  
                        cx.VehNo = zyMixSamples[i].VehSamples[j].VehNo;
                        cx.FetchTime = zyMixSamples[i].VehSamples[j].FetchTime;
                        cx.KouShui = zyMixSamples[i].VehSamples[j].KouShui;
                        cx.KouZa = zyMixSamples[i].VehSamples[j].KouZa;
                        cx.SampleType = zyMixSamples[i].SampleType;
                        cx.ZyDanHao = zyMixSamples[i].ZyDanHao;
                        cx.Wlmc = zyMixSamples[i].MatName;
                    //    cx.Riqi = zyMixSamples[i].Mix_Time.Value.ToString("yyyy-MM-dd");
                        cx.Gysmc = zyMixSamples[i].SupplierName;
                        cx.Pddj = levels[0].QUALITYLEVELNAME;
                       
                        foreach (var item in zyMixSamples[i].CheckVals)
                        {
                            if (item.CheckItemName == "水分")
                            {
                                if (cx.Sf == "")
                                { cx.Sf = item.ReportVal; }

                            }
                            if (item.CheckItemName == "哈氏可磨性")
                            {
                                if (cx.KM == "")
                                { cx.KM = item.ReportVal; }

                            }
                            else if (item.CheckItemName == "灰分")
                            {
                                if (cx.Hf == "")
                                { cx.Hf = item.ReportVal; }

                            }
                            else if (item.CheckItemName == "挥发分")
                            {
                                if (cx.Hff == "")
                                cx.Hff = item.ReportVal;

                            }
                            else if (item.CheckItemName == "硫分")
                            {
                                if (cx.Lf == "")
                                cx.Lf = item.ReportVal;
                            }
                            else if (item.CheckItemName == "S")
                            {
                                if (cx.Lf == "")
                                cx.Lf = item.ReportVal;
                            }
                            else if (item.CheckItemName == "X")
                            {
                                if (cx.X == "")
                                cx.X = item.ReportVal;
                            }
                            else if (item.CheckItemName == "Y")
                            {
                                if (cx.Y == "")
                                cx.Y = item.ReportVal;
                            }
                            else if (item.CheckItemName == "G")
                            {
                                if (cx.G == "")
                                cx.G = item.ReportVal;
                            }

                            else if (item.CheckItemName == "发热量1")
                            {
                                if (cx.Frl == "")
                                cx.Frl = item.ReportVal;
                            }
                            else if (item.CheckItemName == "标准差S")
                            {
                                if (cx.BzcS == "")
                                    cx.BzcS = item.ReportVal;
                            }
                            else if (item.CheckItemName == "Rmax")
                            {
                                if (cx.Rmax == "")
                                    cx.Rmax = item.ReportVal;
                            }
                            else if (item.CheckItemName == "Rran")
                            {
                                if (cx.Rran == "")
                                    cx.Rran = item.ReportVal;
                            }
                            else if (item.CheckItemName == "固定碳")
                            {
                                if (cx.Gdt == "")
                                    cx.Gdt = item.ReportVal;
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
