using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using VehIC_WF.Sampling.czl.Class;
using Zhc.Data;

namespace Xg.Lab.Sample
{
    [DbTable("BD_CUBASDOC", "supplier", "supplier.CUSTCODE=main.SupplierCode", JoinType.Left)]
    [DbTable("QC_Material", "mat", "mat.MatNcId=main.MatPK", JoinType.Left)]
    [DbTable("QC_Sample_Mix", "main")]
    public class QC_SampleMix_ZhiYang : DbEntity
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


        public void RefreshState()
        {
            bool wc = true;
            foreach (var item in this.CheckGroups)
            {
                if ((item.CheckGroupType == "立刻检验" || item.CheckGroupType == "后续检验") && item.LabState == "制样")
                {
                    wc = false;
                }
            }
            if (wc)
            {
                SampleState = SampleState.制样完成;
                this.Save();
            }
        }

        public override void AfterLoad(string loadInfo)
        {
            if (loadInfo.Contains("CheckItems"))
            {
                CheckItems.LoadDataByWhere("main.Sample_Mix_ID=@Sample_Mix_ID", this.Sample_Mix_ID);
            }
            if (loadInfo.Contains("CheckGroups"))
            {
                CheckGroups.LoadDataByWhere("main.Sample_Mix_ID=@Sample_Mix_ID", this.Sample_Mix_ID);
                foreach (var item in CheckGroups)
                {
                    item.ZySample = this;
                }
            }
            base.AfterLoad(loadInfo);
        }

        protected override void AfterSave(System.Data.IDbTransaction trans)
        {
            if (SaveCheckGroups)
            {
                foreach (var item in CheckGroups)
                {
                    item.Sample_Mix_ID = this.Sample_Mix_ID;
                }
                CheckGroups.Save();
            }

            if (SaveCheckItems)
            {
                foreach (var item in CheckItems)
                {
                    item.Sample_Mix_ID = this.Sample_Mix_ID;
                }
                CheckItems.Save();
            }

            base.AfterSave(trans);
        }

        public static QC_SampleMix_ZhiYang GetById(int sampleId)
        {
            QC_SampleMix_ZhiYang_Table table = new QC_SampleMix_ZhiYang_Table();
            table.LoadBySampleMixId(sampleId);
            if (table.Count > 0)
                return table[0];
            else
                return null;
        }
    }

    public class QC_SampleMix_ZhiYang_Table : DbEntityTable<QC_SampleMix_ZhiYang>
    {
        private DbEntityTable<QC_Sample_Lab> labTable = new DbEntityTable<QC_Sample_Lab>();

        public DbEntityTable<QC_Sample_Lab> LabTable
        {
            get { return labTable; }
        }


        public void LoadZyAllData(string wpCode)
        {
            //this.LoadInfo = "CheckItems,CheckGroups";
            //this.LoadDataByWhere(string.Format("main.SampleState={0} and (main.SampleType=1 or main.WpCode in (select WPCode from QC_WpRoute where NextWPCode='{1}'))", (int)SampleState.开始制样, wpCode));

            string sqlWhere = "main.SampleState=" + (int)SampleState.开始制样 + " and main.ZyWpCode='" + wpCode + "'";

            this.LoadDataByWhere(sqlWhere);
            LabTable.Empty();
            if (this.Count > 0)
            {
                //StringBuilder sb = new StringBuilder();
                //sb.Append("main.Sample_Mix_ID in (");
                //foreach (var item in this.Items)
                //{
                //    sb.Append(item.Sample_Mix_ID);
                //    sb.Append(",");
                //}
                //sb.Remove(sb.Length - 1, 1);
                //sb.Append(")");

                //QC_MixCheckItem_Table CheckItems = new QC_MixCheckItem_Table();
                //CheckItems.LoadDataByWhere(sb.ToString());


                //foreach (var item in this.Items)
                //{
                //    var subCheckItems = from ck in CheckItems
                //                        where ck.Sample_Mix_ID == item.Sample_Mix_ID
                //                        select ck;

                //    foreach (var subCk in subCheckItems)
                //    {
                //        item.CheckItems.Add(subCk);
                //    }
                //}

                List<int> labIds = new List<int>();
                DbEntityTable<QC_MixCheckGroup> CheckGroups = new DbEntityTable<QC_MixCheckGroup>();
                CheckGroups.LoadDataByWhere(sqlWhere.Replace("main.", "mix."));

                foreach (var item in this.Items)
                {
                    var subCheckGroup = from cg in CheckGroups
                                        where cg.Sample_Mix_ID == item.Sample_Mix_ID
                                        select cg;

                    foreach (var subCg in subCheckGroup)
                    {
                        item.CheckGroups.Add(subCg);
                        subCg.ZySample = item;
                        if (subCg.Sample_Lab_ID > 0 && !labIds.Contains(subCg.Sample_Lab_ID))
                        {
                            labIds.Add(subCg.Sample_Lab_ID);
                        }
                    }
                }

                StringBuilder sbLabSql = new StringBuilder();
                sbLabSql.Append("main.Sample_Lab_ID in (");

                if (labIds.Count != 0)
                {
                    foreach (var labId in labIds)
                    {
                        sbLabSql.Append(labId);
                        sbLabSql.Append(",");
                    }
                    sbLabSql.Remove(sbLabSql.Length - 1, 1);
                    sbLabSql.Append(")");

                    LabTable.LoadDataByWhere(sbLabSql.ToString());


                    foreach (var cg in CheckGroups)
                    {
                        if (cg.Sample_Lab_ID > 0)
                        {
                            cg.SampleLab = LabTable.FirstOrDefault<QC_Sample_Lab>((lb) => lb.Sample_Lab_ID == cg.Sample_Lab_ID);
                            //if (cg.SampleLab != null)
                            //{
                            cg.SampleLab.MixCheckGroup.Add(cg);
                            //}
                        }
                    }
                }
            }
        }

        public void LoadBySampleMixId(int sampleId)
        {
            this.LoadInfo = "CheckItems,CheckGroups";
            this.LoadDataByWhere("main.Sample_Mix_ID=@Sample_Mix_ID", sampleId);
        }
    }
}
