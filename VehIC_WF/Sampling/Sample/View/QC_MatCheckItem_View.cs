using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Zhc.Data;

namespace Xg.Lab.Sample.View
{
    [DbTable(IsView = true)]
    public class QC_MatCheckItem_View : DbEntity
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
                    RaisePropertyChanged("CheckItemNcId");
                }
            }
        }

        private string _CheckItemCode;
        [DisplayName("检验项目编码")]
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
        [DisplayName("检验项目名称")]
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

        private string _CheckGroupCode="";
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

        private string _CkgShortWord="";
        [DisplayName("样品分类简码")]
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

        private string _CheckGroupType="";
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

        private int _CheckGroupVisIdx=0;

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

    }
}
