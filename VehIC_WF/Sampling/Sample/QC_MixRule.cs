using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Zhc.Data;

namespace Xg.Lab.Sample
{
    public class QC_MixRule : DbEntity
    {

        #region MixRuleId  复杂组批主键
        private int _Ori_MixRuleId = 0;
        private int _MixRuleId = 0;

        /// <summary>
        /// 复杂组批主键
        /// </summary> 
        [DisplayName("复杂组批主键")]
        [DbTableColumn(IsPrimaryKey = true, AutoIncrement = true)]
        public int MixRuleId
        {
            get { return _MixRuleId; }
            set
            {
                if (_MixRuleId != value)
                {
                    if (IsIniting) _Ori_MixRuleId = value;
                    _MixRuleId = value;
                    RaisePropertyChanged("MixRuleId", true);
                }
            }
        }
        #endregion


        #region MatNcId  物料主键
        private string _Ori_MatNcId = "";
        private string _MatNcId = "";

        /// <summary>
        /// 物料主键
        /// </summary> 
        [DisplayName("物料主键")]
        public string MatNcId
        {
            get { return _MatNcId; }
            set
            {
                if (_MatNcId != value)
                {
                    if (IsIniting) _Ori_MatNcId = value;
                    _MatNcId = value;
                    RaisePropertyChanged("MatNcId", true);
                }
            }
        }
        #endregion


        #region CustCode  供应商编码
        private string _Ori_CustCode = "";
        private string _CustCode = "";

        /// <summary>
        /// 供应商编码
        /// </summary> 
        [DisplayName("供应商编码")]
        [DbTableColumn(SortDirection = SortDirection.Descending, SortOrder = 1)]
        public string CustCode
        {
            get { return _CustCode; }
            set
            {
                if (_CustCode != value)
                {
                    if (IsIniting) _Ori_CustCode = value;
                    _CustCode = value;
                    RaisePropertyChanged("CustCode", true);
                }
            }
        }
        #endregion


        #region VehNumber  车数
        private int _Ori_VehNumber = 0;
        private int _VehNumber = 0;

        /// <summary>
        /// 车数
        /// </summary> 
        [DisplayName("车数")]
        [DbTableColumn(SortDirection = SortDirection.Descending, SortOrder = 2)]
        public int VehNumber
        {
            get { return _VehNumber; }
            set
            {
                if (_VehNumber != value)
                {
                    if (IsIniting) _Ori_VehNumber = value;
                    _VehNumber = value;
                    RaisePropertyChanged("VehNumber", true);
                }
            }
        }
        #endregion


        #region PlanMixCount  大桶装小样数
        private int _Ori_PlanMixCount = 1;
        private int _PlanMixCount = 1;

        /// <summary>
        /// 大桶装小样数
        /// </summary> 
        [DisplayName("大桶装小样数")]
        public int PlanMixCount
        {
            get { return _PlanMixCount; }
            set
            {
                if (_PlanMixCount != value)
                {
                    if (value <= 0)
                        _PlanMixCount = 1;
                    else
                        _PlanMixCount = value;
                    RaisePropertyChanged("PlanMixCount", true);
                }
            }
        }
        #endregion


    }
}
