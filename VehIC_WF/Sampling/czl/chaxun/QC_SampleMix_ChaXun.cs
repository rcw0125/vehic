using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using VehIC_WF.Sampling.czl.Class;
using Xg.Lab.Sample;
using Zhc.Data;

namespace VehIC_WF.Sampling.czl.chaxun
{
    [DbTable("QC_Material", "mat", "mat.MatNcId=main.MatPK", JoinType.Left)]
    [DbTable("QC_Sample_Mix", "main")]
    class QC_SampleMix_ChaXun:DbEntity
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

        #region ZyDanHao  制样单号
        private string _Ori_ZyDanHao = "";
        private string _ZyDanHao = "";

        /// <summary>
        /// 制样单号
        /// </summary> 
        [DbTableColumn(SortDirection = SortDirection.Ascending)]
        [DisplayName("制样全单号")]
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

        [RefProperty("ZyDanHao")]
        [NonTableField]
        [DisplayName("制样单号")]
        public string ZyShortDanHao
        {
            get
            {
                return QC_Sample_Mix.ShortStoreCode(ZyDanHao);
            }
            set
            {

            }
        }
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

        private string _ZyWpCode = "";
        [DisplayName("制样作业点")]
        public string ZyWpCode
        {
            get { return _ZyWpCode; }
            set
            {
                if (_ZyWpCode != value)
                {
                    _ZyWpCode = value;
                    RaisePropertyChanged("ZyWpCode", true);
                }
            }
        }

        private string _ZyRecvUser = "";
        [DisplayName("接收人")]
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
        [DisplayName("接收时间")]
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


        [DisplayName("角质层批号")]
        [NonTableField]
        public string ZyJzZuPiHao
        {
            get
            {
                string _ZyJzZuPiHao = "";
                foreach (var item in CheckGroups)
                {
                    if (!string.IsNullOrEmpty(item.ShortZupiHao))
                    {
                        _ZyJzZuPiHao = item.ShortZupiHao;
                        _ZyJzZuPiHao = _ZyJzZuPiHao.Substring(0, _ZyJzZuPiHao.Length - 1);
                        break;
                    }
                }
                return _ZyJzZuPiHao;
            }
            set
            {

            }
        }


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

        #region 检验值
        public bool SaveSampleLabs = false;
        private DbEntityTable<QC_MixCheckGroup> _SampleLabs = new DbEntityTable<QC_MixCheckGroup>();
        /// <summary>
        /// 检验值
        /// </summary>
        public DbEntityTable<QC_MixCheckGroup> SampleLabs
        {
            get { return _SampleLabs; }
        }
        #endregion

        private string _MatClassWord = "";
        [DbTableColumn("mat.ClassWord")]
        public string MatClassWord
        {
            get { return _MatClassWord; }
            set
            {
                if (_MatClassWord != value)
                {
                    _MatClassWord = value;
                    RaisePropertyChanged("MatClassWord");
                }
            }
        }

        /// <summary>
        /// 样品类型
        /// </summary>
        [NonTableField]
        public string SampleDesc
        {
            get
            {
                if (SampleType == SampleType.抽查样)
                {
                    return "抽查样";
                }
                else
                    return "";
            }
            set
            {

            }
        }



        #region 检验项目
        public bool SaveCheckItems = true;
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

        #region 检验分组
        public bool SaveCheckGroups = true;
        private DbEntityTable<QC_MixCheckGroup> _CheckGroups = new DbEntityTable<QC_MixCheckGroup>();
        /// <summary>
        /// 检验分组
        /// </summary>
        public DbEntityTable<QC_MixCheckGroup> CheckGroups
        {
            get
            {
                return _CheckGroups;
            }
        }
        #endregion


















    }
}
