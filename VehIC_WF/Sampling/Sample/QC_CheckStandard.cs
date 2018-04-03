using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zhc.Data;
namespace Xg.Lab.Sample
{
    /// <summary>
    /// 检化验标准
    /// </summary>
    public class QC_CheckStandard : DbEntity
    {

        private string _CheckStandardNcId;
        /// <summary>
        /// 检化验标准ID
        /// </summary>
        [DbTableColumn(IsPrimaryKey = true)]
        public string CheckStandardNcId
        {
            get { return _CheckStandardNcId; }
            set
            {
                if (_CheckStandardNcId != value)
                {
                    _CheckStandardNcId = value;
                    RaisePropertyChanged("CheckStandardCode", true);
                }
            }
        }

        private string _CheckItemNcId;
        /// <summary>
        /// 检化验项目ID
        /// </summary>
        [DbTableColumn(IsPrimaryKey = true)]
        public string CheckItemNcId
        {
            get { return _CheckItemNcId; }
            set
            {
                if (_CheckItemNcId != value)
                {
                    _CheckItemNcId = value;
                    RaisePropertyChanged("CheckItemCode", true);
                }
            }
        }

    }
}
