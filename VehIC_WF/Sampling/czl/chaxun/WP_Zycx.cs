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
using System.IO;
using VehIC_WF.Sampling.czl.chaxun;


namespace VehIC_WF.Sampling.czl.WorkPoint
{
    public partial class WP_Zycx : UserControl
    {
        public WP_Zycx()
        {
            InitializeComponent();
        }
        private DbEntityTable<QC_SampleMix_ChaXun> zyMixSamples = new DbEntityTable<QC_SampleMix_ChaXun>();
        private DbEntityTable<QC_Zycx> cxs = new DbEntityTable<QC_Zycx>();
        DbEntityTable<QC_CheckGroup> cg = new DbEntityTable<QC_CheckGroup>();
        DbEntityTable<QC_Sample_Lab> labs = new DbEntityTable<QC_Sample_Lab>();
        private void WP_Zycx_Load(object sender, EventArgs e)
        {
            this.gridControl1.DataSource = cxs;
            cg.LoadData();
            List<String> cgname = new List<String>();
            cgname.Add("全部");
            foreach (var item in cg)
            {
                cgname.Add(item.CheckGroupName);
            }
            comboBox1.DataSource = cgname;
            List<String> qylx = new List<String>();
            qylx.Add("全部");
            qylx.Add("快样");
            qylx.Add("抽查样");
            qylx.Add("普通样");
            comboBox2.DataSource = qylx;
        }

        private void 查询制样单_Click(object sender, EventArgs e)
        {
            cxs.Clear();
            if (this.dateEdit1.Text != "" && this.dateEdit2.Text != "")
            {
                if (comboBox2.Text == "全部")
          
                zyMixSamples.LoadDataByWhere("main.ZyRecvTime>=@Kssj and main.ZyRecvTime<=@Jssj order by  main.ZyRecvTime", DateTime.Parse(this.dateEdit1.Text.Trim()), DateTime.Parse(this.dateEdit2.Text.Trim())); 
                   else if(comboBox2.Text == "普通样")
                    zyMixSamples.LoadDataByWhere("main.ZyRecvTime>=@Kssj and main.ZyRecvTime<=@Jssj and main.SampleType=@SampleType order by  main.ZyRecvTime", DateTime.Parse(this.dateEdit1.Text.Trim()), DateTime.Parse(this.dateEdit2.Text.Trim()), SampleType.普通样);
                  else if (comboBox2.Text == "抽查样")
                    zyMixSamples.LoadDataByWhere("main.ZyRecvTime>=@Kssj and main.ZyRecvTime<=@Jssj and main.SampleType=@SampleType order by  main.ZyRecvTime", DateTime.Parse(this.dateEdit1.Text.Trim()), DateTime.Parse(this.dateEdit2.Text.Trim()), SampleType.抽查样);
                  else if (comboBox2.Text == "快样")
                    zyMixSamples.LoadDataByWhere("main.ZyRecvTime>=@Kssj and main.ZyRecvTime<=@Jssj and main.SampleType=@SampleType and main.Wpcode=@Wpcode order by  main.ZyRecvTime", DateTime.Parse(this.dateEdit1.Text.Trim()), DateTime.Parse(this.dateEdit2.Text.Trim()), SampleType.普通样, "");
                for (int i = 0; i < zyMixSamples.Count; i++)
                {      
                   
                    if (comboBox1.Text == "全部")
                    zyMixSamples[i].CheckGroups.LoadDataByWhere("main.Sample_Mix_ID=@Sample_Mix_ID", zyMixSamples[i].Sample_Mix_ID);
                    else zyMixSamples[i].CheckGroups.LoadDataByWhere("main.Sample_Mix_ID=@Sample_Mix_ID and main.CheckGroupName=@CheckGroupName", zyMixSamples[i].Sample_Mix_ID,comboBox1.Text);
                    for (int j = 0; j < zyMixSamples[i].CheckGroups.Count; j++)
                    {
                        if (zyMixSamples[i].CheckGroups[j].Sample_Lab_ID != 0)
                        {
                            labs.LoadDataByWhere("main.Sample_Lab_ID=@Sample_Lab_ID", zyMixSamples[i].CheckGroups[j].Sample_Lab_ID);
                        }
                        QC_Zycx cx = new QC_Zycx();
                        cx.Sample_Shcx_ID = i + 1;
                        cx.Sksj = zyMixSamples[i].ZyRecvTime;
                        cx.Lybm = zyMixSamples[i].ZyDanHao;
                        cx.Jzcph = zyMixSamples[i].ZyJzZuPiHao;
                        if (zyMixSamples[i].SampleType == SampleType.普通样&&zyMixSamples[i].WpCode != "")
                        {
                            cx.Qylx = "普通样";
                        }
                        else if (zyMixSamples[i].SampleType == SampleType.普通样 && zyMixSamples[i].WpCode == "")
                        {
                            cx.Qylx = "快样";
                        }
                        else if (zyMixSamples[i].SampleType == SampleType.抽查样)
                        {
                            cx.Qylx = "抽查样";
                        }
                        cx.Jyr = zyMixSamples[i].ZyRecvUser;
                        cx.Ypbm = zyMixSamples[i].CheckGroups[j].StoreCode;
                        cx.Yplx = zyMixSamples[i].CheckGroups[j].CheckGroupName;

                        if (labs.Count > 0)
                        {
                            if (labs[0].MakeTime == null)
                            {
                                cx.Syr = null;
                            }
                           else cx.Syr = labs[0].MakeUser;
                            cx.Sysj = labs[0].MakeTime;
                        }
                        labs.Clear();
                        cxs.Add(cx);

                    }

                }

            }
            else MessageBox.Show("请输入时间段");
        
        
        }

        private void 导出ExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.gridView1.Export(DevExpress.XtraPrinting.ExportTarget.Xls, saveFileDialog1.FileName);
            }
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    string title = DateTime.Now.ToString()+".xls";
        //    saveFileDialog1.FileName = title;
        //    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
        //    {
        //        this.Cursor = Cursors.WaitCursor;
        //        Stream file = saveFileDialog1.OpenFile();
        //    //    file.Write();
        //        file.Close();
        //        object obj = System.Reflection.Missing.Value;
        //        ApplicationClass app = new ApplicationClass();
        //        app.Visible = false;
        //        Workbook wb = app.Workbooks.Open(saveFileDialog1.FileName, obj, obj, obj, obj, obj, obj, obj, obj, obj, obj, obj, obj, obj, obj);
        //        wb.Title = title;
        //        Worksheet ws = (Worksheet)wb.Sheets[1];

        //        int row = 6;
        //        foreach (var item in cxs)
        //        {
        //        //    ws.Cells.set_Item(row,"序号",item.Sample_Shcx_ID);
        //        //    ws.Cells.set_Item(row, "扫扣时间", item.Sksj);
        //            ws.Cells.set_Item(row, "来样编码", item.Lybm);
        //            ws.Cells.set_Item(row, "角质层批号", item.Jzcph);
        //            ws.Cells.set_Item(row, "取样类型", item.Qylx);
        //            ws.Cells.set_Item(row, "接样人", item.Jyr);
        //            ws.Cells.set_Item(row, "样品类型", item.Yplx);
        //            row++;
        //        }
        //        wb.Save();
        //        wb.Saved = true;
        //        app.Visible = true;
        //        this.Cursor = Cursors.Default;
        //    }
        //}
    }
}
