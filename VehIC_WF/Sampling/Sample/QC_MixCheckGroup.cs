using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xg.Lab.Sample;
using Zhc.Data;

namespace VehIC_WF.Sampling.czl.Class
{
    [DbTable("QC_Sample_Mix", "mix", "mix.Sample_Mix_ID=main.Sample_Mix_ID")]
    [DbTable(TableAlias = "main")]
    public class QC_MixCheckGroup : DbEntity
    {
        private int _Id;
        [DisplayName("主键")]
        [DbTableColumn(IsPrimaryKey = true, AutoIncrement = true)]
        public int Id
        {
            get { return _Id; }
            set
            {
                if (_Id != value)
                {
                    _Id = value;
                    RaisePropertyChanged("Id", true);
                }
            }
        }

        private string _CheckGroupCode;
        [DbTableColumn(SortDirection = SortDirection.Ascending, SortOrder = 2)]
        public string CheckGroupCode
        {
            get { return _CheckGroupCode; }
            set
            {
                if (_CheckGroupCode != value)
                {
                    _CheckGroupCode = value;
                    RaisePropertyChanged("CheckGroupCode", true);
                }
            }
        }

        private string _CheckGroupName;

        public string CheckGroupName
        {
            get { return _CheckGroupName; }
            set
            {
                if (_CheckGroupName != value)
                {
                    _CheckGroupName = value;
                    RaisePropertyChanged("CheckGroupName", true);
                }
            }
        }

        private string _CheckGroupType;

        public string CheckGroupType
        {
            get { return _CheckGroupType; }
            set
            {
                if (_CheckGroupType != value)
                {
                    _CheckGroupType = value;
                    RaisePropertyChanged("CheckGroupType", true);
                }
            }
        }

        private string _StoreCode = "";

        public string StoreCode
        {
            get { return _StoreCode; }
            set
            {
                if (_StoreCode != value)
                {
                    _StoreCode = value;
                    RaisePropertyChanged("StoreCode", true);
                }
            }
        }

        [NonTableField]
        public string ShortStoreCode
        {
            get
            {
                return QC_Sample_Mix.ShortStoreCode(StoreCode);
            }
        }

        private int _Sample_Mix_ID;

        public int Sample_Mix_ID
        {
            get { return _Sample_Mix_ID; }
            set
            {
                if (_Sample_Mix_ID != value)
                {
                    _Sample_Mix_ID = value;
                    RaisePropertyChanged("Sample_Mix_ID", true);
                }
            }
        }
      
        private int _Sample_Lab_ID;

        public int Sample_Lab_ID
        {
            get { return _Sample_Lab_ID; }
            set
            {
                if (_Sample_Lab_ID != value)
                {
                    _Sample_Lab_ID = value;
                    RaisePropertyChanged("Sample_Lab_ID", true);
                }
            }
        }

        private string _ZupiHao="";
        /// <summary>
        /// 角质层组批号
        /// </summary>
        public string ZupiHao
        {
            get { return _ZupiHao; }
            set
            {
                if (_ZupiHao != value)
                {
                    _ZupiHao = value;
                    RaisePropertyChanged("ZupiHao", true);
                }
            }
        }

        [RefProperty("ZupiHao")]
        [NonTableField]
        public string ShortZupiHao
        {
            get
            {
                return QC_Sample_Mix.ShortStoreCode(ZupiHao);
            }
            set { }
        }

        #region MatPK  物料主键
        private string _MatPK = "";

        /// <summary>
        /// 物料主键
        /// </summary> 
        [DisplayName("物料主键")]
        [DbTableColumn("mix.MatPK")]
        public string MatPK
        {
            get { return _MatPK; }
            set
            {
                if (_MatPK != value)
                {
                    _MatPK = value;
                    RaisePropertyChanged("MatPK");
                }
            }
        }
        #endregion

        #region SupplierCode  供应商编码
        private string _SupplierCode = "";

        /// <summary>
        /// 供应商编码
        /// </summary> 
        [DbTableColumn("mix.SupplierCode")]
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
       
        #region MakeUser  制样人
        private string _Ori_MakeUser = LocalInfo.Current.user.ID;
        private string _MakeUser = LocalInfo.Current.user.ID;

        /// <summary>
        /// 制样人
        /// </summary> 
        [DisplayName("制样人")]
        public string MakeUser
        {
            get { return _MakeUser; }
            set
            {
                if (_MakeUser != value)
                {
                    if (IsIniting) _Ori_MakeUser = value;
                    _MakeUser = value;
                    RaisePropertyChanged("MakeUser", true);
                }
            }
        }
        #endregion

        private DateTime? _MakeTime;

        public DateTime? MakeTime
        {
            get { return _MakeTime; }
            set
            {
                if (_MakeTime != value)
                {
                    _MakeTime = value;
                    RaisePropertyChanged("MakeTime", true);
                }
            }
        }

        private string _Billtype;

        public string Billtype
        {
            get { return _Billtype; }
            set
            {
                if (_Billtype != value)
                {
                    _Billtype = value;
                    RaisePropertyChanged("Billtype", true);
                }
            }
        }

        private string _ShortWord = "";

        /// <summary>
        /// 缩写标识
        /// </summary> 
        [DisplayName("缩写标识")]
        public string CkgShortWord
        {
            get { return _ShortWord; }
            set
            {
                if (_ShortWord != value)
                {
                    _ShortWord = value;
                    RaisePropertyChanged("ShortWord", true);
                }
            }
        }

        private bool _Sample_TBZD;
        [DbTableColumn("mix.Sample_TBZD")]
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

        #region LabState  检验状态
        private string _Ori_LabState = "制样";
        private string _LabState = "制样";

        /// <summary>
        /// 检验状态
        /// </summary> 
        [DisplayName("检验状态")]
        public string LabState
        {
            get { return _LabState; }
            set
            {
                if (_LabState != value)
                {
                    if (value == "")
                        _LabState = "制样";
                    else
                        _LabState = value;
                    RaisePropertyChanged("LabState", true);
                }
            }
        }
        #endregion

        private int _VisIdx = 0;

        [DbTableColumn(SortDirection = SortDirection.Ascending, SortOrder = 1)]
        public int VisIdx
        {
            get { return _VisIdx; }
            set
            {
                if (_VisIdx != value)
                {
                    _VisIdx = value;
                    RaisePropertyChanged("VisIdx", true);
                }
            }
        }

        private QC_SampleMix_ZhiYang _ZySample = null;

        public QC_SampleMix_ZhiYang ZySample
        {
            get { return _ZySample; }
            set { _ZySample = value; }
        }


        private QC_Sample_Lab _SampleLab = null;

        public QC_Sample_Lab SampleLab
        {
            get { return _SampleLab; }
            set { _SampleLab = value; }
        }

        
        private DbEntityTable<QC_MixCheckItem> _MixCheckItem = new DbEntityTable<QC_MixCheckItem>();

        public DbEntityTable<QC_MixCheckItem> MixCheckItem
        {
            get { return _MixCheckItem; }
            set
            {
                if (_MixCheckItem != value)
                {
                    _MixCheckItem = value;
                    RaisePropertyChanged("MixCheckItem");
                }
            }
        }

        protected override void AfterSave(System.Data.IDbTransaction trans)
        {
            if (MixCheckItem.Count > 0)
            {
                foreach (var item in MixCheckItem)
                {
                    item.CheckGroupId = this.Id;
                }
                MixCheckItem.Save(trans);
            }
            base.AfterSave(trans);
        }

        /// <summary>
        /// 刷新状态
        /// </summary>
        public void RefreshState()
        {

            if (ZySample != null)
            {
                ZySample.RefreshState();
            }
        }
    }
}
