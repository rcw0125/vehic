using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zhc.Data;

namespace Xg.Lab.Sample
{
    public class QC_ChgWater : DbEntity
    {
        private int _ChgWaterId;
        [DbTableColumn(IsPrimaryKey = true, AutoIncrement = true)]
        public int ChgWaterId
        {
            get { return _ChgWaterId; }
            set
            {
                if (_ChgWaterId != value)
                {
                    _ChgWaterId = value;
                    RaisePropertyChanged("ChgWaterId");
                }
            }
        }

        private string _MatNcId;

        public string MatNcId
        {
            get { return _MatNcId; }
            set
            {
                if (_MatNcId != value)
                {
                    _MatNcId = value;
                    RaisePropertyChanged("MatNcId", true);
                }
            }
        }
        
        private string _CustCode;

        public string CustCode
        {
            get { return _CustCode; }
            set
            {
                if (_CustCode != value)
                {
                    _CustCode = value;
                    RaisePropertyChanged("CustCode", true);
                }
            }
        }

        private double? _ChgWater;

        public double? ChgWater
        {
            get { return _ChgWater; }
            set
            {
                if (_ChgWater != value)
                {
                    _ChgWater = value;
                    RaisePropertyChanged("ChgWater", true);
                }
            }
        }

        public static QC_ChgWater GetByMatCust(string matNcId, string custCode)
        {
            DbEntityTable<QC_ChgWater> table = new DbEntityTable<QC_ChgWater>();
            table.LoadDataByWhere("MatNcId=@MatNcId and CustCode=@CustCode", matNcId, custCode);
            if (table.Count > 0)
                return table[0];
            else
                return null;
        }
    }
}
