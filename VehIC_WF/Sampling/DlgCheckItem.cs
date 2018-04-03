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

namespace VehIC_WF.Sampling
{
    public partial class DlgCheckItem : Form
    {
        private DbEntityTable<QC_CheckItem> data = new DbEntityTable<QC_CheckItem>();
      //  private DbEntityTable<QC_CheckGroup> checkGroup = new DbEntityTable<QC_CheckGroup>();

        private List<string> filterCheckItemIds = null;
        private string matNcId="";
        public DlgCheckItem()
        {
            InitializeComponent();
        }
        public DlgCheckItem(List<string> filterCheckItemIds)
        {
            InitializeComponent();
            this.filterCheckItemIds = filterCheckItemIds;
        }

        public DlgCheckItem(List<string> filterCheckItemIds,string matNcId)
        {
            InitializeComponent();
            this.filterCheckItemIds = filterCheckItemIds;
            this.matNcId = matNcId;
        }

        private QC_CheckItem _SelectedCheckItem = null;
        public QC_CheckItem SelectedCheckItem
        {
            get
            {
                return _SelectedCheckItem;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            int[] sels = this.gridView1.GetSelectedRows();
            if (sels.Length > 0)
            {
                int selId = sels[0];
                _SelectedCheckItem = this.gridView1.GetRow(selId) as QC_CheckItem;
                if (_SelectedCheckItem != null)
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

        private void DlgCheckItem_Load(object sender, EventArgs e)
        {
           // checkGroup.LoadData();
           // this.repositoryItemGridLookUpEdit1.DataSource = checkGroup;
           // this.repositoryItemGridLookUpEdit1.ValueMember = "CheckGroupCode";
            if (string.IsNullOrEmpty(matNcId))
                data.LoadData();
            else
                data.LoadDataByWhere("CheckItemNcId in (select CHECKITEMNCID from QC_MATALLCHECKITEM where MATNCID=@MATNCID)", this.matNcId);


            if (filterCheckItemIds != null)
            {
                data.Filter((ck) => !filterCheckItemIds.Contains(ck.CheckItemNcId));
            }

            this.gridControl1.DataSource = data;
        }

    }
}
