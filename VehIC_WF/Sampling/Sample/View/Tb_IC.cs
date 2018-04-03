using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zhc.Data;
namespace VehIC_WF.Sampling.Sample.View
{
    [DbTable(IsView = true)]
    public class Tb_IC : DbEntity
    {
        private string _ICNo = "";

        public string ICNo
        {
            get { return _ICNo; }
            set
            {
                if (_ICNo != value)
                {
                    _ICNo = value;
                    RaisePropertyChanged("ICNo");
                }
            }
        }

        private string _CardNo = "";

        public string CardNo
        {
            get { return _CardNo; }
            set
            {
                if (_CardNo != value)
                {
                    _CardNo = value;
                    RaisePropertyChanged("CardNo");
                }
            }
        }

        //private string _Djh = "";

        //public string Djh
        //{
        //    get { return _Djh; }
        //    set
        //    {
        //        if (_Djh != value)
        //        {
        //            _Djh = value;
        //            RaisePropertyChanged("Djh");
        //        }
        //    }
        //}

        //private DateTime? _RegTime;

        //public DateTime? RegTime
        //{
        //    get { return _RegTime; }
        //    set
        //    {
        //        if (_RegTime != value)
        //        {
        //            _RegTime = value;
        //            RaisePropertyChanged("RegTime");
        //        }
        //    }
        //}

        //private string _RegUser = "";

        //public string RegUser
        //{
        //    get { return _RegUser; }
        //    set
        //    {
        //        if (_RegUser != value)
        //        {
        //            _RegUser = value;
        //            RaisePropertyChanged("RegUser");
        //        }
        //    }
        //}

        //private int _Status;

        //public int Status
        //{
        //    get { return _Status; }
        //    set
        //    {
        //        if (_Status != value)
        //        {
        //            _Status = value;
        //            RaisePropertyChanged("Status");
        //        }
        //    }
        //}

        //private int _IcType;

        //public int IcType
        //{
        //    get { return _IcType; }
        //    set
        //    {
        //        if (_IcType != value)
        //        {
        //            _IcType = value;
        //            RaisePropertyChanged("IcType");
        //        }
        //    }
        //}

        public static Tb_IC GetByICNo(string id)
        {
            DbEntityTable<Tb_IC> ds = new DbEntityTable<Tb_IC>();
            ds.LoadDataByWhere("ICNo=@ICNo", id);

            if (ds.Count > 0)
                return ds[0];
            else
                return null;
        }

    }
}
