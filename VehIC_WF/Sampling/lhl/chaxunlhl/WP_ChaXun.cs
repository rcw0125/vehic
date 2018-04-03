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

namespace VehIC_WF.Sampling
{
    public partial class WP_ChaXun : UserControl
    {

        DbEntityTable<QC_Sample_Veh> vehs = new DbEntityTable<QC_Sample_Veh>();
        DbEntityTable<QC_Sample_Mix> vehscount = new DbEntityTable<QC_Sample_Mix>();
        public WP_ChaXun()
        {
            InitializeComponent();
            this.dateEdit1.Text = DateTime.Now.AddDays(-1).ToString();
            this.dateEdit2.Text = DateTime.Now.ToString();
            // 初始化物料名称

            this.comboBoxEdit2.Properties.Items.Add("全部");
            vehs.LoadDataBySql("select distinct (h.INVNAME) as MatName from QC_Sample_Veh t ,BD_INVBASDOC h where h.PK_INVBASDOC=t.MatPK");
            foreach (var a in vehs)
              {
                  this.comboBoxEdit2.Properties.Items.Add(a.MatName);
                 
              }
       
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            switch(this.comboBoxEdit1.Text)
            {
                case "全部":
                    if (this.comboBoxEdit2.Text == "全部")
                    {
                        vehs.LoadDataByWhere("main.FetchTime >= @begintime and main.FetchTime<=@endtime order by main.FetchTime ", this.dateEdit1.Text, this.dateEdit2.Text);
                    }
                    else
                    {
                        vehs.LoadDataByWhere("main.FetchTime >= @begintime and main.FetchTime<=@endtime and  dhd.INVNAME  =@MatName order by main.FetchTime", this.dateEdit1.Text, this.dateEdit2.Text, this.comboBoxEdit2.Text);
                    }

                    vehscount.LoadDataBySql("select DISTINCT(t.sample_mix_id) from QC_Sample_Mix t,QC_Sample_Veh h where t.Sample_Mix_ID=h.Sample_Mix_ID and h.FetchTime >= @begintime and h.FetchTime<=@endtime", this.dateEdit1.Text, this.dateEdit2.Text);
                    this.textEdit1.Text = vehscount.Count.ToString();
                    break;
                case "快样":
                 if (this.comboBoxEdit2.Text == "全部")
                 {
                     vehs.LoadDataByWhere("main.FetchTime >= @begintime and main.FetchTime<=@endtime and mix.SAMPLETYPE>0 and main.mix_TIME is null order by main.FetchTime", this.dateEdit1.Text, this.dateEdit2.Text);
                 }
                 else
                 {
                     vehs.LoadDataByWhere("main.FetchTime >= @begintime and main.FetchTime<=@endtime and mix.SAMPLETYPE>0 and main.mix_TIME is null and  dhd.INVNAME  =@MatName order by main.FetchTime", this.dateEdit1.Text, this.dateEdit2.Text, this.comboBoxEdit2.Text);
                 }
                 this.textEdit1.Text = vehs.Count.ToString();
                 break;

                case "抽查样":
                 if (this.comboBoxEdit2.Text == "全部")
                 {

                     vehs.LoadDataByWhere("main.FetchTime >= @begintime and main.FetchTime<=@endtime and mix.SampleType=1 order by main.FetchTime", this.dateEdit1.Text, this.dateEdit2.Text);
                
                }
                 else
                 {
                     vehs.LoadDataByWhere("main.FetchTime >= @begintime and main.FetchTime<=@endtime and mix.SampleType=1  and  dhd.INVNAME  =@MatName order by main.FetchTime", this.dateEdit1.Text, this.dateEdit2.Text, this.comboBoxEdit2.Text);
                 }
                 this.textEdit1.Text = vehs.Count.ToString();
                 break;
            }

            this.vehSamplesBindingSource.DataSource = vehs;
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
      
        }

        private void vehSamplesBindingSource_CurrentChanged(object sender, EventArgs e)
        {

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
