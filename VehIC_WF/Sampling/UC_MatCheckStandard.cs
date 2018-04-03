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
using Xg.Lab.Sample;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraGrid;

namespace VehIC_WF.Sampling
{
    public partial class UC_MatCheckStandard : UserControl
    {
        public UC_MatCheckStandard()
        {
            InitializeComponent();
        }
        private DbEntityTable<QC_MatFl_View> matFlView = new DbEntityTable<QC_MatFl_View>();
        //private DbEntityTable<QC_Material_View> materialView = new DbEntityTable<QC_Material_View>();
        //private DbEntityTable<QC_MatCheckItem_View> matCheckItemView = new DbEntityTable<QC_MatCheckItem_View>();
        //private DbEntityTable<QC_MatCheckGroup_View> matCheckGroupView = new DbEntityTable<QC_MatCheckGroup_View>();
        //private DbEntityTable<QC_MatQualityLevel_View> matQualityLevelView = new DbEntityTable<QC_MatQualityLevel_View>();
        //private DbEntityTable<QC_QualityRule> matQualityRule = new DbEntityTable<QC_QualityRule>();

        private DbEntityTable<QC_Material> materials = new DbEntityTable<QC_Material>();
        private DbEntityTable<QC_SupplierDoc> supplierDoc = new DbEntityTable<QC_SupplierDoc>();
        private QC_Material selectedMaterial = null;
        private string selectedMatNcId = "";

        private void UC_MatCheckStandard_Load(object sender, EventArgs e)
        {
            matFlView.LoadDataByWhere("invclasscode like '1%'");
            // materials.LoadData();
            this.treeList1.DataSource = matFlView;
            foreach (TreeListNode item in this.treeList1.Nodes)
            {
                if (SelectTreeNode(item)) break;
            }
            if (LocalInfo.Current.user.ID != "16870")
            { textEdit3.Enabled = false; }

            // this.gridMaterial.DataSource =  materialView;
            this.gridMaterial.DataSource = materials;
            supplierDoc.LoadData();
            QC_SupplierDoc allSupplier = new QC_SupplierDoc();
            allSupplier.CustName = "所有厂家";
            allSupplier.CustShortName = "所有厂家";
            supplierDoc.Insert(0, allSupplier);
            this.qCSupplierDocBindingSource.DataSource = supplierDoc;
            //this.gridCheckItem.DataSource = matCheckItemView;
            //this.gridCheckGroup.DataSource = matCheckGroupView;
            //this.qCMatQualityLevelViewBindingSource.DataSource = matQualityLevelView;


            //  this.gridQualityRule.DataSource = matQualityRule;
            repositoryItemGridLookUpEdit1.DataSource = matQualityLevelViewBindingSource;

            // matQualityRule.ListChanged += matQualityRule_ListChanged;

        }

        private bool SelectTreeNode(TreeListNode parentNode)
        {
            string matFlCode = parentNode.GetValue("MatFlCode").ToString();
            if (matFlCode == "161")
            {
                parentNode.Selected = true;
                return true;
            }
            foreach (TreeListNode item in parentNode.Nodes)
            {
                if (SelectTreeNode(item))
                {
                    return true;
                }
            }
            return false;
        }

        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            materials.LoadDataByWhere("inv.PK_INVCL=@PKINVCL", matFlView[e.Node.Id].PK_INVCL);
            //   materialView.LoadDataByWhere("PK_INVCL=@PKINVCL", matFlView[e.Node.Id].PK_INVCL);
        }

        private void gridView1_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            if (btnSave.Enabled)
            {
                if (MessageBox.Show("原物料已经修改数据，是否保存？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    btnSave_Click(null, null);
                }
            }

            this.selectedMaterial = e.Row as QC_Material;
            if (this.selectedMaterial == null) { selectedMatNcId = ""; xtraTabControl1.Visible = false; return; }
            if (this.selectedMaterial.MatNcId == "") { selectedMatNcId = ""; xtraTabControl1.Visible = false; return; }

            this.Cursor = Cursors.WaitCursor;
            xtraTabControl1.Visible = true;

            selectedMatNcId = this.selectedMaterial.MatNcId;


            if (!string.IsNullOrEmpty(selectedMatNcId))
            {

                this.selectedMaterial.AllCheckItem.LoadDataByWhere("MATNCID=@MATNCID", selectedMatNcId);
              
                //DbEntityTable<QC_MatCheckItem_View>   MatCheckItemView=new DbEntityTable<QC_MatCheckItem_View>();
                //MatCheckItemView.LoadDataByWhere("MATNCID=@MATNCID", selectedMatNcId);
                //bool saveCheckItem = true;

                //foreach (QC_MatAllCheckItem item in this.selectedMaterial.AllCheckItem)
                //{
                //    item.JYLX = "可选";
                //}
                //foreach (var item in MatCheckItemView)
                //{
                //    var ci = this.selectedMaterial.AllCheckItem.FirstOrDefault<QC_MatAllCheckItem>((t) => t.CheckItemNcId == item.CheckItemNcId);
                //    if (ci == null)
                //    {
                //        QC_MatAllCheckItem qa = new QC_MatAllCheckItem();
                //        qa.MatNcId = selectedMatNcId;
                //        qa.CheckItemNcId = item.CheckItemNcId;
                //        qa.CheckItemCode = item.CheckItemCode;
                //        qa.CheckItemName = item.CheckItemName;
                //        qa.JYLX = "必检";
                //        this.selectedMaterial.AllCheckItem.Add(qa);
                //        saveCheckItem = true;
                //    }
                //    else
                //    {
                //        ci.JYLX = "必检";
                //    }
                //}

                //if (saveCheckItem) this.selectedMaterial.AllCheckItem.Save();

                this.selectedMaterial.MatCheckGroup.LoadByMatNcId(selectedMatNcId);
                this.selectedMaterial.MatQualityLevelView.LoadDataByWhere("MATNCID=@MATNCID", selectedMatNcId);
                this.selectedMaterial.ComplexMixRule.LoadDataByWhere("MATNCID=@MATNCID", selectedMatNcId);
                this.selectedMaterial.MatQualityRule.LoadDataByWhere("MATNCID=@MATNCID", selectedMatNcId);
                this.selectedMaterial.ComplexLabRule.LoadDataByWhere("MATNCID=@MATNCID", selectedMatNcId);
                this.selectedMaterial.ChgWaters.LoadDataByWhere("MATNCID=@MATNCID", selectedMatNcId);
                this.selectedMaterial.SaveEnable = false;
                this.qCMaterialBindingSource.DataSource = this.selectedMaterial;
            }
            this.Cursor = Cursors.Default;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.selectedMaterial != null)
            {
                this.selectedMaterial.SaveMatCheckGroup = true;
                this.selectedMaterial.SaveComplexMixRule = true;
                this.selectedMaterial.SaveMatQualityRule = true;
                this.selectedMaterial.SaveComplexLabRule = true;
                this.selectedMaterial.SaveAllCheckItem = true;
                this.selectedMaterial.SaveChgWater = true;
                this.selectedMaterial.Save();
            }
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmBtnQuery_Click(object sender, EventArgs e)
        {
            DlgQueryMaterial dlg = new DlgQueryMaterial();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (dlg.WhereSql != "")
                {
                    materials.LoadDataByWhere(dlg.WhereSql);
                }
            }
        }

        private void 删除ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ToolStripItem menuItem = (ToolStripItem)sender;
            ContextMenuStrip menu = (ContextMenuStrip)menuItem.Owner;
            GridControl flex = menu.SourceControl as GridControl;
            BindingSource bs = (BindingSource)flex.DataSource;
            if (bs.Current != null)
                bs.RemoveCurrent();

            //if (DialogResult.OK == MessageBox.Show("你确实要删除数据吗？", "询问", MessageBoxButtons.OKCancel))
            //{
            //    组批规则数据源.RemoveCurrent();
            //    //int i = gvComplexMixRule.FocusedRowHandle;
            //    //if (i >= 0)
            //    //{
            //    //    gvComplexMixRule.DeleteRow(i);
            //    //}
            //}
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (DialogResult.OK == MessageBox.Show("你确实要删除数据吗？", "询问", MessageBoxButtons.OKCancel))
            {
                int i = gvQualityRule.FocusedRowHandle;
                if (i >= 0)
                {
                    gvQualityRule.DeleteRow(i);
                }
            }
        }

        private void 设定分类标识ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DlgClassWord dlg = new DlgClassWord();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                foreach (var item in materials)
                {
                    item.ClassWord = dlg.ClassWord;
                    item.Save();
                }
            }
        }

        private void 添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> codes = new List<string>();
            foreach (var item in this.selectedMaterial.MatCheckGroup)
            {
                codes.Add(item.CheckGroupCode);
            }
            DlgCheckGroup dlg = new DlgCheckGroup(codes);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (dlg.SelectedCheckGroup != null)
                {
                    QC_MatCheckGroup gp = new QC_MatCheckGroup();
                    gp.MatNcId = selectedMatNcId;
                    gp.CheckGroupCode = dlg.SelectedCheckGroup.CheckGroupCode;
                    gp.CheckGroupName = dlg.SelectedCheckGroup.CheckGroupName;
                    this.selectedMaterial.MatCheckGroup.Add(gp);
                    selectedMaterial.SaveEnable = true;
                }
            }
        }

        private void 删除ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            QC_MatCheckGroup matCheckGroup = matCheckGroupViewBindingSource.Current as QC_MatCheckGroup;
            if (matCheckGroup != null)
            {
                if (matCheckGroup == null || matCheckGroup.Id <= 0)
                {
                    MessageBox.Show("不能删除");
                }
                else
                {
                    if (DialogResult.OK == MessageBox.Show("你确实要删除数据吗？", "询问", MessageBoxButtons.OKCancel))
                    {
                        matCheckGroupViewBindingSource.RemoveCurrent();
                        selectedMaterial.SaveEnable = true;
                    }
                }
            }
            else
            {
                MessageBox.Show("没有选中的行");
            }
        }

        private void btnImportJudgeRule_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                DbEntityTable<QC_QualityRule> rules = new DbEntityTable<QC_QualityRule>();
                DataTable dt = Xg.Tools.ExcelHelper.ImportExcelFile(this.openFileDialog1.FileName);
                DbEntityTable<QC_Material> mats = new DbEntityTable<QC_Material>();
                mats.LoadData();

                for (int i = 1; i < dt.Rows.Count; i++)
                {
                    string matCode = dt.Rows[i][0].ToString().Trim();

                    var mat = from m in mats
                              where m.MatCode == matCode
                              select m;

                    QC_QualityRule rule = new QC_QualityRule();
                    rule.MatNcId = mat.First<QC_Material>().MatNcId;
                    rule.LocalQcLevel = dt.Rows[i][2].ToString().Trim();
                    switch (rule.LocalQcLevel)
                    {
                        case "一级":
                            rule.RuleOrder = 1;
                            break;
                        case "二级":
                            rule.RuleOrder = 2;
                            break;
                        case "三级":
                            rule.RuleOrder = 3;
                            break;
                        default:
                            rule.RuleOrder = 4;
                            break;
                    }
                    string ruleContent = dt.Rows[i][3].ToString().Trim();
                    rule.RuleStr2Contents(ruleContent);
                    rule.QualityLevelID = "1001NC100000002GF3MN";
                    rules.Add(rule);
                }
                rules.Save();

            }
        }


        private void 添加检验项目ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QC_QualityRule rule = this.matQualityRuleBindingSource.Current as QC_QualityRule;
            if (rule != null)
            {
                List<string> filterIds = new List<string>();
                DlgCheckItem dlg = null;
                if (string.IsNullOrEmpty(this.selectedMaterial.MatNcId))
                    dlg = new DlgCheckItem(filterIds);
                else
                    dlg = new DlgCheckItem(filterIds, this.selectedMaterial.MatNcId);

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    if (dlg.SelectedCheckItem != null)
                    {
                        QC_QualityRuleContent qrc = new QC_QualityRuleContent();
                        qrc.CheckItemNcId = dlg.SelectedCheckItem.CheckItemNcId;
                        qrc.CheckItemCode = dlg.SelectedCheckItem.CheckItemCode;
                        qrc.CheckItemName = dlg.SelectedCheckItem.CheckItemName;
                        qrc.Relation = "<=";
                        qrc.ConstraintVal = 0;
                        rule.RuleContents.Add(qrc);
                    }
                }
            }
        }

        private void 删除条件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QC_QualityRuleContent selData = this.ruleContentsBindingSource.Current as QC_QualityRuleContent;
            if (selData != null)
            {
                if (MessageBox.Show("确实要删除此判定条件吗?", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    this.ruleContentsBindingSource.RemoveCurrent();
                }
            }
            else
            {
                MessageBox.Show("没有选中数据", "提示");
            }
        }

        private void 添加检验项目ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (this.selectedMaterial != null)
            {
                List<string> filterIds = new List<string>();
                foreach (var item in selectedMaterial.AllCheckItem)
                {
                    filterIds.Add(item.CheckItemNcId);
                }
                DlgCheckItem dlg = new DlgCheckItem(filterIds);
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    if (dlg.SelectedCheckItem != null)
                    {
                        QC_MatAllCheckItem qrc = new QC_MatAllCheckItem();
                        qrc.CheckItemNcId = dlg.SelectedCheckItem.CheckItemNcId;
                        qrc.CheckItemCode = dlg.SelectedCheckItem.CheckItemCode;
                        qrc.CheckItemName = dlg.SelectedCheckItem.CheckItemName;

                        this.selectedMaterial.AllCheckItem.Add(qrc);
                    }
                }
            }
            else
            {
                MessageBox.Show("没有选中数据", "提示");
            }

        }

        private void 删除检验项目ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QC_MatAllCheckItem selData = this.allCheckItemBindingSource.Current as QC_MatAllCheckItem;
            if (selData != null)
            {
                if (MessageBox.Show("确实要删除吗?", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    this.allCheckItemBindingSource.RemoveCurrent();
                }
            }
            else
            {
                MessageBox.Show("没有选中数据", "提示");
            }
        }

       

        private void 选择供应商_Click_1(object sender, EventArgs e)
        {
            DlgSupplier dlg = new DlgSupplier();
            QC_QualityRule rule = this.matQualityRuleBindingSource.Current as QC_QualityRule;
            if (rule != null)
            { 
             if (dlg.ShowDialog() == DialogResult.OK)
                {
                    if (dlg.SelectedSupplier != null)
                    {
                        rule.SupplierCode = dlg.SelectedSupplier.CUSTCODE;
                        rule.SupplierName = dlg.SelectedSupplier.CUSTSHORTNAME;
                    }
                }
            }
            else
            {
                MessageBox.Show("没有选中数据", "提示");
            }
            
            
            
        }
    }
}
