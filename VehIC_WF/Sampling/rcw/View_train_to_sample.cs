using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Zhc.Data;

namespace VehIC_WF.Sampling.rcw
{
    [DbTable(IsView = true,TableName = "View_train_unload")]
  public  class View_train_to_sample : DbEntity
    {
        [DisplayName("id")]
        public string matchid { get; set; }

        [DisplayName("发站")]
        public string FAZHAN { get; set; }
        [DisplayName("物料名称")]
        public string WLMC { get; set; }
        [DisplayName("火车皮号")]
        public string HCPH { get; set; }
      
        [DisplayName("车厢号")]
        public string CPH { get; set; }
      
        [DisplayName("计毛时刻")]
        public string GROSSTIME { get; set; }
        //[DisplayName("勾选")]
        //public bool xuanze { get; set; }
        //public string TARE { get; set; }
        //public DateTime TARETIME { get; set; }
        //public string CPCX { get; set; }
        //public string GROSS { get; set; }
        //public DateTime ZDSJ{get;set; }
    }

    [DbTable(IsView = true)]
    public class View_train : DbEntity
    {       
        [DisplayName("火车皮号")]
        public string Cardid { get; set; }

    }

    [DbTable(IsView = true,TableName = "View_train_arrivebill")]
    public class View_arrivebill : DbEntity
    {
        [DisplayName("到货单号")]
        public string varrordercode { get; set; }
        [DisplayName("运输方式")]
        public string vdef3 { get; set; }
        [DisplayName("区域")]
        public string vdef4 { get; set; }
        [DisplayName("发站")]
        public string vdef5 { get; set; }

        [DisplayName("物料编码")]
        public string invcode { get; set; }
        [DisplayName("物料名")]
        public string invname { get; set; }
        [DisplayName("日期")]
        public string dreceivedate { get; set; }

        [DisplayName("供应商编码")]
        public string custcode { get; set; }

        [DisplayName("供应商")]
        public string custname { get; set; }
        [DisplayName("供应商id")]
        public string cdeptid { get; set; }
        [DisplayName("吨数")]
        public string vmemo { get; set; }
        [DisplayName("采购部门")]
        public string deptname { get; set; }
        [DisplayName("采购员")]
        public string user_name { get; set; }
        [DisplayName("制单日期")]
        public string tmaketime { get; set; }
        
        public string cauditpsn { get; set; }
      
        public string taudittime { get; set; }
        public string dauditdate { get; set; }
        public string bodymemo { get; set; }
        public string cbaseid { get; set; }
        public string cvendorbaseid { get; set; }
        public string cemployeeid { get; set; }
        public string coperator { get; set; }
       

    }
}
