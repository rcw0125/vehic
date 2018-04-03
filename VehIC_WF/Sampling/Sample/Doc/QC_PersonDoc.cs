using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Zhc.Data;
namespace Xg.Lab.Sample
{
    /// <summary>
    /// 用户
    /// </summary>
    [DbTable("BD_Dept", "dept", "dept.PK_DEPTDOC=psn.PK_DEPTDOC", JoinType.Left)]
    [DbTable("BD_PSNDOC", "psn", true)]
    public class QC_PersonDoc : DbEntity
    {
        private string _PsnCode = "";
        [DisplayName("人员编码")]
        public string PsnCode
        {
            get { return _PsnCode; }
            set
            {
                if (_PsnCode != value)
                {
                    _PsnCode = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string _UserName = "";
        [DisplayName("人员名称")]
        public string PsnName
        {
            get { return _UserName; }
            set
            {
                if (_UserName != value)
                {
                    _UserName = value;
                    RaisePropertyChanged();
                }
            }
        }

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
