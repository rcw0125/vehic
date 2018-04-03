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
    public partial class DlgMaterial : Form
    {
        private DbEntityTable<QC_MatFl_View> matFlView = new DbEntityTable<QC_MatFl_View>();
        private DbEntityTable<QC_Material_View> materialView = new DbEntityTable<QC_Material_View>();
    
        public DlgMaterial()
        {
            InitializeComponent();
        }

        private void DlgMaterial_Load(object sender, EventArgs e)
        {
            matFlView.LoadDataByWhere("invclasscode like '1%'");

            this.treeList1.DataSource = matFlView;
            this.gridMaterial.DataSource = materialView;
        }

        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            materialView.LoadDataByWhere("PK_INVCL=@PKINVCL", matFlView[e.Node.Id].PK_INVCL);
        }

        private QC_Material_View _SelectedMaterial = new QC_Material_View();

        public QC_Material_View SelectedMaterial
        {
            get { return _SelectedMaterial; }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            int[] sels = this.gridView1.GetSelectedRows();
            if (sels.Length > 0)
            {
                int selId = sels[0];
                _SelectedMaterial = this.gridView1.GetRow(selId) as QC_Material_View;
            }
            else
            {
                MessageBox.Show("没有选中数据");
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
