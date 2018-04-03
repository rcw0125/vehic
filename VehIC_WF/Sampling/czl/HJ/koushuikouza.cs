using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Xg.Lab.Sample;
using Zhc.Data;

namespace VehIC_WF.Sampling.czl.HJ
{
    public partial class koushuikouza : Form
    {
        public koushuikouza(int mixid,string zydh)
        {
            samplemixid = mixid;
            zydanhao = zydh;
            InitializeComponent();
        }
        int samplemixid = 0;
        string zydanhao="";
        private void 保存_Click(object sender, EventArgs e)
        {
            vehs.Save();

        }
        private DbEntityTable<QC_Sample_Veh> vehs = new DbEntityTable<QC_Sample_Veh>();
        private DbEntityTable<QC_Sample_Mix> mixs = new DbEntityTable<QC_Sample_Mix>();
        private void koushuikouza_Load(object sender, EventArgs e)
        {
            vehs.LoadDataByWhere("main.Sample_Mix_ID=@Sample_Mix_ID", samplemixid);
            mixs.LoadDataByWhere("main.Sample_Mix_ID=@Sample_Mix_ID or MainSampleMixId=@MainSampleMixId", samplemixid, samplemixid);
            foreach (var item in mixs)
            {
                item.Memo = textBox1.Text;
            }
            mixs.Save();

            this.qCSampleVehBindingSource.DataSource = vehs;
            labelzydh.Text = QC_Sample_Mix.ShortStoreCode(zydanhao);
        }

        private void 确定_Click(object sender, EventArgs e)
        {
            vehs.Save();
            this.Close();
        }

        private void 取消_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
