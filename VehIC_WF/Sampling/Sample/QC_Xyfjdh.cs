using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zhc.Data;
namespace VehIC_WF.Sampling.Sample
{
    class QC_Xyfjdh : DbEntity
    {
        private int _ID;
        [DbTableColumn(IsPrimaryKey = true, AutoIncrement = true)]
        public int ID
        {
            get { return _ID; }
            set
            {
                if (_ID != value)
                {
                    _ID = value;
                    RaisePropertyChanged("ID");
                  
                }
            }
        }

        private string _fjdh;

        public string fjdh
        {
            get { return _fjdh; }
            set
            {
                if (_fjdh != value)
                {
                    _fjdh = value;
                    RaisePropertyChanged("fjdh", true);
                }
            }
        }
        private string _wc;

        public string wc
        {
            get { return _wc; }
            set
            {
                if (_wc != value)
                {
                    _wc = value;
                    RaisePropertyChanged("wc", true);
                }
            }
        }

    }
}
