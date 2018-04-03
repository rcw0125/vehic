using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using Xg.Tools;
using Zhc.Data;
using Zhc.CalFramework;

namespace Xg.Lab.Sample
{
    /// <summary>
    /// 质量判定规则
    /// </summary>
    public class QC_QualityRule : DbEntity
    {
        #region 主键
        private int _QualityRuleId;
        [DbTableColumn(IsPrimaryKey = true, AutoIncrement = true)]
        public int QualityRuleId
        {
            get { return _QualityRuleId; }
            set
            {
                if (_QualityRuleId != value)
                {
                    _QualityRuleId = value;
                    RaisePropertyChanged("QualityRuleId", true);
                }
            }
        }
        #endregion
        #region SupplierCode  供应商编码
        private string _Ori_SupplierCode = "";
        private string _SupplierCode = "";

        /// <summary>
        /// 供应商编码
        /// </summary> 
        [DisplayName("供应商编码")]
        public string SupplierCode
        {
            get { return _SupplierCode; }
            set
            {
                if (_SupplierCode != value)
                {
                    if (IsIniting) _Ori_SupplierCode = value;
                    _SupplierCode = value;
                    RaisePropertyChanged("SupplierCode", true);
                }
            }
        }
        #endregion

        #region SupplierName  供应商名称
        private string _Ori_SupplierName = "";
        private string _SupplierName = "";

        /// <summary>
        /// 供应商名称
        /// </summary> 
        [DisplayName("供应商名称")]
      
        public string SupplierName
        {
            get { return _SupplierName; }
            set
            {
                if (_SupplierName != value)
                {
                    if (IsIniting) _Ori_SupplierName = value;
                    _SupplierName = value;
                    RaisePropertyChanged("SupplierName");
                }
            }
        }
        #endregion
        #region 物料NC主键
        private string _MatNcId;
        /// <summary>
        /// 物料NC主键
        /// </summary>
        public string MatNcId
        {
            get { return _MatNcId; }
            set
            {
                if (_MatNcId != value)
                {
                    _MatNcId = value;
                    RaisePropertyChanged("MatNcId", true);
                }
            }
        }
        #endregion

        #region 质量等级主键
        private string _QualityLevelID;
        /// <summary>
        /// 质量等级主键
        /// </summary>
        public string QualityLevelID
        {
            get { return _QualityLevelID; }
            set
            {
                if (_QualityLevelID != value)
                {
                    _QualityLevelID = value;
                    RaisePropertyChanged("QualityLevel", true);
                }
            }
        }
        #endregion

        #region LocalQcLevel  本地质量等级
        private string _Ori_LocalQcLevel = "";
        private string _LocalQcLevel = "";

        /// <summary>
        /// 本地质量等级
        /// </summary> 
        [DisplayName("本地质量等级")]
        public string LocalQcLevel
        {
            get { return _LocalQcLevel; }
            set
            {
                if (_LocalQcLevel != value)
                {
                    _LocalQcLevel = value;
                    RaisePropertyChanged("LocalQcLevel", true);
                }
            }
        }
        #endregion

        #region 序号
        private int _RuleOrder;
        [DbTableColumn(SortDirection = SortDirection.Ascending)]
        public int RuleOrder
        {
            get { return _RuleOrder; }
            set
            {
                if (_RuleOrder != value)
                {
                    _RuleOrder = value;
                    RaisePropertyChanged("RuleOrder", true);
                }
            }
        }
        #endregion

        #region 判定规则
        private string _RuleContent="";

        public string RuleContent
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                foreach (var item in RuleContents)
                {
                    if (sb.Length > 0)
                    {
                        sb.Append(" 并且 ");
                    }
                    sb.Append(item.CheckItemName);
                    sb.Append(item.Relation);
                    sb.Append(item.ConstraintVal);
                }
                return sb.ToString();
                //return _RuleContent;
            }
            set
            {
                if (_RuleContent != value)
                {
                    _RuleContent = StringTool.SBCToDBC(value);
                    RaisePropertyChanged("RuleContent", true);
                }
            }
        }
        #endregion

        #region 规则内容
        public bool SaveRuleContents = true;

        private DbEntityTable<QC_QualityRuleContent> _RuleContents = new DbEntityTable<QC_QualityRuleContent>();

        /// <summary>
        /// 规则内容
        /// </summary>
        public DbEntityTable<QC_QualityRuleContent> RuleContents
        {
            get {
                return _RuleContents; }
        }
        #endregion

        public string RuleContentFormat2
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                RuleContents.Sort((t1, t2) => t1.CheckItemCode.CompareTo(t2.CheckItemCode));
                var rg = from rgc in RuleContents
                         group rgc by new { rgc.CheckItemCode, rgc.CheckItemName } into g
                         select new { CheckItemCode = g.Key.CheckItemCode, CheckItemName = g.Key.CheckItemName, Count = g.Count<QC_QualityRuleContent>(), RuleItems = g.ToList<QC_QualityRuleContent>() };

                foreach (var item in rg)
                {
                    if (sb.Length > 0) sb.Append("；");
                    if (item.Count == 2)
                    {
                        var item1 = item.RuleItems[0];
                        var item2 = item.RuleItems[1];
                        if ((item1.Relation == ">=" && item2.Relation == "<=") || (item2.Relation == ">=" && item1.Relation == "<="))
                        {
                            sb.Append(item.CheckItemName);
                            sb.Append("(");
                            sb.Append(item1.ConstraintVal);
                            sb.Append("~");
                            sb.Append(item2.ConstraintVal);
                            sb.Append(")");
                            continue;
                        }
                        else if ((item1.Relation == ">" || item1.Relation == ">=") && (item2.Relation == "<" || item2.Relation == "<="))
                        {
                            sb.Append(item1.ConstraintVal);
                            sb.Append(item1.Relation.Replace(">=", "≤").Replace(">", "<"));
                            sb.Append(item.CheckItemName);
                            sb.Append(item2.Relation.Replace("<=", "≤"));
                            sb.Append(item2.ConstraintVal);
                            continue;
                        }
                        else
                        {
                            foreach (var rl in item.RuleItems)
                            {
                                sb.Append(item.CheckItemName);
                                sb.Append(rl.Relation.Replace(">=", "≥").Replace("<=", "≤").Replace("==", "等于").Replace("!=", "不等于"));
                                sb.Append(rl.ConstraintVal);
                            }
                        }
                    }
                    else
                    {
                        foreach (var rl in item.RuleItems)
                        {
                            sb.Append(item.CheckItemName);
                            sb.Append(rl.Relation.Replace(">=", "≥").Replace("<=", "≤").Replace("==", "等于").Replace("!=", "不等于"));
                            sb.Append(rl.ConstraintVal);
                        }
                    }
                }
                return sb.ToString();
            }
        }

        public void RuleStr2Contents(string ruleContent)
        {
            if (!string.IsNullOrEmpty(ruleContent))
            {
                CalUtility calUtil = new CalUtility(ruleContent.Replace("并且", "&&").Replace("或者", "||"));
                QC_CheckItem_Table CheckItemGlobal = QC_CheckItem_Table.Global;

                for (int i = 0; i < calUtil.NifixExpression.Count; i++)
                {
                    if (calUtil.NifixExpression[i].OpTyp == FormulaItemType.Tag)
                    {
                        if (calUtil.NifixExpression[i + 1].OpTyp == FormulaItemType.Operator
                            && calUtil.NifixExpression[i + 2].OpTyp == FormulaItemType.Number)
                        {

                            QC_CheckItem ckItem = CheckItemGlobal.First<QC_CheckItem>((checkItem) => checkItem.CheckItemName == calUtil.NifixExpression[i].Name);
                            QC_QualityRuleContent rc = new QC_QualityRuleContent();
                            rc.CheckItemNcId = ckItem.CheckItemNcId;
                            rc.CheckItemCode = ckItem.CheckItemCode;
                            rc.CheckItemName = ckItem.CheckItemName;
                            rc.Relation = calUtil.NifixExpression[i + 1].Name;
                            rc.ConstraintVal = calUtil.NifixExpression[i + 2].GetValue();
                            RuleContents.Add(rc);
                        }
                        else
                        {
                            throw new Exception("表达式不对，" + ruleContent);
                        }
                    }
                }
            }
        }

        public QC_QualityRule()
        {
            RuleContents.ListChanged += RuleContents_ListChanged;
        }
        
        void RuleContents_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (!this.IsIniting)
            {
                SaveEnable = true;
            }
        }

        protected override void AfterSave(System.Data.IDbTransaction trans)
        {
            if (this.SaveRuleContents)
            {
                if (this.DataState == DataRowState.Deleted)
                {
                    DbContext.ExeSql("Delete From QC_QualityRuleContent where QualityRuleId=@QualityRuleId", this.QualityRuleId);
                    RuleContents.Empty();
                }
                else
                {
                    foreach (var item in RuleContents)
                    {
                        item.QualityRuleId = this.QualityRuleId;
                    }
                    RuleContents.Save(trans);
                }
            }
            base.AfterSave(trans);
        }

        public override void AfterLoad(string loadInfo)
        {
            RuleContents.LoadDataByWhere("QualityRuleId=@QualityRuleId", QualityRuleId);
        }
    }
}
