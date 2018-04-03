using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Zhc.Data;
using Xg.Lab.Sample.View;
using DevExpress.XtraGrid.Views.Grid;

namespace VehIC_WF.Sampling
{
    public partial class UC_QualityRule : UserControl
    {
        private DbEntityTable<QC_QualityRule_View> _dataSource = new DbEntityTable<QC_QualityRule_View>();

        public DbEntityTable<QC_QualityRule_View> DataSource
        {
            get { return _dataSource; }
            set
            {
                if (_dataSource != value)
                {
                    _dataSource = value;
                    this.qCQualityRuleViewBindingSource.DataSource = _dataSource;
                }
            }
        }
    
        public UC_QualityRule()
        {
            InitializeComponent();
            this.qCQualityRuleViewBindingSource.DataSource = _dataSource;
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView gv = sender as GridView;
            if (gv != null && e.RowHandle >= 0 && (e.Column.FieldName == "CurrentVal" || e.Column.FieldName == "LimitContent"))
            {
                QC_QualityRule_View sv = gv.GetRow(e.RowHandle) as QC_QualityRule_View;
                if (sv != null)
                {
                    if (!sv.Hege)
                    {
                        e.Appearance.BackColor = Color.LightGoldenrodYellow;
                    }
                }
            }
        }
    }
}
