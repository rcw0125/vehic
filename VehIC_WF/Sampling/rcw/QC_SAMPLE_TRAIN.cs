using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xg.Lab.Sample;
using Zhc.Data;

namespace VehIC_WF.Sampling.rcw
{
    [DbTable("QC_Sample_Train")]
    public class QC_Sample_Train : DbEntity
    {
        private string _Sample_Veh_ID;
        /// <summary>
        /// 样品主键
        /// </summary>
        [DbTableColumn(IsPrimaryKey = true)]
        [DisplayName("样品主键")]
        public string Sample_Veh_ID
        {
            get { return _Sample_Veh_ID; }
            set
            {
                if (_Sample_Veh_ID != value)
                {
                    _Sample_Veh_ID = value;
                    RaisePropertyChanged("Sample_Veh_ID", true);
                  
                }
            }
        }




        #region FAZHAN  发站    
        private string _FAZHAN;
        /// <summary>
        /// 发站
        /// </summary> 
        [DisplayName("发站")]
        public string FAZHAN
        {
            get { return _FAZHAN; }
            set
            {
                if (_FAZHAN != value)
                {
                    _FAZHAN = value;
                    RaisePropertyChanged("FAZHAN", true);
                }
            }
        }
        #endregion

        #region WLMC  物料名称    
        private string _WLMC;
        /// <summary>
        /// 发站
        /// </summary> 
        [DisplayName("物料名称")]
        public string WLMC
        {
            get { return _WLMC; }
            set
            {
                if (_WLMC != value)
                {
                    _WLMC = value;
                    RaisePropertyChanged("WLMC", true);
                }
            }
        }
        #endregion


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
        /// 计毛时间
        /// </summary> 
        [DisplayName("计毛时间")]
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
        [DisplayName("车厢号")]
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
        [DisplayName("车皮号")]
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
        [DisplayName("勾选")]
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
                    _SampleState = value;
                    RaisePropertyChanged();
                }
            }
        }
        #endregion


    }
}
