using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Zhc.Data;

namespace Xg.Lab.Sample
{
    public class QC_LabRule : DbEntity
    {

        #region LabRuleId  复杂组批主键
        private int _Ori_LabRuleId = 0;
        private int _LabRuleId = 0;

        /// <summary>
        /// 角质层组批主键
        /// </summary> 
        [DisplayName("角质层组批主键")]
        [DbTableColumn(IsPrimaryKey = true, AutoIncrement = true)]
        public int LabRuleId
        {
            get { return _LabRuleId; }
            set
            {
                if (_LabRuleId != value)
                {
                    if (IsIniting) _Ori_LabRuleId = value;
                    _LabRuleId = value;
                    RaisePropertyChanged("LabRuleId", true);
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
       [DbTableColumn(SortDirection=SortDirection.Descending,SortOrder=1)]
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


        #region MixNumber  大桶样品数
        private int _Ori_MixNumber = 0;
        private int _MixNumber = 0;

        /// <summary>
        /// 大桶样品数
        /// </summary> 
        [DisplayName("大桶样品数")]
        [DbTableColumn(SortDirection = SortDirection.Descending, SortOrder = 2)]
        public int MixNumber
        {
            get { return _MixNumber; }
            set
            {
                if (_MixNumber != value)
                {
                    if (IsIniting) _Ori_MixNumber = value;
                    _MixNumber = value;
                    RaisePropertyChanged("MixNumber", true);
                }
            }
        }
        #endregion


        #region PlanCount  角质层样数
        private int _Ori_PlanCount = 1;
        private int _PlanCount = 1;

        /// <summary>
        /// 角质层样数
        /// </summary> 
        [DisplayName("角质层样数")]
        public int PlanCount
        {
            get { return _PlanCount; }
            set
            {
                if (_PlanCount != value)
                {
                    if (value <= 0)
                        _PlanCount = 1;
                    else
                        _PlanCount = value;

                    RaisePropertyChanged("PlanCount", true);
                }
            }
        }
        #endregion


    }
}
