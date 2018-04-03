using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zhc.Data;

namespace VehIC_WF.Sampling.czl.Class
{
    class QC_Zycx:DbEntity
    {

        private int _Sample_Zycx_ID;
        [DbTableColumn(IsPrimaryKey = true)]
        public int Sample_Shcx_ID
        {
            get { return _Sample_Zycx_ID; }
            set
            {
                if (_Sample_Zycx_ID != value)
                {
                    _Sample_Zycx_ID = value;
                    RaisePropertyChanged("Sample_Zycx_ID", true);
                }
            }
        }

        private DateTime? _Sksj;
        public DateTime ? Sksj
        {
            get { return _Sksj; }
            set
            {
                if (_Sksj != value)
                {
                    _Sksj = value;
                    RaisePropertyChanged("Sksj", true);
                }
            }
        }
        private String _Lybm ;
        public String  Lybm
        {
            get { return _Lybm; }
            set
            {
                if (_Lybm != value)
                {
                    _Lybm = value;
                    RaisePropertyChanged("Lybm", true);
                }
            }
        }
        private string _Ypbm = "";
        public string Ypbm
        {
            get { return _Ypbm; }
            set
            {
                if (_Ypbm != value)
                {
                    _Ypbm = value;
                    RaisePropertyChanged("Ypbm", true);
                }
            }
        }
        private string _Jzcph = "";
        public string Jzcph
        {
            get { return _Jzcph; }
            set
            {
                if (_Jzcph != value)
                {
                    _Jzcph = value;
                    RaisePropertyChanged("Jzcph", true);
                }
            }
        }


        private string _Qylx = "";
        public string Qylx
        {
            get { return _Qylx; }
            set
            {
                if (_Qylx != value)
                {
                    _Qylx = value;
                    RaisePropertyChanged("Qylx", true);
                }
            }
        }

        private string _Yplx = "";
        public string Yplx
        {
            get { return _Yplx; }
            set
            {
                if (_Yplx != value)
                {
                    _Yplx = value;
                    RaisePropertyChanged("Yplx", true);
                }
            }
        }
        private string _Jyr = "";
        public string Jyr
        {
            get { return _Jyr; }
            set
            {
                if (_Jyr != value)
                {
                    _Jyr = value;
                    RaisePropertyChanged("Jyr", true);
                }
            }
        }
        
        private DateTime? _Sysj ;
        public DateTime? Sysj
        {
            get { return _Sysj; }
            set
            {
                if (_Sysj != value)
                {
                    _Sysj = value;
                    RaisePropertyChanged("Jysj", true);
                }
            }
        }
        private string _Syr = "";
        public string Syr
        {
            get { return _Syr; }
            set
            {
                if (_Syr != value)
                {
                    _Syr = value;
                    RaisePropertyChanged("Syr", true);
                }
            }
        }
    }
}
