using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zhc.Data;
using System.ComponentModel;

namespace Xg.Lab.Sample.View
{
    [DbTable(IsView = true)]
    public class v_train_weight : DbEntity
    { 
        //private string _CARRIVEORDERID;
      
        //public string CARRIVEORDERID
        //{
        //    get { return _CARRIVEORDERID; }
        //    set
        //    {
        //        if (_CARRIVEORDERID != value)
        //        {
        //            _CARRIVEORDERID = value;
        //            RaisePropertyChanged("CARRIVEORDERID");
        //        }
        //    }
        //}

        private string _VARRORDERCODE = "";
       
        public string VARRORDERCODE
        {
            get { return _VARRORDERCODE; }
            set
            {
                if (_VARRORDERCODE != value)
                {
                    _VARRORDERCODE = value;
                    RaisePropertyChanged("VARRORDERCODE");
                }
            }
        }

        private string _CARNO = "";
        public string CARNO
        {
            get { return _CARNO; }
            set
            {
                if (_CARNO != value)
                {
                    _CARNO = value;
                    RaisePropertyChanged("CARNO");
                }
            }
        }

        private string _GROSSWEIGHT;

        public string GROSSWEIGHT
        {
            get { return _GROSSWEIGHT; }
            set
            {
                if (_GROSSWEIGHT != value)
                {
                    _GROSSWEIGHT = value;
                    RaisePropertyChanged("GROSSWEIGHT");
                }
            }
        }
            private string  _GROSS_DATETIME;

            public string GROSS_DATETIME
        {
            get { return _GROSS_DATETIME; }
            set
            {
                if (_GROSS_DATETIME != value)
                {
                    _GROSS_DATETIME= value;
                    RaisePropertyChanged("GROSS_DATETIME");
                }
            }
        }

            private string _TAREWEIGHT;

        public string TAREWEIGHT
        {
            get { return _TAREWEIGHT; }
            set
            {
                if (_TAREWEIGHT != value)
                {
                    _TAREWEIGHT = value;
                    RaisePropertyChanged("TAREWEIGHT");
                }
            }
        }
            private string _TARE_DATETIME;

            public string TARE_DATETIME
        {
            get { return _TARE_DATETIME; }
            set
            {
                if (_TARE_DATETIME != value)
                {
                    _TARE_DATETIME = value;
                    RaisePropertyChanged("TARE_DATETIME");
                }
            }
        }
    }
}
