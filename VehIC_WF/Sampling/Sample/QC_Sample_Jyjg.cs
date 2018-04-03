using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zhc.Data;

namespace VehIC_WF.Sampling.Sample
{
    class QC_Sample_Jyjg : DbEntity
    {
        private int _ID;
        /// <summary>
        /// 主键
        /// </summary>
        [DbTableColumn(IsPrimaryKey = true, AutoIncrement = true)]

        public int ID
        {
            get { return _ID; }
            set
            {
                if (_ID != value)
                {
                    _ID = value;
                    RaisePropertyChanged("ID");
                }
            }
        }
        private bool _Shangchuan = false;

        public bool Shangchuan
        {
            get { return _Shangchuan; }
            set
            {
                if (IsIniting) _Shangchuan = value;

                _Shangchuan = value;
                RaisePropertyChanged("Shangchuan", true);

            }
        }
        private string _JQCode;

        public string JQCode
        {
            get { return _JQCode; }
            set
            {
                if (_JQCode != value)
                {
                    _JQCode = value;
                    RaisePropertyChanged("JQCode", true);
                }
            }
        }
        private string _SampleName;

        public string SampleName
        {
            get { return _SampleName; }
            set
            {
                if (_SampleName != value)
                {
                    _SampleName = value;
                    RaisePropertyChanged("SampleName", true);
                }
            }
        }
        private string _Date;

        public string Date
        {
            get { return _Date; }
            set
            {
                if (_Date != value)
                {
                    _Date = value;
                    RaisePropertyChanged("Date", true);
                }
            }
        }
        private string _JYShebei;

        public string JYShebei
        {
            get { return _JYShebei; }
            set
            {
                if (_JYShebei != value)
                {
                    _JYShebei = value;
                    RaisePropertyChanged("JYShebei", true);
                }
            }
        }
        private string _Value;

        public string Value
        {
            get { return _Value; }
            set
            {
                if (_Value != value)
                {
                    _Value = value;
                    RaisePropertyChanged("Value", true);
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
    }
}
