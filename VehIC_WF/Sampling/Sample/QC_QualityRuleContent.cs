using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Zhc.Data;

namespace Xg.Lab.Sample
{
    [DbTable(TableAlias = "main")]
    [DbTable("QC_CheckItem", "chitem", "chitem.CheckItemNcId=main.CheckItemNcId", JoinType.Left)]
    public class QC_QualityRuleContent : DbEntity
    {
        #region 主键
        private int _QualityRuleContentId;
        [DbTableColumn(IsPrimaryKey = true, AutoIncrement = true)]
        public int QualityRuleContentId
        {
            get { return _QualityRuleContentId; }
            set
            {
                if (_QualityRuleContentId != value)
                {
                    _QualityRuleContentId = value;
                    RaisePropertyChanged("QualityRuleContentId");
                }
            }
        }
        #endregion

        #region 父键
        private int _QualityRuleId = 0;

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

        #region CheckItemNcId
        private string _CheckItemNcId = "";
        private string _Ori_CheckItemNcId = "";

        public string CheckItemNcId
        {
            get { return _CheckItemNcId; }
            set
            {
                if (_CheckItemNcId != value)
                {
                    _CheckItemNcId = value;
                    RaisePropertyChanged("CheckItemNcid", true);
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
        [DbTableColumn("chitem.CheckItemCode")]
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
        [DbTableColumn("chitem.CheckItemName")]
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
        private string _Ori_Relation = "";
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
                    RaisePropertyChanged("Relation", true);
                }
            }
        }
        #endregion


        #region ConstraintVal  约束值
        private double? _Ori_ConstraintVal = 0;
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
                    RaisePropertyChanged("ConstraintVal", true);
                }
            }
        }
        #endregion


    }
}
