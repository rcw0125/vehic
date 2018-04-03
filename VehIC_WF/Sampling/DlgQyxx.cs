using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VehIC_WF.Sampling.Sample;
using Xg.Lab.Sample;
using Zhc.Data;

namespace VehIC_WF.Sampling
{
    public partial class DlgQyxx : Form
    {
        private DbEntityTable<QC_Qyxx> data = new DbEntityTable<QC_Qyxx>();
    
  
        public DlgQyxx()
        {
            InitializeComponent();
        }
      

       
        private void btnOk_Click(object sender, EventArgs e)
        {
            data.Save();
        }

        private void DlgCheckItem_Load(object sender, EventArgs e)
        {
            data.LoadDataByWhere("state=0");
            qCQyxxBindingSource.DataSource = data;
        }

        private void 刷新_Click(object sender, EventArgs e)
        {
            data.LoadDataByWhere("state=0");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
