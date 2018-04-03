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
    public partial class UC_CheckGroup : UserControl
    {
        public UC_CheckGroup()
        {
            InitializeComponent();
        }

        private DbEntityTable<QC_CheckGroup> checkGroup = new DbEntityTable<QC_CheckGroup>();

        private void UC_CheckGroup_Load(object sender, EventArgs e)
        {
            this.gridControl1.DataSource = checkGroup;
            checkGroup.ListChanged += checkGroup_ListChanged;
            LoadData();
        }

        private void LoadData()
        {
            btnSave.Enabled = false;
            checkGroup.LoadData();
        }

        void checkGroup_ListChanged(object sender, ListChangedEventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            checkGroup.Save();
            btnSave.Enabled = false;
            MessageBox.Show("保存完成");
        }
    }
}
