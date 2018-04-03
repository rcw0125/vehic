using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zhc.Data;
namespace VehIC_WF.Sampling.czl.Class
{
    [DbTable(IsView = true)]
  public class BD_CUBASDOC : DbEntity
    {

        private string _PK_CUBASDOC;
        [DbTableColumn(IsPrimaryKey = true)]
        public string PK_CUBASDOC
        {
            get { return _PK_CUBASDOC; }
            set
            {
                if (_PK_CUBASDOC != value)
                {
                    _PK_CUBASDOC = value;
                    RaisePropertyChanged("PK_CUBASDOC", true);
                }
            }
        }


        private string _CUSTCODE;

        public string CUSTCODE
        {
            get { return _CUSTCODE; }
            set
            {
                if (_CUSTCODE != value)
                {
                    _CUSTCODE = value;
                    RaisePropertyChanged("CUSTCODE", true);
                }
            }
        }

        private string _CUSTSHORTNAME;

        public string CUSTSHORTNAME
        {
            get { return _CUSTSHORTNAME; }
            set
            {
                if (_CUSTSHORTNAME != value)
                {
                    _CUSTSHORTNAME = value;
                    RaisePropertyChanged("CUSTSHORTNAME", true);
                }
            }
        }





    }
}
