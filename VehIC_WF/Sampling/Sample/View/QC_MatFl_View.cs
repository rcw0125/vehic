using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zhc.Data;

namespace Xg.Lab.Sample.View
{
    [DbTable(TableName = "BD_INVCL", IsView = true)]
    public class QC_MatFl_View : DbEntity
    {
        private string _PK_INVCL = "";

        public string PK_INVCL
        {
            get { return _PK_INVCL; }
            set
            {
                if (_PK_INVCL != value)
                {
                    _PK_INVCL = value;
                    RaisePropertyChanged("PK_INVCL");
                }
            }
        }

        private string _MatFlCode;
        [DbTableColumn("INVCLASSCODE")]
        public string MatFlCode
        {
            get { return _MatFlCode; }
            set
            {
                if (_MatFlCode != value)
                {
                    _MatFlCode = value;
                    RaisePropertyChanged("MatFlCode");
                }
            }
        }

        private string _MatFlName;
        [DbTableColumn("INVCLASSNAME")]
        public string MatFlName
        {
            get { return _MatFlName; }
            set
            {
                if (_MatFlName != value)
                {
                    _MatFlName = value;
                    RaisePropertyChanged("MatFlName");
                }
            }
        }

        [NonTableField]
        public string MatFlParentCode
        {
            get
            {
                if (MatFlCode.Length > 2)
                {
                    return MatFlCode.Substring(0, MatFlCode.Length - 2);
                }
                else
                    return "";
            }
        }
    }
}
