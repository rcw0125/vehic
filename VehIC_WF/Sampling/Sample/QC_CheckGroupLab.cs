using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zhc.Data;

namespace Xg.Lab.Sample
{
    [DbTable(IsView = true)]
    public class QC_CheckGroupLab : DbEntity
    {
        private string _CheckGroupName = "";

        public string CheckGroupName
        {
            get { return _CheckGroupName; }
            set
            {
                if (_CheckGroupName != value)
                {
                    _CheckGroupName = value;
                    RaisePropertyChanged("CheckGroupName");
                }
            }
        }

        private string _YpDanHao = "";

        public string YpDanHao
        {
            get { return _YpDanHao; }
            set
            {
                if (_YpDanHao != value)
                {
                    _YpDanHao = value;
                    RaisePropertyChanged("YpDanHao");
                }
            }
        }

        private string _SendUser = "";

        public string SendUser
        {
            get { return _SendUser; }
            set
            {
                if (_SendUser != value)
                {
                    _SendUser = value;
                    RaisePropertyChanged("SendUser");
                }
            }
        }

        private DateTime? _SendTime = null;

        public DateTime? SendTime
        {
            get { return _SendTime; }
            set
            {
                if (_SendTime != value)
                {
                    _SendTime = value;
                    RaisePropertyChanged("SendTime");
                }
            }
        }

        private string _JyCode = "";

        public string JyCode
        {
            get { return _JyCode; }
            set
            {
                if (_JyCode != value)
                {
                    _JyCode = value;
                    RaisePropertyChanged("JyCode");
                }
            }
        }

        private string _JyUser="";

        public string JyUser
        {
            get { return _JyUser; }
            set
            {
                if (_JyUser != value)
                {
                    _JyUser = value;
                    RaisePropertyChanged("JyUser");
                }
            }
        }


        private DateTime? _JyTime = null;

        public DateTime? JyTime
        {
            get { return _JyTime; }
            set
            {
                if (_JyTime != value)
                {
                    _JyTime = value;
                    RaisePropertyChanged("JyTime");
                }
            }
        }

        private string _LabState="";
        /// <summary>
        /// 检验状态
        /// </summary>
        public string LabState
        {
            get { return _LabState; }
            set
            {
                if (_LabState != value)
                {
                    _LabState = value;
                    RaisePropertyChanged("LabState");
                }
            }
        }

    }
}
