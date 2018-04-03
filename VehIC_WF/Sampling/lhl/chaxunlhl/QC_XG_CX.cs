using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Zhc.Data;

namespace Xg.Lab.Sample
{
     [DbTable(TableName = "QC_XIUGAI_CX", IsView = true)]
    public class BC_XG_CX : DbEntity
    {
         public static String GetName(String id)
         {
             String name = "";
             object result = DbContext.ExecuteScalar("select PSNNAME from BD_PSNDOC where PSNCODE='" + id + "'");
             if (result != null && result != DBNull.Value)
             {
                 name = Convert.ToString(result);  //供应商编码
             }
             return name;
         }

         private string _厂家;
        /// <summary>
        // 厂家
        /// </summary>

        [System.ComponentModel.DisplayName("厂家")]
        public string 厂家
        {
            get { return _厂家; }
            set
            {
                if (_厂家 != value)
                {
                    _厂家 = value;
                    RaisePropertyChanged("厂家", true);
                }
            }
        }
        private string _煤种;
        /// <summary>
        // 煤种
        /// </summary>

        [System.ComponentModel.DisplayName("煤种")]
        public string 煤种
        {
            get { return _煤种; }
            set
            {
                if (_煤种 != value)
                {
                    _煤种 = value;
                    RaisePropertyChanged("煤种", true);
                }
            }
        }
        private string _车牌号;
        /// <summary>
        // 车牌号
        /// </summary>

        [System.ComponentModel.DisplayName("车牌号")]
        public string 车牌号
        {
            get { return _车牌号; }
            set
            {
                if (_车牌号 != value)
                {
                    _车牌号 = value;
                    RaisePropertyChanged("车牌号", true);
                }
            }
        }
        private string _检验项目;
        /// <summary>
        // 检验项目
        /// </summary>

        [System.ComponentModel.DisplayName("检验项目")]
        public string 检验项目
        {
            get { return _检验项目; }
            set
            {
                if (_检验项目 != value)
                {
                    _检验项目 = value;
                    RaisePropertyChanged("检验项目", true);
                }
            }
        }
        private string _原始值;
        /// <summary>
        // 原始值
        /// </summary>

        [System.ComponentModel.DisplayName("原始值")]
        public string 原始值
        {
            get { return _原始值; }
            set
            {
                if (_原始值 != value)
                {
                    _原始值 = value;
                    RaisePropertyChanged("原始值", true);
                }
            }
        }
        private string _修改值;
        /// <summary>
        // 修改值
        /// </summary>

        [System.ComponentModel.DisplayName("修改值")]
        public string 修改值
        {
            get { return _修改值; }
            set
            {
                if (_修改值 != value)
                {
                    _修改值 = value;
                    RaisePropertyChanged("修改值", true);
                }
            }
        }
        private string _修改原因;
        /// <summary>
        // 修改原因
        /// </summary>

        [System.ComponentModel.DisplayName("修改原因")]
        public string 修改原因
        {
            get { return _修改原因; }
            set
            {
                if (_修改原因 != value)
                {
                    _修改原因 = value;
                    RaisePropertyChanged("修改原因", true);
                }
            }
        }
        private string _修改人;
        /// <summary>
        // 修改人
        /// </summary>

        [System.ComponentModel.DisplayName("修改人")]
        public string 修改人
        {
            get { return GetName(_修改人); }
            set
            {
                if (_修改人 != value)
                {
                    _修改人 = value;
                    RaisePropertyChanged("修改人", true);
                }
            }
        }
        private DateTime? _修改时间=null;
        /// <summary>
        // 修改时间
        /// </summary>

        [System.ComponentModel.DisplayName("修改时间")]
        public DateTime? 修改时间
        {
            get { return _修改时间; }
            set
            {
                if (_修改时间 != value)
                {
                    _修改时间 = value;
                    RaisePropertyChanged("修改时间", true);
                }
            }
        }
        private DateTime? _取样时间 = null;
        /// <summary>
        // 取样时间
        /// </summary>

        [System.ComponentModel.DisplayName("取样时间")]
        public DateTime? 取样时间
        {
            get { return _取样时间; }
            set
            {
                if (_取样时间 != value)
                {
                    _取样时间 = value;
                    RaisePropertyChanged("取样时间", true);
                }
            }
        }
    }
}
