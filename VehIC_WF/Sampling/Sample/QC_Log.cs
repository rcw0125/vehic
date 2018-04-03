using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Zhc.Data;
using System.Data.Linq.Mapping;
namespace Xg.Lab.Sample
{
    [DbTable("QC_Log")]
    [Table(Name="QC_Log")]
    public class QC_Log : DbEntity
    {
        private int _ID;
        [DbTableColumn(IsPrimaryKey = true, AutoIncrement = true)]
        [Column(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
        public int ID
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



        #region BillId  单据Id
        private string _Ori_BillId = "";
        private string _BillId = "";

        /// <summary>
        /// 单据Id
        /// </summary> 
        [DisplayName("单据Id")]
        [Column(Storage = "_BillId", DbType = "VarChar(400)")]
        public string BillId
        {
            get { return _BillId; }
            set
            {
                if (_BillId != value)
                {
                    if (IsIniting) _Ori_BillId = value;
                    _BillId = value;
                    RaisePropertyChanged("BillId", true);
                }
            }
        }
        #endregion


        #region OperateType  操作类型
        private string _Ori_OperateType = "";
        private string _OperateType = "";

        /// <summary>
        /// 操作类型
        /// </summary> 
        [DisplayName("操作类型")]
        [Column(Storage = "_OperateType", DbType = "VarChar(400)")]
        public string OperateType
        {
            get { return _OperateType; }
            set
            {
                if (_OperateType != value)
                {
                    if (IsIniting) _Ori_OperateType = value;
                    _OperateType = value;
                    RaisePropertyChanged("OperateType", true);
                }
            }
        }
        #endregion


        #region OperateContent  操作内容
        private string _Ori_OperateContent = "";
        private string _OperateContent = "";

        /// <summary>
        /// 操作内容
        /// </summary> 
        [DisplayName("操作内容")]
        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_OperateContent", DbType = "VarChar(400)")] 
        public string OperateContent
        {
            get { return _OperateContent; }
            set
            {
                if (_OperateContent != value)
                {
                    if (IsIniting) _Ori_OperateContent = value;
                    _OperateContent = value;
                    RaisePropertyChanged("OperateContent", true);
                }
            }
        }
        #endregion


        #region OperateUser  操作用户
        private string _Ori_OperateUser = "";
        private string _OperateUser = "";

        /// <summary>
        /// 操作用户
        /// </summary> 
        [DisplayName("操作用户")]
        public string OperateUser
        {
            get { return _OperateUser; }
            set
            {
                if (_OperateUser != value)
                {
                    if (IsIniting) _Ori_OperateUser = value;
                    _OperateUser = value;
                    RaisePropertyChanged("OperateUser", true);
                }
            }
        }
        #endregion

        #region OperateTime  操作时间
        private DateTime? _Ori_OperateTime = null;
        private DateTime? _OperateTime = null;

        /// <summary>
        /// 操作时间
        /// </summary> 
        [DisplayName("操作时间")]
        public DateTime? OperateTime
        {
            get { return _OperateTime; }
            set
            {
                if (_OperateTime != value)
                {
                    if (IsIniting) _Ori_OperateTime = value;
                    _OperateTime = value;
                    RaisePropertyChanged("OperateTime", true);
                }
            }
        }
        #endregion

    }
}
