using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Zhc.Data;
namespace VehIC_WF.Sampling.czl.chaxun
{
    class QC_Hbcx : DbEntity
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

        private string _Riqi = "";
        public string Riqi
        {
            get { return _Riqi; }
            set
            {
                if (_Riqi != value)
                {
                    _Riqi = value;
                    RaisePropertyChanged("Riqi", true);
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
        private string _Frl = "";
        public string Frl
        {
            get { return _Frl; }
            set
            {
                if (_Frl != value)
                {
                    _Frl = value;
                    RaisePropertyChanged("Frl", true);
                }
            }
        }


    }
}
