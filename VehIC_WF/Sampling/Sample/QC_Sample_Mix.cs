using System;
using Zhc.Data;
using System.ComponentModel;
using System.Reflection;
using System.Data;
using System.Data.Linq.Mapping;
using VehIC_WF.Sampling.czl.Class;
using VehIC_WF.Sampling.Nc;
using VehIC_WF;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Xg.Lab.Sample
{
    /// <summary>
    /// 检验批次
    /// </summary>
    [DbTable("QC_Sample_Mix", "parent", "parent.Sample_Mix_ID=main.MainSampleMixId", JoinType.Left)]
    [DbTable("tb_WorkCenter", "wp", "wp.WCCode=main.WpCode", JoinType.Left)]
    [DbTable("BD_INVBASDOC", "mat", "mat.PK_INVBASDOC=main.MatPK", JoinType.Left)]
    [DbTable("BD_CUBASDOC", "supplier", "supplier.CUSTCODE=main.SupplierCode", JoinType.Left)]
    [DbTable(TableAlias = "main")]
    public partial class QC_Sample_Mix : DbEntity
    {
        #region 主键
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
        #endregion
        private bool _WCQY = false;

        public bool WCQY
        {
            get { return _WCQY; }
            set
            {
                if (_WCQY != value)
                {
                    _WCQY = value;
                    RaisePropertyChanged("WCQY", true);
                }
            }
        }
        private bool _WCDY = false;

        public bool WCDY
        {
            get { return _WCDY; }
            set
            {
                if (_WCDY != value)
                {
                    _WCDY = value;
                    RaisePropertyChanged("WCDY", true);
                }
            }
        }
        private int _MainSampleMixId;
        /// <summary>
        ///  正样ID
        /// </summary>
        public int MainSampleMixId
        {
            get { return _MainSampleMixId; }
            set
            {
                if (_MainSampleMixId != value)
                {
                    _MainSampleMixId = value;
                    RaisePropertyChanged("MainSampleMixId", true);
                }
            }
        }



       
        #region WLLX  物料类型
        private string _Ori_WLLX;
        private string _WLLX;

        /// <summary>
        /// 物料类型
        /// </summary> 
        [DisplayName("物料类型")]
        [DbTableColumn("WLLX")]
        public string WLLX
        {
            get { return _WLLX; }
            set
            {
                if (_WLLX != value)
                {
                    if (IsIniting) _Ori_WLLX = value;
                    _WLLX = value;
                    RaisePropertyChanged("WLLX", true);
                }
            }
        }
        #endregion
        #region SCFS 上传方式
        private string _Ori_SCFS;
        private string _SCFS;

        /// <summary>
        /// 上传方式
        /// </summary> 
        [DisplayName("上传方式")]
        [DbTableColumn("SCFS")]
        public string SCFS
        {
            get { return _SCFS; }
            set
            {
                if (_SCFS != value)
                {
                    if (IsIniting) _Ori_SCFS = value;
                    _SCFS = value;
                    RaisePropertyChanged("SCFS", true);
                }
            }
        }
        #endregion

        #region Fjdyr 复检调样人
        private string _Ori_Fjdyr;
        private string _Fjdyr;

        /// <summary>
        /// 复检调样人
        /// </summary> 
        [DisplayName("复检调样人")]
        [DbTableColumn("Fjdyr")]
        public string Fjdyr
        {
            get { return _Fjdyr; }
            set
            {
                if (_Fjdyr != value)
                {
                    if (IsIniting) _Ori_Fjdyr = value;
                    _Fjdyr = value;
                    RaisePropertyChanged("Fjdyr", true);
                }
            }
        }
        #endregion
        private DateTime? _MainSampleMixTime;
        [DbTableColumn("parent.Mix_Time")]
        public DateTime? MainSampleMixTime
        {
            get { return _MainSampleMixTime; }
            set
            {
                if (_MainSampleMixTime != value)
                {
                    _MainSampleMixTime = value;
                    RaisePropertyChanged("MainSampleMixTime");
                }
            }
        }

        private string _MainSampleZyDanHao="";

        [DbTableColumn("parent.ZyDanHao")]
        public string MainSampleZyDanHao
        {
            get { return _MainSampleZyDanHao; }
            set
            {
                if (_MainSampleZyDanHao != value)
                {
                    _MainSampleZyDanHao = value;
                    RaisePropertyChanged("MainSampleZyDanHao");
                }
            }
        }




        #region StoreCode  样品单号
        private string _Ori_StoreCode = "";
        private string _StoreCode = "";

        /// <summary>
        /// 检验单号
        /// </summary> 
        [DisplayName("样品单号")]
        [DbTableColumn("YpDanHao")]
        public string StoreCode
        {
            //  get { return Zhc.Util.To32Str(this.Sample_Mix_ID); }
            get
            {
                //if (string.IsNullOrEmpty(_StoreCode))
                //{
                //    _StoreCode = DbContext.GetSeq("YP" + DateTime.Today.ToString("yyyyMMdd"), 3);
                //}
                
                return _StoreCode;
            }
            set
            {
                if (_StoreCode != value)
                {
                    if (IsIniting) _Ori_StoreCode = value;
                    _StoreCode = value;
                    RaisePropertyChanged("StoreCode", true);
                }
            }
        }
        #endregion

        #region WpCode  作业点编码
        private string _Ori_WpCode = "";
        private string _WpCode = "";

        /// <summary>
        /// 作业点编码
        /// </summary> 
        [DisplayName("作业点编码")]
        public string WpCode
        {
            get { return _WpCode; }
            set
            {
                if (_WpCode != value)
                {
                    if (IsIniting) _Ori_WpCode = value;
                    _WpCode = value;
                    RaisePropertyChanged("WpCode", true);
                }
            }
        }
        #endregion

        #region WpName  作业点名称
        private string _Ori_WpName = "";
        private string _WpName = "";

        /// <summary>
        /// 作业点名称
        /// </summary> 
        [DisplayName("作业点名称")]
        [DbTableColumn("wp.WCNAME")]
        public string WpName
        {
            get { return _WpName; }
            set
            {
                if (_WpName != value)
                {
                    if (IsIniting) _Ori_WpName = value;
                    _WpName = value;
                    RaisePropertyChanged("WpName");
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
        [DbTableColumn("supplier.CUSTSHORTNAME")]
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

        #region MatPK  物料主键
        private string _Ori_MatPK = "";
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
                    if (IsIniting) _Ori_MatPK = value;
                    _MatPK = value;
                    RaisePropertyChanged("MatPK", true);
                }
            }
        }
        #endregion

        #region MatCode  物料编码
        private string _Ori_MatCode = "";
        private string _MatCode = "";

        /// <summary>
        /// 物料编码
        /// </summary> 
        [DisplayName("物料编码")]
        public string MatCode
        {
            get { return _MatCode; }
            set
            {
                if (_MatCode != value)
                {
                    if (IsIniting) _Ori_MatCode = value;
                    _MatCode = value;
                    RaisePropertyChanged("MatCode", true);
                }
            }
        }
        #endregion

        #region MatName  物料名称
        private string _Ori_MatName = "";
        private string _MatName = "";

        /// <summary>
        /// 物料名称
        /// </summary> 
        [DisplayName("物料名称")]
        [DbTableColumn("mat.INVNAME")]
        public string MatName
        {
            get { return _MatName; }
            set
            {
                if (_MatName != value)
                {
                    if (IsIniting) _Ori_MatName = value;
                    _MatName = value;
                    RaisePropertyChanged("MatName");
                }
            }
        }
        #endregion

        #region TempID  临时号
        private int _Ori_TempID = 0;
        private int _TempID = 0;

        /// <summary>
        /// 临时号
        /// </summary> 
        [DisplayName("临时号")]
        public int TempID
        {
            get { return _TempID; }
            set
            {
                if (_TempID != value)
                {
                    if (IsIniting) _Ori_TempID = value;
                    _TempID = value;
                    RaisePropertyChanged("TempID", true);
                }
            }
        }
        #endregion

        #region CardID  卡号
        private string _Ori_CardID = "";
        private string _CardID = "";

        /// <summary>
        /// 卡号
        /// </summary> 
        [DisplayName("卡号")]
        public string CardID
        {
            get { return _CardID; }
            set
            {
                if (_CardID != value)
                {
                    if (IsIniting) _Ori_CardID = value;
                    _CardID = value;
                    RaisePropertyChanged("CardID", true);
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
      
        #region ZyDanHao  制样单号
        private string _Ori_ZyDanHao = "";
        private string _ZyDanHao = "";

        /// <summary>
        /// 制样单号
        /// </summary> 
        [DisplayName("制样单号")]
        public string ZyDanHao
        {
            get { return _ZyDanHao; }
            set
            {
                if (_ZyDanHao != value)
                {
                    if (IsIniting) _Ori_ZyDanHao = value;
                    _ZyDanHao = value;
                    RaisePropertyChanged("ZyDanHao", true);
                }
            }
        }
        #endregion
      
        private string _ZyRecvUser = "";
        [DisplayName("制样人")]
        public string ZyRecvUser
        {
            get { return _ZyRecvUser; }
            set
            {
                if (_ZyRecvUser != value)
                {
                    _ZyRecvUser = value;
                    RaisePropertyChanged("ZyRecvUser", true);
                }
            }
        }

        private DateTime? _ZyRecvTime = null;
        [DisplayName("制样时间")]
        public DateTime? ZyRecvTime
        {
            get { return _ZyRecvTime; }
            set
            {
                if (_ZyRecvTime != value)
                {
                    _ZyRecvTime = value;
                    RaisePropertyChanged("ZyRecvTime", true);
                }
            }
        }

        #region KouZa  扣杂
        private double? _Ori_KouZa = null;
        private double? _KouZa = null;

        /// <summary>
        /// 扣杂
        /// </summary> 
        [DisplayName("扣杂")]
        public double? KouZa
        {
            get
            {
                _KouZa = 0;
                foreach (var item in this.VehSamples)
                {
                    _KouZa += (item.KouZa ?? 0);
                }
                return _KouZa;
            }
            set
            {
                if (_KouZa != value)
                {
                    if (IsIniting) _Ori_KouZa = value;
                    _KouZa = value;
                    RaisePropertyChanged("KouZa", true);
                }
            }
        }
        #endregion

        #region KouShui  扣水
        private double? _Ori_KouShui = null;
        private double? _KouShui = null;

        /// <summary>
        /// 扣水
        /// </summary> 
        [DisplayName("扣水")]
        public double? KouShui
        {
            get
            {
                _KouShui = 0;
                foreach (var item in this.VehSamples)
                {
                    _KouShui += (item.KouShui ?? 0);
                }
                return _KouShui;
            }
            set
            {
                if (_KouShui != value)
                {
                    if (IsIniting) _Ori_KouShui = value;
                    _KouShui = value;
                    RaisePropertyChanged("KouShui", true);
                }
            }
        }
        #endregion

        #region QualityLevelID  质量等级
        private string _Ori_QualityLevelID = "";
        private string _QualityLevelID = "";

        /// <summary>
        /// 质量等级
        /// </summary> 
        [DisplayName("质量等级")]
        public string QualityLevelID
        {
            get { return _QualityLevelID; }
            set
            {
                if (_QualityLevelID != value)
                {
                    if (IsIniting) _Ori_QualityLevelID = value;
                    _QualityLevelID = value;
                    JudgeCondition = "人工判定";
                    RaisePropertyChanged("QualityLevelID", true);
                }
            }
        }
        #endregion

        #region 质量等级名称
        private string _QualityLevelName = "";
        [DisplayName("质量等级名称")]
        [NonTableField]
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
                    JudgeCondition = "人工判定";
                }
            }
        }
        #endregion

        #region JudgeCondition  判定条件
        private string _Ori_JudgeCondition = "";
        private string _JudgeCondition = "";

        /// <summary>
        /// 判定条件
        /// </summary> 
        [DisplayName("判定条件")]
        public string JudgeCondition
        {
            get { return _JudgeCondition; }
            set
            {
                if (_JudgeCondition != value)
                {
                    if (IsIniting) _Ori_JudgeCondition = value;
                    _JudgeCondition = value;
                    RaisePropertyChanged("JudgeCondition", true);
                }
            }
        }
        #endregion

        #region JudgeUser  判定人
        private string _Ori_JudgeUser = "";
        private string _JudgeUser = "";

        /// <summary>
        /// 判定人
        /// </summary> 
        [DisplayName("判定人")]
        public string JudgeUser
        {
            get { return _JudgeUser; }
            set
            {
                if (_JudgeUser != value)
                {
                    if (IsIniting) _Ori_JudgeUser = value;
                    _JudgeUser = value;
                    RaisePropertyChanged("JudgeUser", true);
                }
            }
        }
        #endregion

        #region JudgeTime  判定时间
        private DateTime? _Ori_JudgeTime = null;
        private DateTime? _JudgeTime = null;

        /// <summary>
        /// 判定时间
        /// </summary> 
        [DisplayName("判定时间")]
        public DateTime? JudgeTime
        {
            get { return _JudgeTime; }
            set
            {
                if (_JudgeTime != value)
                {
                    if (IsIniting) _Ori_JudgeTime = value;
                    _JudgeTime = value;
                    RaisePropertyChanged("JudgeTime", true);
                }
            }
        }
        #endregion

        #region UploadNcUser  上传NC人
        private string _Ori_UploadNcUser = "";
        private string _UploadNcUser = "";

        /// <summary>
        /// 上NC传人
        /// </summary> 
        [DisplayName("上传NC人")]
        public string UploadNcUser
        {
            get { return _UploadNcUser; }
            set
            {
                if (_UploadNcUser != value)
                {
                    if (IsIniting) _Ori_UploadNcUser = value;
                    _UploadNcUser = value;
                    RaisePropertyChanged("UploadNcUser", true);
                }
            }
        }
        #endregion

        #region UploadNcTime  上传NC时间
        private DateTime? _Ori_UploadNcTime = null;
        private DateTime? _UploadNcTime = null;

        /// <summary>
        /// 上传NC时间
        /// </summary> 
        [DisplayName("上传NC时间")]
        public DateTime? UploadNcTime
        {
            get { return _UploadNcTime; }
            set
            {
                if (_UploadNcTime != value)
                {
                    if (IsIniting) _Ori_UploadNcTime = value;
                    _UploadNcTime = value;
                    RaisePropertyChanged("UploadNcTime", true);
                }
            }
        }
        #endregion

        #region ExamineDept  抽样部门
        private string _Ori_ExamineDept = "";
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
                    if (IsIniting) _Ori_ExamineDept = value;
                    _ExamineDept = value;
                    RaisePropertyChanged("ExamineDept", true);
                }
            }
        }
        #endregion

        #region ExamineType  抽样类型
        private string _Ori_ExamineType = "";
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
                    if (IsIniting) _Ori_ExamineType = value;
                    _ExamineType = value;
                    RaisePropertyChanged("ExamineType", true);
                }
            }
        }
        #endregion

        #region FetchTime  取样时间
        private DateTime? _Ori_FetchTime = null;
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
                    if (IsIniting) _Ori_FetchTime = value;
                    _FetchTime = value;
                    RaisePropertyChanged("FetchTime", true);
                }
            }
        }
        #endregion

        #region FetchPerson  取样人
        private string _Ori_FetchPerson = "";
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
                    if (IsIniting) _Ori_FetchPerson = value;
                    _FetchPerson = value;
                    RaisePropertyChanged("FetchPerson", true);
                }
            }
        }
        #endregion

        #region FetchPlace  取样位置
        private string _Ori_FetchPlace = "";
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
                    if (IsIniting) _Ori_FetchPlace = value;
                    _FetchPlace = value;
                    RaisePropertyChanged("FetchPlace", true);
                }
            }
        }
        #endregion

        #region VehNo  车牌号
        private string _Ori_VehNo = "";
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
                    if (IsIniting) _Ori_VehNo = value;
                    _VehNo = value;
                    RaisePropertyChanged("VehNo", true);
                }
            }
        }
        #endregion

        private string _Sample_Cylx="";

        public string Sample_Cylx
        {
            get { return _Sample_Cylx; }
            set
            {
                if (_Sample_Cylx != value)
                {
                    _Sample_Cylx = value;
                    RaisePropertyChanged("Sample_Cylx");
                }
            }
        }


        #region IndependentReport  独立报检
        private bool _Ori_IndependentReport = false;
        private bool _IndependentReport = false;

        /// <summary>
        /// 独立报检
        /// </summary> 
        [DisplayName("独立报检")]
        public bool IndependentReport
        {
            get
            {
                switch (this.SampleType)
                {
                    case SampleType.破包样:
                        return true;
                    case SampleType.普通样:
                        return true;
                    case SampleType.抽查样:
                        return _IndependentReport;
                    case SampleType.校验样:
                        return false;
                    default:
                        return _IndependentReport;
                }
            }
            set
            {      
                if (IsIniting) _Ori_IndependentReport = value;
                if (_IndependentReport != value)
                {
                    _IndependentReport = value;
                    RaisePropertyChanged("IndependentReport", true);
                }
            }
        }
        #endregion

        #region NoticeBillId  作业单号
        private string _Ori_NoticeBillId = "";
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
                    if (IsIniting) _Ori_NoticeBillId = value;
                    _NoticeBillId = value;
                    RaisePropertyChanged("NoticeBillId", true);
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

        #region Memo  备注
        private string _Ori_Memo = "";
        private string _Memo = "";

        /// <summary>
        /// 备注
        /// </summary> 
        [DisplayName("备注")]
        public string Memo
        {
            get { return _Memo; }
            set
            {
                if (_Memo != value)
                {
                    if (IsIniting) _Ori_Memo = value;
                    _Memo = value;
                    RaisePropertyChanged("Memo", true);
                }
            }
        }
        #endregion

        #region NcQcBillNo  NC质检单号
        private string _Ori_NcQcBillNo = "";
        private string _NcQcBillNo = "";

        /// <summary>
        /// NC质检单号
        /// </summary> 
        [DisplayName("NC质检单号")]
        public string NcQcBillNo
        {
            get { return _NcQcBillNo; }
            set
            {
                if (_NcQcBillNo != value)
                {
                    if (IsIniting) _Ori_NcQcBillNo = value;
                    _NcQcBillNo = value;
                    RaisePropertyChanged("NcQcBillNo", true);
                }
            }
        }
        #endregion

        [NonTableField]
        public string Riqi
        {
            get
            {
                if (this.SampleType == SampleType.抽查样 && MainSampleMixTime != null)
                {
                    return MainSampleMixTime == null ? "" : MainSampleMixTime.Value.ToString("yyyy-MM-dd");
                }
                else if (this.SampleType == SampleType.复检样 && MainSampleMixTime != null)
                {
                    DbEntityTable<QC_Sample_Mix> mixs = new DbEntityTable<QC_Sample_Mix>();
                    mixs.LoadDataByWhere("main.Sample_Mix_ID=@Sample_Mix_ID", this.MainSampleMixId);
                    if (mixs.Count > 0)
                    {
                        if (mixs[0].SampleType == SampleType.抽查样)
                        {


                            return MainSampleMixTime == null ? "" : mixs[0].MainSampleMixTime.Value.ToString("yyyy-MM-dd");
                        }

                        else return MainSampleMixTime == null ? "" : MainSampleMixTime.Value.ToString("yyyy-MM-dd");

                    }
                    else { return Mix_Time == null ? "" : Mix_Time.Value.ToString("yyyy-MM-dd"); }
                }
                else
                {
                    return Mix_Time == null ? "" : Mix_Time.Value.ToString("yyyy-MM-dd");

                }
            }
            set { }
        }

        [NonTableField]
        public string FenZu
        {
            get
            {
                return string.Format("{0},{1}", SupplierName, MatName);

                //if (this.SampleType == SampleType.普通样)
                //    return this.WpName + "," + this.SupplierName + "," + this.MatName;
                //else if (this.SampleType == SampleType.抽查样)
                //    return string.Format("{1},{2}", SampleType.ToString(), SupplierName, MatName);
                //else
                //    return string.Format("{1},{2}", SampleType.ToString(), WpName, MatName);
            }
            set { }
        }
       
        [NonTableField]
        public string LeiXing
        {
            get
            {
                if (this.SampleType == SampleType.普通样)
                {
                    if (string.IsNullOrEmpty(WpCode))
                    {
                        return "快样";
                    }
                    else
                    {
                        return "正样";
                    }
                }
                else if (this.SampleType == SampleType.抽查样)
                {
                    return "抽样";
                }
                else
                {
                    return this.SampleType.ToString();
                }
            }
            set { }
        }

        public bool SaveIcInfo = false;
        public QC_IC_Info IcInfo = null;

        #region 车辆信息
        public bool SaveVehSamples = false;
        private QC_Sample_Veh_Table _VehSamples = new QC_Sample_Veh_Table();
        /// <summary>
        /// 车取样
        /// </summary>
        public QC_Sample_Veh_Table VehSamples
        {
            get { return _VehSamples; }
        }
        #endregion

        #region 检验项目
        public bool SaveCheckItems = false;
        private QC_MixCheckItem_Table _CheckItems = new QC_MixCheckItem_Table();
        /// <summary>
        /// 检验项目
        /// </summary>
        public QC_MixCheckItem_Table CheckItems
        {
            get
            {
                return _CheckItems;
            }
        }
        #endregion

        #region 检验值
        public bool SaveCheckVals = false;
        private QC_Sample_Value_Table _CheckVals = new QC_Sample_Value_Table();
        /// <summary>
        /// 检验值
        /// </summary>
        public QC_Sample_Value_Table CheckVals
        {
            get { return _CheckVals; }
        }
        #endregion

        #region 抽查样
        private QC_Sample_Mix_Table _InspectSamples = new QC_Sample_Mix_Table();
        /// <summary>
        /// 抽查样
        /// </summary>
        public QC_Sample_Mix_Table InspectSamples
        {
            get { return _InspectSamples; }
        }
        #endregion

        private DbEntityTable<QC_CheckGroupLab> _CheckGroupLabs = new DbEntityTable<QC_CheckGroupLab>();

        public DbEntityTable<QC_CheckGroupLab> CheckGroupLabs
        {
            get { return _CheckGroupLabs; }
        }

        [NonTableField]
        [RefProperty("IndependentReport")]
        public string FinishCommand
        {
            get
            {
                string _FinishCommand = "上传NC";
                if (this.SampleType == SampleType.普通样)
                {
                    _FinishCommand = "上传NC";
                }
                else if (this.SampleType == SampleType.抽查样 && this.IndependentReport)
                {
                    _FinishCommand = "上传NC";
                }
                else if (this.SampleType == SampleType.复检样 && this.IndependentReport)
                {
                    _FinishCommand = "上传NC";
                }
                else
                {
                    _FinishCommand = "处理";
                }

                return _FinishCommand;
            }
            set
            {

            }
        }

        public QC_Sample_Mix()
        {
            VehSamples.ListChanged += SubSet_ListChanged;
            CheckItems.ListChanged += SubSet_ListChanged;
           //CheckVals.ListChanged += CheckVals_ListChanged;
        }

        void CheckVals_ListChanged(object sender, ListChangedEventArgs e)
        {
            SaveEnable = true;
        }

        void SubSet_ListChanged(object sender, ListChangedEventArgs e)
        {
            SaveEnable = true;
        }

        /// <summary>
        /// 做质量判定
        /// </summary>
        public bool JudgeQuality()
        {
            bool result = false;
            DbEntityTable<QC_QualityRule> mixSample_QualityRules = new DbEntityTable<QC_QualityRule>();
            if (this.WLLX == "外矿")
            { mixSample_QualityRules.LoadDataByWhere("MatNcId=@MatNcId  and SupplierCode=@SupplierCode", this.MatPK,this.SupplierCode); }
            else
            { mixSample_QualityRules.LoadDataByWhere("MatNcId=@MatNcId", this.MatPK); }
            foreach (var item in mixSample_QualityRules)
            {
                this.CheckVals.DefaultSort();
                if (this.SampleType == SampleType.普通样)
                { this.CheckVals.DaoxuSort(); }
                Zhc.CalFramework.CalUtility calUtil = new Zhc.CalFramework.CalUtility(item.RuleContent.Replace("并且", "&&").Replace("或者", "||"));
                if (calUtil.DoCal(this.CheckVals) > 0)
                {
                    this.QualityLevelID = item.QualityLevelID;
                    this.LocalQcLevel = item.LocalQcLevel;
                    this.JudgeCondition = item.RuleContentFormat2;
                    result = true;
                    break;
                }
            }

            if (!result)
            {
                QC_Material material = QC_Material.GetByID(this.MatPK);
                if (material != null && !string.IsNullOrEmpty(material.QualityLevelId))
                {
                    this.QualityLevelID = material.QualityLevelId;
                    this.LocalQcLevel = material.LocalQcLevel;
                    this.JudgeCondition = "物料默认值";
                    result = true;
                }
            }
            this.JudgeUser = LocalInfo.Current.user.ID;
            this.JudgeTime = DateTime.Now;
            this.SampleState = SampleState.质量判定完成;
            return result;
        }

        /// <summary>
        /// 报检值
        /// </summary>
        /// <returns></returns>
        public bool CreateReportVal()
        {
            DbEntityTable<QC_Sample_Mix> mixs = new DbEntityTable<QC_Sample_Mix>();
            if (this.SampleType == SampleType.普通样&&this.WLLX=="合金")
            {
                mixs.LoadDataByWhere("main.MainSampleMixId=@MainSampleMixId",this.Sample_Mix_ID);
                if (mixs.Count > 0)
                {
                    if (mixs[0].SampleState < SampleState.化验审核完成)
                    { throw new Exception(string.Format("破包样还未化验审核完成")); }
                }
            
            }
            else if (this.SampleType == SampleType.破包样 && this.WLLX == "合金")
            {
                mixs.LoadDataByWhere("main.Sample_Mix_ID=@Sample_Mix_ID", this.MainSampleMixId);
                if (mixs.Count > 0)
                {
                    if (mixs[0].SampleState < SampleState.化验审核完成)
                    { throw new Exception(string.Format("普通样还未化验审核完成")); }
                }

            }
            int count1 = QC_CheckMaxMinVal.GetBatchNum(this.Riqi, this.SupplierCode, this.MatPK);
            int count2 = QC_CheckMaxMinVal.GetCheckFinishBatchNum(this.Riqi, this.SupplierCode, this.MatPK);
            if (count2 != count1)
            {
                throw new Exception(string.Format("还有{0}个没有制样完成.", count1 - count2));
            }
            string CaO = "";
            string MgO = "";
            string SiO = "";
            string ALO = "";
            string KO = "";
            string NAO = "";
            foreach (var item in this.CheckVals)
            {
                if (this.SampleType == SampleType.抽查样 && item.ValSource == "正样") continue;
                if (this.SampleType == SampleType.复检样 && item.ValSource == "正样") continue;
                if (this.SampleType == SampleType.抽查样 && item.ValSource == "") continue;
                if (this.SampleType == SampleType.普通样 && (item.ValSource == "复检样" || item.ValSource == "抽样")) continue;
                if (item.CheckItemCode == "10060")
                {
                    foreach (var it in this.CheckVals)

                    {
                        if (it.CheckItemCode == "10058")
                            KO = it.CheckVal;
                        else if (it.CheckItemCode == "10059")
                            NAO = it.CheckVal;
                    }
                    if (KO != null && KO != "" && NAO != null && NAO!="")
                    item.CheckVal = (Convert.ToDouble(KO) + Convert.ToDouble(NAO)).ToString("N2");
                }
                if (item.CheckItemCode == "10009")
                {

                    foreach (var it in this.CheckVals)
                    {
                        if (it.CheckItemCode == "10006")
                            CaO = it.CheckVal;
                        else if (it.CheckItemCode == "10004")
                            MgO = it.CheckVal;
                        else if (it.CheckItemCode == "10005")
                            SiO = it.CheckVal;
                        else if (it.CheckItemCode == "10007")
                            ALO = it.CheckVal;
                    }

                    if (CaO != null && MgO != null && SiO != null && ALO != null && CaO != "" && MgO != "" && SiO != "" && ALO != "")
                    {
                        if ((Convert.ToDouble(SiO) + Convert.ToDouble(ALO)) != 0)
                            item.CheckVal = ((Convert.ToDouble(CaO) + Convert.ToDouble(MgO)) / (Convert.ToDouble(SiO) + Convert.ToDouble(ALO))).ToString("N2");

                    }
                }
                item.ReportVal = item.CheckVal;
                if (this.SampleType == SampleType.抽查样)
                {
                    cys.LoadDataByWhere("main.VehNo=@VehNo and main.SampleType=@SampleType and main.mainsamplemixid=@mainsamplemixid", this.VehNo, SampleType.抽查样,this.MainSampleMixId);
                    if (cys.Count > 1)
                    {
                        object avg;
                        if (item.CheckItemCode == "10012")
                        {
                             avg = DbContext.ExecuteScalar("Select cast(avg(cast(checkval as decimal(18,1))) as decimal(18,1)) From QC_Sample_cyavg Where SampleType=@SampleType and mainsamplemixid=@mainsamplemixid and vehno=@vehno and checkitemcode=@checkitemcode", SampleType.抽查样, this.MainSampleMixId, this.VehNo, item.CheckItemCode);
                        }
                        else {  avg = DbContext.ExecuteScalar("Select cast(avg(cast(checkval as decimal(18,2))) as decimal(18,2)) From QC_Sample_cyavg Where SampleType=@SampleType and mainsamplemixid=@mainsamplemixid and vehno=@vehno and checkitemcode=@checkitemcode", SampleType.抽查样, this.MainSampleMixId, this.VehNo, item.CheckItemCode); }
                        item.ReportVal = Convert.ToString(avg);
                    }
                    cys.Clear();
                }
                if (this.SampleType == SampleType.破包样  && this.WLLX == "合金")
                {

                    object avg;
                    int xiaoshuweishu = item.CheckVal.Length - item.CheckVal.IndexOf(".")-1;
                    avg = DbContext.ExecuteScalar("  Select  cast(avg(cast(checkval as decimal(18,"+ xiaoshuweishu + "))) as decimal(18," + xiaoshuweishu + ")) From QC_Sample_cyavg Where  (sample_mix_id=@sample_mix_id or sample_mix_id=@MainSampleMixId)  and  checkitemcode=@checkitemcode", this.Sample_Mix_ID,this.MainSampleMixId,item.CheckItemCode);
                    item.ReportVal = Convert.ToString(avg);
                    if (item.CheckItemName.StartsWith("粒度"))
                    {
                        item.ReportVal = item.CheckVal;
                    }
                }
                if ( this.SampleType == SampleType.普通样 && this.WLLX == "合金")
                {

                    object avg;
                    int xiaoshuweishu = item.CheckVal.Length - item.CheckVal.IndexOf(".")-1;
                    avg = DbContext.ExecuteScalar("  Select  cast(avg(cast(checkval as decimal(18," + xiaoshuweishu + "))) as decimal(18," + xiaoshuweishu + ")) From QC_Sample_cyavg Where   (sample_mix_id=@sample_mix_id or MainSampleMixId=@MainSampleMixId)  and  checkitemcode=@checkitemcode", this.Sample_Mix_ID, this.Sample_Mix_ID, item.CheckItemCode);
                    item.ReportVal = Convert.ToString(avg);
                }
                if (item.CheckItemCode == "10001"&&this.SupplierCode!="130401165")
                {
                    QC_CheckMaxMinVal maxmin = QC_CheckMaxMinVal.GetMaxMinVal(this.Riqi, this.SupplierCode, this.MatPK);
                    if (maxmin != null)
                    {
                        if (maxmin.MaxVal - maxmin.MinVal <= 1)
                        {
                            item.ReportVal = maxmin.MaxVal.ToString("N2");
                        }
                    }

                    QC_ChgWater chgWater = QC_ChgWater.GetByMatCust(this.MatPK, this.SupplierCode);
                    if (chgWater != null && chgWater.ChgWater != null && item.ReportVal != "")
                    {
                        item.ReportVal = (Convert.ToDouble(item.ReportVal) + chgWater.ChgWater.Value).ToString();
                    }
                }
                item.ReportValSource = "系统";

            }
            this.SampleState = SampleState.报检数据生成;
            return true;
        }

        DbEntityTable<QC_Sample_Mix> cys = new DbEntityTable<QC_Sample_Mix>();
        
        /// <summary>
        /// 自动生成报检值
        /// </summary>
        public bool ZdCreateReportVal()
        {
            int count1 = QC_CheckMaxMinVal.GetBatchNum(this.Riqi, this.SupplierCode, this.MatPK);
            int count2 = QC_CheckMaxMinVal.GetCheckFinishBatchNum(this.Riqi, this.SupplierCode, this.MatPK);
            if (count2 != count1)
            {
                return false;
            }
            string CaO = "";
            string MgO = "";
            string SiO = "";
            string ALO = "";
            string KO = "";
            string NAO = "";
            foreach (var item in this.CheckVals)
            {




                if (this.SampleType == SampleType.抽查样 && item.ValSource == "正样") continue;
                if (this.SampleType == SampleType.抽查样 && item.ValSource == "") continue;
                if (this.SampleType == SampleType.复检样 && item.ValSource == "正样") continue;

                if (this.SampleType == SampleType.普通样 && (item.ValSource == "复检样" || item.ValSource == "抽样")) continue;
                if (item.CheckItemCode == "10060")
                {
                    foreach (var it in this.CheckVals)
                    {
                        if (it.CheckItemCode == "10058")
                            KO = it.CheckVal;
                        else if (it.CheckItemCode == "10059")
                            NAO = it.CheckVal;
                    }
                    if (KO != null && KO != "" && NAO != null && NAO != "")
                        item.CheckVal = (Convert.ToDouble(KO) + Convert.ToDouble(NAO)).ToString("N2");
                }
                if (item.CheckItemCode == "10009")
                {

                    foreach (var it in this.CheckVals)
                    {
                        if (it.CheckItemCode == "10006")
                            CaO = it.CheckVal;
                        else if (it.CheckItemCode == "10004")
                            MgO = it.CheckVal;
                        else if (it.CheckItemCode == "10005")
                            SiO = it.CheckVal;
                        else if (it.CheckItemCode == "10007")
                            ALO = it.CheckVal;
                    }

                    if (CaO != null && MgO != null && SiO != null && ALO != null && CaO != "" && MgO != "" && SiO != "" && ALO != "")
                    {
                        if ((Convert.ToDouble(SiO) + Convert.ToDouble(ALO)) != 0)
                            item.CheckVal = ((Convert.ToDouble(CaO) + Convert.ToDouble(MgO)) / (Convert.ToDouble(SiO) + Convert.ToDouble(ALO))).ToString("N2");

                    }
                }


                
                item.ReportVal = item.CheckVal;
                if (this.SampleType == SampleType.抽查样)
                {
                    cys.LoadDataByWhere("main.VehNo=@VehNo and main.SampleType=@SampleType and main.mainsamplemixid=@mainsamplemixid", this.VehNo, SampleType.抽查样,this.MainSampleMixId);
                    if (cys.Count > 1)
                    {
                        object avg;
                        if (item.CheckItemCode == "10012")
                        {
                            avg = DbContext.ExecuteScalar("Select cast(avg(cast(checkval as decimal(18,1))) as decimal(18,1)) From QC_Sample_cyavg Where SampleType=@SampleType and mainsamplemixid=@mainsamplemixid and vehno=@vehno and checkitemcode=@checkitemcode", SampleType.抽查样, this.MainSampleMixId, this.VehNo, item.CheckItemCode);
                        }
                        else { avg = DbContext.ExecuteScalar("Select cast(avg(cast(checkval as decimal(18,2))) as decimal(18,2)) From QC_Sample_cyavg Where SampleType=@SampleType and mainsamplemixid=@mainsamplemixid and vehno=@vehno and checkitemcode=@checkitemcode", SampleType.抽查样, this.MainSampleMixId, this.VehNo, item.CheckItemCode); }
                        item.ReportVal = Convert.ToString(avg);
                    }
                    cys.Clear();
                }
              
                if (item.CheckItemCode == "10001" && this.SupplierCode != "130401165")
                {
                    QC_CheckMaxMinVal maxmin = QC_CheckMaxMinVal.GetMaxMinVal(this.Riqi, this.SupplierCode, this.MatPK);
                    if (maxmin != null)
                    {
                        if (maxmin.MaxVal - maxmin.MinVal <= 1)
                        {
                            item.ReportVal = maxmin.MaxVal.ToString("N2");
                        }
                    }

                    QC_ChgWater chgWater = QC_ChgWater.GetByMatCust(this.MatPK, this.SupplierCode);
                    if (chgWater != null && chgWater.ChgWater != null && item.ReportVal != "")
                    {
                        item.ReportVal = (Convert.ToDouble(item.ReportVal) + chgWater.ChgWater.Value).ToString();
                    }
                }
                item.ReportValSource = "系统";

            }
            this.SampleState = SampleState.报检数据生成;
            return true;
        }
        /// <summary>
        /// 报检数据
        /// </summary>
        /// <returns></returns>
        public bool UploadToNc()
        {
            foreach (var item in this.VehSamples)
            {

                if (item.Sjsl == 0 || item.Sjsl == null)
                {
                    return false;
                }

            }
            if (string.IsNullOrEmpty(this.QualityLevelID))
            {
                throw new Exception("还没有做质量判定");
            }
            double?  koushui=null;
            double?  kouza =null;
            DateTime curTime = DateTime.Now;
            string CurUser = LocalInfo.Current.user.ID;
            ufinterface uf = new ufinterface();

            uf.bill.id = this.ZyDanHao;
            uf.bill.bill_head.header.cprayerid = CurUser;
            uf.bill.bill_head.header.dpraydate = curTime.ToString("yyyy-MM-dd HH:mm:ss");
            uf.bill.bill_head.header.cauditpsn = CurUser;
            uf.bill.bill_head.header.creporterid = CurUser;
            uf.bill.bill_head.header.dreportdate = curTime.ToString("yyyy-MM-dd HH:mm:ss");
            uf.bill.bill_head.header.vbatchcode = this.ZyDanHao;
         
            uf.bill.bill_head.header.vmemo = this.Memo;

            foreach (var veh in this.VehSamples)
            {
                if (this.SampleType==SampleType.普通样 && veh.IndependentReport != null && veh.IndependentReport.Value) continue;
              
                VehItem item = new VehItem();
              
                item.cbaseid = veh.MatPK;
                item.ccheckstate_bid = this.QualityLevelID;
                //DbEntityTable<QC_NoticeDhdItem_View> data = new DbEntityTable<QC_NoticeDhdItem_View>();
                //data.LoadDataByWhere("NoticeId=@NoticeId", veh.NoticeBillId);
                //if (data.Count < 1)
                //{
                //    throw new Exception("找不到作业单信息，作业单号：" + veh.NoticeBillId);
                //}

                item.csourcebillcode = veh.NcDhdHeadNo;
                item.csourcebillrowid = veh.NcDhdBodyId; // data[0].NcDhdBodyId;// veh.NcBillId;
                item.vdef1 = veh.VehNo; // data[0].Cph;

                try
                {
                    item.vdef2 = veh.T1.Split(' ')[0];// data[0].T1.Split(' ')[0];
                    item.vdef7 = veh.T1.Split(' ')[1]; //data[0].T1.Split(' ')[1];
                }
                catch
                {
                    throw new Exception("称重时间有问题：" + veh.T1);
                }
                try
                {
                    item.vdef4 = veh.T2.Split(' ')[0];
                    item.vdef8 = veh.T2.Split(' ')[1];
                }
                catch
                {
                    throw new Exception("回皮时间有问题：" + veh.T2);
                }
                item.vdef9 = veh.Sjsl==null?"":veh.Sjsl.Value.ToString();//  data[0].Sjsl;

                item.vdef10 = veh.KouShui.ToString();
                item.vdef11 = veh.KouZa.ToString();
                item.vdef18 = veh.Memo;
                item.vstobatchcode = veh.RukuPch;
                uf.bill.bill_head.items.item.Add(item);
                if (veh.KouShui != null && koushui == null)
                { koushui = 0; koushui += veh.KouShui; }
                else if (veh.KouShui != null && koushui != null)
                {

                    koushui += veh.KouShui;
                }
                if (veh.KouZa != null && kouza == null)
                { kouza = 0; kouza += veh.KouZa; }
               else if (veh.KouZa != null && kouza != null)
                { kouza += veh.KouZa; }
            }
            uf.bill.bill_head.header.vdef18 = koushui == null ? "" : koushui.Value.ToString("N3");
            uf.bill.bill_head.header.vdef19 = kouza == null ? "" : kouza.Value.ToString("N3");
            this.CheckVals.DefaultSort();
            if (this.SampleType == SampleType.普通样)
            { this.CheckVals.DaoxuSort(); }
            List<string> checkItemCode = new List<string>();

            foreach (var checkVal in this.CheckVals)
            {
                CheckValItem item = new CheckValItem();
                item.ccheckitemid = checkVal.CheckItemNcId;
                item.cresult = checkVal.ReportVal;
                item.ccheckerid = CurUser;// checkVal.CheckUser;
                item.dcheckdate = curTime.ToString("yyyy-MM-dd HH:mm:ss");// checkVal.CheckTime.ToString();
                item.vsamplecode = "1";
                if (!checkItemCode.Contains(item.ccheckitemid))
                {
                    checkVal.FinalVal = checkVal.ReportVal;
                    if (this.SampleType == SampleType.普通样)
                    {
                        checkVal.FinalType = "正样";
                    }
                    if (this.SampleType == SampleType.抽查样)
                    {
                        checkVal.FinalType = "抽样";
                    }
                    if (this.SampleType == SampleType.复检样)
                    {
                        checkVal.FinalType = "复检样";
                        foreach (var ck in this.CheckVals)
                        {
                            if (ck.ValSource == "正样" && ck.CheckItemCode == checkVal.CheckItemCode)
                            {
                                ck.FinalVal = checkVal.ReportVal;
                                ck.FinalType = "复检样";

                            }

                        }
                    
                    
                    }
                   

                    checkItemCode.Add(item.ccheckitemid);
                    if (item.cresult != "")
                        uf.bill.bill_head.b2Items.item.Add(item);
                }
            }

            string xml = TelComm.Serialize<ufinterface>(uf);

            Encoding encode = Encoding.GetEncoding("gb2312");
            if (!System.IO.Directory.Exists(@".\log\")) System.IO.Directory.CreateDirectory(@".\log\");
            File.WriteAllText(@".\log\" + this.ZyDanHao + ".xml", xml, encode);
            string ncBillNo = TelComm.TransferXML(xml);
            if (!string.IsNullOrEmpty(ncBillNo))
            {
                try
                {
                    this.NcQcBillNo = ncBillNo;
                    this.UploadNcUser = CurUser;
                    this.UploadNcTime = curTime;
                    this.SampleState = SampleState.NC报检完成;
                    this.SCFS = "手动上传";
                    this.SaveCheckVals = true;
                    this.Save();
                }
                catch
                {
                    throw new Exception("保存失败");
                }
            }
            return true;
        }
        /// <summary>
        /// 自动报检数据
        /// </summary>
        /// <returns></returns>
         public bool ZdUploadToNc()
        {
            foreach (var item in this.VehSamples)
            {

                if (item.Sjsl == 0 || item.Sjsl == null)
                {
                    return false;
                }
            
            }


            if (string.IsNullOrEmpty(this.QualityLevelID))
            {
                return false;
            }
            double?  koushui=null;
            double?  kouza =null;
            DateTime curTime = DateTime.Now;
            string CurUser = LocalInfo.Current.user.ID;
            ufinterface uf = new ufinterface();

            uf.bill.id = this.ZyDanHao;
            uf.bill.bill_head.header.cprayerid = CurUser;
            uf.bill.bill_head.header.dpraydate = curTime.ToString("yyyy-MM-dd HH:mm:ss");
            uf.bill.bill_head.header.cauditpsn = CurUser;
            uf.bill.bill_head.header.creporterid = CurUser;
            uf.bill.bill_head.header.dreportdate = curTime.ToString("yyyy-MM-dd HH:mm:ss");
            uf.bill.bill_head.header.vbatchcode = this.ZyDanHao;
         
            uf.bill.bill_head.header.vmemo = this.Memo;

            foreach (var veh in this.VehSamples)
            {
                if (this.SampleType==SampleType.普通样 && veh.IndependentReport != null && veh.IndependentReport.Value) continue;
              
                VehItem item = new VehItem();
              
                item.cbaseid = veh.MatPK;
                item.ccheckstate_bid = this.QualityLevelID;
                //DbEntityTable<QC_NoticeDhdItem_View> data = new DbEntityTable<QC_NoticeDhdItem_View>();
                //data.LoadDataByWhere("NoticeId=@NoticeId", veh.NoticeBillId);
                //if (data.Count < 1)
                //{
                //    throw new Exception("找不到作业单信息，作业单号：" + veh.NoticeBillId);
                //}

                item.csourcebillcode = veh.NcDhdHeadNo;
                item.csourcebillrowid = veh.NcDhdBodyId; // data[0].NcDhdBodyId;// veh.NcBillId;
                item.vdef1 = veh.VehNo; // data[0].Cph;

                try
                {
                    item.vdef2 = veh.T1.Split(' ')[0];// data[0].T1.Split(' ')[0];
                    item.vdef7 = veh.T1.Split(' ')[1]; //data[0].T1.Split(' ')[1];
                }
                catch
                {
                    return false;
                }
                try
                {
                    item.vdef4 = veh.T2.Split(' ')[0];
                    item.vdef8 = veh.T2.Split(' ')[1];
                }
                catch
                {
                    return false;
                }
                item.vdef9 = veh.Sjsl==null?"":veh.Sjsl.Value.ToString();//  data[0].Sjsl;

                item.vdef10 = veh.KouShui.ToString();
                item.vdef11 = veh.KouZa.ToString();
                item.vdef18 = veh.Memo;
                item.vstobatchcode = veh.RukuPch;
                uf.bill.bill_head.items.item.Add(item);
                if (veh.KouShui != null && koushui == null)
                { koushui = 0; koushui += veh.KouShui; }
                else if (veh.KouShui != null && koushui != null)
                {

                    koushui += veh.KouShui;
                }
                if (veh.KouZa != null && kouza == null)
                { kouza = 0; kouza += veh.KouZa; }
               else if (veh.KouZa != null && kouza != null)
                { kouza += veh.KouZa; }
            }
            uf.bill.bill_head.header.vdef18 = koushui == null ? "" : koushui.Value.ToString("N2");
            uf.bill.bill_head.header.vdef19 = kouza == null ? "" : kouza.Value.ToString("N2");
            this.CheckVals.DefaultSort();
            if (this.SampleType == SampleType.普通样)
            { this.CheckVals.DaoxuSort(); }
            List<string> checkItemCode = new List<string>();

            foreach (var checkVal in this.CheckVals)
            {
                CheckValItem item = new CheckValItem();
                item.ccheckitemid = checkVal.CheckItemNcId;
                item.cresult = checkVal.ReportVal;
                item.ccheckerid = CurUser;// checkVal.CheckUser;
                item.dcheckdate = curTime.ToString("yyyy-MM-dd HH:mm:ss");// checkVal.CheckTime.ToString();
                item.vsamplecode = "1";
                if (!checkItemCode.Contains(item.ccheckitemid))
                {
                    checkVal.FinalVal = checkVal.ReportVal;
                    if (this.SampleType == SampleType.普通样)
                    {
                        checkVal.FinalType = "正样";
                    }
                    if (this.SampleType == SampleType.抽查样)
                    {
                        checkVal.FinalType = "抽样";
                    }
                    if (this.SampleType == SampleType.复检样)
                    {
                        checkVal.FinalType = "复检样";
                        foreach (var ck in this.CheckVals)
                        {
                            if (ck.ValSource == "正样" && ck.CheckItemCode == checkVal.CheckItemCode)
                            {
                                ck.FinalVal = checkVal.ReportVal;
                                ck.FinalType = "复检样";

                            }

                        }
                    
                    
                    }
                   

                    checkItemCode.Add(item.ccheckitemid);
                    if (item.cresult != "")
                        uf.bill.bill_head.b2Items.item.Add(item);
                }
            }

            string xml = TelComm1.Serialize<ufinterface>(uf);

            Encoding encode = Encoding.GetEncoding("gb2312");
            if (!System.IO.Directory.Exists(@".\log\")) System.IO.Directory.CreateDirectory(@".\log\");
            File.WriteAllText(@".\log\" + this.ZyDanHao + ".xml", xml, encode);
            string ncBillNo = TelComm1.TransferXML(xml);
            if (!string.IsNullOrEmpty(ncBillNo))
            {
                try
                {
                    this.NcQcBillNo = ncBillNo;
                    this.UploadNcUser = CurUser;
                    this.UploadNcTime = curTime;
                    this.SampleState = SampleState.NC报检完成;
                    this.SCFS = "自动上传";
                    this.SaveCheckVals = true;
                    this.Save();
                   
                }
                catch
                {
                    throw new Exception("保存失败");
                }
            }
            return true;
        }
        /// <summary>
        /// 加载详细信息
        /// </summary>
        public void LoadDataDetailes()
         {
             bool fujianchouyang = false;
            if (SampleType == SampleType.抽查样 )
            {
                int parentId = InspectSampleParentId(this.Sample_Mix_ID);
                this.VehSamples.LoadDataByNoticeBillId(this.NoticeBillId);
                if (daycheck() == 0)
                {
                    this.CheckVals.LoadInspectSampleAllData(this.Sample_Mix_ID, parentId);
                }
                else
                {
                    this.CheckVals.LoadInspectHotAllData( this.Sample_Mix_ID, parentId, daycheck(), "发热量1");
                }
            }
            else if (SampleType == SampleType.破包样)
            {

                this.VehSamples.LoadDataBySampleMixId(this.MainSampleMixId);
              
                    this.CheckVals.LoadZhengSampleAllData(this.Sample_Mix_ID);
               
              
                this.InspectSamples.LoadInpsectSamples(this.Sample_Mix_ID);
                foreach (var item in this.InspectSamples)
                {
                    item.CheckVals.LoadInspectSampleAllData(item.Sample_Mix_ID, this.Sample_Mix_ID);
                }
            }

            else if (SampleType == SampleType.复检样)
            {
                int parentId = InspectSampleParentId(this.Sample_Mix_ID);
                DbEntityTable<QC_Sample_Mix> mixs = new DbEntityTable<QC_Sample_Mix>();
                mixs.LoadDataByWhere("main.Sample_Mix_ID=@Sample_Mix_ID", this.MainSampleMixId);
                if (mixs.Count > 0)
                {

                    if (mixs[0].SampleType == SampleType.抽查样)
                    {

                        fujianchouyang = true;
                        this.VehSamples.LoadDataByNoticeBillId(mixs[0].NoticeBillId);
                        this.CheckVals.LoadRecheckInspectSampleAllData(this.Sample_Mix_ID, this.MainSampleMixId, mixs[0].MainSampleMixId);
                    }
                    else
                    {
                        this.VehSamples.LoadDataBySampleMixId(this.MainSampleMixId);
                        this.CheckVals.LoadRecheckSampleAllData(this.Sample_Mix_ID, this.MainSampleMixId);
                        bool cunzaifrl = false;
                        foreach (var it in this.CheckVals)
                        {
                            if (it.CheckItemName == "发热量1")
                                cunzaifrl = true;
                        }


                        if (cunzaifrl == false)
                        {
                             QC_Sample_Value_Table ckvs = new QC_Sample_Value_Table();
                             int hotdh = 0;
                             object cntObj = DbContext.ExecuteScalar("SELECT mck.Sample_Mix_ID FROM  QC_MixCheckItem mck  inner join qc_sample_mix mix on mix.SAMPLE_MIX_ID=mck.SAMPLE_MIX_ID  where mix.Mix_Time>='" + mixs[0].Mix_Time.Value.Date + "' and mix.SampleType=" + (int)SampleType.普通样 + " and mix.SupplierCode=@SupplierCode and mix.MatPK=@MatPK and mck.checkitemname = @checkitemname ", this.SupplierCode, this.MatPK, "发热量1");
                             if (cntObj != null)
                               {
                                  hotdh = Convert.ToInt32(cntObj);       
                               }
                              ckvs.LoadHotData(hotdh, this.MainSampleMixId, "发热量1");

                            foreach (var item in ckvs)
                            {
                                if (item.CheckItemName == "发热量1")
                                {
                                    item.ValSource = "正样";
                                    this.CheckVals.Add(item);
                                }

                            }
                        }
                    }
                }
                else
                {
                    this.VehSamples.LoadDataBySampleMixId(this.MainSampleMixId);
                    this.CheckVals.LoadRecheckSampleAllData(this.Sample_Mix_ID, this.MainSampleMixId);
                }



                // this.CheckVals.LoadHotData(daycheck(), this.MainSampleMixId, "发热量1");
            }
            else
            {
                this.VehSamples.LoadDataBySampleMixId(this.Sample_Mix_ID);
                if (daycheck() == 0)
                {
                    this.CheckVals.LoadZhengSampleAllData(this.Sample_Mix_ID);
                }
                else
                {
                    this.CheckVals.LoadHotData(daycheck(), this.Sample_Mix_ID, "发热量1");
                }
                this.InspectSamples.LoadInpsectSamples(this.Sample_Mix_ID);
                foreach (var item in this.InspectSamples)
                {
                    item.CheckVals.LoadInspectSampleAllData(item.Sample_Mix_ID, this.Sample_Mix_ID);
                }
            }


            CheckGroupLabs.LoadDataBySql("select mck.CheckGroupName as CheckGroupName,IsNull(lab.StoreCode,mck.StoreCode) as YpDanHao,mck.MakeUser as SendUser,IsNull(lab.MakeTime,mck.MakeTime) as SendTime,lab.JyCode as JyCode,lab.JyUser,lab.JyTime,lab.LabState from qc_mixcheckgroup mck left join QC_Sample_Lab lab on lab.sample_lab_id=mck.sample_lab_id where mck.Sample_Mix_Id=" + this.Sample_Mix_ID);

            this.CheckVals.DefaultSort();
            if (this.SampleType == SampleType.普通样||fujianchouyang)
            { this.CheckVals.DaoxuSort(); fujianchouyang = false; }
            this.SaveEnable = false;
        }

        public  int daycheck()
        {
            int hotdh = 0;
         
            object cntObj = DbContext.ExecuteScalar("SELECT mck.Sample_Mix_ID FROM  QC_MixCheckItem mck  inner join qc_sample_mix mix on mix.SAMPLE_MIX_ID=mck.SAMPLE_MIX_ID  where mix.Mix_Time>='" + this.Mix_Time.Value.Date + "' and mix.SampleType=" + (int)SampleType.普通样 + " and mix.SupplierCode=@SupplierCode and mix.MatPK=@MatPK and mck.checkitemname = @checkitemname ", this.SupplierCode, this.MatPK, "发热量1");
            if (cntObj != null)
            {
                hotdh = Convert.ToInt32(cntObj);
                  
            }
            return hotdh;
        }
        public void LoadCheckVals()
        {

     

            if (SampleType == SampleType.抽查样)
            {
                int parentId = InspectSampleParentId(this.Sample_Mix_ID);
                this.VehSamples.LoadDataByNoticeBillId(this.NoticeBillId);
                this.CheckVals.LoadInspectSampleAllData(this.Sample_Mix_ID, parentId);
            }
            else
            {
              
                    this.VehSamples.LoadDataBySampleMixId(this.Sample_Mix_ID);
                    this.CheckVals.LoadDataBySampleMixId(this.Sample_Mix_ID);
              
            }
            this.CheckVals.DefaultSort();
            if (this.SampleType == SampleType.普通样)
            { this.CheckVals.DaoxuSort(); }
        }

        protected override void AfterSave(IDbTransaction trans)
        {
            if (this.SampleType == SampleType.抽查样)
            {
                string sql = "Update veh Set veh.IsInspectSample=(select count(*) from QC_Sample_Mix mix1 where mix1.NoticeBillId=veh.NoticeBillId and mix1.SampleType=1),";
                sql += "veh.IndependentReport=(select count(*) from QC_Sample_Mix mix2 where mix2.NoticeBillId=veh.NoticeBillId and mix2.SampleType=1 and mix2.IndependentReport=1)";
                sql += " from QC_Sample_Veh veh";
                sql += " where veh.NoticeBillId='" + this._NoticeBillId + "'";
                DbContext.ExeSql(trans, sql);
            }
            if (this.DataState == DataRowState.Deleted)
            {
                DbContext.ExeSql("Update QC_IC_Info Set SampleId=0 where SampleId=@Sample_Mix_ID and CardType=@CardType", this.Sample_Mix_ID, QC_IC_Info.CardUseType_Mix);
            }

            if (SaveIcInfo && IcInfo != null && !string.IsNullOrEmpty(this.CardID))
            {
                IcInfo.SampleId = this.Sample_Mix_ID;
                IcInfo.Save();
            }

            if (this.SampleType == SampleType.普通样)
            {
                if (this.SaveVehSamples)
                {
                    if (this.DataState == DataRowState.Deleted)
                    {
                       // DbContext.ExeSql("Delete From QC_Sample_Veh where Sample_Mix_ID=@Sample_Mix_ID", this.Sample_Mix_ID);
                       // VehSamples.Empty();
                    }
                    else
                    {
                        foreach (var item in VehSamples)
                        {
                            item.Sample_Mix_ID = this.Sample_Mix_ID;
                        }
                        VehSamples.Save(trans);
                    }
                }
            }

            if (this.SaveCheckItems)
            {
                if (this.DataState == DataRowState.Deleted)
                {
                    CheckItems.DeleteBySampleMixId(this.Sample_Mix_ID);
                    CheckItems.Empty();
                }
                else
                {
                    foreach (var item in CheckItems)
                    {
                        item.Sample_Mix_ID = this.Sample_Mix_ID;
                    }
                }
                CheckItems.Save();
            }

            if (this.SaveCheckVals)
            {
                if (this.DataState == DataRowState.Deleted)
                {
                    // DbContext.ExeSql("Delete From QC_Sample_Value where Sample_Mix_ID=@Sample_Mix_ID AND Sample_LAB_ID>0", this.Sample_Mix_ID);
                }
                else
                {
                    CheckVals.Save(trans);
                }
            }

        }

        public void CopyData(QC_Sample_Mix original)
        {
            this.MatPK = original.MatPK;
            this.MatCode = original.MatCode;
            this.MatName = original.MatName;
            this.MainSampleMixId = original.Sample_Mix_ID;
            this.MainSampleZyDanHao = original.ZyDanHao;
            //this.Memo = "原始样品为：" + original.ZyDanHao;

            QC_Sample_Value_Table orignalSample_CheckVals = new QC_Sample_Value_Table();
            orignalSample_CheckVals.LoadDataBySampleMixId(original.Sample_Mix_ID);
            foreach (var item in orignalSample_CheckVals)
            {
                QC_MixCheckItem sv = new QC_MixCheckItem();
                sv.CheckItemNcId = item.CheckItemNcId;
                sv.CheckItemCode = item.CheckItemCode;
                sv.CheckItemName = item.CheckItemName;
                sv.CheckItemUnit = item.CheckItemUnit;
                sv.ActualVal = item.CheckVal;
                this.CheckItems.Add(sv);
            }
        }

        public static QC_Sample_Mix GetByID(int id)
        {
            DbEntityTable<QC_Sample_Mix> ds = new DbEntityTable<QC_Sample_Mix>();
            ds.LoadDataByWhere("Sample_Mix_ID=@Sample_Mix_ID", id);

            if (ds.Count > 0)
                return ds[0];
            else
                return null;
        }

        /// <summary>
        /// 根据制样单号
        /// </summary>
        public static QC_Sample_Mix GetByZydh(string zydh)
        {
            DbEntityTable<QC_Sample_Mix> ds = new DbEntityTable<QC_Sample_Mix>();
            ds.LoadDataByWhere("main.ZyDanHao=@ZyDanHao", zydh);

            if (ds.Count > 0)
                return ds[0];
            else
                return null;
        }

        /// <summary>
        /// 获取抽查样正样主键
        /// </summary>
        public static int InspectSampleParentId(int InpsectSampleMixId)
        {
            object parentId = DbContext.ExecuteScalar("select veh.Sample_Mix_ID from QC_Sample_Veh veh INNER JOIN QC_Sample_Mix mix on mix.NoticeBillId=veh.NoticeBillId and mix.SampleType=" + Convert.ToInt32(SampleType.抽查样) + " Where mix.Sample_Mix_ID=@Sample_Mix_ID", InpsectSampleMixId);
            if (parentId != null)
            {
                return Convert.ToInt32(parentId);
            }
            return 0;
        }

        /// <summary>
        /// 更新抽查样的正样
        /// </summary>
        public static void UpdateInspectMainSample()
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.Append("update sp set sp.mainsamplemixid=mix.Sample_Mix_ID");
            sbSql.Append(" from qc_sample_mix sp ");
            sbSql.Append(" INNER JOIN QC_Sample_Veh veh on sp.NoticeBillId=veh.NoticeBillId");
            sbSql.Append(" INNER JOIN QC_Sample_Mix mix on mix.Sample_Mix_ID=veh.Sample_Mix_ID and mix.SampleType=0");
            sbSql.Append(" where sp.SampleType=1 and (sp.mainsamplemixid is null or sp.mainsamplemixid<=0)");
            DbContext.ExeSql(sbSql.ToString());
        }
        
        /// <summary>
        /// 更新化验审核完成状态
        /// </summary>
        public static void UpdateSampleState()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update t1 set t1.SAMPLESTATE=6");
            sb.Append(" from QC_SAMPLE_MIX t1");
            sb.Append(" where t1.SAMPLESTATE=4 and not exists (");
            sb.Append(" select * from QC_MIXCHECKGROUP t2");
            sb.Append(" inner join QC_SAMPLE_LAB t3 on t3.SAMPLE_LAB_ID=t2.SAMPLE_LAB_ID");
            sb.Append("  where t2.SAMPLE_MIX_ID=t1.SAMPLE_MIX_ID and t3.CheckGroupType='后续检验' and t3.BillType<>'审核通过')");
            DbContext.ExeSql(sb.ToString());
        }
       
        /// <summary>
        /// 更新上传成分
        /// </summary>
        public static void UpdateReportValue()
        {
            //汇总扣水，扣杂
            StringBuilder sqlKou = new StringBuilder();
            sqlKou.Append("update t1 set t1.KouShui=(select SUM(Isnull(t2.KOUSHUI,0)) from QC_SAMPLE_VEH  t2 ");
            sqlKou.Append("left join QC_SAMPLE_MIX t3 on t3.NoticeBillId=t2.NOTICEBILLID and t3.SAMPLETYPE=1 ");
            sqlKou.Append("where t2.SAMPLE_MIX_ID=t1.SAMPLE_MIX_ID and IsNull(t3.IndependentReport,0)=0) ");
            sqlKou.Append(",t1.KouZa=(select SUM(Isnull(t2.KouZa,0)) from QC_SAMPLE_VEH  t2 ");
            sqlKou.Append("left join QC_SAMPLE_MIX t3 on t3.NoticeBillId=t2.NOTICEBILLID and t3.SAMPLETYPE=1");
            sqlKou.Append("where t2.SAMPLE_MIX_ID=t1.SAMPLE_MIX_ID and IsNull(t3.IndependentReport,0)=0) ");
            sqlKou.Append("from QC_SAMPLE_MIX t1 where t1.SampleState=" + (int)SampleState.化验审核完成);
            DbContext.ExeSql(sqlKou.ToString());

            //生成一般报检数据
            string sql = "update QC_MixSampleValue_V set ReportVal=CheckVal where SAMPLETYPE=0 and SAMPLESTATE=" + (int)SampleState.化验审核完成;
            DbContext.ExeSql(sql);

            //生成水分报检数据
            StringBuilder sb = new StringBuilder();
            sb.Append("update t1 set t1.ReportVal =");
            sb.Append(" (select max(cast(CheckVal as float))");
            sb.Append(" from QC_MixSampleValue_V t2 ");
            sb.Append(" where t2.MATPK=t1.MATPK and t2.SUPPLIERCODE=t1.SUPPLIERCODE and t2.CHECKITEMCODE=t1.CHECKITEMCODE and year(t2.Mix_Time)=year(t1.Mix_Time) and month(t2.Mix_Time)=month(t1.Mix_Time)and day(t2.Mix_Time)=day(t1.Mix_Time))");
            sb.Append(" from QC_MixSampleValue_V t1");
            sb.Append(string.Format(" where t1.CHECKITEMCODE='10001' and t1.SAMPLETYPE={0} and t1.SAMPLESTATE={1}", (int)SampleType.普通样, (int)SampleState.化验审核完成)); //10001:水分 SAMPLETYPE=0：普通样 t1.SAMPLESTATE=审核完成
            sb.Append(" and (select max(cast(CheckVal as float))-min(cast(CheckVal as float))");
            sb.Append(" from QC_MixSampleValue_V t3  ");
            sb.Append(" where t3.MATPK=t1.MATPK and t3.SUPPLIERCODE=t1.SUPPLIERCODE and t3.CHECKITEMCODE=t1.CHECKITEMCODE and year(t3.Mix_Time)=year(t1.Mix_Time) and month(t3.Mix_Time)=month(t1.Mix_Time)and day(t3.Mix_Time)=day(t1.Mix_Time))<=2");
            DbContext.ExeSql(sb.ToString());

        }

        public static string ShortStoreCode(string fullCode)
        {
            if (string.IsNullOrEmpty(fullCode)) return "";

            int idx = -1;
            for (int i = 0; i < fullCode.Length; i++)
            {
                if (Char.IsNumber(fullCode[i]))
                {
                    idx = i;
                    break;
                }
            }

            if (idx >= 0)
            {
                StringBuilder sb = new StringBuilder();
                if (idx > 0)
                {
                    sb.Append(fullCode.Substring(0, idx));
                }
                idx += 6;
                if (fullCode.Length >= idx)
                {
                    sb.Append(fullCode.Substring(idx, fullCode.Length - idx));
                }
                return sb.ToString();
            }
            else
                return "";
        }

        public static string FullStoreCode(string shortCode)
        {
            if (string.IsNullOrEmpty(shortCode)) return "";

            int idx = -1;
            for (int i = 0; i < shortCode.Length; i++)
            {
                if (Char.IsNumber(shortCode[i]))
                {
                    idx = i;
                    break;
                }
            }

            if (idx >= 0)
            {
                StringBuilder sb = new StringBuilder();
                if (idx > 0)
                {
                    sb.Append(shortCode.Substring(0, idx));
                }

                string ri = shortCode.Substring(idx, 2);
                int day = int.Parse(ri);
                DateTime rq = DateTime.Today;
                if (day > rq.Day)
                {
                    rq.AddMonths(-1);
                }

                sb.Append(rq.ToString("yyyyMM"));
                if (shortCode.Length >= idx)
                {
                    sb.Append(shortCode.Substring(idx, shortCode.Length - idx));
                }
                return sb.ToString();
            }
            else
                return "";
        }

        public static string GetZyDanHao(string shortCode)
        {
            string dh = "";
            Regex reg = new Regex(@"(?<MatWord>([a-z]|[A-Z])+)(?<BianHao>\d+)(?<YangWord>\w*)");
            Match match = reg.Match(shortCode);
            if (match.Success)
            {
                string MatWord = match.Groups["MatWord"].Value;
                string BianHao = match.Groups["BianHao"].Value;
                string YangWord = match.Groups["YangWord"].Value;
                string xuhao = BianHao.Substring(BianHao.Length - 2, 2);
                //    int nextXuhao = Convert.ToInt32(xuhao) + 1;
                if (BianHao.Length <= 8)
                {
                    string ri = BianHao.Substring(2);
                    int day = int.Parse(ri);
                    DateTime rq = DateTime.Today;
                    if (day > rq.Day)
                    {
                        rq.AddMonths(-1);
                    }
                    dh = MatWord + rq.ToString("yyyyMM") + BianHao;
                }
                else
                    dh = MatWord + BianHao;
            }
            return dh;
           
        }

    }

    public enum SampleType
    {
        /// <summary>
        /// 普通样 Common
        /// </summary>
        普通样=0,
        /// <summary>
        /// 抽查样 Examine
        /// </summary>
        抽查样=1,
        /// <summary>
        /// 校验样(假样) Verification
        /// </summary>
        校验样=2,
        复检样 = 3,
        机器取样 = 7,
        人工取样 = 8,
        破包样=4
    }

    public enum SampleState
    {
        /// <summary>
        ///初始状态 Initial
        /// </summary>
        初始状态 = 0,
        /// <summary>
        /// 开始组批 Batching
        /// </summary>
        开始组批 = 1,
        /// <summary>
        /// 组批完成 Batched
        /// </summary>
        组批完成 = 2,
        /// <summary>
        /// 开始制样 Making
        /// </summary>
        开始制样 = 3,
        /// <summary>
        /// 制样完成 Maked
        /// </summary>
        制样完成 = 4,
        /// <summary>
        /// 检验完成 Checked
        /// </summary>
        检验完成 = 5,
        /// <summary>
        /// 审核完成 Audited
        /// </summary>
        化验审核完成 = 6,

        报检数据生成 = 7,
        质量判定完成 = 8,
        /// <summary>
        /// 报检完成 UpLoaded
        /// </summary>
        NC报检完成 = 9,
        处理完成=10,
        取用=11
    }

    public class QC_Sample_Mix_Table : DbEntityTable<QC_Sample_Mix>
    {
        /// <summary>
        /// 加载抽查样
        /// </summary>
        public void LoadInpsectSamples()
        {
            this.LoadDataByWhere(string.Format("main.SampleState={0} and main.SampleType={1} and main.Sample_Cylx<>'管理抽样'", (int)SampleState.组批完成, (int)SampleType.抽查样));
        }


        public void LoadInpsectSamples(int SampleMixId)
        {
            string whereSql = " main.SampleType=" + Convert.ToInt32(SampleType.抽查样) + " and main.Sample_Cylx<>'管理抽样' and exists (select * from QC_Sample_Veh veh where veh.Sample_Mix_ID=@Sample_Mix_ID and veh.NoticeBillId=main.NoticeBillId)";
            this.LoadDataByWhere(whereSql, SampleMixId);
        }

        /// <summary>
        /// 加载抽查样
        /// </summary>
        public void LoadInpsectSamples(string whereSql)
        {
            this.LoadDataByWhere(whereSql + " and main.Sample_Cylx<>'管理抽样' and main.SampleType=" + Convert.ToInt32(SampleType.抽查样));
        }

        /// <summary>
        /// 加载抽查样
        /// </summary>
        public void LoadManageInpsectSamples()
        {
            this.LoadDataByWhere(string.Format("main.SampleState={0} and main.SampleType={1} and main.Sample_Cylx='管理抽样'", (int)SampleState.组批完成, (int)SampleType.抽查样));
        }

        public void LoadManageInpsectSamples(int SampleMixId)
        {
            string whereSql = " main.SampleType=" + Convert.ToInt32(SampleType.抽查样) + " and main.Sample_Cylx='管理抽样' and exists (select * from QC_Sample_Veh veh where veh.Sample_Mix_ID=@Sample_Mix_ID and veh.NoticeBillId=main.NoticeBillId)";
            this.LoadDataByWhere(whereSql, SampleMixId);
        }

        /// <summary>
        /// 加载抽查样
        /// </summary>
        public void LoadManageInpsectSamples(string whereSql)
        {
            this.LoadDataByWhere(whereSql + " and main.Sample_Cylx='管理抽样' and main.SampleType=" + Convert.ToInt32(SampleType.抽查样));
        }


        /// <summary>
        /// 加载检验样
        /// </summary>
        public void LoadVerifSamples()
        {
            this.LoadDataByWhere(" main.SampleType=" + Convert.ToInt32(SampleType.校验样));
        }

        /// <summary>
        /// 加载检验样
        /// </summary>
        public void LoadVerifSamples(string whereSql)
        {
            this.LoadDataByWhere(whereSql + " and main.SampleType=" + Convert.ToInt32(SampleType.校验样));
        }

        /// <summary>
        /// 加载检验样
        /// </summary>
        public void LoadRecheckSamples()
        {
            this.LoadDataByWhere(string.Format("main.SampleState={0} and main.SampleType={1}", (int)SampleState.组批完成, Convert.ToInt32(SampleType.复检样)));
        }

        /// <summary>
        /// 加载检验样
        /// </summary>
        public void LoadRecheckSamples(string whereSql)
        {
            this.LoadDataByWhere(whereSql + string.Format(" and main.SampleState={0} and main.SampleType={1}", (int)SampleState.组批完成, Convert.ToInt32(SampleType.复检样)));
        }
    }
   
}