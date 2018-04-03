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
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
namespace VehIC_WF.Sampling
{
    public partial class glcx : UserControl
    {
        DbEntityTable<QC_CX_BS> cxs = new DbEntityTable<QC_CX_BS>();
        DbEntityTable<QC_Sample_Mix> remix = new DbEntityTable<QC_Sample_Mix>();
        public glcx()
        {
            InitializeComponent();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (this.comboBoxEdit1.SelectedItem.ToString() == "全部")
            {
                cxs.LoadDataByWhere("组批时间>=@组批时间小 and 组批时间<=@组批时间大 and WLLX='煤' and SampleState>=@SampleState", this.dateEdit1.DateTime, this.dateEdit2.DateTime,SampleState.化验审核完成);
            }
            else
            {
                cxs.LoadDataByWhere("组批时间>=@组批时间小 and 组批时间<=@组批时间大 and 车牌号 like @车牌号 and WLLX='煤' and SampleState>=@SampleState", this.dateEdit1.DateTime, this.dateEdit2.DateTime, "%" + this.comboBoxEdit1.SelectedItem + "%",SampleState.化验审核完成);

            }

            foreach (var item in cxs)
            {





                if (item.SampleType == SampleType.普通样 || item.SampleType == SampleType.抽查样)
                {

                    remix.LoadDataByWhere("main.SampleType=@SampleType and main.MainSampleMixId=@MainSampleMixId", SampleType.复检样, item.SAMPLE_MIX_ID);
                   
                    if (remix.Count > 0)
                    {
                        remix[0].LoadDataDetailes();
                        foreach (var it in remix[0].CheckVals)
                        {
                            if (it.CheckItemName == "水分" && it.ValSource == "复检样")
                            { item.水分复检值 = it.CheckVal;
                            item.水分复检人 = it.CheckUserName;
                            item.水分复检时间 = it.CheckTime;
                            }
                            if (it.CheckItemName == "灰分" && it.ValSource == "复检样")
                            {
                                item.灰分复检值 = it.CheckVal;
                                item.灰分复检人 = it.CheckUserName;
                                item.灰分复检时间 = it.CheckTime;
                            }
                            if (it.CheckItemName == "挥发分" && it.ValSource == "复检样")
                            {
                                item.挥发分复检值 = it.CheckVal;
                                item.挥发分复检人 = it.CheckUserName;
                                item.挥发分复检时间 = it.CheckTime;
                            }
                            if (it.CheckItemName == "S" && it.ValSource == "复检样")
                            {
                                item.S复检值 = it.CheckVal;
                                item.S复检人 = it.CheckUserName;
                                item.S复检时间 = it.CheckTime;
                            }
                            if (it.CheckItemName == "Y" && it.ValSource == "复检样")
                            {
                                item.Y复检值 = it.CheckVal;
                                item.Y复检人 = it.CheckUserName;
                                item.Y复检时间 = it.CheckTime;
                            }
                            if (it.CheckItemName == "X" && it.ValSource == "复检样")
                            {
                                item.X复检值 = it.CheckVal;
                                item.X复检人 = it.CheckUserName;
                                item.X复检时间 = it.CheckTime;
                            }
                            if (it.CheckItemName == "G" && it.ValSource == "复检样")
                            {
                                item.G复检值 = it.CheckVal;
                                item.G复检人 = it.CheckUserName;
                                item.G复检时间 = it.CheckTime;
                            }
                            if (it.CheckItemName == "标准差S" && it.ValSource == "复检样")
                            {
                                item.标准差S复检值 = it.CheckVal;
                                item.标准差S复检人 = it.CheckUserName;
                                item.标准差S复检时间 = it.CheckTime;
                            }
                            if (it.CheckItemName == "Rmax" && it.ValSource == "复检样")
                            {
                                item.Rmax复检值 = it.CheckVal;
                                item.Rmax复检人 = it.CheckUserName;
                                item.Rmax复检时间 = it.CheckTime;
                            }
                            if (it.CheckItemName == "哈氏可磨性" && it.ValSource == "复检样")
                            {
                                item.可磨复检值 = it.CheckVal;
                                item.可磨复检人 = it.CheckUserName;
                                item.可磨复检时间 = it.CheckTime;
                            }
                            if (it.CheckItemName == "p" && it.ValSource == "复检样")
                            {
                                item.p复检值 = it.CheckVal;
                                item.p复检人 = it.CheckUserName;
                                item.p复检时间 = it.CheckTime;
                            }
                            if (it.CheckItemName == "硫分" && it.ValSource == "复检样")
                            {
                                item.硫分复检值 = it.CheckVal;
                                item.硫分复检人 = it.CheckUserName;
                                item.硫分复检时间 = it.CheckTime;
                            }
                            if (it.CheckItemName == "发热量1" && it.ValSource == "复检样")
                            {
                                item.发热量1复检值 = it.CheckVal;
                                item.发热量1复检人 = it.CheckUserName;
                                item.发热量1复检时间 = it.CheckTime;
                            }
                        
                        }
                    
                    
                    }
                }
            
            
            }






           // cxs.LoadDataBySql("select h.VEHNO as  车牌号,h.FETCHTIME as 取样时间,h.KOUSHUI as 扣水,h.KOUZA as 扣杂,h.FetchPerson as 取样人,h.WPCODE as 取样点,l.* "
                            //  + "from QC_Sample_Veh h left join  QC_SampleMix_Info l on h.SAMPLE_MIX_ID =l.SAMPLE_MIX_ID ");
                             // + "where  h.VEHNO=@车牌号", this.comboBoxEdit1.SelectedItem);
            // cxs.LoadData();   , this.dateEdit1.Text, this.dateEdit2.Text
            this.qCCXBSBindingSource.DataSource = cxs;
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void 导出ExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // ToolStripItem menuItem = (ToolStripItem)sender;
           // ContextMenuStrip menu = (ContextMenuStrip)menuItem.Owner;
            if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.gridView1.Export(DevExpress.XtraPrinting.ExportTarget.Xls, saveFileDialog1.FileName);
            }
            
        }

        private void gridView1_RowStyle(object sender, RowStyleEventArgs e)
        {
            int hand = e.RowHandle;
            if (hand < 0) return;

            QC_CX_BS cx = (QC_CX_BS)gridView1.GetRow(hand);

            if (cx != null)
            {
                Font f1 = new System.Drawing.Font("宋体", 1, FontStyle.Bold);
                Font f2 = new System.Drawing.Font("宋体", 9, FontStyle.Regular);
                if (cx.SampleState< SampleState.化验审核完成)
                {
                    e.Appearance.Font = f1;// 改变行字体
                }
                else
                {
                    e.Appearance.Font = f2;// 改变行字体
                }
            }
        }

    }
}
