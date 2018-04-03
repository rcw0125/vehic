using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xg.Lab.Sample.View;
using Zhc.Data;

namespace Xg.Lab.Sample
{
    /// <summary>
    /// 物料
    /// </summary>
    [DbTable("QC_Material", "main")]
    [DbTable("BD_INVBASDOC", "inv", "inv.PK_INVBASDOC=main.MatNcId", JoinType.Right)]
    public class QC_Material : DbEntity
    {
        private string _MatNcId;
        /// <summary>
        /// 物料NC主键
        /// </summary>
        [DbTableColumn(IsPrimaryKey = true)]
        public string MatNcId
        {
            get { return _MatNcId; }
            set
            {
                if (_MatNcId != value)
                {
                    _MatNcId = value;
                    RaisePropertyChanged("MatNcId", true);
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
        private string _MatCode;
        /// <summary>
        /// 物料编码
        /// </summary>
        [DbTableColumn(ColName = "inv.INVCODE", SortDirection = SortDirection.Ascending, SortOrder = 1)]
        public string MatCode
        {
            get { return _MatCode; }
            set
            {
                if (_MatCode != value)
                {
                    _MatCode = value;
                    RaisePropertyChanged("MatCode", true);
                }
            }
        }

        private string _MatName;
        /// <summary>
        /// 物料名称
        /// </summary>
        [DbTableColumn("inv.INVNAME")]
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

        private string _CheckStandardNcId;
        /// <summary>
        /// 检化验标准ID
        /// </summary>
        public string CheckStandardNcId
        {
            get { return _CheckStandardNcId; }
            set
            {
                if (_CheckStandardNcId != value)
                {
                    _CheckStandardNcId = value;
                    RaisePropertyChanged("CheckStandardCode", true);
                }
            }
        }

        private string _QualityLevelId;
        /// <summary>
        /// 默认质量等级
        /// </summary>
        public string QualityLevelId
        {
            get { return _QualityLevelId; }
            set
            {
                if (_QualityLevelId != value)
                {
                    _QualityLevelId = value;
                    RaisePropertyChanged("QualityLevelId", true);
                }
            }
        }

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
                }
            }
        }
        #endregion

        #region BatchNum  批次混样数量
        private int _Ori_BatchNum = 1;
        private int _BatchNum = 1;

        /// <summary>
        /// 批次混样数量
        /// </summary> 
        [DisplayName("批次混样数量")]
        public int BatchNum
        {
            get { return _BatchNum; }
            set
            {
                if (_BatchNum != value)
                {
                    if (value <= 0)
                        _BatchNum = 1;
                    else
                        _BatchNum = value;

                    RaisePropertyChanged("BatchNum", true);
                }
            }
        }
        #endregion

        #region BatchOneNum  一桶一车数量
        private int _Ori_BatchOneNum = 0;
        private int _BatchOneNum = 0;

        /// <summary>
        /// 一桶一车数量
        /// </summary> 
        [DisplayName("一桶一车数量")]
        public int BatchOneNum
        {
            get { return _BatchOneNum; }
            set
            {
                if (_BatchOneNum != value)
                {
                    if (IsIniting) _Ori_BatchOneNum = value;
                    _BatchOneNum = value;
                    RaisePropertyChanged("BatchOneNum", true);
                }
            }
        }
        #endregion

        #region ClassWord  分类编码
        private string _Ori_ClassWord = "";
        private string _ClassWord = "";

        /// <summary>
        /// 分类编码
        /// </summary> 
        [DisplayName("分类编码")]
        public string ClassWord
        {
            get { return _ClassWord; }
            set
            {
                if (_ClassWord != value)
                {
                    if (IsIniting) _Ori_ClassWord = value;
                    _ClassWord = value;
                    RaisePropertyChanged("ClassWord", true);
                }
            }
        }
        #endregion

        #region InUse  是否启用
        private bool _Ori_InUse = false;
        private bool _InUse = false;

        /// <summary>
        /// 是否启用
        /// </summary> 
        [DisplayName("是否启用")]
        public bool InUse
        {
            get { return _InUse; }
            set
            {
                if (_InUse != value)
                {
                    if (IsIniting) _Ori_InUse = value;
                    _InUse = value;
                    RaisePropertyChanged("InUse", true);
                }
            }
        }
        #endregion
        #region sfqyj  是否取样机
        private bool _Ori_sfqyj = false;
        private bool _sfqyj = false;

        /// <summary>
        /// 是否取样机
        /// </summary> 
        [DisplayName("是否取样机")]
        public bool sfqyj
        {
            get { return _sfqyj; }
            set
            {
                if (_sfqyj != value)
                {
                    if (IsIniting) _Ori_sfqyj = value;
                    _sfqyj = value;
                    RaisePropertyChanged("sfqyj", true);
                }
            }
        }
        #endregion
        #region 组批规则
        public bool SaveComplexMixRule = false;

        private DbEntityTable<QC_MixRule> complexMixRule = new DbEntityTable<QC_MixRule>();
        /// <summary>
        /// 复杂混样逻辑
        /// </summary>
        public DbEntityTable<QC_MixRule> ComplexMixRule
        {
            get { return complexMixRule; }
        }
        #endregion

        #region 所有检验项目
        public bool SaveAllCheckItem = false;

        private DbEntityTable<QC_MatAllCheckItem> allCheckItem = new DbEntityTable<QC_MatAllCheckItem>();
        /// <summary>
        /// 所有检验项目
        /// </summary>
        public DbEntityTable<QC_MatAllCheckItem> AllCheckItem
        {
            get { return allCheckItem; }
        }
        #endregion

        #region 制样组批规则
        public bool SaveComplexLabRule = false;

        private DbEntityTable<QC_LabRule> complexLabRule = new DbEntityTable<QC_LabRule>();
        /// <summary>
        /// 制样组批规则
        /// </summary>
        public DbEntityTable<QC_LabRule> ComplexLabRule
        {
            get { return complexLabRule; }
        }
        #endregion

        #region 质量判定规则
        public bool SaveMatQualityRule = false;

        private DbEntityTable<QC_QualityRule> matQualityRule = new DbEntityTable<QC_QualityRule>();

        /// <summary>
        /// 质量判定规则
        /// </summary>
        public DbEntityTable<QC_QualityRule> MatQualityRule
        {
            get { return matQualityRule; }
        }
        #endregion

        #region 检验分组
        public bool SaveMatCheckGroup = false;

        private QC_MatCheckGroupTable matCheckGroup = new QC_MatCheckGroupTable();
        /// <summary>
        /// 检验分组
        /// </summary>
        public QC_MatCheckGroupTable MatCheckGroup
        {
            get { return matCheckGroup; }
        }
        #endregion

        #region 质量等级
        private DbEntityTable<QC_MatQualityLevel_View> matQualityLevelView = new DbEntityTable<QC_MatQualityLevel_View>();
        /// <summary>
        /// 质量等级
        /// </summary>
        public DbEntityTable<QC_MatQualityLevel_View> MatQualityLevelView
        {
            get { return matQualityLevelView; }
        }
        #endregion

        #region 调整水分
        public bool SaveChgWater = false;

        private DbEntityTable<QC_ChgWater> chgWaters = new DbEntityTable<QC_ChgWater>();
        /// <summary>
        /// 制样组批规则
        /// </summary>
        public DbEntityTable<QC_ChgWater> ChgWaters
        {
            get { return chgWaters; }
        }
        #endregion

        public QC_Material()
        {
            AllCheckItem.ListChanged += complexMixRule_ListChanged;
            complexMixRule.ListChanged += complexMixRule_ListChanged;
            matQualityRule.ListChanged += complexMixRule_ListChanged;
            complexLabRule.ListChanged += complexMixRule_ListChanged;
            chgWaters.ListChanged += complexMixRule_ListChanged;
        }

        void complexMixRule_ListChanged(object sender, ListChangedEventArgs e)
        {
            this.SaveEnable = true;
        }

        protected override void AfterSave(System.Data.IDbTransaction trans)
        {
            if (SaveAllCheckItem)
            {
                foreach (var item in AllCheckItem)
                {
                    item.MatNcId = this.MatNcId;
                }
                AllCheckItem.Save();
            }


            if (SaveMatCheckGroup)
            {
                foreach (var item in MatCheckGroup)
                {
                    item.MatNcId = this.MatNcId;
                }
                MatCheckGroup.Save();
            }

            if (SaveComplexMixRule)
            {
                foreach (var item in ComplexMixRule)
                {
                    item.MatNcId = this.MatNcId;
                }
                ComplexMixRule.Save();
            }

            if (SaveComplexLabRule)
            {
                foreach (var item in ComplexLabRule)
                {
                    item.MatNcId = this.MatNcId;
                }
                ComplexLabRule.Save();
            }

            if (SaveMatQualityRule)
            {
                foreach (var item in MatQualityRule)
                {
                    item.MatNcId = this.MatNcId;
                }
                MatQualityRule.Save();
            }

            if (SaveChgWater)
            {
                foreach (var item in ChgWaters)
                {
                    item.MatNcId = this.MatNcId;
                }
                ChgWaters.Save();
            }

            base.AfterSave(trans);
        }


        public static QC_Material GetByID(string id)
        {
            DbEntityTable<QC_Material> ds = new DbEntityTable<QC_Material>();
            ds.LoadDataByWhere("MatNcId=@MatNcId", id);

            if (ds.Count > 0)
                return ds[0];
            else
                return null;
        }

        public static QC_Material GetByCode(string matCode)
        {
            DbEntityTable<QC_Material> ds = new DbEntityTable<QC_Material>();
            ds.LoadDataByWhere("inv.INVCODE=@MatCode", matCode);

            if (ds.Count > 0)
                return ds[0];
            else
                return null;
        }

    }
}
