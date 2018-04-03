using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Zhc.Data;
namespace Xg.Lab.Sample
{
    [DbTable(TableName="QC_Sample_Mix",IsView=true)]
     public class BC_DT_State : DbEntity
    {
        
        private Int32 _TEMPID;
        /// <summary>
        /// 位置
        /// </summary>
           [DisplayName("位置")]
        public Int32 TEMPID
        {
            get { return _TEMPID; }
            set
            {
                if (_TEMPID != value)
                {
                    _TEMPID = value;
                    RaisePropertyChanged("TEMPID", true);
                }
            }
        }

           #region MixPlanCount  计划样数
           private int _Ori_MixPlanCount = 0;
           private int _MixPlanCount = 0;

        /// <summary>
        /// 计划样数
        /// </summary> 
        [DisplayName("计划样数")]
        public int MixPlanCount
        {
            get { return _MixPlanCount; }
            set
            {
                if (_MixPlanCount != value)
                {
                    if (IsIniting) _Ori_MixPlanCount = value;
                    _MixPlanCount = value;
                    RaisePropertyChanged("MixPlanCount", true);
                }
            }
        }
        #endregion

        #region MixCount  实际样数
        private int _Ori_MixCount = 0;
        private int _MixCount = 0;

        /// <summary>
        /// 实际样数
        /// </summary> 
        [DisplayName("实际样数")]
        public int MixCount
        {
            get { return _MixCount; }
            set
            {
                if (_MixCount != value)
                {
                    if (IsIniting) _Ori_MixCount = value;
                    _MixCount = value;
                    RaisePropertyChanged("MixCount", true);
                }
            }
        }
        #endregion

        /// <summary>
        /// 大桶状态
        /// </summary>
        #region SampleState 检验单状态
        private SampleState _Ori_SampleState = SampleState.初始状态;
        private SampleState _SampleState = SampleState.初始状态;
        
        /// <summary>
        /// 大桶状态
        /// </summary>
        [DisplayName("大桶状态")]
        [DbTableColumn(SortDirection = SortDirection.Ascending)]
        public SampleState SampleState
        {
            get { return _SampleState; }
            set
            {
                if (_SampleState != value)
                {
                    if (IsIniting) _Ori_SampleState = value;
                    _SampleState = value;
                    RaisePropertyChanged();
                }
            }
        }
        #endregion

        private DateTime _FANGTONG_TIME;
        /// <summary>
        /// 放桶时间
        /// </summary>
        [DisplayName("放桶时间")]
        public DateTime FANGTONG_TIME
        {
            get { return _FANGTONG_TIME; }
            set
            {
                if (_FANGTONG_TIME != value)
                {
                    _FANGTONG_TIME = value;
                    RaisePropertyChanged("FANGTONG_TIME", true);
                }
            }
        }
        private DateTime _SHOUTONG_TIME;
        /// <summary>
        /// 收桶时间
        /// </summary>
        [DisplayName("收桶时间")]
        public DateTime SHOUTONG_TIME
        {
            get { return _SHOUTONG_TIME; }
            set
            {
                if (_SHOUTONG_TIME != value)
                {
                    _SHOUTONG_TIME = value;
                    RaisePropertyChanged("SHOUTONG_TIME", true);
                }
            }
        }
    }
}
