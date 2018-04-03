using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zhc.Data;
using System.ComponentModel;

namespace VehIC_WF.Sampling.czl.Class
{
    [DbTable(IsView = true)]
    class QC_CheckItem_View:DbEntity
    {
        private string _MatCode;


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
        
        private string _CheckGroupCode;
     
     
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

        private string _CheckItemCode;
      
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

        public string CheckItemName
        {
            get { return _CheckItemCode; }
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

        private string _CheckItemNcid;

        public string CheckItemNcid
        {
            get { return _CheckItemNcid; }
            set
            {
                if (_CheckItemNcid != value)
                {
                    _CheckItemNcid = value;
                    RaisePropertyChanged("CheckItemNcid", true);
                }
            }
        }


    }
}
