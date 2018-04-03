using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Zhc.Data;

namespace Xg.Lab.Sample.View
{
    [DbTable(IsView=true)]
    public class QC_QualityRule_View:DbEntity
    {
        #region 主键
        private int _QualityRuleId;
        public int QualityRuleId
        {
            get { return _QualityRuleId; }
            set
            {
                if (_QualityRuleId != value)
                {
                    _QualityRuleId = value;
                    RaisePropertyChanged();
                }
            }
        }
        #endregion

        #region 物料NC主键
        private string _MatNcId="";
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
                    RaisePropertyChanged();
                }
            }
        }
        #endregion

        #region 序号
        private int _RuleOrder;
        [DbTableColumn(SortDirection = SortDirection.Ascending,SortOrder=1)]
        public int RuleOrder
        {
            get { return _RuleOrder; }
            set
            {
                if (_RuleOrder != value)
                {
                    _RuleOrder = value;
                    RaisePropertyChanged();
                }
            }
        }
        #endregion

        #region 质量等级主键
        private string _QualityLevelID="";
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
                    RaisePropertyChanged();
                }
            }
        }
        #endregion

        #region 质量等级编码
        private string _QualityLevelCode = "";
        [DisplayName("质量等级编码")]
        public string QualityLevelCode
        {
            get { return _QualityLevelCode; }
            set
            {
                if (_QualityLevelCode != value)
                {
                    _QualityLevelCode = value;
                    RaisePropertyChanged();
                }
            }
        }
        #endregion

        #region 质量等级名称
        private string _QualityLevelName = "";
        [DisplayName("质量等级名称")]
        public string QualityLevelName
        {
            get { return _QualityLevelName; }
            set
            {
                if (_QualityLevelName != value)
                {
                    _QualityLevelName = value;
                    RaisePropertyChanged();
                }
            }
        }
        #endregion

        #region LocalQcLevel  本地质量等级
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
                    RaisePropertyChanged();
                }
            }
        }
        #endregion

        #region CheckItemNcId
        private string _CheckItemNcId = "";

        public string CheckItemNcId
        {
            get { return _CheckItemNcId; }
            set
            {
                if (_CheckItemNcId != value)
                {
                    _CheckItemNcId = value;
                    RaisePropertyChanged();
                }
            }
        }
        #endregion

        #region CheckItemCode 检验项编码
        private string _CheckItemCode = "";

        /// <summary>
        /// 检验项编码
        /// </summary> 
        [DisplayName("检验项编码")]
        [DbTableColumn(SortDirection = SortDirection.Ascending, SortOrder = 2)]
        public string CheckItemCode
        {
            get { return _CheckItemCode; }
            set
            {
                if (_CheckItemCode != value)
                {
                    _CheckItemCode = value;
                    RaisePropertyChanged("CheckItemCode");
                }
            }
        }
        #endregion

        #region CheckItemName  检验项名称
        private string _CheckItemName = "";

        /// <summary>
        /// 检验项名称
        /// </summary> 
        [DisplayName("检验项名称")]
        public string CheckItemName
        {
            get { return _CheckItemName; }
            set
            {
                if (_CheckItemName != value)
                {
                    _CheckItemName = value;
                    RaisePropertyChanged("CheckItemName");
                }
            }
        }

        #endregion

        #region Relation  关系运算
        private string _Relation = "";

        /// <summary>
        /// 关系运算
        /// </summary> 
        [DisplayName("关系运算")]
        public string Relation
        {
            get { return _Relation; }
            set
            {
                if (_Relation != value)
                {
                    _Relation = value;
                    RaisePropertyChanged("Relation");
                }
            }
        }
        #endregion

        #region ConstraintVal  约束值
        private double? _ConstraintVal = 0;

        /// <summary>
        /// 约束值
        /// </summary> 
        [DisplayName("约束值")]
        public double? ConstraintVal
        {
            get { return _ConstraintVal; }
            set
            {
                if (_ConstraintVal != value)
                {
                    _ConstraintVal = value;
                    RaisePropertyChanged("ConstraintVal");
                }
            }
        }
        #endregion

        private double? _CurrentVal = null;
        [DisplayName("当前值")]
        [NonTableField]
        public double? CurrentVal
        {
            get { return _CurrentVal; }
            set {
                if (_CurrentVal != value)
                {
                    _CurrentVal = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// 是否合格
        /// </summary>
        [RefProperty("CurrentVal")]
        [RefProperty("Relation")]
        [RefProperty("ConstraintVal")]
        [NonTableField]
        public bool Hege
        {
            get {
                if (CurrentVal == null) return true;
                if (ConstraintVal == null) return true;
                switch (Relation.Trim())
                {
                    case ">":
                        return CurrentVal > ConstraintVal;
                    case ">=":
                        return CurrentVal >= ConstraintVal;
                    case "<":
                        return CurrentVal < ConstraintVal;
                    case "<=":
                        return CurrentVal <= ConstraintVal;
                    case "==":
                        return CurrentVal == ConstraintVal;
                    case "!=":
                        return CurrentVal != ConstraintVal;
                    default:
                        throw new Exception("不认识的比较操作：\"" + Relation + "\"");
                }
            
            }
            set
            {
               
            }
        }


        [RefProperty("Relation")]
        [RefProperty("ConstraintVal")]
        [DisplayName("约束")]
        [NonTableField]
        public string LimitContent
        {
            get { return Relation + (ConstraintVal == null ? "" : ConstraintVal.Value.ToString()); }
            set
            {
            }
        }

    }
}
