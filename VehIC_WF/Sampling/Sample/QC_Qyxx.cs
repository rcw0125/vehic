using System;
using Zhc.Data;
using System.ComponentModel;
using System.Reflection;
using System.Data;
using System.Data.Linq.Mapping;
using VehIC_WF.Sampling.czl.Class;
using VehIC_WF.Sampling.Nc;
using VehIC_WF;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace VehIC_WF.Sampling.Sample
{
    class QC_Qyxx : DbEntity
    {
        #region 主键
        private int _Qyxxid;
        /// <summary>
        /// 主键
        /// </summary>
        [DbTableColumn(IsPrimaryKey = true, AutoIncrement = true)]
        [Browsable(false)]
        public int Qyxxid
        {
            get { return _Qyxxid; }
            set
            {
                if (_Qyxxid != value)
                {
                    _Qyxxid = value;
                    RaisePropertyChanged("Qyxxid");
                }
            }
        }
        #endregion

        #region cph  车牌号
        private string _Ori_cph;
        private string _cph;

        /// <summary>
        /// 物料类型
        /// </summary> 
        [DisplayName("车牌号")]
        [DbTableColumn("cph")]
        public string cph
        {
            get { return _cph; }
            set
            {
                if (_cph != value)
                {
                    if (IsIniting) _Ori_cph = value;
                    _cph = value;
                    RaisePropertyChanged("cph", true);
                }
            }
        }
        #endregion
        #region matname  物料名称
        private string _Ori_matname;
        private string _matname;

        /// <summary>
        /// 物料类型
        /// </summary> 
        [DisplayName("物料名称")]
        [DbTableColumn("matname")]
        public string matname
        {
            get { return _matname; }
            set
            {
                if (_matname != value)
                {
                    if (IsIniting) _Ori_matname = value;
                    _matname = value;
                    RaisePropertyChanged("matname", true);
                }
            }
        }
        #endregion
        #region custname  供应商名称
        private string _Ori_custname;
        private string _custname;

        /// <summary>
        /// 物料类型
        /// </summary> 
        [DisplayName("供应商名称")]
        [DbTableColumn("custname")]
        public string custname
        {
            get { return _custname; }
            set
            {
                if (_custname != value)
                {
                    if (IsIniting) _Ori_custname = value;
                    _custname = value;
                    RaisePropertyChanged("custname", true);
                }
            }
        }
        #endregion
        #region chedao  车道
        private string _Ori_chedao;
        private string _chedao;

        /// <summary>
        /// 物料类型
        /// </summary> 
        [DisplayName("车道")]
        [DbTableColumn("chedao")]
        public string chedao
        {
            get { return _chedao; }
            set
            {
                if (_chedao != value)
                {
                    if (IsIniting) _Ori_chedao = value;
                    _chedao = value;
                    RaisePropertyChanged("chedao", true);
                }
            }
        }
        #endregion

        #region state  状态
        private Int32 _Ori_state;
        private Int32 _state;

        /// <summary>
        /// 物料类型
        /// </summary> 
        [DisplayName("状态")]
        [DbTableColumn("state")]
        public Int32 state
        {
            get { return _state; }
            set
            {
                if (_state != value)
                {
                    if (IsIniting) _Ori_state = value;
                    _state = value;
                    RaisePropertyChanged("state", true);
                }
            }
        }
        #endregion
        #region qyds  取样点数
        private Int32 _Ori_qyds;
        private Int32 _qyds;

        /// <summary>
        /// 物料类型
        /// </summary> 
        [DisplayName("取样点数")]
        [DbTableColumn("qyds")]
        public Int32 qyds
        {
            get { return _qyds; }
            set
            {
                if (_qyds != value)
                {
                    if (IsIniting) _Ori_qyds = value;
                    _qyds = value;
                    RaisePropertyChanged("qyds", true);
                }
            }
        }
        #endregion


    }
}
