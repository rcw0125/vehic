using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using VehIC_WF;
using VehIC_WF.Sampling.czl.Class;
using Xg.Lab.Sample;
using Zhc.Data;

namespace Xg.Lab.Sample
{
    /// <summary>
    /// 化验样
    /// </summary>
    [DbTable("QC_Sample_mix", "mix", "mix.Sample_mix_id=main.Sample_mix_id", JoinType.Left)]
    [DbTable("BD_INVBASDOC", "mat", "mat.PK_INVBASDOC=mix.MatPK", JoinType.Left)]
 
    [DbTable(TableName="QC_Sample_Lab",TableAlias = "main")]
    public class QC_Sample_Lab_Jy : DbEntity
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
        [DbTableColumn("mat.invname")]
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


        #region JyCode  检验单号
        private string _JyCode = "";

        /// <summary>
        /// 检验单号
        /// </summary> 
        [DisplayName("检验单号")]
        public string JyCode
        {
            get { return _JyCode; }
            set
            {
                if (_JyCode != value)
                {
                    _JyCode = value;
                    RaisePropertyChanged("JyCode", true);
                }
            }
        }
        #endregion


        #region JyUser 收样人
        private string _JyUser="";

        public string JyUser
        {
            get { return _JyUser; }
            set
            {
                if (_JyUser != value)
                {
                    _JyUser = value;
                    RaisePropertyChanged("JyUser", true);
                }
            }
        }
        #endregion 

        #region JyTime 收样时间
        private DateTime? _JyTime = null;

        public DateTime? JyTime
        {
            get { return _JyTime; }
            set
            {
                if (_JyTime != value)
                {
                    _JyTime = value;
                    RaisePropertyChanged("JyTime", true);
                }
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

        public QC_Sample_Lab_Jy()
        {
            CheckVals.ListChanged += CheckVals_ListChanged;
        }

        void CheckVals_ListChanged(object sender, ListChangedEventArgs e)
        {
            SaveEnable = true;
        }

        protected override void AfterSave(System.Data.IDbTransaction trans)
        {
            if (this.SaveCheckVals)
            {
                if (this.DataState == DataRowState.Deleted)
                {
                    // DbContext.ExeSql("Delete From QC_Sample_Value where Sample_Mix_ID=@Sample_Mix_ID AND Sample_LAB_ID>0", this.Sample_Mix_ID);
                }
                else
                {
                    foreach (var item in CheckVals)
                    {
                        item.Sample_Lab_ID = this.Sample_Lab_ID;
                    }
                    CheckVals.Save(trans);
                }
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
        }

        public static QC_Sample_Lab_Jy GetById(int id)
        {
            DbEntityTable<QC_Sample_Lab_Jy> table = new DbEntityTable<QC_Sample_Lab_Jy>();
            table.LoadInfo = "CheckVals";
            table.LoadDataByWhere("main.Sample_Lab_ID = @Sample_Lab_ID", id);
            if (table.Count == 1)
            {
                return table[0];
            }
            else if (table.Count > 1)
            {
                throw new Exception(string.Format("主键不唯一：{0}", id));
            }
            else
            {
                return null;
            }
        }

    }
}
