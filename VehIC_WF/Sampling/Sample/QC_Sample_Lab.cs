using System;
using System.ComponentModel;
using System.Data;
using System.Text;
using VehIC_WF;
using VehIC_WF.Sampling.czl.Class;
using Zhc.Data;

namespace Xg.Lab.Sample
{
    /// <summary>
    /// 化验样
    /// </summary>
    [DbTable("QC_Sample_mix", "mix", "mix.Sample_mix_id=main.Sample_mix_id", JoinType.Left)]
    [DbTable("BD_CUBASDOC", "cust", "cust.CUSTCODE=mix.SupplierCode", JoinType.Left)]
    [DbTable(TableAlias = "main")]
    public class QC_Sample_Lab : DbEntity
    {

        private int _Sample_Lab_ID;
        [DbTableColumn(IsPrimaryKey = true, AutoIncrement = true)]
        public int Sample_Lab_ID
        {
            get { return _Sample_Lab_ID; }
            set
            {
                if (_Sample_Lab_ID != value)
                {
                    _Sample_Lab_ID = value;
                    RaisePropertyChanged("Sample_Lab_ID", true);
                    RaisePropertyChanged("StoreCode");
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
        #region StoreCode  样品单号
        private string _Ori_StoreCode = "";
        private string _StoreCode = "";

        /// <summary>
        /// 样品单号
        /// </summary> 
        [DisplayName("样品单号")]
        public string StoreCode
        {
            // get { return Zhc.Util.To32Str(Sample_Mix_ID); }
            get { return _StoreCode; }
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

        [NonTableField]
        public string ShortStoreCode
        {
            get
            {
                return QC_Sample_Mix.ShortStoreCode(StoreCode);
            }
        }

        private string _MatName;
        [DisplayName("物料名称")]
        public string MatName
        {
            get { return _MatName; }
            set
            {
                if (_MatName != value)
                {
                    _MatName = value;
                    RaisePropertyChanged("MatName", true);
                }
            }
        }
        private string _CustName;
        [DisplayName("供应商名称")]
        [DbTableColumn("cust.custname")]
        public string CustName
        {
            get { return _CustName; }
            set
            {
                if (_CustName != value)
                {
                    _CustName = value;
                    RaisePropertyChanged("CustName", true);
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

        private int _TempID;

        public int TempID
        {
            get { return _TempID; }
            set
            {
                if (_TempID != value)
                {

                    _TempID = value;
                    RaisePropertyChanged("TempID", true);
                }
            }
        }

        private string _CardId;

        public string CardId
        {
            get { return _CardId; }
            set
            {
                if (_CardId != value)
                {
                    _CardId = value;
                    RaisePropertyChanged("CardId", true);
                }
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

        private string _CheckGroupCode = "";
        /// <summary>
        /// 样品分类编码
        /// </summary>
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

        private string _CheckGroupName = "";
        /// <summary>
        /// 样品分类名称
        /// </summary>
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

        private string _CheckGroupType = "";
        /// <summary>
        /// 样品分类类型
        /// </summary>
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


        //#region PrintContent  制样要求（打印内容)
        //private string _Ori_PrintContent = "";
        //private string _PrintContent = "";

        ///// <summary>
        ///// 制样要求（打印内容)
        ///// </summary> 
        //[DisplayName("制样要求（打印内容)")]
        //public string PrintContent
        //{
        //    get { return _PrintContent; }
        //    set
        //    {
        //        if (_PrintContent != value)
        //        {
        //            _PrintContent = value;
        //            RaisePropertyChanged("PrintContent", true);
        //        }
        //    }
        //}
        //#endregion

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
                    _WpCode = value;
                    RaisePropertyChanged("WpCode", true);
                }
            }
        }
        #endregion

        #region MakeUser  制样人
        private string _Ori_MakeUser = "";
        private string _MakeUser = "";

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


        /// <summary>
        /// 刷新状态
        /// </summary>
        public void RefreshState()
        {
            foreach (var item in MixCheckGroup)
            {
                item.LabState = this.LabState;
                item.Billtype = this.Billtype;
                item.RefreshState();
            }
        }

        private DbEntityTable<QC_MixCheckGroup> _MixCheckGroup = new DbEntityTable<QC_MixCheckGroup>();

        public DbEntityTable<QC_MixCheckGroup> MixCheckGroup
        {
            get { return _MixCheckGroup; }
            set
            {
                if (_MixCheckGroup != value)
                {
                    _MixCheckGroup = value;
                    RaisePropertyChanged("MixCheckGroup");
                }
            }
        }

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

        public QC_Sample_Lab()
        {
            CheckVals.ListChanged += CheckVals_ListChanged;
        }

        void CheckVals_ListChanged(object sender, ListChangedEventArgs e)
        {
            SaveEnable = true;
        }

        //protected override void BeforeSave(System.Data.IDbTransaction trans)
        //{
        //    if (MixCheckGroup.Count > 0 && CheckGroupName.StartsWith("角质层"))
        //    {
        //        StringBuilder sb = new StringBuilder();
        //        foreach (var item in MixCheckGroup)
        //        {
        //            if (sb.Length > 0)
        //            {
        //                sb.Append("+");
        //            }
        //            sb.Append(item.ShortStoreCode);
        //        }
        //        this.PrintContent = sb.ToString();
        //    }
        //    base.BeforeSave(trans);
        //}

        protected override void AfterSave(System.Data.IDbTransaction trans)
        {
            if (MixCheckGroup.Count > 0)
            {
                foreach (var item in MixCheckGroup)
                {
                    item.Sample_Lab_ID = this.Sample_Lab_ID;
                }
                MixCheckGroup.Save(trans);
            }

            if (this.SaveCheckVals)
            {
                //if (this.DataState == DataRowState.Deleted)
                //{
                //    // DbContext.ExeSql("Delete From QC_Sample_Value where Sample_Mix_ID=@Sample_Mix_ID AND Sample_LAB_ID>0", this.Sample_Mix_ID);
                //}
                //else
                //{
                    foreach (var item in CheckVals)
                    {
                        item.Sample_Lab_ID = this.Sample_Lab_ID;
                    }
                    CheckVals.Save(trans);
                //}
            }

            base.AfterSave(trans);
        }

        public override void AfterLoad(string loadInfo)
        {
            if (loadInfo.Contains("CheckVals"))
            {
                CheckVals.LoadDataByWhere("main.Sample_Lab_Id=@Sample_Lab_Id", this.Sample_Lab_ID);
            }
            base.AfterLoad(loadInfo);
            this.SaveEnable = false;
        }

    }
}