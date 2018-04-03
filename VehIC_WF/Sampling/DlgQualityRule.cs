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
    public partial class DlgQualityRule : Form
    {
        private QC_Sample_Mix curSampleMix = null;
        public DlgQualityRule(QC_Sample_Mix sampleMix)
        {
            InitializeComponent();
            this.curSampleMix = sampleMix;
        }

        private void DlgQualityRule_Load(object sender, EventArgs e)
        {
            this.uC_QualityRule1.DataSource.LoadDataByWhere("MATNCID=@MATNCID", curSampleMix.MatPK);
            foreach (var item in this.uC_QualityRule1.DataSource)
            {
                item.CurrentVal = this.curSampleMix.CheckVals.GetTagValueByCode(item.CheckItemCode);
            }
            this.Text = string.Format("({0}{1}---判定标准)", this.curSampleMix.MatCode, this.curSampleMix.MatName);
        }
    }
}
