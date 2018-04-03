using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zhc.Data;

namespace VehIC_WF.Class
{
    [DbTable(IsView = true)]
    class BD_INVBASDOC : DbEntity
    {
        private string _PK_INVBASDOC;
        [DbTableColumn(IsPrimaryKey = true)]
        public string PK_INVBASDOC
        {
            get { return _PK_INVBASDOC; }
            set
            {
                if (_PK_INVBASDOC != value)
                {
                    _PK_INVBASDOC = value;
                    RaisePropertyChanged("PK_INVBASDOC", true);
                }
            }
        }


        private string _INVCODE;

        public string INVCODE
        {
            get { return _INVCODE; }
            set
            {
                if (_INVCODE != value)
                {
                    _INVCODE = value;
                    RaisePropertyChanged("INVCODE", true);
                }
            }
        }

        private string _INVNAME;

        public string INVNAME
        {
            get { return _INVNAME; }
            set
            {
                if (_INVNAME != value)
                {
                    _INVNAME = value;
                    RaisePropertyChanged("INVNAME", true);
                }
            }
        }


    }
}
