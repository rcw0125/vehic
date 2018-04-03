using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Zhc.Data;
namespace Xg.Lab.Sample.View
{
    [DbTable(IsView = true, TableName = "QC_CheckItem")]
    public class QC_CheckItemSelect_View : DbEntity
    {
        private string _CheckItemNcId;
        [Browsable(false)]
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
        [DbTableColumn(SortDirection=SortDirection.Ascending)]
        public string CheckItemCode
        {
            get { return _CheckItemCode; }
            set
            {
                if (_CheckItemCode != value)
                {
                    _CheckItemCode = value;
                    RaisePropertyChanged("CheckItemCode", true);
                }
            }
        }

        private string _CheckItemName;
        /// <summary>
        /// 名称
        /// </summary>
        [DisplayName("检验项目名称")]
        public string CheckItemName
        {
            get { return _CheckItemName; }
            set
            {
                if (_CheckItemName != value)
                {
                    _CheckItemName = value;
                    RaisePropertyChanged("CheckItemName", true);
                }
            }
        }

        private string _CheckItemUnit;
        /// <summary>
        /// 单位
        /// </summary>
        [DisplayName("检验项目单位")]
        public string CheckItemUnit
        {
            get { return _CheckItemUnit; }
            set
            {
                if (_CheckItemUnit != value)
                {
                    _CheckItemUnit = value;
                    RaisePropertyChanged("CheckItemUnit", true);
                }
            }
        }

        private string _DisplayName;
        [NonTableField]
        public string DisplayName
        {
            get { return _DisplayName; }
            set
            {
                if (_DisplayName != value)
                {
                    _DisplayName = value;
                    RaisePropertyChanged("DisplayName");
                }
            }
        }


        private string _ParentID="";
        [NonTableField]
        public string ParentID
        {
            get
            {
                if (CheckItemCode.Length > 1)
                {
                    return CheckItemCode.Substring(0, 1);
                }
                else
                {
                    return _ParentID;
                }

            }
            set
            {
                if (_ParentID != value)
                {
                    _ParentID = value;
                    RaisePropertyChanged("ParentID");
                }
            }
        }

    }
}
