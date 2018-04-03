using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Text;
using Zhc.Data;
namespace VehIC_WF.Sampling.Sample
{
    class QC_Sample_Qyd : DbEntity
    {  
        #region 主键
        private int _Sample_Qyd_ID;
        /// <summary>
        /// 主键
        /// </summary>
        [DbTableColumn(IsPrimaryKey = true, AutoIncrement = true)]
        [Browsable(false)]
        public int Sample_Qyd_ID
        {
            get { return _Sample_Qyd_ID; }
            set
            {
                if (_Sample_Qyd_ID != value)
                {
                    _Sample_Qyd_ID = value;
                    RaisePropertyChanged("Sample_Qyd_ID");
                }
            }
        }
        #endregion
        #region noticeid  作业单号
        private string _Ori_noticeid;
        private string _noticeid;

       
        [DisplayName("作业单号")]
        public string noticeid
        {
            get { return _noticeid; }
            set
            {
                if (_noticeid != value)
                {
                    if (IsIniting) _Ori_noticeid = value;
                    _noticeid = value;
                    RaisePropertyChanged("noticeid", true);
                }
            }
        }
        #endregion

        #region zptime  组批时间
        private string _Ori_zptime;
        private string _zptime;

        [DisplayName("组批时间")]
        public string zptime
        {
            get { return _zptime; }
            set
            {
                if (_zptime != value)
                {
                    if (IsIniting) _Ori_zptime = value;
                    _zptime = value;
                    RaisePropertyChanged("zptime", true);
                }
            }
        }
        #endregion
        #region zpdh  组批单号
        private string _Ori_zpdh;
        private string _zpdh;

        /// <summary>
        /// 物料类型
        /// </summary> 
        [DisplayName("组批单号")]
        public string zpdh
        {
            get { return _zpdh; }
            set
            {
                if (_zpdh != value)
                {
                    if (IsIniting) _Ori_zpdh = value;
                    _zpdh = value;
                    RaisePropertyChanged("zpdh", true);
                }
            }
        }
        #endregion
        #region rwdtime  取样单时间
        private string _Ori_qydtime;
        private string _qydtime;

        /// <summary>
        /// 物料类型
        /// </summary> 
        [DisplayName("取样单时间")]
        public string qydtime
        {
            get { return _qydtime; }
            set
            {
                if (_qydtime != value)
                {
                    if (IsIniting) _Ori_qydtime = value;
                    _qydtime = value;
                    RaisePropertyChanged("qydtime", true);
                }
            }
        }
        #endregion
        #region qydh  取样单号
        private string _Ori_qydh;
        private string _qydh;

        /// <summary>
        /// 物料类型
        /// </summary> 
        [DisplayName("任务单号")]
        public string qydh
        {
            get { return _qydh; }
            set
            {
                if (_qydh != value)
                {
                    if (IsIniting) _Ori_qydh = value;
                    _qydh = value;
                    RaisePropertyChanged("qydh", true);
                }
            }
        }
        #endregion
        #region begintime  进门时间
        private string _Ori_begintime;
        private string _begintime;

        /// <summary>
        /// 物料类型
        /// </summary> 
        [DisplayName("物料类型")]
        public string begintime
        {
            get { return _begintime; }
            set
            {
                if (_begintime != value)
                {
                    if (IsIniting) _Ori_begintime = value;
                    _begintime = value;
                    RaisePropertyChanged("begintime", true);
                }
            }
        }
        #endregion

        #region SupplierCode  供应商编码
        private string _Ori_SupplierCode = "";
        private string _SupplierCode = "";

        /// <summary>
        /// 供应商编码
        /// </summary> 
        [DisplayName("供应商编码")]
        public string SupplierCode
        {
            get { return _SupplierCode; }
            set
            {
                if (_SupplierCode != value)
                {
                    if (IsIniting) _Ori_SupplierCode = value;
                    _SupplierCode = value;
                    RaisePropertyChanged("SupplierCode", true);
                }
            }
        }
        #endregion

        #region SupplierName  供应商名称
        private string _SupplierName = "";

        /// <summary>
        /// 供应商名称
        /// </summary> 
        [DisplayName("供应商名称")]
      
        public string SupplierName
        {
            get { return _SupplierName; }
            set
            {
                if (_SupplierName != value)
                {
                    _SupplierName = value;
                    RaisePropertyChanged("SupplierName");
                }
            }
        }
        #endregion

        #region MatPK  物料主键
        private string _Ori_MatPK = "";
        private string _MatPK = "";

        /// <summary>
        /// 物料主键
        /// </summary> 
        [DisplayName("物料主键")]
        public string MatPK
        {
            get { return _MatPK; }
            set
            {
                if (_MatPK != value)
                {
                    if (IsIniting) _Ori_MatPK = value;
                    _MatPK = value;
                    RaisePropertyChanged("MatPK", true);
                }
            }
        }
        #endregion

        #region MatCode  物料编码
        private string _Ori_MatCode = "";
        private string _MatCode = "";

        /// <summary>
        /// 物料编码
        /// </summary> 
        [DisplayName("物料编码")]
        public string MatCode
        {
            get { return _MatCode; }
            set
            {
                if (_MatCode != value)
                {
                    if (IsIniting) _Ori_MatCode = value;
                    _MatCode = value;
                    RaisePropertyChanged("MatCode", true);
                }
            }
        }
        #endregion

        #region MatName  物料名称

        private string _MatName = "";
        /// <summary>
        /// 物料名称
        /// </summary> 
        [DisplayName("物料名称")]
       
        public string MatName
        {
            get { return _MatName; }
            set
            {
                if (_MatName != value)
                {
                    _MatName = value;
                    RaisePropertyChanged("MatName");
                }
            }
        }
        #endregion
        #region koushui  扣水

        private double? _koushui;
        /// <summary>
        /// 扣水
        /// </summary> 
        [DisplayName("扣水")]

        public double? koushui
        {
            get { return _koushui; }
            set
            {
                if (_koushui != value)
                {
                    _koushui = value;
                    RaisePropertyChanged("koushui");
                }
            }
        }
        #endregion
        #region kouza  扣杂

        private double? _kouza ;
        /// <summary>
        ///扣杂
        /// </summary> 
        [DisplayName("扣杂")]

        public double? kouza
        {
            get { return _kouza; }
            set
            {
                if (_kouza != value)
                {
                    _kouza = value;
                    RaisePropertyChanged("kouza");
                }
            }
        }
        #endregion
























    }
}
