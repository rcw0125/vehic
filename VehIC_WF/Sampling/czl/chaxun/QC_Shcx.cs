using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zhc.Data;

namespace VehIC_WF.Sampling.czl.Class
{
    class QC_Shcx : DbEntity
    {
        #region 主键
        private int _Sample_Shcx_ID ;
        [DbTableColumn(IsPrimaryKey = true)]
        public int Sample_Shcx_ID
        {
            get { return _Sample_Shcx_ID; }
            set
            {
                if (_Sample_Shcx_ID != value)
                {
                    _Sample_Shcx_ID = value;
                    RaisePropertyChanged("Sample_Shcx_ID", true);
                }
            }
        }
        #endregion
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
        private string _Gys = "";
        public string Gys
        {
            get { return _Gys; }
            set
            {
                if (_Gys != value)
                {
                    _Gys = value;
                    RaisePropertyChanged("Gys", true);
                }
            }
        }
        private string _Cph = "";
        public string Cph
        {
            get { return _Cph; }
            set
            {
                if (_Cph != value)
                {
                    _Cph = value;
                    RaisePropertyChanged("Cph", true);
                }
            }
        }
        private string _Yplx ="";
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


        private string _Lybm = "";
        public string Lybm
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

 

        private DateTime? _Jysj;
        public DateTime? Jysj
        {
            get { return _Jysj; }
            set
            {
                if (_Jysj != value)
                {
                    _Jysj = value;
                    RaisePropertyChanged("Jysj", true);
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


        private string _Fxry;
        public string Fxry
        {
            get { return _Fxry; }
            set
            {
                if (_Fxry != value)
                {
                    _Fxry = value;
                    RaisePropertyChanged("Fxry", true);
                }
            }
        }


        private DateTime? _Fxsj;
        public DateTime? Fxsj
        {
            get { return _Fxsj; }
            set
            {
                if (_Fxsj != value)
                {
                    _Fxsj = value;
                    RaisePropertyChanged("Fxsj", true);
                }
            }
        }

        private string _Hf;
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

        private string _Frl;
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



        private string _Hff;
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

        private string _S;
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


        private string _Gdt;
        public string Gdt
        {
            get { return _Gdt; }
            set
            {
                if (_Gdt != value)
                {
                    _Gdt = value;
                    RaisePropertyChanged("Gdt", true);
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
        private string _MgO;
        public string MgO
        {
            get { return _MgO; }
            set
            {
                if (_MgO != value)
                {
                    _MgO = value;
                    RaisePropertyChanged("MgO", true);
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
        private string _CaO;
        public string CaO
        {
            get { return _CaO; }
            set
            {
                if (_CaO != value)
                {
                    _CaO = value;
                    RaisePropertyChanged("CaO", true);
                }
            }
        }

        private string _Al2O3;
        public string Al2O3
        {
            get { return _Al2O3; }
            set
            {
                if (_Al2O3 != value)
                {
                    _Al2O3 = value;
                    RaisePropertyChanged("Al2O3", true);
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
        private string _TiO2;
        public string TiO2
        {
            get { return _TiO2; }
            set
            {
                if (_TiO2 != value)
                {
                    _TiO2 = value;
                    RaisePropertyChanged("TiO2", true);
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
        private string _MnO;
        public string MnO
        {
            get { return _MnO; }
            set
            {
                if (_MnO != value)
                {
                    _MnO = value;
                    RaisePropertyChanged("MnO", true);
                }
            }
        }
        private string _K2O;
        public string K2O
        {
            get { return _K2O; }
            set
            {
                if (_K2O != value)
                {
                    _K2O = value;
                    RaisePropertyChanged("K2O", true);
                }
            }
        }
        private string _Na2O;
        public string Na2O
        {
            get { return _Na2O; }
            set
            {
                if (_Na2O != value)
                {
                    _Na2O = value;
                    RaisePropertyChanged("Na2O", true);
                }
            }
        }
        private string _V2O5;
        public string V2O5
        {
            get { return _V2O5; }
            set
            {
                if (_V2O5 != value)
                {
                    _V2O5 = value;
                    RaisePropertyChanged("V2O5", true);
                }
            }
        }
        private string _Pb;
        public string Pb
        {
            get { return _Pb; }
            set
            {
                if (_Pb != value)
                {
                    _Pb = value;
                    RaisePropertyChanged("Pb", true);
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
        private string _As;
        public string As
        {
            get { return _As; }
            set
            {
                if (_As != value)
                {
                    _As = value;
                    RaisePropertyChanged("As", true);
                }
            }
        }
        private string _Sn;
        public string Sn
        {
            get { return _Sn; }
            set
            {
                if (_Sn != value)
                {
                    _Sn = value;
                    RaisePropertyChanged("Sn", true);
                }
            }
        }
        private string _Sb;
        public string Sb
        {
            get { return _Sb; }
            set
            {
                if (_Sb != value)
                {
                    _Sb = value;
                    RaisePropertyChanged("Sb", true);
                }
            }
        }
        private string _Lf;
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
    }
}
