using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VehIC_WF.Sampling.czl.Class;
using Xg.Lab.Sample;
using Zhc.Data;

namespace VehIC_WF.Sampling
{
    public partial class DlgSupplier : Form
    {
        private DbEntityTable<BD_CUBASDOC> data = new DbEntityTable<BD_CUBASDOC>();
      //  private DbEntityTable<QC_CheckGroup> checkGroup = new DbEntityTable<QC_CheckGroup>();

   
     
        public DlgSupplier()
        {
            InitializeComponent();
        }
       

        private BD_CUBASDOC _SelectedSupplier = null;
        public BD_CUBASDOC SelectedSupplier
        {
            get
            {
                return _SelectedSupplier;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            int[] sels = this.gridView1.GetSelectedRows();
            if (sels.Length > 0)
            {
                int selId = sels[0];
                _SelectedSupplier = this.gridView1.GetRow(selId) as BD_CUBASDOC;
                if (_SelectedSupplier != null)
                {
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("没有选中数据");
            }
        }

        private void DlgCheckItem_Load(object sender, EventArgs e)
        {
          
                data.LoadData();
            this.gridControl1.DataSource = data;
        }

        private void 查询_Click(object sender, EventArgs e)
        {
            if (!(textBox1.Text == ""))
                data.LoadDataByWhere("CUSTCODE='" + textBox1.Text + "'");
            else if (!(textBox2.Text == ""))
                data.LoadDataByWhere("CUSTSHORTNAME like '%" + textBox2.Text + "%'");

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
