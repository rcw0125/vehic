using System;
using System.ComponentModel;
using Zhc.Data;
using System.Data;
using VehIC_WF.Sampling.czl.Class;
using VehIC_WF;

namespace Xg.Lab.Sample
{
    /// <summary>
    /// 汽车样
    /// </summary>  
    //[DbTable("QC_Sample_Mix", "mix", "mix.NoticeBillId=main.NoticeBillId and mix.SampleType=1", JoinType.Left)]
    //[DbTable("BD_INVBASDOC", "mat", "mat.PK_INVBASDOC=main.MatPK", JoinType.Left)]
    [DbTable("QC_NoticeDhdItem_View","dhd","dhd.NcDhdBodyId=main.NcDhdBodyId", JoinType.Left)]
    [DbTable("tb_WorkCenter", "wp", "wp.WCCode=main.WpCode", JoinType.Left)]
    [DbTable("BD_INVBASDOC", "INV", "INV.PK_INVBASDOC=main.MatPK", JoinType.Left)]
    [DbTable("BD_CUBASDOC", "CU", "CU.CUSTCODE=main.SupplierCode", JoinType.Left)]
    [DbTable("QC_Sample_Veh", "main")]
    public partial class QC_Sample_Veh : DbEntity
    {
        private int _Sample_Veh_ID;
        /// <summary>
        /// 样品主键
        /// </summary>
        [DbTableColumn(IsPrimaryKey = true, AutoIncrement = true)]
        [DisplayName("样品主键")]
        public int Sample_Veh_ID
        {
            get { return _Sample_Veh_ID; }
            set
            {
                if (_Sample_Veh_ID != value)
                {
                    _Sample_Veh_ID = value;
                    RaisePropertyChanged("Sample_Veh_ID", true);
                    RaisePropertyChanged("StoreCode");
                }
            }
        }
        #region zptime  组批时间
        private string _Ori_zptime;
        private string _zptime;

        /// <summary>
        /// 物料类型
        /// </summary> 
        [DisplayName("组批时间")]
        public string zptime
        {
            get { return _zptime; }
            set
            {
                if (_zptime != value)
                {
                    if (IsIniting) _Ori_zptime = value;
                    _zptime = value;
                    RaisePropertyChanged("zptime", true);
                }
            }
        }
        #endregion
        #region zpdh  组批单号
        private string _Ori_zpdh;
        private string _zpdh;

        /// <summary>
        /// 物料类型
        /// </summary> 
        [DisplayName("组批单号")]
        public string zpdh
        {
            get { return _zpdh; }
            set
            {
                if (_zpdh != value)
                {
                    if (IsIniting) _Ori_zpdh = value;
                    _zpdh = value;
                    RaisePropertyChanged("zpdh", true);
                }
            }
        }
        #endregion
        #region rwdtime  任务单时间
        private string _Ori_rwdtime;
        private string _rwdtime;

        /// <summary>
        /// 物料类型
        /// </summary> 
        [DisplayName("任务单时间")]
        public string rwdtime
        {
            get { return _rwdtime; }
            set
            {
                if (_rwdtime != value)
                {
                    if (IsIniting) _Ori_rwdtime = value;
                    _rwdtime = value;
                    RaisePropertyChanged("rwdtime", true);
                }
            }
        }
        #endregion
        #region rwdh  任务单号
        private string _Ori_rwdh;
        private string _rwdh;

        /// <summary>
        /// 物料类型
        /// </summary> 
        [DisplayName("任务单号")]
        public string rwdh
        {
            get { return _rwdh; }
            set
            {
                if (_rwdh != value)
                {
                    if (IsIniting) _Ori_rwdh = value;
                    _rwdh = value;
                    RaisePropertyChanged("rwdh", true);
                }
            }
        }
        #endregion
        #region begintime  进门时间
        private string _Ori_begintime;
        private string _begintime;

        /// <summary>
        /// 进门时间
        /// </summary> 
        [DisplayName("进门时间")]
        public string begintime
        {
            get { return _begintime; }
            set
            {
                if (_begintime != value)
                {
                    if (IsIniting) _Ori_begintime = value;
                    _begintime = value;
                    RaisePropertyChanged("begintime", true);
                }
            }
        }
        #endregion
        #region WLLX  物料类型
        private string _Ori_WLLX;
        private string _WLLX;

        /// <summary>
        /// 物料类型
        /// </summary> 
        [DisplayName("物料类型")]
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
                if (IsIniting) _Ori_WpCode = value;
                if (_WpCode != value)
                {
                    _WpCode = value;
                    RaisePropertyChanged("WpCode", true);
                }
            }
        }
        #endregion

        #region WpName  作业点名称
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
        private string _SupplierName = "";

        /// <summary>
        /// 供应商名称
        /// </summary> 
        [DisplayName("供应商名称")]
        [DbTableColumn("CU.CUSTSHORTNAME")]
        public string SupplierName
        {
            get { return _SupplierName; }
            set
            {
                if (_SupplierName != value)
                {
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

        private string _MatName = "";
        /// <summary>
        /// 物料名称
        /// </summary> 
        [DisplayName("物料名称")]
        [DbTableColumn("INV.INVNAME")]
        public string MatName
        {
            get { return _MatName; }
            set
            {
                if (_MatName != value)
                {
                    _MatName = value;
                    RaisePropertyChanged("MatName");
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

        #region NoticeBillBodyId  作业单表体主键
        private string _Ori_NoticeBillBodyId = "";
        private string _NoticeBillBodyId = "";

        /// <summary>
        /// 作业单表体主键
        /// </summary> 
        [DisplayName("作业单表体主键")]
        public string NoticeBillBodyId
        {
            get { return _NoticeBillBodyId; }
            set
            {
                if (_NoticeBillBodyId != value)
                {
                    if (IsIniting) _Ori_NoticeBillBodyId = value;
                    _NoticeBillBodyId = value;
                    RaisePropertyChanged("NoticeBillBodyId", true);
                }
            }
        }
        #endregion


        #region NcDhdHeadNo  NC到货表头单号
        private string _Ori_NcDhdHeadNo = "";
        private string _NcDhdHeadNo = "";

        /// <summary>
        /// NC到货表头单号
        /// </summary> 
        [DisplayName("NC到货表头单号")]
        public string NcDhdHeadNo
        {
            get { return _NcDhdHeadNo; }
            set
            {
                if (_NcDhdHeadNo != value)
                {
                    if (IsIniting) _Ori_NcDhdHeadNo = value;
                    _NcDhdHeadNo = value;
                    RaisePropertyChanged("NcDhdHeadNo", true);
                }
            }
        }
        #endregion


        #region NcDhdBodyId  NC到货表体主键
        private string _Ori_NcDhdBodyId = "";
        private string _NcDhdBodyId = "";

        /// <summary>
        /// NC到货表体主键
        /// </summary> 
        [DisplayName("NC到货表体主键")]
        public string NcDhdBodyId
        {
            get { return _NcDhdBodyId; }
            set
            {
                if (_NcDhdBodyId != value)
                {
                    if (IsIniting) _Ori_NcDhdBodyId = value;
                    _NcDhdBodyId = value;
                    RaisePropertyChanged("NcDhdBodyId", true);
                }
            }
        }
        #endregion

        #region Sample_Mix_ID  混合样主键
        private int _Ori_Sample_Mix_ID = 0;
        private int _Sample_Mix_ID = 0;

        /// <summary>
        /// 混合样主键
        /// </summary> 
        [DisplayName("混合样主键")]
        public int Sample_Mix_ID
        {
            get { return _Sample_Mix_ID; }
            set
            {
                if (_Sample_Mix_ID != value)
                {
                    if (IsIniting) _Ori_Sample_Mix_ID = value;
                    _Sample_Mix_ID = value;
                    RaisePropertyChanged("Sample_Mix_ID", true);
                }
            }
        }
        #endregion


        private DateTime? _Mix_Time = null;
        /// <summary>
        /// 混样时间
        /// </summary>
        [DisplayName("混样时间")]
        public DateTime? Mix_Time
        {
            get { return _Mix_Time; }
            set
            {
                if (_Mix_Time != value)
                {
                    _Mix_Time = value;
                    RaisePropertyChanged("Mix_Time", true);
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
            get { return _KouZa; }
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
            get { return _KouShui; }
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

        #region RukuPch  入库批次号
        private string _Ori_RukuPch = "";
        private string _RukuPch = "";

        /// <summary>
        /// 入库批次号
        /// </summary> 
        [DisplayName("入库批次号")]
        public string RukuPch
        {
            get { return _RukuPch; }
            set
            {
                if (_RukuPch != value)
                {
                    if (IsIniting) _Ori_RukuPch = value;
                    _RukuPch = value;
                    RaisePropertyChanged("RukuPch", true);
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

        #region SAMPLE_TBZD  特别指定
        private bool _SAMPLE_TBZD = false;
        /// <summary>
        // 特别指定
        /// </summary> 
        [DisplayName("特别指定")]
        public bool SAMPLE_TBZD
        {
            get { return _SAMPLE_TBZD; }
            set
            {
                if (_SAMPLE_TBZD != value)
                {
                    if (IsIniting) _SAMPLE_TBZD = value;
                    _SAMPLE_TBZD = value;
                    RaisePropertyChanged("SAMPLE_TBZD", true);
                }
            }
        }
        #endregion
        #region zp  组批
        private bool _zp = false;
        /// <summary>
        // 特别指定
        /// </summary> 
        [DisplayName("组批")]
        public bool zp
        {
            get { return _zp; }
            set
            {
                if (_zp != value)
                {
                    if (IsIniting) _zp = value;
                    _zp = value;
                    RaisePropertyChanged("zp", true);
                }
            }
        }
        #endregion
        #region Sample_JY  是否假样

        private bool _Sample_JY = false;

        /// <summary>
        /// 是否假样
        /// </summary> 
        [DisplayName("是否假样")]
        public bool Sample_JY
        {
            get { return _Sample_JY; }
            set
            {
                if (_Sample_JY != value)
                {
                    _Sample_JY = value;
                    RaisePropertyChanged("Sample_JY", true);
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

        private double? _Sjsl=null;
        [DbTableColumn("dhd.Sjsl")]
        public double? Sjsl
        {
            get { return _Sjsl; }
            set
            {
                if (_Sjsl != value)
                {
                    _Sjsl = value;
                    RaisePropertyChanged("Sjsl", true);
                }
            }
        }
     
        /// <summary>
        /// 用于排序的数量
        /// </summary>
        public double Pxsl
        {
            get
            {
                if (Sjsl.HasValue) 
                    return Sjsl.Value;
                else
                {
                    Random r = new Random();
                    return r.NextDouble() * 100;
                }
            }
        }

        private string _T1;
        /// <summary>
        /// 称重时间
        /// </summary>
       [DbTableColumn("dhd.t1")]
        public string T1
        {
            get { return _T1; }
            set
            {
                if (_T1 != value)
                {
                    _T1 = value;
                    RaisePropertyChanged("T1");
                }
            }
        }

        private string _T2;
        /// <summary>
        /// 回皮时间
        /// </summary>
        [DbTableColumn("dhd.t2")]
        public string T2
        {
            get { return _T2; }
            set
            {
                if (_T2 != value)
                {
                    _T2 = value;
                    RaisePropertyChanged("T2");
                }
            }
        }

        private SampleType _SampleType = SampleType.普通样;
        /// <summary>
        /// 取样类型
        /// </summary>
        public SampleType SampleType
        {
            get { return _SampleType; }
            set
            {
                if (_SampleType != value)
                {
                    _SampleType = value;
                    RaisePropertyChanged("SampleType", true);
                }
            }
        }


        private bool? _IsInspectSample;
        /// <summary>
        /// 是否有抽检样
        /// </summary>
         // [DbTableColumn(ColName = "(case when mix.Sample_Mix_ID is null then 0 else 1 end)", IsCalcColumn = true)]
        [DisplayName("是否有抽检样")]
        public bool? IsInspectSample
        {
            get { return _IsInspectSample; }
            set
            {
                if (_IsInspectSample != value)
                {
                    _IsInspectSample = value;
                    RaisePropertyChanged("IsInspectSample");
                }
            }
        }

        private bool? _IndependentReport;
        /// <summary>
        /// 是否单独报检
        /// </summary>
        //[DbTableColumn(ColName = "IsNull(mix.IndependentReport,0)", IsCalcColumn = true)]
        [DisplayName("是否单独报检")]
        public bool? IndependentReport
        {
            get { return _IndependentReport; }
            set
            {
                if (_IndependentReport != value)
                {
                    _IndependentReport = value;
                    RaisePropertyChanged("IndependentReport");
                }
            }
        }

       
        public bool SaveIcInfo = false;
        public QC_IC_Info IcInfo = null;
       
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

        public QC_Sample_Veh()
        {
            CheckItems.ListChanged += CheckItems_ListChanged;
        }

        void CheckItems_ListChanged(object sender, ListChangedEventArgs e)
        {
            SaveEnable = true;
        }

        protected override void BeforeSave(IDbTransaction trans)
        {
            if (this.DataState == DataRowState.Added)
            {
                string sql = "Select IndependentReport from  QC_Sample_Mix mix where  mix.NoticeBillId='" + this.NoticeBillId + "' and mix.SampleType=1";
                IDbCommand cmd = trans.Connection.CreateCommand();
                cmd.Transaction = trans;
                cmd.CommandText = sql;
                IDataReader dr = cmd.ExecuteReader();
                this.IsInspectSample = false;
                this.IndependentReport = false;
                while (dr.Read())
                {
                    this.IsInspectSample = true;
                    if (dr.GetBoolean(0))
                        this.IndependentReport = true;
                }
                dr.Close();
            }
            base.BeforeSave(trans);
        }

        public void CopyData(QC_Sample_Mix original)
        {
            this.MatPK = original.MatPK;
            this.MatCode = original.MatCode;
            this.MatName = original.MatName;
            this.CheckItems.Empty();

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
        protected override void AfterSave(IDbTransaction trans)
        {

            if (SaveIcInfo && IcInfo != null)
            {
                if (this.DataState == DataRowState.Deleted)
                {
                    QC_IC_Info.UnBinding(this.CardID);
                    this.IcInfo = null;
                }
                IcInfo.SampleId = this.Sample_Veh_ID;
                IcInfo.Save(trans);
            }

            if (this.SaveCheckItems)
            {
                if (this.DataState == DataRowState.Deleted)
                {
                    CheckItems.DeleteBySampleVehId(this.Sample_Mix_ID);
                    CheckItems.Empty();
                }
                else
                {
                    foreach (var item in CheckItems)
                    {
                        item.Sample_Veh_ID = this.Sample_Veh_ID;
                    }
                }
                CheckItems.Save();
            }

            if (this.DataState == DataRowState.Deleted)
            {
                DbContext.ExeSql("Update QC_IC_Info Set SampleId=0 where SampleId=@Sample_Veh_ID and CardType=@CardType", this.Sample_Veh_ID, QC_IC_Info.CardUseType_Veh);
            }

            if (this.DataState == DataRowState.Modified)
            {
                if (this._Ori_KouShui != this._KouShui || this._Ori_KouZa != this._KouZa)
                {
                    QC_Log log = new QC_Log();
                    log.BillId = this.Sample_Veh_ID.ToString();
                    log.OperateType = "扣水扣杂修改";
                    log.OperateContent = string.Format("扣水原值:{0},扣水新值:{1},扣杂原值:{2},扣杂新值:{3}", this._Ori_KouShui, this._KouShui, _Ori_KouZa, _KouZa);
                    log.OperateUser = LocalInfo.Current.user.ID;
                    log.OperateTime = DateTime.Now;
                    log.Save();
                }
            }
            base.AfterSave(trans);
        }
    }

    public class QC_Sample_Veh_Table : DbEntityTable<QC_Sample_Veh>
    {
        /// <summary>
        /// 加载非独立报检的数据
        /// </summary>
        /// <param name="SampleMixId"></param>
        public void LoadDataNonIndependentReport(int SampleMixId)
        {
            // this.LoadDataByWhere("Sample_Mix_ID=@Sample_Mix_ID and Not exists (select Sample_Mix_Id from QC_Sample_Mix where  NoticeBillId=NoticeBillId)"
        }

        public void LoadDataBySampleMixId(int SampleMixId)
        {
            LoadDataByWhere("main.Sample_Mix_ID=@Sample_Mix_ID",SampleMixId);
        }

        public void LoadDataByNoticeBillId(string noticeBillId)
        {
            LoadDataByWhere("main.NoticeBillId=@NoticeBillId", noticeBillId);
        }

        /// <summary>
        /// 加载未组批的校验样
        /// </summary>
        public void LoadVerifSamples()
        {
            LoadDataByWhere(string.Format("main.Sample_Mix_ID=0 and main.SampleType={0}" ,(int)SampleType.校验样));
        }
    }

}