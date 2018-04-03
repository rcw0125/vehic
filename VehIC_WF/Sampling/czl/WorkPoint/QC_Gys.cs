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
    public partial class QC_Gys : Form
    {
        public QC_Gys()
        {
            InitializeComponent();
        }

        private void 添加供应商_Click(object sender, EventArgs e)
        {
            DlgSupplier dlg = new DlgSupplier();
            QC_BD_CUBASDOC gys = new QC_BD_CUBASDOC();
            
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    if (dlg.SelectedSupplier != null)
                    {
                        gys.PK_CUBASDOC = dlg.SelectedSupplier.PK_CUBASDOC;
                        gys.CUSTCODE = dlg.SelectedSupplier.CUSTCODE;
                        gys.CUSTSHORTNAME = dlg.SelectedSupplier.CUSTSHORTNAME;
                        gyss.Add(gys);
                        gyss.Save();
                    }

                }
            
            else
            {
                MessageBox.Show("没有选中数据", "提示");
            }
        }

        private void 删除供应商_Click(object sender, EventArgs e)
        {
            QC_BD_CUBASDOC gongyingshang = (QC_BD_CUBASDOC)this.qCBDCUBASDOCBindingSource.Current;
            this.qCBDCUBASDOCBindingSource.RemoveCurrent();
            gyss.Save();
        }
        DbEntityTable<QC_BD_CUBASDOC> gyss = new DbEntityTable<QC_BD_CUBASDOC>();
        private void QC_Gys_Load(object sender, EventArgs e)
        {
            gyss.LoadData();
            this.qCBDCUBASDOCBindingSource.DataSource = gyss;
        }
        private QC_BD_CUBASDOC _SelectedGys = null;
        public QC_BD_CUBASDOC SelectedGys
        {
            get
            {
                return _SelectedGys;
            }
        }
        private void 确定_Click(object sender, EventArgs e)
        {
            int[] sels = this.gridView1.GetSelectedRows();
            if (sels.Length > 0)
            {
                int selId = sels[0];
                _SelectedGys = this.gridView1.GetRow(selId) as QC_BD_CUBASDOC;
                if (_SelectedGys != null)
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
