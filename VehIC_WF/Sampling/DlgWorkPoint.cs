using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Xg.Lab.Sample.View;
using Zhc.Data;

namespace VehIC_WF.Sampling
{
    public partial class DlgWorkPoint : Form
    {    
        private DbEntityTable<QC_WorkPoint_View> data = new DbEntityTable<QC_WorkPoint_View>();
        public DlgWorkPoint()
        {
            InitializeComponent();
            this.gridControl1.DataSource = data;
        }
        private QC_WorkPoint_View _SelectedWorkPoint = new QC_WorkPoint_View();

        public QC_WorkPoint_View SelectedWorkPoint
        {
            get { return _SelectedWorkPoint; }
        }
  
        private void btnOk_Click(object sender, EventArgs e)
        {
            int[] sels = this.gridView1.GetSelectedRows();
            if (sels.Length > 0)
            {
                int selId = sels[0];
                _SelectedWorkPoint = this.gridView1.GetRow(selId) as QC_WorkPoint_View;
            }
            else
            {
                MessageBox.Show("没有选中数据");
            }
        }

        private void DlgWorkPoint_Load(object sender, EventArgs e)
        {
            data.LoadDataByWhere("WCTypeId=@WCTypeId","02");
        }
    }
}
