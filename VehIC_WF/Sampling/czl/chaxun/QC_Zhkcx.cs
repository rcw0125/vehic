using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zhc.Data;

namespace VehIC_WF.Sampling.czl.Class
{
    class QC_Zhkcx : DbEntity
    {
        #region 主键
        private int _Xh;
        [DbTableColumn(IsPrimaryKey = true)]
        public int Xh
        {
            get { return _Xh; }
            set
            {
                if (_Xh != value)
                {
                    _Xh = value;
                    RaisePropertyChanged("Xh", true);
                }
            }
        }
        #endregion

        private Int32 _Tempid;
        public Int32 Tempid
        {
            get { return _Tempid; }
            set
            {
                if (_Tempid != value)
                {
                    _Tempid = value;
                    RaisePropertyChanged("Tempid", true);
                }
            }
        }
        private string _Ch = "";
        public string Ch
        {
            get { return _Ch; }
            set
            {
                if (_Ch != value)
                {
                    _Ch = value;
                    RaisePropertyChanged("Ch", true);
                }
            }
        }
        private string _Wlmc = "";
        public string Wlmc
        {
            get { return _Wlmc; }
            set
            {
                if (_Wlmc != value)
                {
                    _Wlmc = value;
                    RaisePropertyChanged("Wlmc", true);
                }
            }
        }
        private string _Gysmc = "";
        public string Gysmc
        {
            get { return _Gysmc; }
            set
            {
                if (_Gysmc != value)
                {
                    _Gysmc = value;
                    RaisePropertyChanged("Gysmc", true);
                }
            }
        }
        private DateTime? _Qysj;
        public DateTime? Qysj
        {
            get { return _Qysj; }
            set
            {
                if (_Qysj != value)
                {
                    _Qysj = value;
                    RaisePropertyChanged("Qysj", true);
                }
            }
        }
        private string _Pddj = "";
        public string Pddj
        {
            get { return _Pddj; }
            set
            {
                if (_Pddj != value)
                {
                    _Pddj = value;
                    RaisePropertyChanged("Pddj", true);
                }
            }
        }
        private string _Zyd = "";
        public string Zyd
        {
            get { return _Zyd; }
            set
            {
                if (_Zyd != value)
                {
                    _Zyd = value;
                    RaisePropertyChanged("Zyd", true);
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
        private double? _Ks ;
        public double? Ks
        {
            get { return _Ks; }
            set
            {
                if (_Ks != value)
                {
                    _Ks = value;
                    RaisePropertyChanged("Ks", true);
                }
            }
        }

        private double? _Kz ;
        public double? Kz
        {
            get { return _Kz; }
            set
            {
                if (_Kz != value)
                {
                    _Kz = value;
                    RaisePropertyChanged("Kz", true);
                }
            }
        }
        private string _Sf = "";
        public string Sf
        {
            get { return _Sf; }
            set
            {
                if (_Sf != value)
                {
                    _Sf = value;
                    RaisePropertyChanged("Sf", true);
                }
            }
        }
        private string _Hf = "";
        public string Hf
        {
            get { return _Hf; }
            set
            {
                if (_Hf != value)
                {
                    _Hf = value;
                    RaisePropertyChanged("Hf", true);
                }
            }
        }

        private string _Hff = "";
        public string Hff
        {
            get { return _Hff; }
            set
            {
                if (_Hff != value)
                {
                    _Hff = value;
                    RaisePropertyChanged("Hff", true);
                }
            }
        }
        private string _Lf = "";
        public string Lf
        {
            get { return _Lf; }
            set
            {
                if (_Lf != value)
                {
                    _Lf = value;
                    RaisePropertyChanged("Lf", true);
                }
            }
        }
        private string _X = "";
        public string X
        {
            get { return _X; }
            set
            {
                if (_X != value)
                {
                    _X = value;
                    RaisePropertyChanged("X", true);
                }
            }
        }
        private string _Y = "";
        public string Y
        {
            get { return _Y; }
            set
            {
                if (_Y != value)
                {
                    _Y = value;
                    RaisePropertyChanged("Y", true);
                }
            }
        }
        private string _G = "";
        public string G
        {
            get { return _G; }
            set
            {
                if (_G != value)
                {
                    _G = value;
                    RaisePropertyChanged("G", true);
                }
            }
        }
        private string _Bzc = "";
        public string Bzc
        {
            get { return _Bzc; }
            set
            {
                if (_Bzc != value)
                {
                    _Bzc = value;
                    RaisePropertyChanged("Bzc", true);
                }
            }
        }
        private string _Rmax = "";
        public string Rmax
        {
            get { return _Rmax; }
            set
            {
                if (_Rmax != value)
                {
                    _Rmax = value;
                    RaisePropertyChanged("Rmax", true);
                }
            }
        }
        private string _Kmx = "";
        public string Kmx
        {
            get { return _Kmx; }
            set
            {
                if (_Kmx != value)
                {
                    _Kmx = value;
                    RaisePropertyChanged("Kmx", true);
                }
            }
        }
        private string _Rz = "";
        public string Rz
        {
            get { return _Rz; }
            set
            {
                if (_Rz != value)
                {
                    _Rz = value;
                    RaisePropertyChanged("Rz", true);
                }
            }
        }
        private string _P = "";
        public string P
        {
            get { return _P; }
            set
            {
                if (_P != value)
                {
                    _P = value;
                    RaisePropertyChanged("P", true);
                }
            }
        }
        private string _S = "";
        public string S
        {
            get { return _S; }
            set
            {
                if (_S != value)
                {
                    _S = value;
                    RaisePropertyChanged("S", true);
                }
            }
        }
        private string _FetchPlace = "";
        public string FetchPlace
        {
            get { return _FetchPlace; }
            set
            {
                if (_FetchPlace != value)
                {
                    _FetchPlace = value;
                    RaisePropertyChanged("FetchPlace", true);
                }
            }
        }
        private string _FetchPerson = "";
        public string FetchPerson
        {
            get { return _FetchPerson; }
            set
            {
                if (_FetchPerson!= value)
                {
                    _FetchPerson = value;
                    RaisePropertyChanged("FetchPerson", true);
                }
            }
        }
        private double? _Sjsl ;
        public double? Sjsl
        {
            get { return _Sjsl; }
            set
            {
                if (_Sjsl != value)
                {
                    _Sjsl = value;
                    RaisePropertyChanged("Sjsl", true);
                }
            }
        }
    }
}
