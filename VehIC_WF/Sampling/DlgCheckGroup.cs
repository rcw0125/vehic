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
    public partial class DlgCheckGroup : Form
    {
        public DlgCheckGroup()
        {
            InitializeComponent();
        }

        private List<string> curTable = null;
        public DlgCheckGroup(List<string> curTable)
        {
            InitializeComponent();
            this.curTable = curTable;
        }

        private QC_CheckGroup selectedCheckGroup = null;

        public QC_CheckGroup SelectedCheckGroup
        {
            get { return selectedCheckGroup; }
            set { selectedCheckGroup = value; }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            int[] rowIds = gvCheckGroup.GetSelectedRows();
            if (rowIds.Length > 0)
            {
                SelectedCheckGroup = gvCheckGroup.GetRow(rowIds[0]) as QC_CheckGroup;
            }
            this.Close();
        }

        private DbEntityTable<QC_CheckGroup> checkGroups = new DbEntityTable<QC_CheckGroup>();
       
        private void DlgCheckGroup_Load(object sender, EventArgs e)
        {
            checkGroups.LoadDataByWhere("CheckGroupType='留存样' or CheckGroupType='中间样' ");
            if (curTable != null)
            {
                checkGroups.Filter((cg) => !curTable.Contains(cg.CheckGroupCode));
            }
            this.qCCheckGroupBindingSource.DataSource = checkGroups;
        }
    }
}
