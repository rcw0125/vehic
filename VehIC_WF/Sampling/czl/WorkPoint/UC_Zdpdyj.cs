using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Zhc.Data;
using VehIC_WF.Sampling.Sample;
namespace VehIC_WF.Sampling.czl.WorkPoint
{
    public partial class UC_Zdpdyj : UserControl
    {
        public UC_Zdpdyj()
        {
            InitializeComponent();
        }
        DbEntityTable<QC_Sample_zdpdyj> yjs = new DbEntityTable<QC_Sample_zdpdyj>();
        private void UC_Zdpdyj_Load(object sender, EventArgs e)
        {
            if (LocalInfo.Current.user.ID == "17116")
            {
                this.保存.Visible = true;
                this.新增.Visible = true;
            }
            else
            {
                this.保存.Visible = false;
                this.新增.Visible = false;
            
            }
            yjs.LoadData();
            qCSamplezdpdyjBindingSource.DataSource = yjs;
        }

        private void 保存_Click(object sender, EventArgs e)
        {
            yjs.Save();
            MessageBox.Show("保存成功");
        }

        private void 新增_Click(object sender, EventArgs e)
        {
            QC_Sample_zdpdyj i = new QC_Sample_zdpdyj();
            yjs.Add(i);
        }
    }
}
