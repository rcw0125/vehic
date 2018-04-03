using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Zhc.Data;

namespace Xg.Lab.Sample.View
{
    [DbTable(IsView = true)]
    public class QC_MatQualityLevel_View : DbEntity
    {
        private string _MATNCID = "";
        [Browsable(false)]
        public string MATNCID
        {
            get { return _MATNCID; }
            set
            {
                if (_MATNCID != value)
                {
                    _MATNCID = value;
                    RaisePropertyChanged("MATNCID");
                }
            }
        }

        private string _QUALITYLEVELID;
        
        public string QUALITYLEVELID
        {
            get { return _QUALITYLEVELID; }
            set
            {
                if (_QUALITYLEVELID != value)
                {
                    _QUALITYLEVELID = value;
                    RaisePropertyChanged("QUALITYLEVELID");
                }
            }
        }

        private string _QUALITYLEVELCODE = "";
        [DisplayName("质量等级编码")]
        public string QUALITYLEVELCODE
        {
            get { return _QUALITYLEVELCODE; }
            set
            {
                if (_QUALITYLEVELCODE != value)
                {
                    _QUALITYLEVELCODE = value;
                    RaisePropertyChanged("QUALITYLEVELCODE");
                }
            }
        }

        private string _QUALITYLEVELNAME = "";
        [DisplayName("质量等级名称")]
        public string QUALITYLEVELNAME
        {
            get { return _QUALITYLEVELNAME; }
            set
            {
                if (_QUALITYLEVELNAME != value)
                {
                    _QUALITYLEVELNAME = value;
                    RaisePropertyChanged("QUALITYLEVELNAME");
                }
            }
        }

    }
}
