using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zhc.Data;
using System.ComponentModel;

namespace Xg.Lab.Sample
{
    /// <summary>
    /// 检化验项目
    /// </summary>
    public class QC_CheckItem : DbEntity
    {
        private string _CheckItemNcId;
        /// <summary>
        /// 主键
        /// </summary>
        [DbTableColumn(IsPrimaryKey=true)]
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

        private string _CheckGroupCode;
        /// <summary>
        /// 分组
        /// </summary>
         [DisplayName("检验项目分组")]
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

    }


    public class QC_CheckItem_Table : DbEntityTable<QC_CheckItem>
    {
        private static QC_CheckItem_Table _Global = null;
        public static QC_CheckItem_Table Global
        {
            get
            {
                if (_Global == null)
                {
                    _Global = new QC_CheckItem_Table();
                    _Global.LoadData();
                }
                return _Global;
            }
        }
    }
}
