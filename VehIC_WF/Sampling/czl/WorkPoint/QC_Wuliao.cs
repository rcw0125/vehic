using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VehIC_WF.Sampling.czl.Class;
using Zhc.Data;
namespace VehIC_WF.Sampling.czl.WorkPoint
{
    public partial class QC_Wuliao : Form
    {
        public QC_Wuliao()
        {
            InitializeComponent();
        }
        DbEntityTable<QC_Material_wl> wls = new DbEntityTable<QC_Material_wl>();
        private void QC_Wuliao_Load(object sender, EventArgs e)
        {
            wls.LoadData();
            this.qCMaterialwlBindingSource.DataSource = wls;
        }

        private void 添加物料_Click(object sender, EventArgs e)
        {
            QC_Material_wl wl = new QC_Material_wl();
            DlgMaterial dlg = new DlgMaterial();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (dlg.SelectedMaterial != null)
                {
                    wl.MatNcId = dlg.SelectedMaterial.PK_INVBASDOC;
                    wl.MatCode = dlg.SelectedMaterial.InvCode;
                    wl.MatName = dlg.SelectedMaterial.InvName;
                    wl.InUse = dlg.SelectedMaterial.InUse;
                 
                }
                wls.Add(wl);
                wls.Save();
            }
          
        }

        private void 删除物料ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QC_Material_wl wuliao = (QC_Material_wl)this.qCMaterialwlBindingSource.Current;
            this.qCMaterialwlBindingSource.RemoveCurrent();
            wuliao.Save();
        }
      

        private QC_Material_wl _SelectedWl = null;
        public QC_Material_wl SelectedWl
        {
            get
            {
                return _SelectedWl;
            }
        }
        private void 确定_Click(object sender, EventArgs e)
        {
            int[] sels = this.gridView1.GetSelectedRows();
            if (sels.Length > 0)
            {
                int selId = sels[0];
                _SelectedWl = this.gridView1.GetRow(selId) as QC_Material_wl;
                if (_SelectedWl != null)
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

        private void 取消_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
