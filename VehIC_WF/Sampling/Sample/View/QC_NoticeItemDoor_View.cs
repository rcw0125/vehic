using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zhc.Data;
namespace Xg.Lab.Sample.View
{
    [DbTable(IsView = true, IsDistinct = true)]
    public class QC_NoticeItemDoor_View : DbEntity
    {
        private string _NoticeId = "";

        public string NoticeId
        {
            get { return _NoticeId; }
            set
            {
                if (_NoticeId != value)
                {
                    _NoticeId = value;
                    RaisePropertyChanged();
                }
            }
        }
        private string _cph = "";

        public string Cph
        {
            get { return _cph; }
            set
            {
                _cph = value;
            }
        }
        private string _NoticeBodyId = "";

        public string NoticeBodyId
        {
            get { return _NoticeBodyId; }
            set { _NoticeBodyId = value; }
        }
        private string _NcDhdHeadNo = "";

        public string NcDhdHeadNo
        {
            get { return _NcDhdHeadNo; }
            set { _NcDhdHeadNo = value; }
        }
        private string _NcDhdBodyId = "";

        public string NcDhdBodyId
        {
            get { return _NcDhdBodyId; }
            set { _NcDhdBodyId = value; }
        }

        public string PK_CUBASDOC { get; set; }



        private string _CUSTCODE = "";

        public string CUSTCODE
        {
            get { return _CUSTCODE; }
            set { _CUSTCODE = value; }
        }
        private string _CUSTNAME = "";

        public string CUSTNAME
        {
            get { return _CUSTNAME; }
            set { _CUSTNAME = value; }
        }
        private string _INVCODE = "";

        public string PK_INVBASDOC { get; set; }

        public string INVCODE
        {
            get { return _INVCODE; }
            set { _INVCODE = value; }
        }
        private string _INVNAME = "";

        public string INVNAME
        {
            get { return _INVNAME; }
            set { _INVNAME = value; }
        }

        private string _InTime = "";

        public string InTime
        {
            get { return _InTime; }
            set
            {
                if (_InTime != value)
                {
                    _InTime = value;
                    RaisePropertyChanged("InTime");
                }
            }
        }

        private string _OutTime = "";

        public string OutTime
        {
            get { return _OutTime; }
            set
            {
                if (_OutTime != value)
                {
                    _OutTime = value;
                    RaisePropertyChanged("OutTime");
                }
            }
        }

        [NonTableField]
        public DateTime QuYangTime
        {
            get
            {
                DateTime t1 = DateTime.Now.AddMinutes(-10);
                if (!string.IsNullOrEmpty(InTime))
                    DateTime.TryParse(InTime, out t1);

                DateTime t2 = DateTime.Now;
                if (!string.IsNullOrEmpty(OutTime))
                    DateTime.TryParse(InTime, out t2);

                DateTime result = t1.AddSeconds((t2 - t1).TotalSeconds / 2);
                return result;
            }
        }
    }
}
