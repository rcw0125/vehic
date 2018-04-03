using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zhc.Data;

namespace Xg.Lab.Sample
{
    public class QC_Sample_Value_log : DbEntity
    {
        private int _Id;
        [DbTableColumn(IsPrimaryKey = true, AutoIncrement = true)]
        public int Id
        {
            get { return _Id; }
            set
            {
                if (_Id != value)
                {
                    _Id = value;
                    RaisePropertyChanged("Id");
                }
            }
        }

        private string _Sample_Value_Id = "";

        public string Sample_Value_Id
        {
            get { return _Sample_Value_Id; }
            set
            {
                if (_Sample_Value_Id != value)
                {
                    _Sample_Value_Id = value;
                    RaisePropertyChanged("Sample_Value_Id");
                }
            }
        }

        private string _ValType;

        public string ValType
        {
            get { return _ValType; }
            set
            {
                if (_ValType != value)
                {
                    _ValType = value;
                    RaisePropertyChanged("ValType");
                }
            }
        }

        private string _OldVal;

        public string OldVal
        {
            get { return _OldVal; }
            set
            {
                if (_OldVal != value)
                {
                    _OldVal = value;
                    RaisePropertyChanged("OldVal");
                }
            }
        }

        private string _NewVal;

        public string NewVal
        {
            get { return _NewVal; }
            set
            {
                if (_NewVal != value)
                {
                    _NewVal = value;
                    RaisePropertyChanged("NewVal");
                }
            }
        }

        private string _Reason;

        public string Reason
        {
            get { return _Reason; }
            set
            {
                if (_Reason != value)
                {
                    _Reason = value;
                    RaisePropertyChanged("Reason");
                }
            }
        }

        private string _Modifier;

        public string Modifier
        {
            get { return _Modifier; }
            set
            {
                if (_Modifier != value)
                {
                    _Modifier = value;
                    RaisePropertyChanged("Modifier");
                }
            }
        }

        private DateTime? _ModifyTime;

        public DateTime? ModifyTime
        {
            get { return _ModifyTime; }
            set
            {
                if (_ModifyTime != value)
                {
                    _ModifyTime = value;
                    RaisePropertyChanged("ModifyTime");
                }
            }
        }

    }
}
