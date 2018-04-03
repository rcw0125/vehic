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
    public partial class UC_CheckItem : UserControl
    {
        private DbEntityTable<QC_CheckItem> data = new DbEntityTable<QC_CheckItem>();
        private DbEntityTable<QC_CheckGroup> checkGroup = new DbEntityTable<QC_CheckGroup>();
        public UC_CheckItem()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            checkGroup.LoadData();
            data.LoadData(); 
            btnSave.Enabled = false;
        }

        void checkGroup_ListChanged(object sender, ListChangedEventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            data.Save();
            MessageBox.Show("保存完成");
        }

        private void FrmCheckItem_Load(object sender, EventArgs e)
        {
            this.gridControl1.DataSource = data; 
            this.repositoryItemGridLookUpEdit1.DataSource= checkGroup;
            this.repositoryItemGridLookUpEdit1.ValueMember = "CheckGroupCode";
            data.ListChanged += checkGroup_ListChanged;
            LoadData();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
