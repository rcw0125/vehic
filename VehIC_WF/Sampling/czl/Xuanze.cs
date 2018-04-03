using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Xg.Lab.Sample;
using Zhc.Data;

namespace VehIC_WF.Sampling.czl
{
    public partial class Xuanze : Form
    {
        public Xuanze(DbEntityTable<QC_NoticeDhdItem_View> duohuo)
        {
            InitializeComponent();
            this.qCDhdnoticeItemViewBindingSource.DataSource = duohuo;
        
        }

        private DbEntityTable<QC_NoticeDhdItem_View> huo = new DbEntityTable<QC_NoticeDhdItem_View>();
        private QC_NoticeDhdItem_View _SelectedDhdItem = null;

        public QC_NoticeDhdItem_View SelectedDhdItem
        {
            get { return _SelectedDhdItem; }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            _SelectedDhdItem = this.qCDhdnoticeItemViewBindingSource.Current as QC_NoticeDhdItem_View;
            if (_SelectedDhdItem != null)
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
