using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zhc.Data;
using System.ComponentModel;

namespace Xg.Lab.Sample
{
    /// <summary>
    /// 样品分类
    /// </summary>
    public class QC_CheckGroup : DbEntity
    {
        private string _CheckGroupCode;
        [DbTableColumn(IsPrimaryKey = true)]
        [DisplayName("样品分类编码")]
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
        [DisplayName("样品分类名称")]
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


        #region ShortWord  缩写标识
        private string _Ori_ShortWord = "";
        private string _ShortWord = "";

        /// <summary>
        /// 缩写标识
        /// </summary> 
        [DisplayName("缩写标识")]
        public string ShortWord
        {
            get { return _ShortWord; }
            set
            {
                if (_ShortWord != value)
                {
                    if (IsIniting) _Ori_ShortWord = value;
                    _ShortWord = value;
                    RaisePropertyChanged("ShortWord", true);
                }
            }
        }
        #endregion


        #region CheckGroupType  样品分类类型
        private string _Ori_CheckGroupType = "";
        private string _CheckGroupType = "";

        /// <summary>
        /// 样品分类类型
        /// </summary> 
        [DisplayName("样品分类类型")]
        public string CheckGroupType
        {
            get { return _CheckGroupType; }
            set
            {
                if (_CheckGroupType != value)
                {
                    if (IsIniting) _Ori_CheckGroupType = value;
                    _CheckGroupType = value;
                    RaisePropertyChanged("CheckGroupType", true);
                }
            }
        }
        #endregion

        private int _VisIdx=0;

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

    }
}
