using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
namespace VehIC_WF.Sampling.Nc
{
    [Serializable]
    public class VehItem
    {

        private string _csourcebillcode = "";
        /// <summary>
        /// <!-- 到货单号 -->
        /// </summary>
        public string csourcebillcode
        {
            get { return _csourcebillcode; }
            set { _csourcebillcode = value; }
        }

        private string _csourcebillrowid = ""; //{ get { return "1001NC100000005634XY"; } set { } } //<!-- 到货单表体行ID -->
        /// <summary>
        ///  到货单表体行ID
        /// </summary>
        public string csourcebillrowid
        {
            get { return _csourcebillrowid; }
            set { _csourcebillrowid = value; }
        }


        private string _cbaseid = "";// { get { return "CHDA0000000000009348"; } set { } } //<!-- 暂时保留 存货ID-->
        /// <summary>
        /// 暂时保留 存货ID
        /// </summary>
        public string cbaseid
        {
            get { return _cbaseid; }
            set { _cbaseid = value; }
        }


        private string _ccheckstate_bid = "";
        /// <summary>
        /// 判定结果主键
        /// </summary>
        public string ccheckstate_bid
        {
            get { return _ccheckstate_bid; }
            set { _ccheckstate_bid = value; }
        }

        private string _vdef1 = "";
        /// <summary>
        /// 车牌号
        /// </summary>
        public string vdef1
        {
            get { return _vdef1; }
            set { _vdef1 = value; }
        }


        private string _vdef2 = "";
        /// <summary>
        /// 计量毛重日期
        /// </summary>
        public string vdef2
        {
            get { return _vdef2; }
            set { _vdef2 = value; }
        }

        private string _vdef4 = "";
        /// <summary>
        /// 计量皮重日期
        /// </summary>
        public string vdef4
        {
            get { return _vdef4; }
            set { _vdef4 = value; }
        }

        private string _vdef7 = "";
        /// <summary>
        /// 计量毛重时间
        /// </summary>
        public string vdef7
        {
            get { return _vdef7; }
            set { _vdef7 = value; }
        }

        private string _vdef8 = "";
        /// <summary>
        /// 计量皮重时间
        /// </summary>
        public string vdef8
        {
            get { return _vdef8; }
            set { _vdef8 = value; }
        }

        private string _vdef9 = "";
        /// <summary>
        /// 计量净重
        /// </summary>
        public string vdef9
        {
            get { return _vdef9; }
            set { _vdef9 = value; }
        }


        private string _vdef10 = "";
        /// <summary>
        /// 单车扣水
        /// </summary>
        public string vdef10
        {
            get { return _vdef10; }
            set { _vdef10 = value; }
        }

        private string _vdef11 = "";
        /// <summary>
        /// 单车扣杂
        /// </summary>
        public string vdef11
        {
            get { return _vdef11; }
            set { _vdef11 = value; }
        }

        private string _vmemo = "";
        /// <summary>
        /// 表体行备注
        /// </summary>
        public string vdef18
        {
            get { return _vmemo; }
            set { _vmemo = value; }
        }

        private string _vstobatchcode = "";
        /// <summary>
        /// 暂时保留，入库批次号
        /// </summary>
        public string vstobatchcode
        {
            get { return _vstobatchcode; }
            set { _vstobatchcode = value; }
        }
    }
}
