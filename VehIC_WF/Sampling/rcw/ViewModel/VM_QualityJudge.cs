using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xg.Lab.Sample;
using Zhc;

namespace Xg.Lab.ViewModel
{
    public class VM_QualityJudge : EntityBase
    {
        private bool _IsCommonSample=true;
        /// <summary>
        /// 是否普通样
        /// </summary>
        public bool IsCommonSample
        {
            get { return _IsCommonSample; }
            set
            {
                if (_IsCommonSample != value)
                {
                    _IsCommonSample = value;
                    RaisePropertyChanged();
                }
            }
        }

        private bool _IsVerifSample=false;
        /// <summary>
        /// 是否校验样
        /// </summary>
        public bool IsVerifSample
        {
            get { return _IsVerifSample; }
            set
            {
                if (_IsVerifSample != value)
                {
                    _IsVerifSample = value;
                    RaisePropertyChanged();
                }
            }
        }

        private bool _IsInspectSample;
        /// <summary>
        /// 是否抽查样
        /// </summary>
        public bool IsInspectSample
        {
            get { return _IsInspectSample; }
            set
            {
                if (_IsInspectSample != value)
                {
                    _IsInspectSample = value;
                    RaisePropertyChanged();
                }
            }
        }

        private QC_Sample_Mix sample = null;

        public QC_Sample_Mix Sample
        {
            get { return sample; }
            set
            {
                if (sample != value)
                {
                    sample = value;
                    if (sample != null)
                    {
                        switch(sample.SampleType) 
                        {       
                            case SampleType.普通样:
                                IsCommonSample = true;
                                break;
                            case SampleType.抽查样:
                                IsInspectSample = true;
                                break;
                            case SampleType.校验样:
                                IsVerifSample = true;
                                break;
                        }
                    }
                }
            }
        }
    }
}
