using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Xg.Lab.Sample;

namespace VehIC_WF.Sampling
{
    public partial class DlgRecheck : Form
    {
        private int mainSampleMixId = 0;
        public DlgRecheck(int mainSampleMixId)
        {
            InitializeComponent();
            this.mainSampleMixId = mainSampleMixId;
        }

        private QC_Sample_Mix_Table RecheckSamples = new QC_Sample_Mix_Table();

        private QC_Sample_Mix selectedSample = null;
        public QC_Sample_Mix SelectedSample
        {
            get
            {
                return selectedSample;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            QC_Sample_Mix selectedSample = this.qCSampleMixBindingSource.Current as QC_Sample_Mix;
            if (selectedSample == null)
            {
                MessageBox.Show("没有选择数据");
                return;
            }
            DialogResult = DialogResult.OK;
            this.Close();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void DlgRecheck_Load(object sender, EventArgs e)
        {
            RecheckSamples.LoadInfo = "CheckVals";
            RecheckSamples.LoadDataByWhere("main.MainSampleMixId=@MainSampleMixId and main.SampleType=" + Convert.ToInt32(SampleType.复检样), this.mainSampleMixId);
        }
    }
}
