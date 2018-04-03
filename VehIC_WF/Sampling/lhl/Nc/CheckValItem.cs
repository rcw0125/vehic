using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
namespace VehIC_WF.Sampling.Nc
{
    [Serializable]
    public class CheckValItem
    {

        private string _cbaseid = "";

        public string cbaseid
        {
            get { return _cbaseid; }
            set { _cbaseid = value; }
        }


        private string _dcheckdate = "";// { get { return "2015-03-30 09:17:46"; } set { } } //<!-- 检验时间 -->
        /// <summary>
        /// 检验时间
        /// </summary>
        public string dcheckdate
        {
            get { return _dcheckdate; }
            set { _dcheckdate = value; }
        }

        public string vsamplecode { get { return "1"; } set { } } //<!-- 样本号，固定，如果有多份检化验结果时再变动。 -->
  

        public string nnum { get { return ""; } set { } } //


        private string _ccheckitemid = "";// { get { return "1001NC10000000004KX1"; } set { } } //<!-- 检验项目 -->
        /// <summary>
        /// 检验项目
        /// </summary>
        public string ccheckitemid
        {
            get { return _ccheckitemid; }
            set { _ccheckitemid = value; }
        }

        private string _ccheckstandardid = "";//{ get { return ""; } set { } } //
        /// <summary>
        /// 检验标准ID
        /// </summary>
        public string ccheckstandardid
        {
            get { return _ccheckstandardid; }
            set { _ccheckstandardid = value; }
        }

        private string _icheckstandard = "";
        
        public string icheckstandard
        {
            get { return _icheckstandard; }
            set { _icheckstandard = value; }
        }
        /// <summary>
        /// 检验结果
        /// </summary>
        private string _cresult = "";//{ get { return "0.20"; } set { } } //<!-- 检验结果 -->

        public string cresult
        {
            get { return _cresult; }
            set { _cresult = value; }
        }

        private string _ccheckerid = "";// { get { return "02127"; } set { } } //<!-- 检验员 -->
        /// <summary>
        /// 检验员
        /// </summary>
        public string ccheckerid
        {
            get { return _ccheckerid; }
            set { _ccheckerid = value; }
        }
    }
}
