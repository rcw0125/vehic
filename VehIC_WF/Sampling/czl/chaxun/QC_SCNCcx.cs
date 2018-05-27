using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xg.Lab.Sample;
using Zhc.Data;

namespace VehIC_WF.Sampling.czl.chaxun
{
    class QC_SCNCcx : DbEntity
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
        #region ZyDanHao  制样单号
        private string _Ori_ZyDanHao = "";
        private string _ZyDanHao = "";

        /// <summary>
        /// 制样单号
        /// </summary> 
        [DisplayName("制样单号")]
        public string ZyDanHao
        {
            get { return _ZyDanHao; }
            set
            {
                if (_ZyDanHao != value)
                {
                    if (IsIniting) _Ori_ZyDanHao = value;
                    _ZyDanHao = value;
                    RaisePropertyChanged("ZyDanHao", true);
                }
            }
        }
        #endregion
       
        #region SampleType 取样类型
        private SampleType _Ori_SampleType = SampleType.普通样;
        private SampleType _SampleType = SampleType.普通样;
        /// <summary>
        /// 取样类型
        /// </summary>
        [DisplayName("取样类型")]
        public SampleType SampleType
        {
            get { return _SampleType; }
            set
            {
                if (_SampleType != value)
                {
                    if (IsIniting) _Ori_SampleType = value;
                    _SampleType = value;
                    RaisePropertyChanged();
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
        #region FetchTime  取样时间
        private DateTime? _Ori_FetchTime = null;
        private DateTime? _FetchTime = null;

        /// <summary>
        /// 取样时间
        /// </summary> 
        [DisplayName("取样时间")]
        public DateTime? FetchTime
        {
            get { return _FetchTime; }
            set
            {
                if (_FetchTime != value)
                {
                    if (IsIniting) _Ori_FetchTime = value;
                    _FetchTime = value;
                    RaisePropertyChanged("FetchTime", true);
                }
            }
        }
        #endregion
        #region VehNo  车牌号
        private string _Ori_VehNo = "";
        private string _VehNo = "";

        /// <summary>
        /// 车牌号
        /// </summary> 
        [DisplayName("车牌号")]
        public string VehNo
        {
            get { return _VehNo; }
            set
            {
                if (_VehNo != value)
                {
                    if (IsIniting) _Ori_VehNo = value;
                    _VehNo = value;
                    RaisePropertyChanged("VehNo", true);
                }
            }
        }
        #endregion

        #region KouZa  扣杂
        private double? _Ori_KouZa = null;
        private double? _KouZa = null;

        /// <summary>
        /// 扣杂
        /// </summary> 
        [DisplayName("扣杂")]
        public double? KouZa
        {
            get { return _KouZa; }
            set
            {
                if (_KouZa != value)
                {
                    if (IsIniting) _Ori_KouZa = value;
                    _KouZa = value;
                    RaisePropertyChanged("KouZa", true);
                }
            }
        }
        #endregion

        #region KouShui  扣水
        private double? _Ori_KouShui = null;
        private double? _KouShui = null;

        /// <summary>
        /// 扣水
        /// </summary> 
        [DisplayName("扣水")]
        public double? KouShui
        {
            get { return _KouShui; }
            set
            {
                if (_KouShui != value)
                {
                    if (IsIniting) _Ori_KouShui = value;
                    _KouShui = value;
                    RaisePropertyChanged("KouShui", true);
                }
            }
        }
        #endregion
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
        private string _KM = "";
        public string KM
        {
            get { return _KM; }
            set
            {
                if (_KM != value)
                {
                    _KM = value;
                    RaisePropertyChanged("KM", true);
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
        private string _BzcS = "";
        public string BzcS
        {
            get { return _BzcS; }
            set
            {
                if (_BzcS != value)
                {
                    _BzcS = value;
                    RaisePropertyChanged("BzcS", true);
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
        private string _Rran = "";
        public string Rran
        {
            get { return _Rran; }
            set
            {
                if (_Rran != value)
                {
                    _Rran = value;
                    RaisePropertyChanged("Rran", true);
                }
            }
        }
        private string _Gdt = "";
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
     
    }
    }

