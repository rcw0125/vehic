using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Xg.Lab.Sample;
using Xg.Lab.Sample.View;
using Zhc.Data;

namespace VehIC_WF.Sampling
{
    public partial class DlgChe : Form
    {
 

          private DbEntityTable<QC_Sample_Veh> vehs = new DbEntityTable<QC_Sample_Veh>();
          private DbEntityTable<QC_Sample_Veh> vehs1 = new DbEntityTable<QC_Sample_Veh>();
          private QC_Sample_Veh _SelectedVeh = null;

        public QC_Sample_Veh SelectedVeh
        {
            get { return _SelectedVeh; }
        }

        public DlgChe(string cph, DateTime quyangTime)
        {
            InitializeComponent();
            vehs.LoadDataByWhere(string.Format("vehno like '%{0}%' order by Sample_Veh_id desc ", cph)); //, quyangTime.AddHours(12), quyangTime.AddHours(-12)and InTime<=@SamTime1 and (OutTime>=@SamTime2 or OutTime is null) and OutTime<>'null'
          
            if (vehs.Count > 0)
            {
                vehs1.Add(vehs[0]);
            }

            this.qCSampleVehBindingSource.DataSource = vehs1;
        }

        private void DlgChe_Load(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            _SelectedVeh = this.qCSampleVehBindingSource.Current as QC_Sample_Veh;
            if (_SelectedVeh != null)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("没有选中数据");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
