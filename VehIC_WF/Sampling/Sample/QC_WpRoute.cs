using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zhc.Data;
using System.ComponentModel;

namespace Xg.Lab.Sample
{
    /// <summary>
    /// 作业点
    /// </summary>
    [DbTable("tb_WorkCenter", "wc", "wc.WCCode=wp.WPCode", JoinType = JoinType.Right)]
    [DbTable("QC_WpRoute", "wp")]
    public class QC_WpRoute : DbEntity
    {

        #region WPCode  作业点编码
        private string _Ori_WPCode = "";
        private string _WPCode = "";

        /// <summary>
        /// 作业点编码
        /// </summary> 
        [DisplayName("作业点编码")]
        [DbTableColumn(IsPrimaryKey=true)]
        public string WPCode
        {
            get { return _WPCode; }
            set
            {
                if (_WPCode != value)
                {
                    if (IsIniting) _Ori_WPCode = value;
                    _WPCode = value;
                    RaisePropertyChanged("WPCode", true);
                }
            }
        }
        #endregion

        private string _WCCode = "";
        [DbTableColumn("wc.WCCode")]
        public string WCCode
        {
            get { return _WCCode; }
            set
            {
                if (_WCCode != value)
                {
                    _WCCode = value;
                    RaisePropertyChanged("WCCode", true);
                }
            }
        }

        private string _WCName;
        [DbTableColumn("wc.WCName")]
        public string WCName
        {
            get { return _WCName; }
            set
            {
                if (_WCName != value)
                {
                    _WCName = value;
                    RaisePropertyChanged("WCName", true);
                }
            }
        }


        #region NextWPCode  下一个作业点
        private string _Ori_NextWPCode = "";
        private string _NextWPCode = "";

        /// <summary>
        /// 下一个作业点
        /// </summary> 
        [DisplayName("下一个作业点")]
        public string NextWPCode
        {
            get { return _NextWPCode; }
            set
            {
                if (_NextWPCode != value)
                {
                    if (IsIniting) _Ori_NextWPCode = value;
                    _NextWPCode = value;
                    RaisePropertyChanged("NextWPCode", true);
                }
            }
        }
        #endregion

        protected override void BeforeSave(System.Data.IDbTransaction trans)
        {
            if (string.IsNullOrEmpty(WPCode))
            {
                WPCode = WCCode;
                SetDataStateAsAdded();
            }
            base.BeforeSave(trans);
        }
    }
}
