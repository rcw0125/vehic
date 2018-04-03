using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Zhc.Data;

namespace Xg.Lab.Sample.View
{
    [DbTable(IsView = true, TableName = "tb_WorkCenter")]
    public class QC_WorkPoint_View : DbEntity
    {
        private string _WCCode;
        [DisplayName("作业点编码")]
        public string WCCode
        {
            get { return _WCCode; }
            set
            {
                if (_WCCode != value)
                {
                    _WCCode = value;
                    RaisePropertyChanged("WCCode");
                }
            }
        }

        private string _WCTypeId;

        public string WCTypeId
        {
            get { return _WCTypeId; }
            set
            {
                if (_WCTypeId != value)
                {
                    _WCTypeId = value;
                    RaisePropertyChanged("WCTypeId");
                }
            }
        }

        private string _WCBM;

        public string WCBM
        {
            get { return _WCBM; }
            set
            {
                if (_WCBM != value)
                {
                    _WCBM = value;
                    RaisePropertyChanged("WCBM");
                }
            }
        }

        private string _WCName;
        [DisplayName("作业点名称")]
        public string WCName
        {
            get { return _WCName; }
            set
            {
                if (_WCName != value)
                {
                    _WCName = value;
                    RaisePropertyChanged("WCName");
                }
            }
        }

    }
}
