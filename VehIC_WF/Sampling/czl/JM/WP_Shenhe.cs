using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Zhc.Data;
using VehIC_WF.Class;
using Xg.Lab.Sample;
using VehIC_WF.Sampling.czl.Class;
using VehIC_WF.Sampling;

namespace VehIC_WF.WorkPoint
{
    public partial class WP_Shenhe : UserControl
    {
        public WP_Shenhe()
        {
            InitializeComponent();
        }
        private QC_Sample_Lab_Jy curLab = null;
        DbEntityTable<QC_Sample_Lab_Jy> pici = new DbEntityTable<QC_Sample_Lab_Jy>();
        DbEntityTable<QC_MixCheckGroup> mcg = new DbEntityTable<QC_MixCheckGroup>();
        DbEntityTable<QC_Sample_Mix> mix = new DbEntityTable<QC_Sample_Mix>();
        DbEntityTable<BD_INVBASDOC> wl = new DbEntityTable<BD_INVBASDOC>();
      
        private void WP_Shenhe_Load(object sender, EventArgs e)
        {
            loadData();
            this.qCSampleLabJyBindingSource.DataSource = pici; 
        }

        private void loadData()
        {
            pici.LoadInfo = "CheckVals";
            pici.LoadDataByWhere("main.BillType=@BillType and main.CheckGroupType='后续检验' order by main.JyCode desc", "检验完成");
            foreach (var item in pici)
            {
                mcg.LoadDataByWhere("main.Sample_Lab_ID=@Sample_Lab_ID", item.Sample_Lab_ID);
                mix.LoadDataByWhere("main.Sample_Mix_ID=@Sample_Lab_ID", mcg[0].Sample_Mix_ID);
                wl.LoadDataByWhere("PK_INVBASDOC=@PK_INVBASDOC", mix[0].MatPK);
                item.MatName = wl[0].INVNAME;
            }
        }

        private void 通过审核_Click(object sender, EventArgs e)
        {
            if (curLab != null)
            {
                curLab.Billtype = "审核通过";
                curLab.LabState = "审核通过";
                foreach (var item in curLab.CheckVals)
                {
                    item.Auditor = FrmMain.localinfo.user.Name;
                    item.AuditTime = DateTime.Now;
                }
                curLab.SaveCheckVals = true;
                pici.Save();
                loadData();
            }
            else
            { MessageBox.Show("没有选择数据"); }

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void 查询检验单_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.dateEdit1.Text.Trim()) && !string.IsNullOrEmpty(this.dateEdit2.Text.Trim()))
            {
                pici.LoadInfo = "CheckVals";
                pici.LoadDataByWhere("main.JyTime>=@Ksdate and  main.JyTime<=@Jsdate order by main.JyCode desc", DateTime.Parse(this.dateEdit1.Text.Trim()), DateTime.Parse(this.dateEdit2.Text.Trim()));
                foreach (var item in pici)
                {
                    mcg.LoadDataByWhere("main.Sample_Lab_ID=@Sample_Lab_ID", item.Sample_Lab_ID);
                    mix.LoadDataByWhere("main.Sample_Mix_ID=@Sample_Lab_ID", mcg[0].Sample_Mix_ID);
                    wl.LoadDataByWhere("PK_INVBASDOC=@PK_INVBASDOC", mix[0].MatPK);
                    item.MatName = wl[0].INVNAME;
                }
            }
        }

        private void qCSampleLabJyBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            this.curLab = qCSampleLabJyBindingSource.Current as QC_Sample_Lab_Jy;

        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void 修改值ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (this.gridView_CheckVal.FocusedRowHandle >= 0)
            {
                QC_Sample_Value val = this.gridView_CheckVal.GetRow(this.gridView_CheckVal.FocusedRowHandle) as QC_Sample_Value;
                string valType = "";
                if (this.gridView_CheckVal.FocusedColumn.FieldName == "CheckVal")
                {
                    valType = "检验值";
                }
                if (this.gridView_CheckVal.FocusedColumn.FieldName == "ReportVal")
                {
                    valType = "报检值";
                }
                if (valType != "")
                {
                    DlgUpdateCheckVal dlg = new DlgUpdateCheckVal(val, valType);
                    dlg.ShowDialog();
                }
            }
        }
    }
}
