using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zhc.Data;
using System.ComponentModel;

namespace Xg.Lab.Sample.View
{
    [DbTable(IsView=true)]
    public class QC_MatCheckGroup_View : DbEntity
    {
        private string _CheckGroupCode;
        [DisplayName("样品分类编码")]
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

        private string _CheckGroupType = "";

        [DisplayName("样品分类类型")]
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


    }
}
