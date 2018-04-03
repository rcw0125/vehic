using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Zhc.Data;
using Xg.Lab.Sample;
namespace VehIC_WF.Sampling
{
    public partial class UC_WpRoute : DevExpress.XtraEditors.XtraUserControl
    {
        public UC_WpRoute()
        {
            InitializeComponent();
        }
        private DbEntityTable<QC_WpRoute> wpRoutes = new DbEntityTable<QC_WpRoute>();
        private DbEntityTable<QC_WpRoute> selecteRoutes = new DbEntityTable<QC_WpRoute>();
        private void btnSave_Click(object sender, EventArgs e)
        {
            wpRoutes.Save();
            btnSave.Enabled = false;
        }

        private void UC_WpRoute_Load(object sender, EventArgs e)
        {
            wpRoutes.LoadDataByWhere("wc.WCTypeId='02' or wc.WCTypeId='21'");
            selecteRoutes.LoadDataByWhere("wc.WCTypeId='21' or wc.WCTypeId='22' ");
            this.qCWpRouteBindingSource.DataSource = wpRoutes;
            this.qCWpRouteBindingSource1.DataSource = selecteRoutes;
            wpRoutes.ListChanged += wpRoutes_ListChanged;
        }

        void wpRoutes_ListChanged(object sender, ListChangedEventArgs e)
        {
            btnSave.Enabled = true;
        }
    }
}
