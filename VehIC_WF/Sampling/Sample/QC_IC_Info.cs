using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zhc.Data;
using System.ComponentModel;

namespace Xg.Lab.Sample
{
    /// <summary>
    /// 磁卡档案
    /// </summary>
    public class QC_IC_Info : DbEntity
    {
        private string _CardID;
        [DisplayName("磁卡号")]
        [DbTableColumn(IsPrimaryKey = true)]
        public string CardID
        {
            get { return _CardID; }
            set
            {
                if (_CardID != value)
                {
                    _CardID = value;
                    RaisePropertyChanged("CardID", true);
                }
            }
        }

        private string _CardType;
        [DisplayName("磁卡使用类型")]
        public string CardType
        {
            get { return _CardType; }
            set
            {
                if (_CardType != value)
                {
                    _CardType = value;
                    RaisePropertyChanged("CardType", true);
                }
            }
        }

        private string _RegUser;
        [DisplayName("注册用户")]
        public string RegUser
        {
            get { return _RegUser; }
            set
            {
                if (_RegUser != value)
                {
                    _RegUser = value;
                    RaisePropertyChanged("RegUser", true);
                }
            }
        }

        private DateTime? _RegTime;
        [DisplayName("注册时间")]
        public DateTime? RegTime
        {
            get { return _RegTime; }
            set
            {
                if (_RegTime != value)
                {
                    _RegTime = value;
                    RaisePropertyChanged("RegTime", true);
                }
            }
        }

        private int _SampleId;
        [DisplayName("样品主键")]
        public int SampleId
        {
            get { return _SampleId; }
            set
            {
                if (_SampleId != value)
                {
                    _SampleId = value;
                    RaisePropertyChanged("SampleId", true);
                    RaisePropertyChanged("IsBingingBill");
                }
            }
        }

        [NonTableField]
        [DisplayName("是否绑定单据")]
        public bool IsBingingBill
        {
            get { return SampleId > 0; }
            set { }
        }

        #region BindCardUser  刷卡人
        private string _Ori_BindCardUser = "";
        private string _BindCardUser = "";

        /// <summary>
        /// 刷卡人
        /// </summary> 
        [DisplayName("刷卡人")]
        public string BindCardUser
        {
            get { return _BindCardUser; }
            set
            {
                if (_BindCardUser != value)
                {
                    if (IsIniting) _Ori_BindCardUser = value;
                    _BindCardUser = value;
                    RaisePropertyChanged("BindCardUser", true);
                }
            }
        }
        #endregion

        #region BindCardTime  刷卡时间
        private DateTime? _Ori_BindCardTime = null;
        private DateTime? _BindCardTime = null;

        /// <summary>
        /// 刷卡时间
        /// </summary> 
        [DisplayName("刷卡时间")]
        public DateTime? BindCardTime
        {
            get { return _BindCardTime; }
            set
            {
                if (_BindCardTime != value)
                {
                    if (IsIniting) _Ori_BindCardTime = value;
                    _BindCardTime = value;
                    RaisePropertyChanged("BindCardTime", true);
                }
            }
        }
        #endregion

        public const string CardUseType_Veh = "CUT001";
        public const string CardUseType_Mix = "CUT002";

        public static QC_IC_Info FindByCardId(string cardId)
        {
            DbEntityTable<QC_IC_Info> table = new DbEntityTable<QC_IC_Info>();
            table.LoadDataByWhere("CardID=@CardID", cardId);
            if (table.Count == 1)
            {
                return table[0];
            }
            else if (table.Count > 1)
            {
                throw new Exception(string.Format("根据卡号:{0}找到多条记录，但是不允许出现这种情况", cardId));
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 解除绑定
        /// </summary>
        /// <param name="cardId"></param>
        public static void UnBinding(string cardId)
        {
            DbContext.ExeSql("update QC_IC_Info set SampleId=0 where CardID=@CardID", cardId);
        }
    }
}
