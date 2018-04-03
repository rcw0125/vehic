using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zhc.Data;
namespace VehIC_WF.Sampling.Sample
{
    class TB_TaskFlow : DbEntity
    {

        private string _ID;
        [DbTableColumn(IsPrimaryKey = true)]
        public string ID
        {
            get { return _ID; }
            set
            {
                if (_ID != value)
                {
                    _ID = value;
                    RaisePropertyChanged("ID", true);
                  
                }
            }
        }

        private string _NoticeID;

        public string NoticeID
        {
            get { return _NoticeID; }
            set
            {
                if (_NoticeID != value)
                {
                    _NoticeID = value;
                    RaisePropertyChanged("NoticeID", true);
                }
            }
        }
        private string _NoticeItemID;

        public string NoticeItemID
        {
            get { return _NoticeItemID; }
            set
            {
                if (_NoticeItemID != value)
                {
                    _NoticeItemID = value;
                    RaisePropertyChanged("NoticeItemID", true);
                }
            }
        }
        private int _XH;

        public int XH
        {
            get { return _XH; }
            set
            {
                if (_XH != value)
                {
                    _XH = value;
                    RaisePropertyChanged("XH", true);
                }
            }
        }
        private string _WCCode;

        public string WCCode
        {
            get { return _WCCode; }
            set
            {
                if (_WCCode != value)
                {
                    _WCCode = value;
                    RaisePropertyChanged("WCCode", true);
                }
            }
               
        }
        private string _OperatorID;

        public string OperatorID
        {
            get { return _OperatorID; }
            set
            {
                if (_OperatorID != value)
                {
                    _OperatorID = value;
                    RaisePropertyChanged("OperatorID", true);
                }
            }
        }
              
        
        private string  _BeginTime;

        public string BeginTime
        {
            get { return _BeginTime; }
            set
            {
                if (_BeginTime != value)
                {
                    _BeginTime = value;
                    RaisePropertyChanged("BeginTime", true);
                }
            }
        }
        private string _EndTime;

        public string EndTime
        {
            get { return _EndTime; }
            set
            {
                if (_EndTime != value)
                {
                    _EndTime = value;
                    RaisePropertyChanged("EndTime", true);
                }
            }
        }
        private string _Result;

        public string Result
        {
            get { return _Result; }
            set
            {
                if (_Result != value)
                {
                    _Result = value;
                    RaisePropertyChanged("Result", true);
                }
            }
        }
                private int _Status;

        public int  Status
        {
            get { return _Status; }
            set
            {
                if (_Status != value)
                {
                    _Status = value;
                    RaisePropertyChanged("Status", true);
                }
            }
        }

          

    }
}
