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
    public partial class xgcx : UserControl
    {
        DbEntityTable<BC_XG_CX> cxs = new DbEntityTable<BC_XG_CX>();
        public xgcx()
        {
            InitializeComponent();
            this.dateEdit1.DateTime = DateTime.Now.AddDays(-3);
            this.dateEdit2.DateTime = DateTime.Now;

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (this.comboBoxEdit1.SelectedItem.ToString() == "全部")
            {
                cxs.LoadDataByWhere("取样时间>=@取样时间小 and 取样时间<=@取样时间大", this.dateEdit1.DateTime, this.dateEdit2.DateTime);
            }
            else
            {
                cxs.LoadDataByWhere("取样时间>=@组批时间小 and 取样时间<=@取样时间大 and 车牌号 like @车牌号", this.dateEdit1.DateTime, this.dateEdit2.DateTime, "%" + this.comboBoxEdit1.SelectedItem + "%");

            }
         this.bCXGCXBindingSource.DataSource = cxs;
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void gridControl1_Click(object sender, EventArgs e)
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
