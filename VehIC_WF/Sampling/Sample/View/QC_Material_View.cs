using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zhc.Data;
using System.ComponentModel;

namespace Xg.Lab.Sample.View
{
    [DbTable("BD_INVBASDOC","main",true)]
    [DbTable("QC_Material", "mat", "mat.MatNcId=main.PK_INVBASDOC", JoinType.Left)]
    public class QC_Material_View : DbEntity
    {
        private string _PK_INVBASDOC;
        [Browsable(false)]
        public string PK_INVBASDOC
        {
            get { return _PK_INVBASDOC; }
            set
            {
                if (_PK_INVBASDOC != value)
                {
                    _PK_INVBASDOC = value;
                    RaisePropertyChanged("PK_INVBASDOC");
                }
            }
        }

        private string _InvCode = "";
        [DisplayName("物料编码")]
        public string InvCode
        {
            get { return _InvCode; }
            set
            {
                if (_InvCode != value)
                {
                    _InvCode = value;
                    RaisePropertyChanged("InvCode");
                }
            }
        }

        private string _InvName = "";
        [DisplayName("物料名称")]
        public string InvName
        {
            get { return _InvName; }
            set
            {
                if (_InvName != value)
                {
                    _InvName = value;
                    RaisePropertyChanged("InvName");
                }
            }
        }

        private bool _InUse;
        [DbTableColumn("mat.InUse")]
        public bool InUse
        {
            get { return _InUse; }
            set
            {
                if (_InUse != value)
                {
                    _InUse = value;
                    RaisePropertyChanged("InUse");
                }
            }
        }

    }
}
