using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zhc.Data;

namespace VehIC_WF.Sampling.czl.Class
{
    [DbTable(IsView = true)]
    class QC_HJZPFENZU : DbEntity
    {
      
        private bool _ZUPI = false;

        public bool ZUPI
        {
            get { return _ZUPI; }
            set
            {
                if (_ZUPI != value)
                {
                    if (IsIniting) _ZUPI = value;
                    _ZUPI = value;
                    RaisePropertyChanged("ZUPI", true);
                }
            }
        }


        private string _INVCODE = "";
        /// <summary>
        /// 物料编码
        /// </summary>
        public string INVCODE
        {
            get { return _INVCODE; }
            set { _INVCODE = value; }
        }

        private string _INVNAME = "";
        /// <summary>
        /// 物料名称
        /// </summary>
        public string INVNAME
        {
            get { return _INVNAME; }
            set { _INVNAME = value; }
        }
        private string _CUSTCODE = "";
        /// <summary>
        /// 供应商编码
        /// </summary>
        public string CUSTCODE
        {
            get { return _CUSTCODE; }
            set { _CUSTCODE = value; }
        }

        private string _CUSTNAME = "";
        /// <summary>
        /// 供应商名称
        /// </summary>
        public string CUSTNAME
        {
            get { return _CUSTNAME; }
            set { _CUSTNAME = value; }
        }



    }
}
