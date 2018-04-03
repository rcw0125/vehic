using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Zhc.Data;

namespace Xg.Lab.Sample
{
    public class QC_MixLab : DbEntity
    {
        private int _MixLab_Id;
        [DbTableColumn(IsPrimaryKey = true, AutoIncrement = true)]
        public int MixLab_Id
        {
            get { return _MixLab_Id; }
            set
            {
                if (_MixLab_Id != value)
                {
                    _MixLab_Id = value;
                    RaisePropertyChanged("MixLab_Id", true);
                }
            }
        }

        #region SampleMix_Id  大桶样Id
        private int _Ori_SampleMix_Id = 0;
        private int _SampleMix_Id = 0;

        /// <summary>
        /// 大桶样Id
        /// </summary> 
        [DisplayName("大桶样Id")]
        public int SampleMix_Id
        {
            get { return _SampleMix_Id; }
            set
            {
                if (_SampleMix_Id != value)
                {
                    if (IsIniting) _Ori_SampleMix_Id = value;
                    _SampleMix_Id = value;
                    RaisePropertyChanged("SampleMix_Id", true);
                }
            }
        }
        #endregion

        #region SampleLab_Id  制样Id
        private int _Ori_SampleLab_Id = 0;
        private int _SampleLab_Id = 0;

        /// <summary>
        /// 制样Id
        /// </summary> 
        [DisplayName("制样Id")]
        public int SampleLab_Id
        {
            get { return _SampleLab_Id; }
            set
            {
                if (_SampleLab_Id != value)
                {
                    if (IsIniting) _Ori_SampleLab_Id = value;
                    _SampleLab_Id = value;
                    RaisePropertyChanged("SampleLab_Id", true);
                }
            }
        }
        #endregion

    }
}
