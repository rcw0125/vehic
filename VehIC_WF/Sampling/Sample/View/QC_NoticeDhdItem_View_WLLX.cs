using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VehIC_WF.Sampling.czl;
using VehIC_WF.Sampling.Sample;
using Zhc.Data;


namespace VehIC_WF.Sampling.Sample.View
{
    [DbTable(IsView = true)]


    class QC_NoticeDhdItem_View_WLLX : DbEntity
    {
   
        
        private string _NoticeId = "";

        public string NoticeId
        {
            get { return _NoticeId; }
            set { _NoticeId = value; }
        }

        private string _cph = "";
        /// <summary>
        /// 车牌号
        /// </summary>
        public string Cph
        {
            get { return _cph; }
            set { _cph = value; }
        }
        private string _icno = "";
        /// <summary>
        /// 车卡号
        /// </summary>
        public string icno
        {
            get { return _icno; }
            set { _icno = value; }
        }
        private string _NoticeBodyId = "";

        public string NoticeBodyId
        {
            get { return _NoticeBodyId; }
            set { _NoticeBodyId = value; }
        }

        private string _NcDhdHeadNo = "";

        public string NcDhdHeadNo
        {
            get { return _NcDhdHeadNo; }
            set { _NcDhdHeadNo = value; }
        }
        private string _NcDhdBodyId = "";

        public string NcDhdBodyId
        {
            get { return _NcDhdBodyId; }
            set { _NcDhdBodyId = value; }
        }

        private string _PK_INVBASDOC = "";
        /// <summary>
        /// 物料主键
        /// </summary>
        public string PK_INVBASDOC
        {
            get { return _PK_INVBASDOC; }
            set { _PK_INVBASDOC = value; }
        }

        private string _INVCODE = "";
        /// <summary>
        /// 物料编码
        /// </summary>
        public string INVCODE
        {
            get { return _INVCODE; }
            set { _INVCODE = value; }
        }

        private string _INVNAME = "";
        /// <summary>
        /// 物料名称
        /// </summary>
        public string INVNAME
        {
            get { return _INVNAME; }
            set { _INVNAME = value; }
        }


        private string _PK_CUBASDOC = "";
        /// <summary>
        /// 供应商主键
        /// </summary>
        public string PK_CUBASDOC
        {
            get { return _PK_CUBASDOC; }
            set { _PK_CUBASDOC = value; }
        }

        private string _CUSTCODE = "";
        /// <summary>
        /// 供应商编码
        /// </summary>
        public string CUSTCODE
        {
            get { return _CUSTCODE; }
            set { _CUSTCODE = value; }
        }

        private string _CUSTNAME = "";
        /// <summary>
        /// 供应商名称
        /// </summary>
        public string CUSTNAME
        {
            get { return _CUSTNAME; }
            set { _CUSTNAME = value; }
        }

        private string _CUSTSHORTNAME = "";
        /// <summary>
        /// 供应商简称
        /// </summary>
        public string CUSTSHORTNAME
        {
            get { return _CUSTSHORTNAME; }
            set
            {
                _CUSTSHORTNAME = value;
            }
        }

        private double? _sjsl = null;
        /// <summary>
        /// 计量净重
        /// </summary>
        public double? Sjsl
        {
            get { return _sjsl; }
            set { _sjsl = value; }
        }

        private double? _w1 = null;
        /// <summary>
        /// 计量毛重
        /// </summary>
        public double? W1
        {
            get { return _w1; }
            set { _w1 = value; }
        }

        private double? _w2 = null;
        /// <summary>
        /// 计量皮重
        /// </summary>
        public double? W2
        {
            get { return _w2; }
            set { _w2 = value; }
        }

        private string _t1 = "";
        /// <summary>
        /// 计量毛重时间
        /// </summary>
        public string T1
        {
            get { return _t1; }
            set { _t1 = value; }
        }

        private string _t2 = "";
        /// <summary>
        /// 计量皮重时间
        /// </summary>
        public string T2
        {
            get { return _t2; }
            set { _t2 = value; }
        }
        private int? _status = null;
        /// <summary>
        ///状态
        /// </summary>
        public int? Status
        {
            get { return _status; }
            set { _status = value; }
        }
        private string _WLLX = "";
       
        public string WLLX
        {
            get { return _WLLX; }
            set { _WLLX = value; }
        }
        private string _begintime = "";

        public string begintime
        {
            get { return _begintime; }
            set { _begintime = value; }
        }
    }
}
