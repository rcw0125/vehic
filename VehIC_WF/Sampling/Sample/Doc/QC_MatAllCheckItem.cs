using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Zhc.Data;

namespace Xg.Lab.Sample
{
    [DbTable(TableAlias = "main")]
    [DbTable("QC_CheckItem", "ck", "ck.CheckItemNcId=main.CheckItemNcId", JoinType.Left)]
    [DbTable("QC_CheckGroup", "cg", "cg.CheckGroupCode=ck.CheckGroupCode", JoinType.Left)]
    public class QC_MatAllCheckItem : DbEntity
    {
        #region Id  主键
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
                    _Id = value;
                    RaisePropertyChanged("Id", true);
                }
            }
        }
        #endregion

        #region MatNcId  物料主键
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
                    _MatNcId = value;
                    RaisePropertyChanged("MatNcId", true);
                }
            }
        }
        #endregion

        private string _CheckItemNcId;
        /// <summary>
        /// 主键
        /// </summary>
        public string CheckItemNcId
        {
            get { return _CheckItemNcId; }
            set
            {
                if (_CheckItemNcId != value)
                {
                    _CheckItemNcId = value;
                    RaisePropertyChanged("CheckItemNcId", true);
                }
            }
        }

        private string _CheckItemCode;
        /// <summary>
        /// 编码
        /// </summary>
        [DisplayName("检验项目编码")]
        [DbTableColumn(ColName = "ck.CheckItemCode", SortDirection = SortDirection.Ascending, SortOrder = 1)]
        public string CheckItemCode
        {
            get { return _CheckItemCode; }
            set
            {
                if (_CheckItemCode != value)
                {
                    _CheckItemCode = value;
                    RaisePropertyChanged("CheckItemCode");
                }
            }
        }

        private string _CheckItemName;
        /// <summary>
        /// 名称
        /// </summary>
        [DisplayName("检验项目名称")]
        [DbTableColumn("ck.CheckItemName")]
        public string CheckItemName
        {
            get { return _CheckItemName; }
            set
            {
                if (_CheckItemName != value)
                {
                    _CheckItemName = value;
                    RaisePropertyChanged("CheckItemName");
                }
            }
        }

        private string _CheckItemUnit;
        [DisplayName("检验项目单位")]
        [DbTableColumn("ck.CheckItemUnit")]
        public string CheckItemUnit
        {
            get { return _CheckItemUnit; }
            set
            {
                if (_CheckItemUnit != value)
                {
                    _CheckItemUnit = value;
                    RaisePropertyChanged("CheckItemUnit");
                }
            }
        }

        private string _CheckGroupCode = "";
        [DisplayName("样品分类编码")]
        [DbTableColumn("cg.CheckGroupCode")]
        public string CheckGroupCode
        {
            get { return _CheckGroupCode; }
            set
            {
                if (_CheckGroupCode != value)
                {
                    _CheckGroupCode = value;
                    RaisePropertyChanged("CheckGroupCode");
                }
            }
        }


        private string _CheckGroupName;
        [DisplayName("样品分类名称")]
        [DbTableColumn("cg.CheckGroupName")]
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

        private string _CkgShortWord = "";
        [DisplayName("样品分类简码")]
        [DbTableColumn("cg.ShortWord")]
        public string CkgShortWord
        {
            get { return _CkgShortWord; }
            set
            {
                if (_CkgShortWord != value)
                {
                    _CkgShortWord = value;
                    RaisePropertyChanged("CkgShortWord");
                }
            }
        }

        private string _CheckGroupType = "";
        [DisplayName("样品分类类型")]
        [DbTableColumn("cg.CheckGroupType")]
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

        private int _CheckGroupVisIdx = 0;
        //显示顺序
        [DbTableColumn("cg.VisIdx")]
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

       
        private string _JYLX="";
        /// <summary>
        ///  检验类型
        /// </summary>
        public string JYLX
        {
            get { return _JYLX; }
            set
            {
                if (_JYLX != value)
                {
                    _JYLX = value;
                    RaisePropertyChanged("JYLX", true);
                }
            }
        }

    }
}
