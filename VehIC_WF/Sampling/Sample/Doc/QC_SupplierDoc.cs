using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Zhc.Data;

namespace Xg.Lab.Sample
{
   /// <summary>
   /// 供应商
   /// </summary>
    [DbTable("BD_CUBASDOC", "cust", true)]
    public class QC_SupplierDoc : DbEntity
    {
        private string _CustCode = "";
        [DisplayName("客户编码")]
        public string CustCode
        {
            get { return _CustCode; }
            set
            {
                if (_CustCode != value)
                {
                    _CustCode = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string _CustName = "";
        [DisplayName("客户名称")]
        public string CustName
        {
            get { return _CustName; }
            set
            {
                if (_CustName != value)
                {
                    _CustName = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string _CustShortName = "";
        [DisplayName("客户简称")]
        public string CustShortName
        {
            get { return _CustShortName; }
            set
            {
                if (_CustShortName != value)
                {
                    _CustShortName = value;
                    RaisePropertyChanged();
                }
            }
        }
    }
}
