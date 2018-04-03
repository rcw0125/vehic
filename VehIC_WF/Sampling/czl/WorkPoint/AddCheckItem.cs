using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Zhc.Data;
using VehIC_WF.Class;
using Xg.Lab.Sample;

namespace VehIC_WF
{
    public partial class AddCheckItem : Form
    {
        public AddCheckItem()
        {
            InitializeComponent();
        }
        DbEntityTable<QC_MatAllCheckItem> check = new DbEntityTable<QC_MatAllCheckItem>();
        public string MatNcId;
        private void 添加检验项目_Load(object sender, EventArgs e)
        {
            if (MatNcId != null && MatNcId != "")
            {
                check.LoadDataByWhere("MatNcId=@MatNcId", MatNcId);
                this.qCMatAllCheckItemBindingSource.DataSource = check;
            }
        }
        private QC_Sample_Value _selectedCheckItem = null;
        public QC_Sample_Value SelectedCheckItem
        {
            get
            {
                return _selectedCheckItem;
            }
        }
        private void 确定_Click(object sender, EventArgs e)
        {
            QC_MatAllCheckItem curdata = this.qCMatAllCheckItemBindingSource.Current as QC_MatAllCheckItem;
            if (curdata != null)
            {
                _selectedCheckItem = new QC_Sample_Value();
                _selectedCheckItem.CheckItemCode = curdata.CheckItemCode;
                _selectedCheckItem.CheckItemName = curdata.CheckItemName;
         
                DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                this.Close();
            }
        }

        private void 取消_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void 查询_Click(object sender, EventArgs e)
        {
            check.LoadDataByWhere("CheckItemCode=@CheckItemCode", textBox1.Text);
        }

        private void 刷新_Click(object sender, EventArgs e)
        {
            if (MatNcId != null && MatNcId != "")
            check.LoadDataByWhere("MatNcId=@MatNcId", MatNcId);
        }
    }
}
