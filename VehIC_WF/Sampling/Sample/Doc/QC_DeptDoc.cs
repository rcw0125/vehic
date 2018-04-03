using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zhc.Data;

namespace Xg.Lab.Sample
{
    [DbTable("BD_Dept", "dept", true)]
    public class QC_DeptDoc : DbEntity
    {
        private string _DeptCode = "";
        [DisplayName("部门编码")]
        public string DeptCode
        {
            get { return _DeptCode; }
            set
            {
                if (_DeptCode != value)
                {
                    _DeptCode = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string _DeptName;
        [DisplayName("部门名称")]
        public string DeptName
        {
            get { return _DeptName; }
            set
            {
                if (_DeptName != value)
                {
                    _DeptName = value;
                    RaisePropertyChanged();
                }
            }
        }
    }
}
