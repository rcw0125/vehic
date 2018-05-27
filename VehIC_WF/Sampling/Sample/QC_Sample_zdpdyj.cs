using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zhc.Data;
namespace VehIC_WF.Sampling.Sample
{
    class QC_Sample_zdpdyj : DbEntity
    {
        private int _sample_pd_id;
        /// <summary>
        /// 主键
        /// </summary>
        [DbTableColumn(IsPrimaryKey = true, AutoIncrement = true)]

        public int sample_pd_id
        {
            get { return _sample_pd_id; }
            set
            {
                if (_sample_pd_id != value)
                {
                    _sample_pd_id = value;
                    RaisePropertyChanged("sample_pd_id");
                }
            }
        }
        private string _WLLX;

        public string WLLX
        {
            get { return _WLLX; }
            set
            {
                if (_WLLX != value)
                {
                    _WLLX = value;
                    RaisePropertyChanged("WLLX", true);
                }
            }
        }
        private string _matname;

        public string matname
        {
            get { return _matname; }
            set
            {
                if (_matname != value)
                {
                    _matname = value;
                    RaisePropertyChanged("matname", true);
                }
            }
        }
        private string _matcode;

        public string matcode
        {
            get { return _matcode; }
            set
            {
                if (_matcode != value)
                {
                    _matcode = value;
                    RaisePropertyChanged("matcode", true);
                }
            }
        }
        private string _type;

        public string type
        {
            get { return _type; }
            set
            {
                if (_type != value)
                {
                    _type = value;
                    RaisePropertyChanged("type", true);
                }
            }
        }
        private string _sf;

        public string sf
        {
            get { return _sf; }
            set
            {
                if (_sf != value)
                {
                    _sf = value;
                    RaisePropertyChanged("sf", true);
                }
            }
        }
        private string _hf;

        public string hf
        {
            get { return _hf; }
            set
            {
                if (_hf != value)
                {
                    _hf = value;
                    RaisePropertyChanged("hf", true);
                }
            }
        }
        private string _hff;

        public string hff
        {
            get { return _hff; }
            set
            {
                if (_hff != value)
                {
                    _hff = value;
                    RaisePropertyChanged("hff", true);
                }
            }
        }
        private string _Y;

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
        private string _G;

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
        private string _TFe;

        public string TFe
        {
            get { return _TFe; }
            set
            {
                if (_TFe != value)
                {
                    _TFe = value;
                    RaisePropertyChanged("TFe", true);
                }
            }
        }
        private string _SiO2;

        public string SiO2
        {
            get { return _SiO2; }
            set
            {
                if (_SiO2 != value)
                {
                    _SiO2 = value;
                    RaisePropertyChanged("SiO2", true);
                }
            }
        }
        private string _P;

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
        private string _Cu;

        public string Cu
        {
            get { return _Cu; }
            set
            {
                if (_Cu != value)
                {
                    _Cu = value;
                    RaisePropertyChanged("Cu", true);
                }
            }
        }
        private string _Zn;

        public string Zn
        {
            get { return _Zn; }
            set
            {
                if (_Zn != value)
                {
                    _Zn = value;
                    RaisePropertyChanged("Zn", true);
                }
            }
        }

    }
}
