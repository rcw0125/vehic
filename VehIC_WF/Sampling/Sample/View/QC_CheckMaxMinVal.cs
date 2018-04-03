using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zhc.Data;

namespace Xg.Lab.Sample
{
    [DbTable(IsView=true)]
    public class QC_CheckMaxMinVal : DbEntity
    {

        private double _MaxVal=0;

        public double MaxVal
        {
            get { return _MaxVal; }
            set
            {
                if (_MaxVal != value)
                {
                    _MaxVal = value;
                    RaisePropertyChanged("MaxVal");
                }
            }
        }

        private double _MinVal=0;

        public double MinVal
        {
            get { return _MinVal; }
            set
            {
                if (_MinVal != value)
                {
                    _MinVal = value;
                    RaisePropertyChanged("MinVal");
                }
            }
        }

        /// <summary>
        /// 获取报检批次数量
        /// </summary>
        public static int GetBatchNum(string rq, string supplierCode, string matNcId)
        {
            object count = DbContext.ExecuteScalar("Select Count(*) From QC_Sample_Mix Where convert(varchar(10),Mix_Time,120)=@rq and SUPPLIERCODE=@SUPPLIERCODE and MATPK=@MATPK and SampleType=@SampleType", rq, supplierCode, matNcId, (int)SampleType.普通样);
           return Convert.ToInt32(count);
        }

        /// <summary>
        /// 获取报检批次化验完成数量
        /// </summary>
        public static int GetCheckFinishBatchNum(string rq, string supplierCode, string matNcId)
        {
            object count = DbContext.ExecuteScalar("Select Count(*) From QC_Sample_Mix Where convert(varchar(10),Mix_Time,120)=@rq and SUPPLIERCODE=@SUPPLIERCODE and MATPK=@MATPK and SampleType=@SampleType and SampleState>=@SampleState", rq, supplierCode, matNcId, (int)SampleType.普通样, (int)SampleState.制样完成);
            return Convert.ToInt32(count);
        }

        public static QC_CheckMaxMinVal GetMaxMinVal(string rq, string supplierCode, string matNcId)
        {
            
            DbEntityTable<QC_CheckMaxMinVal> table = new DbEntityTable<QC_CheckMaxMinVal>();
            table.LoadDataBySql("select max(cast(CheckVal as float)) as MaxVal,min(cast(CheckVal as float)) as MinVal from QC_MixSampleValue_V where SampleState>=" + (int)SampleState.化验审核完成 + " and SampleType=" + (int)SampleType.普通样 + " and CHECKITEMCODE='10001' and checkVal<>'' and convert(varchar(10),Mix_Time,120)=@rq and SUPPLIERCODE=@SUPPLIERCODE and MATPK=@MATPK", rq, supplierCode, matNcId);
            if (table.Count > 0)
                return table[0];
            else
                return null;
        }
    }
}
