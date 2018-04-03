using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zhc.Data;

namespace Xg.Lab.Sample
{
    [DbTable(IsView=true)]
     public class cheshu: DbEntity
    {
        private string _cj;
        /// <summary>
      // 厂家
        /// </summary>
      
        [System.ComponentModel.DisplayName("厂家")]
        public string cj
        {
            get { return _cj; }
            set
            {
                if (_cj != value)
                {
                    _cj = value;
                    RaisePropertyChanged("cj", true);
                }
            }
        }
        private string _wl;
        /// <summary>
        // 物料
        /// </summary>

        [System.ComponentModel.DisplayName("物料")]
        public string wl
        {
            get { return _wl; }
            set
            {
                if (_wl != value)
                {
                    _wl = value;
                    RaisePropertyChanged("wl", true);
                }
            }
        }
        private string _dd;
        /// <summary>
        // 取样地点
        /// </summary>

        [System.ComponentModel.DisplayName("取样地点")]
        public string dd
        {
            get { return _dd; }
            set
            {
                if (_dd != value)
                {
                    _dd = value;
                    RaisePropertyChanged("dd", true);
                }
            }
        }
        private int _num;
        /// <summary>
        // 车数
        /// </summary>

        [System.ComponentModel.DisplayName("车数")]
        public int num
        {
            get { return _num; }
            set
            {
                if (_num != value)
                {
                    _num = value;
                    RaisePropertyChanged("num", true);
                }
            }
        }
    }
}
