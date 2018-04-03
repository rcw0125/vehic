using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Zhc.Data;
using Xg.Lab.Sample;

namespace VehIC_WF.Sampling
{
    public partial class UC_Batching : DevExpress.XtraEditors.XtraUserControl
    {
        public UC_Batching()
        {
            InitializeComponent();
        }

        private void wizardControl1_Click(object sender, EventArgs e)
        {

        }

        private void txtBtnWp_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

        }

        private DbEntityTable<QC_Sample_Veh> vehSamples = new DbEntityTable<QC_Sample_Veh>();
        private DbEntityTable<QC_Sample_Mix> mixSamples = new DbEntityTable<QC_Sample_Mix>();

        private string WpCode = "";
        private string WpName = "";
        private void wizardPage1_PageCommit(object sender, EventArgs e)
        {
            if (wizardControl1.SelectedPageIndex == 1)
            {
                DlgWorkPoint dlg = new DlgWorkPoint();
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    if (dlg.SelectedWorkPoint != null)
                    {

                        this.WpName = dlg.SelectedWorkPoint.WCName;
                        this.WpCode = dlg.SelectedWorkPoint.WCCode;
                        txtBtnWp.EditValue = string.Format("({0}){1}", dlg.SelectedWorkPoint.WCBM, dlg.SelectedWorkPoint.WCName);
                        vehSamples.LoadDataByWhere("WpCode=@WpCode And Sample_Mix=0",WpCode);
                        this.labelControl1.Text = vehSamples.Count.ToString();
                    }
                }
            }
        }
    }
}
