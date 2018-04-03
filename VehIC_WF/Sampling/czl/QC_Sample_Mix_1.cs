using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VehIC_WF.Sampling.czl.Class;
using Zhc.Data;

namespace Xg.Lab.Sample
{
    public partial class QC_Sample_Mix
    {
      

        private DbEntityTable<QC_MixCheckItem> _AddCheckItems = new DbEntityTable<QC_MixCheckItem>();
        /// <summary>
        /// 添加检验项目
        /// </summary>
        public DbEntityTable<QC_MixCheckItem> AddCheckItems
        {
            get
            {
                return _AddCheckItems;
            }
        }

        private bool _Sample_TBZD=false;

        public bool Sample_TBZD
        {
            get { return _Sample_TBZD; }
            set
            {
                if (_Sample_TBZD != value)
                {
                    _Sample_TBZD = value;
                    RaisePropertyChanged("Sample_TBZD", true);
                }
            }
        }



    }
}
