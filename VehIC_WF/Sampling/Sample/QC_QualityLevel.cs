using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zhc.Data;
namespace Xg.Lab.Sample
{
    /// <summary>
    /// 质量等级
    /// </summary>
    public class QC_QualityLevel:DbEntity
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

        private string _QualityLevelID;
        /// <summary>
        /// 质量等级项NC主键
        /// </summary>
        [DbTableColumn(IsPrimaryKey = true)]
        public string QualityLevelID
        {
            get { return _QualityLevelID; }
            set
            {
                if (_QualityLevelID != value)
                {
                    _QualityLevelID = value;
                    RaisePropertyChanged("QualityLevelID", true);
                }
            }
        }

        private string _QualityLevelCode;
        /// <summary>
        /// 质量等级项编码
        /// </summary>
        public string QualityLevelCode
        {
            get { return _QualityLevelCode; }
            set
            {
                if (_QualityLevelCode != value)
                {
                    _QualityLevelCode = value;
                    RaisePropertyChanged("QualityLevelCode", true);
                }
            }
        }


        private string _QualityLevelName;
        /// <summary>
        /// 质量等级项名称
        /// </summary>
        public string QualityLevelName
        {
            get { return _QualityLevelName; }
            set
            {
                if (_QualityLevelName != value)
                {
                    _QualityLevelName = value;
                    RaisePropertyChanged("QualityLevelName", true);
                }
            }
        }

    }
}
