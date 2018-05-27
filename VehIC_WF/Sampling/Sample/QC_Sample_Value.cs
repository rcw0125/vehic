using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zhc.Data;
using System.ComponentModel;
using Zhc.CalFramework;
using System.Data;
using VehIC_WF;
using Xg.Tools;
namespace Xg.Lab.Sample
{
    [DbTable("QC_Sample_Lab", "lab", "lab.Sample_Lab_ID=main.Sample_Lab_ID", JoinType.Left)]
    [DbTable("QC_CheckItem", "chitem", "chitem.CheckItemNcId=main.CheckItemNcId", JoinType.Left)]
    [DbTable("BD_PSNDOC", "psn", "psn.PSNCODE=main.CheckUser", JoinType.Left)]
    [DbTable(TableAlias = "main")]
    public partial class QC_Sample_Value : DbEntity
    {
        private string _FinalType;

        public string FinalType
        {
            get { return _FinalType; }
            set
            {
                if (_FinalType != value)
                {
                    _FinalType = value;
                    RaisePropertyChanged("FinalType");
                }
            }
        }
        private string _FinalVal;
     
        public string FinalVal
        {
            get { return _FinalVal; }
            set
            {
                if (_FinalVal != value)
                {
                    _FinalVal = value;
                    RaisePropertyChanged("FinalVal");
                }
            }
        }

        private string _RecheckVal;
        [NonTableField]
        public string RecheckVal
        {
            get { return _RecheckVal; }
            set
            {
                if (_RecheckVal != value)
                {
                    _RecheckVal = value;
                    RaisePropertyChanged("RecheckVal");
                }
            }
        }
        #region 主键
        private string _Sample_Value_ID = Guid.NewGuid().ToString();
        [DbTableColumn(IsPrimaryKey = true)]
        public string Sample_Value_ID
        {
            get { return _Sample_Value_ID; }
            set
            {
                if (_Sample_Value_ID != value)
                {
                    _Sample_Value_ID = value;
                    RaisePropertyChanged("Sample_Value_ID", true);
                }
            }
        }
        #endregion

        private int _Sample_Lab_ID;
        /// <summary>
        /// 分组检验样主键
        /// </summary>
        public int Sample_Lab_ID
        {
            get { return _Sample_Lab_ID; }
            set
            {
                if (_Sample_Lab_ID != value)
                {
                    _Sample_Lab_ID = value;
                    RaisePropertyChanged();
                }
            }
        }


        #region CheckItemNcId  检验项主键
        private string _Ori_CheckItemNcId = "";
        private string _CheckItemNcId = "";

        /// <summary>
        /// 检验项主键
        /// </summary> 
        [DisplayName("检验项主键")]
        public string CheckItemNcId
        {
            get { return _CheckItemNcId; }
            set
            {
                if (_CheckItemNcId != value)
                {
                    if (IsIniting) _Ori_CheckItemNcId = value;
                    _CheckItemNcId = value;
                    RaisePropertyChanged("CheckItemNcId", true);
                }
            }
        }
        #endregion

        #region CheckItemCode 检验项编码
        private string _Ori_CheckItemCode = "";
        private string _CheckItemCode = "";

        /// <summary>
        /// 检验项编码
        /// </summary> 
        [DisplayName("检验项编码")]
        [DbTableColumn("chitem.CheckItemCode")]
        public string CheckItemCode
        {
            get { return _CheckItemCode; }
            set
            {
                if (_CheckItemCode != value)
                {
                    if (IsIniting) _Ori_CheckItemCode = value;
                    _CheckItemCode = value;
                    RaisePropertyChanged("CheckItemCode");
                }
            }
        }
        #endregion

        #region CheckItemName  检验项名称

        private string _Ori_CheckItemName = "";
        private string _CheckItemName = "";

        /// <summary>
        /// 检验项名称
        /// </summary> 
        [DisplayName("检验项名称")]
        [DbTableColumn("chitem.CheckItemName")]
        public string CheckItemName
        {
            get { return _CheckItemName; }
            set
            {
                if (_CheckItemName != value)
                {
                    if (IsIniting) _Ori_CheckItemName = value;
                    _CheckItemName = value;
                    RaisePropertyChanged("CheckItemName");
                }
            }
        }

        #endregion

        #region CheckItemUnit  计量单位
        private string _Ori_CheckItemUnit = "";
        private string _CheckItemUnit = "";

        /// <summary>
        /// 计量单位
        /// </summary> 
        [DisplayName("计量单位")]
        [DbTableColumn("chitem.CheckItemUnit")]
        public string CheckItemUnit
        {
            get { return _CheckItemUnit; }
            set
            {
                if (_CheckItemUnit != value)
                {
                    if (IsIniting) _Ori_CheckItemUnit = value;
                    _CheckItemUnit = value;
                    RaisePropertyChanged("CheckItemUnit");
                }
            }
        }
        #endregion


        #region ActualVal  原始值
        private string _Ori_ActualVal = "";
        private string _ActualVal = "";

        /// <summary>
        /// 原始值
        /// </summary> 
        [DisplayName("原始值")]
        public string ActualVal
        {
            get { return _ActualVal; }
            set
            {
                if (IsIniting) _Ori_ActualVal = value;
                if (_ActualVal != value)
                {
                    _ActualVal = FNumVal(value); ;
                    RaisePropertyChanged("ActualVal", true);
                }
            }
        }
        #endregion

        private bool chgCheckVal = false;

        #region CheckVal 检验值
        private string _Ori_CheckVal = "";
        private string _CheckVal = "";
        /// <summary>
        /// 检验值
        /// </summary>
        [DisplayName("检验值")]
        public string CheckVal
        {
            get { return _CheckVal; }
            set
            {
                if (IsIniting) _Ori_CheckVal = value;
                if (_CheckVal != value)
                {
                    _CheckVal = FNumVal(value);
                    chgCheckVal = true;
                    RaisePropertyChanged("CheckVal", true);
                }
            }
        }

        private string FNumVal(string value)
        {
            string resultStr = "";
            string strVal = StringTool.SBCToDBC(value).Replace(" ", "");

            double result;
            if (double.TryParse(strVal, out result))
                resultStr = strVal;

            return resultStr;
        }

        #endregion

        #region ReportVal 报检值
        private string _Ori_ReportVal = "";
        private string _ReportVal = "";
        /// <summary>
        /// 报检值
        /// </summary>
        [DisplayName("报检值")]
        public string ReportVal
        {
            get { return _ReportVal; }
            set
            {
                if (IsIniting) _Ori_ReportVal = value;
                if (_ReportVal != value)
                {
                    _ReportVal = FNumVal(value);
                    if (!IsIniting) ReportValSource = "人工";
                    RaisePropertyChanged("ReportVal", true);
                }
            }
        }
        #endregion

        private string _ReportValSource="系统";
        [DisplayName("报检值来源")]
        public string ReportValSource
        {
            get { return _ReportValSource; }
            set
            {
                if (_ReportValSource != value)
                {
                    _ReportValSource = value;
                    RaisePropertyChanged("ReportValSource", true);
                }
            }
        }


        private string _JYCODE;
        /// <summary>
        /// 检验编码
        /// </summary>
       [DbTableColumn("lab.JYCODE")]
        public string JYCODE
        {
            get { return _JYCODE; }
            set
            {
                if (_JYCODE != value)
                {
                    _JYCODE = value;
                    RaisePropertyChanged("JYCODE", true);
                }
            }
        }


        #region CheckUser  检验人
        private string _Ori_CheckUser = "";
        private string _CheckUser = "";

        /// <summary>
        /// 检验人
        /// </summary> 
        [DisplayName("检验人")]
        public string CheckUser
        {
            get { return _CheckUser; }
            set
            {
                if (_CheckUser != value)
                {
                    if (IsIniting) _Ori_CheckUser = value;
                    _CheckUser = value;
                    RaisePropertyChanged("CheckUser", true);
                }
            }
        }
        #endregion

        #region CheckUserName
        private string _CheckUserName;
        /// <summary>
        /// 
        /// </summary>
        [DbTableColumn("psn.PSNNAME")]
        public string CheckUserName
        {
            get { return _CheckUserName; }
            set
            {
                if (_CheckUserName != value)
                {
                    _CheckUserName = value;
                    RaisePropertyChanged("CheckUserName");
                }
            }
        }
        #endregion

        #region CheckTime  检验时间
        private DateTime? _Ori_CheckTime = null;
        private DateTime? _CheckTime = null;

        /// <summary>
        /// 检验时间
        /// </summary> 
        [DisplayName("检验时间")]
        public DateTime? CheckTime
        {
            get { return _CheckTime; }
            set
            {
                if (_CheckTime != value)
                {
                    if (IsIniting) _Ori_CheckTime = value;
                    _CheckTime = value;
                    RaisePropertyChanged("CheckTime", true);
                }
            }
        }
        #endregion

        #region Auditor  审核人
        private string _Ori_Auditor = "";
        private string _Auditor = "";

        /// <summary>
        /// 审核人
        /// </summary> 
        [DisplayName("审核人")]
        public string Auditor
        {
            get { return _Auditor; }
            set
            {
                if (_Auditor != value)
                {
                    if (IsIniting) _Ori_Auditor = value;
                    _Auditor = value;
                    RaisePropertyChanged("Auditor", true);
                }
            }
        }
        #endregion


        private string _AuditorName;
        [NonTableField]
        public string AuditorName
        {
            get { return _AuditorName; }
            set
            {
                if (_AuditorName != value)
                {
                    _AuditorName = value;
                    RaisePropertyChanged("AuditorName");
                }
            }
        }


        #region AuditTime 审核时间
        private DateTime? _Ori_AuditTime = null;
        private DateTime? _AuditTime = null;
        /// <summary>
        /// 审核时间
        /// </summary>
        public DateTime? AuditTime
        {
            get { return _AuditTime; }
            set
            {
                if (_AuditTime != value)
                {
                    if (IsIniting) _Ori_AuditTime = value;
                    _AuditTime = value;
                    RaisePropertyChanged("AuditTime");
                }
            }
        }
        #endregion

        private string _ValSource = "";
        /// <summary>
        /// 检验值来源
        /// </summary>
        [DisplayName("来源")]
        [NonTableField]
        public string ValSource
        {
            get { return _ValSource; }
            set
            {
                if (_ValSource != value)
                {
                    _ValSource = value;
                    RaisePropertyChanged("ValSource");
                }
            }
        }

        #region

        private int _Sample_Mix_ID;
        /// <summary>
        /// 组批检验样主键
        /// </summary>
        [NonTableField]
        public int Sample_Mix_ID
        {
            get { return _Sample_Mix_ID; }
            set
            {
                if (_Sample_Mix_ID != value)
                {
                    _Sample_Mix_ID = value;
                    RaisePropertyChanged("Sample_Mix_ID");
                }
            }
        }


        #endregion

        private int _VisIdx = 0;

        [DbTableColumn(ColName = "chitem.VisIdx", SortDirection = SortDirection.Ascending, SortOrder = 1)]
        public int VisIdx
        {
            get { return _VisIdx; }
            set
            {
                if (_VisIdx != value)
                {
                    _VisIdx = value;
                    RaisePropertyChanged("VisIdx", true);
                }
            }
        }
        public override void RejectChanges()
        {
            _CheckVal = _Ori_CheckVal;
            base.RejectChanges();
        }

        public void JianYan()
        {
            if (chgCheckVal)
            {
                this.CheckUser = LocalInfo.Current.user.ID;
                this.CheckTime = DateTime.Now;
                chgCheckVal = false;
            }
        }

        protected override void AfterSave(System.Data.IDbTransaction trans)
        {
            if (this.DataState == DataRowState.Modified)
            {
                if (this.ReportValSource == "人工")
                {
                    QC_Log log = new QC_Log();
                    log.BillId = this.Sample_Value_ID;
                    log.OperateType = "报检值修改";
                    log.OperateContent = string.Format("项目编码:{0},项目名称:{1},原值:{2},新值:{3}", this.CheckItemCode, this.CheckItemName, this._Ori_ReportVal, this.ReportVal);
                    log.OperateUser = LocalInfo.Current.user.ID;
                    log.OperateTime = DateTime.Now;
                    log.Save();
                }
                if (this._Ori_CheckVal != this._CheckVal)
                {
                    QC_Log log = new QC_Log();
                    log.BillId = this.Sample_Value_ID;
                    log.OperateType = "检验值修改";
                    log.OperateContent = string.Format("项目编码:{0},项目名称:{1},原值:{2},新值:{3}", this.CheckItemCode, this.CheckItemName, this._Ori_CheckVal, this._CheckVal);
                    log.OperateUser = LocalInfo.Current.user.ID;
                    log.OperateTime = DateTime.Now;
                    log.Save();
                }
            }
            base.AfterSave(trans);
        }
    }

    public class QC_Sample_Value_Table : DbEntityTable<QC_Sample_Value>, IGetTagValue
    {
        public double? GetTagValue(string tagName)
        {
            foreach (var item in this)
            {
                if (item.CheckItemName == tagName)
                {
                    double result;
                    if (double.TryParse(item.ReportVal.Trim(), out result))
                        return result;
                    else
                        return null;
                }
            }
            return null;
        }

        public double? GetTagValueByCode(string tagCode)
        {
            foreach (var item in this)
            {
                if (item.CheckItemCode == tagCode)
                {
                    double result;
                    if (double.TryParse(item.ReportVal.Trim(), out result))
                        return result;
                    else
                        return null;
                }
            }
            return null;
        }

        public void LoadDataBySampleMixId(int SampleMixId)
        {
            this.LoadDataBySql("Select * from QC_MixSampleValue_V Where Sample_Mix_ID=@Sample_Mix_ID", SampleMixId);
        }

        /// <summary>
        /// 加载抽查样所有的检验值，包括普通检验值
        /// </summary>
        /// <param name="SampleMixId"></param>
        public void LoadInspectSampleAllData(int SampleMixId)
        {
            this.LoadDataBySql("Select * from QC_MixSampleValue_V Where Sample_Mix_ID=@Sample_Mix_ID", SampleMixId);
        }

        public void LoadHotData(int HotMixId,int SampleMixId,String HotMat)
        {
            this.LoadDataBySql("Select * from QC_MixSampleValue_V Where (Sample_Mix_ID=@Sample_Mix_ID or (MainSampleMixId=@Sample_Mix_ID and SampleType=1)) or (Sample_Mix_ID=@HotMixId and checkitemname=@checkitemname)", SampleMixId, HotMixId, HotMat);
            foreach (var item in this)
            {
                QC_Sample_Value_Table recheckvals = new QC_Sample_Value_Table();
                recheckvals.LoadDataBySql("Select * from QC_MixSampleValue_V Where  MainSampleMixId=@ZhengSampleMixId and SampleType=3", SampleMixId);

                if (item.Sample_Mix_ID == SampleMixId)
                    item.ValSource = "正样";
                else item.ValSource = "抽样";

                if (item.CheckItemCode == "30093")
                { item.ValSource = ""; }
                if (item.ValSource == "正样")
                {

                    foreach (var it in recheckvals)
                    {

                        if (it.CheckItemCode == item.CheckItemCode)
                        {
                            item.RecheckVal = it.CheckVal;

                        }

                    }

                }


            }
        }
        DbEntityTable<QC_Sample_Mix> mixs = new DbEntityTable<QC_Sample_Mix>();
        public void LoadInspectSampleAllData(int InspectSampleMixId, int SampleMixId)
        {
            this.LoadDataBySql("Select * from QC_MixSampleValue_V Where Sample_Mix_ID=@InspectSampleMixId or Sample_Mix_ID=@Sample_Mix_ID", InspectSampleMixId, SampleMixId);
            foreach (var item in this)
            {
                mixs.LoadDataByWhere("main.Sample_Mix_ID=@Sample_Mix_ID", SampleMixId);
                if(item.Sample_Mix_ID==InspectSampleMixId)
                    item.ValSource="抽样";
                if (item.Sample_Mix_ID == SampleMixId && (mixs[0].SampleType == SampleType.普通样 || mixs[0].SampleType == SampleType.人工取样 || mixs[0].SampleType == SampleType.机器取样))
                    item.ValSource = "正样";
                if (item.Sample_Mix_ID == SampleMixId && mixs[0].SampleType == SampleType.抽查样)
                    item.ValSource = "抽样";
            }
        
        }
        public void LoadRecheckSampleAllData(int RecheckSampleMixId, int SampleMixId)
        {
            this.LoadDataBySql("Select * from QC_MixSampleValue_V Where Sample_Mix_ID=@InspectSampleMixId or Sample_Mix_ID=@Sample_Mix_ID", RecheckSampleMixId, SampleMixId);
            foreach (var item in this)
            {
                if (item.Sample_Mix_ID == RecheckSampleMixId)
                    item.ValSource = "复检样";
                if (item.Sample_Mix_ID == SampleMixId)
                    item.ValSource = "正样";
            }

        }
        public void LoadRecheckInspectSampleAllData(int RecheckSampleMixId, int cySampleMixId, int zySampleMixId)
        {
            this.LoadDataBySql("Select * from QC_MixSampleValue_V Where Sample_Mix_ID=@InspectSampleMixId or Sample_Mix_ID=@cySample_Mix_ID or Sample_Mix_ID=@zySample_Mix_ID", RecheckSampleMixId, cySampleMixId, zySampleMixId);
            foreach (var item in this)
            {
                if (item.Sample_Mix_ID == RecheckSampleMixId)
                    item.ValSource = "复检样";
                if (item.Sample_Mix_ID == cySampleMixId)
                    item.ValSource = "抽样";
                if (item.Sample_Mix_ID == zySampleMixId)
                    item.ValSource = "A正样";
            }

        }

        public void LoadZhengSampleAllData(int ZhengSampleMixId)
        {
            this.LoadDataBySql("Select * from QC_MixSampleValue_V Where (Sample_Mix_ID=@ZhengSampleMixId or (MainSampleMixId=@ZhengSampleMixId and (SampleType=1 or SampleType=4))) and SampleType<>3", ZhengSampleMixId);

            QC_Sample_Value_Table recheckvals = new QC_Sample_Value_Table();
            recheckvals.LoadDataBySql("Select * from QC_MixSampleValue_V Where  MainSampleMixId=@ZhengSampleMixId and SampleType=3", ZhengSampleMixId);
            foreach (var item in this)
            {
              
                
                if (item.Sample_Mix_ID == ZhengSampleMixId)
                    item.ValSource = "正样";
                else item.ValSource = "抽样";
                if (item.ValSource == "正样")
                {

                    foreach (var it in recheckvals)
                    {

                        if (it.CheckItemCode == item.CheckItemCode)
                        {
                            item.RecheckVal = it.CheckVal;
                        
                        }
                    
                    }
                
                }


            }

        }
        public void LoadInspectHotAllData(int InspectSampleMixId, int SampleMixId,int hotMixID, String HotMat)
        {
            this.LoadDataBySql("Select * from QC_MixSampleValue_V Where Sample_Mix_ID=@InspectSampleMixId or Sample_Mix_ID=@Sample_Mix_ID or (Sample_Mix_ID=@HotMixId and checkitemname=@checkitemname)", InspectSampleMixId, SampleMixId, hotMixID, HotMat);
            foreach (var item in this)
            {
                if (item.Sample_Mix_ID == InspectSampleMixId)
                    item.ValSource = "抽样";
                if (item.Sample_Mix_ID == SampleMixId)
                    item.ValSource = "正样";
            }

        }

        public void DefaultSort()
        {
            this.Sort((t1, t2) =>
            {
                int result = t1.ValSource.CompareTo(t2.ValSource);
                if (result == 0)
                    result = t1.CheckItemCode.CompareTo(t2.CheckItemCode);
                return result;
            });
        }
        public void DaoxuSort()
        {
            this.Sort((t1, t2) =>
            {
                int result = t1.ValSource.CompareTo(t2.ValSource);
                if (result == 0)
                    result = 0-t1.CheckItemCode.CompareTo(t2.CheckItemCode);
                return 0-result;
            });
        }

    }
}
