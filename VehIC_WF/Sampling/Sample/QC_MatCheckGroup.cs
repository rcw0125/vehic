using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xg.Lab.Sample.View;
using Zhc.Data;

namespace Xg.Lab.Sample
{
    [DbTable("QC_CheckGroup", "cp", "cp.CheckGroupCode=matcp.CheckGroupCode", JoinType = JoinType.Left)]
    [DbTable("QC_MatCheckGroup", "matcp")]
    public class QC_MatCheckGroup : DbEntity
    {

        #region Id  主键
        private int _Ori_Id = 0;
        private int _Id = 0;

        /// <summary>
        /// 主键
        /// </summary> 
        [DisplayName("主键")]
        [DbTableColumn(IsPrimaryKey = true, AutoIncrement = true)]
        public int Id
        {
            get { return _Id; }
            set
            {
                if (_Id != value)
                {
                    if (IsIniting) _Ori_Id = value;
                    _Id = value;
                    RaisePropertyChanged("Id", true);
                }
            }
        }
        #endregion


        #region MatNcId  物料主键
        private string _Ori_MatNcId = "";
        private string _MatNcId = "";

        /// <summary>
        /// 物料主键
        /// </summary> 
        [DisplayName("物料主键")]
        public string MatNcId
        {
            get { return _MatNcId; }
            set
            {
                if (_MatNcId != value)
                {
                    if (IsIniting) _Ori_MatNcId = value;
                    _MatNcId = value;
                    RaisePropertyChanged("MatNcId", true);
                }
            }
        }
        #endregion


        #region CheckGroupCode  样品分类编码
        private string _Ori_CheckGroupCode = "";
        private string _CheckGroupCode = "";

        /// <summary>
        /// 样品分类编码
        /// </summary> 
        [DisplayName("样品分类编码")]
        public string CheckGroupCode
        {
            get { return _CheckGroupCode; }
            set
            {
                if (_CheckGroupCode != value)
                {
                    if (IsIniting) _Ori_CheckGroupCode = value;
                    _CheckGroupCode = value;
                    RaisePropertyChanged("CheckGroupCode", true);
                }
            }
        }
        #endregion

        private string _CheckGroupName="";
        [DisplayName("样品分类名称")]
        [DbTableColumn("cp.CheckGroupName")]
        public string CheckGroupName
        {
            get { return _CheckGroupName; }
            set
            {
                if (_CheckGroupName != value)
                {
                    _CheckGroupName = value;
                    RaisePropertyChanged("CheckGroupName");
                }
            }
        }

        private string _CheckGroupType="";
        [DisplayName("样品分类类型")]
        [DbTableColumn("cp.CheckGroupType")]
        public string CheckGroupType
        {
            get { return _CheckGroupType; }
            set
            {
                if (_CheckGroupType != value)
                {
                    _CheckGroupType = value;
                    RaisePropertyChanged("CheckGroupType");
                }
            }
        }


        #region ShortWord  缩写标识
        private string _ShortWord = "";

        /// <summary>
        /// 缩写标识
        /// </summary> 
        [DisplayName("缩写标识")]
        [DbTableColumn("cp.ShortWord")]
        public string ShortWord
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
        #endregion

        private int _CheckGroupVisIdx = 0;
        /// <summary>
        /// 显示顺序
        /// </summary>
        [DbTableColumn("cp.VisIdx")]
        public int CheckGroupVisIdx
        {
            get { return _CheckGroupVisIdx; }
            set
            {
                if (_CheckGroupVisIdx != value)
                {
                    _CheckGroupVisIdx = value;
                    RaisePropertyChanged("CheckGroupVisIdx");
                }
            }
        }


        protected override void BeforeSave(System.Data.IDbTransaction trans)
        {
            if (Id < 0)
            {
                SetDataStateAsUnchanged();
            }
            base.BeforeSave(trans);
        }
    }

    public class QC_MatCheckGroupTable : DbEntityTable<QC_MatCheckGroup>
    {
        public void LoadByMatNcId(string matNcId)
        {
            this.LoadDataByWhere("MATNCID=@MATNCID", matNcId);
            DbEntityTable<QC_MatCheckGroup_View> matCheckGroups = new DbEntityTable<QC_MatCheckGroup_View>();
            matCheckGroups.LoadDataByWhere("MATNCID=@MATNCID", matNcId);
            foreach (var item in matCheckGroups)
            {
                QC_MatCheckGroup gp = new QC_MatCheckGroup();
                gp.Id = -1;
                gp.MatNcId = matNcId;
                gp.CheckGroupCode = item.CheckGroupCode;
                gp.CheckGroupName = item.CheckGroupName;
                gp.CheckGroupType = item.CheckGroupType;
                gp.ShortWord = item.ShortWord;
                gp.SetDataStateAsUnchanged();
                this.Add(gp);
            }
        }
    }
}
