using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace VehIC_WF.Sampling.Nc
{
    [Serializable]
    public class header
    {

        private string _vbatchcode = "";//{ get { return "检验批次"; } } //
        /// <summary>
        /// 检验批次
        /// </summary>
        public string vbatchcode
        {
            get { return _vbatchcode; }
            set { _vbatchcode = value; }
        }

        private string _cpraydeptid = "VEHIC";//{ get { return "VEHIC"; } }
        /// <summary>
        /// 保留
        /// </summary>
        public string cpraydeptid
        {
            get { return _cpraydeptid; }
            set
            {
                //_cpraydeptid = value;
            }
        }

        private string _cprayerid = "";//{ get { return "16988"; } }//<!-- 报检人 -->
        /// <summary>
        /// 报检人
        /// </summary>
        public string cprayerid
        {
            get { return _cprayerid; }
            set { _cprayerid = value; }
        }
        
        private string _creporterid = "";//{ get { return "02127"; } }//<!-- 报告人 -->
        /// <summary>
        /// 报告人
        /// </summary>
        public string creporterid
        {
            get { return _creporterid; }
            set { _creporterid = value; }
        }
      
        private string _cauditpsn = "";//{ get { return "09192"; } }//<!-- 审核人 -->
        /// <summary>
        /// 审核人
        /// </summary>
        public string cauditpsn
        {
            get { return _cauditpsn; }
            set { _cauditpsn = value; }
        }
   
        private string _dpraydate = "";//{ get { return "2015-04-02 10:54:46"; } }//
        /// <summary>
        /// 报检时间
        /// </summary>
        public string dpraydate
        {
            get { return _dpraydate; }
            set { _dpraydate = value; }
        }
      
        private string _dreportdate = "";//{ get { return "2015-02-10 16:38:46"; } }
        /// <summary>
        /// 报告时间
        /// </summary>
        public string dreportdate
        {
            get { return _dreportdate; }
            set { _dreportdate = value; }
        }
      
        private string _vdef18 = "";//{ get { return "4"; } }
        /// <summary>
        /// 表头扣水合计
        /// </summary>
        public string vdef18
        {
            get { return _vdef18; }
            set { _vdef18 = value; }
        }
      
        private string _vdef19 = "";//{ get { return "6"; } }
        /// <summary>
        /// 表头扣杂合计
        /// </summary>
        public string vdef19
        {
            get { return _vdef19; }
            set { _vdef19 = value; }
        }
      
        private string _vmemo = "";//{ get { return "表头备注信息"; } }
        /// <summary>
        /// 表头备注信息
        /// </summary>
        public string vmemo
        {
            get { return _vmemo; }
            set { _vmemo = value; }
        }
    }
}
