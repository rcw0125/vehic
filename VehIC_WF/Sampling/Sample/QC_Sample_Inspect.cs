using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Zhc.Data;

namespace Xg.Lab.Sample
{
    public class QC_Sample_Inspect : DbEntity
    {
        private int _Sample_Mix_ID;
        /// <summary>
        /// 主键
        /// </summary>
        [DbTableColumn(IsPrimaryKey = true, AutoIncrement = true)]
        [Browsable(false)]
        public int Sample_Mix_ID
        {
            get { return _Sample_Mix_ID; }
            set
            {
                if (_Sample_Mix_ID != value)
                {
                    _Sample_Mix_ID = value;
                    RaisePropertyChanged("Sample_Mix_ID");
                }
            }
        }

        #region NoticeBillId  作业单号
        private string _NoticeBillId = "";

        /// <summary>
        /// 作业单号
        /// </summary> 
        [DisplayName("作业单号")]
        public string NoticeBillId
        {
            get { return _NoticeBillId; }
            set
            {
                if (_NoticeBillId != value)
                {
                    _NoticeBillId = value;
                    RaisePropertyChanged("NoticeBillId", true);
                }
            }
        }
        #endregion

        #region VehNo  车牌号
        private string _VehNo = "";

        /// <summary>
        /// 车牌号
        /// </summary> 
        [DisplayName("车牌号")]
        public string VehNo
        {
            get { return _VehNo; }
            set
            {
                if (_VehNo != value)
                {
                    _VehNo = value;
                    RaisePropertyChanged("VehNo", true);
                }
            }
        }
        #endregion

        #region SupplierCode  供应商编码
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
                    _SupplierCode = value;
                    RaisePropertyChanged("SupplierCode", true);
                }
            }
        }
        #endregion

        #region MatPK  物料主键
        private string _MatPK = "";

        /// <summary>
        /// 物料主键
        /// </summary> 
        [DisplayName("物料主键")]
        public string MatPK
        {
            get { return _MatPK; }
            set
            {
                if (_MatPK != value)
                {
                    _MatPK = value;
                    RaisePropertyChanged("MatPK", true);
                }
            }
        }
        #endregion





        #region ExamineDept  抽样部门
        private string _ExamineDept = "";

        /// <summary>
        /// 抽样部门
        /// </summary> 
        [DisplayName("抽样部门")]
        public string ExamineDept
        {
            get { return _ExamineDept; }
            set
            {
                if (_ExamineDept != value)
                {
                    _ExamineDept = value;
                    RaisePropertyChanged("ExamineDept", true);
                }
            }
        }
        #endregion

        #region ExamineType  抽样类型
        private string _ExamineType = "";

        /// <summary>
        /// 抽样类型
        /// </summary> 
        [DisplayName("抽样类型")]
        public string ExamineType
        {
            get { return _ExamineType; }
            set
            {
                if (_ExamineType != value)
                {
                    _ExamineType = value;
                    RaisePropertyChanged("ExamineType", true);
                }
            }
        }
        #endregion

        #region FetchTime  取样时间
        private DateTime? _FetchTime = null;

        /// <summary>
        /// 取样时间
        /// </summary> 
        [DisplayName("取样时间")]
        public DateTime? FetchTime
        {
            get { return _FetchTime; }
            set
            {
                if (_FetchTime != value)
                {
                    _FetchTime = value;
                    RaisePropertyChanged("FetchTime", true);
                }
            }
        }
        #endregion

        #region FetchPerson  取样人
        private string _FetchPerson = "";

        /// <summary>
        /// 取样人
        /// </summary> 
        [DisplayName("取样人")]
        public string FetchPerson
        {
            get { return _FetchPerson; }
            set
            {
                if (_FetchPerson != value)
                {
                    _FetchPerson = value;
                    RaisePropertyChanged("FetchPerson", true);
                }
            }
        }
        #endregion

        #region FetchPlace  取样位置
        private string _FetchPlace = "";

        /// <summary>
        /// 取样位置
        /// </summary> 
        [DisplayName("取样位置")]
        public string FetchPlace
        {
            get { return _FetchPlace; }
            set
            {
                if (_FetchPlace != value)
                {
                    _FetchPlace = value;
                    RaisePropertyChanged("FetchPlace", true);
                }
            }
        }
        #endregion

        #region SampleType 取样类型
        private SampleType _Ori_SampleType = SampleType.普通样;
        private SampleType _SampleType = SampleType.普通样;
        /// <summary>
        /// 取样类型
        /// </summary>
        [DisplayName("取样类型")]
        public SampleType SampleType
        {
            get { return _SampleType; }
            set
            {
                if (_SampleType != value)
                {
                    if (IsIniting) _Ori_SampleType = value;
                    _SampleType = value;
                    RaisePropertyChanged();
                }
            }
        }
        #endregion

        #region SampleState 状态
        private SampleState _Ori_SampleState = SampleState.初始状态;
        private SampleState _SampleState = SampleState.初始状态;

        /// <summary>
        /// 状态
        /// </summary>
        [DisplayName("状态")]
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
      
        private bool _Sample_TBZD = false;

        public bool Sample_TBZD
        {
            get { return _Sample_TBZD; }
            set
            {
                if (_Sample_TBZD != value)
                {
                    _Sample_TBZD = value;
                    RaisePropertyChanged("Sample_TBZD", true);
                }
            }
        }

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
        #region MixUser  组批人
        private string _Ori_MixUser = "";
        private string _MixUser = "";

        /// <summary>
        /// 组批人
        /// </summary> 
        [DisplayName("组批人")]
        public string MixUser
        {
            get { return _MixUser; }
            set
            {
                if (_MixUser != value)
                {
                    if (IsIniting) _Ori_MixUser = value;
                    _MixUser = value;
                    RaisePropertyChanged("MixUser", true);
                }
            }
        }
        #endregion

        #region Mix_Time  组批时间
        private DateTime? _Ori_Mix_Time = null;
        private DateTime? _Mix_Time = null;

        /// <summary>
        /// 组批时间
        /// </summary> 
        [DisplayName("组批时间")]
        public DateTime? Mix_Time
        {
            get { return _Mix_Time; }
            set
            {
                if (_Mix_Time != value)
                {
                    if (IsIniting) _Ori_Mix_Time = value;
                    _Mix_Time = value;
                    RaisePropertyChanged("Mix_Time", true);
                }
            }
        }
        #endregion

        #region FangTong_User  放桶人
        private string _FangTong_User = "";

        /// <summary>
        /// 放桶人
        /// </summary> 
        [DisplayName("放桶人")]
        public string FangTong_User
        {
            get { return _FangTong_User; }
            set
            {
                if (_FangTong_User != value)
                {
                    _FangTong_User = value;
                    RaisePropertyChanged("FangTong_User", true);
                }
            }
        }
        #endregion

        #region FangTong_Time  放桶时间
        private DateTime? _FangTong_Time = null;

        /// <summary>
        /// 放桶时间
        /// </summary> 
        [DisplayName("放桶时间")]
        public DateTime? FangTong_Time
        {
            get { return _FangTong_Time; }
            set
            {
                if (_FangTong_Time != value)
                {
                    _FangTong_Time = value;
                    RaisePropertyChanged("FangTong_Time", true);
                }
            }
        }
        #endregion

        #region ShouTong_User  收桶人
        private string _ShouTong_User = "";

        /// <summary>
        /// 创建人
        /// </summary> 
        [DisplayName("创建人")]
        public string ShouTong_User
        {
            get { return _ShouTong_User; }
            set
            {
                if (_ShouTong_User != value)
                {
                    _ShouTong_User = value;
                    RaisePropertyChanged("ShouTong_User", true);
                }
            }
        }
        #endregion

        #region ShouTong_Time  收桶时间
        private DateTime? _ShouTong_Time = null;

        /// <summary>
        /// 收桶时间
        /// </summary> 
        [DisplayName("收桶时间")]
        public DateTime? ShouTong_Time
        {
            get { return _ShouTong_Time; }
            set
            {
                if (_ShouTong_Time != value)
                {
                    _ShouTong_Time = value;
                    RaisePropertyChanged("ShouTong_Time", true);
                }
            }
        }
        #endregion
      

    }
}
