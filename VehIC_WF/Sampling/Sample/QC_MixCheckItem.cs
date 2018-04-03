using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zhc.Data;
using System.ComponentModel;
using Zhc.CalFramework;
namespace VehIC_WF.Sampling.czl.Class
{

    [DbTable("QC_CheckItem", "ck", "ck.CheckItemNcId=main.CheckItemNcId", JoinType.Left)]
    [DbTable("QC_CheckGroup", "cg", "cg.CheckGroupCode=ck.CheckGroupCode", JoinType.Left)]
    [DbTable(TableAlias = "main")]
    public class QC_MixCheckItem : DbEntity
    {
        #region 主键
        private int _Id;
        [DisplayName("主键")]
        [DbTableColumn(IsPrimaryKey = true, AutoIncrement = true)]
        public int Id
        {
            get { return _Id; }
            set
            {
                if (_Id != value)
                {
                    _Id = value;
                    RaisePropertyChanged("Id", true);
                }
            }
        }
        #endregion

        #region CheckItemNcId
        private string _CheckItemNcId="";
        private string _Ori_CheckItemNcId="";

        public string CheckItemNcId
        {
            get { return _CheckItemNcId; }
            set
            {
                if (_CheckItemNcId != value)
                {
                    _CheckItemNcId = value;
                    RaisePropertyChanged("CheckItemNcid", true);
                }
            }
        }
        #endregion

        #region CheckItemCode
        private string _CheckItemCode = "";
        private string _Ori_CheckItemCode = "";

        public string CheckItemCode
        {
            get { return _CheckItemCode; }
            set
            {
                if (_CheckItemCode != value)
                {
                    _CheckItemCode = value;
                    RaisePropertyChanged("CheckItemCode", true);
                }
            }
        }
        #endregion

        #region CheckItemName
        private string _CheckItemName="";
        private string _Ori_CheckItemName="";

        public string CheckItemName
        {
            get { return _CheckItemName; }
            set
            {
                if (_CheckItemName != value)
                {
                    _CheckItemName = value;
                    RaisePropertyChanged("CheckItemName", true);
                }
            }
        }
        #endregion 

        #region CheckItemUnit
        private string _CheckItemUnit="";
        private string _Ori_CheckItemUnit = "";

        public string CheckItemUnit
        {
            get { return _CheckItemUnit; }
            set
            {
                if (_CheckItemUnit != value)
                {
                    _CheckItemUnit = value;
                    RaisePropertyChanged("CheckItemUnit", true);
                }
            }
        }
        #endregion

        #region Sample_Mix_ID
        private int _Sample_Mix_ID=0;
        private int _Ori_Sample_Mix_ID = 0;

        public int Sample_Mix_ID
        {
            get { return _Sample_Mix_ID; }
            set
            {
                if (_Sample_Mix_ID != value)
                {
                    _Sample_Mix_ID = value;
                    RaisePropertyChanged("Sample_Mix_ID", true);
                }
            }
        }
        #endregion

        #region Sample_Veh_ID  车样ID
        private int _Ori_Sample_Veh_ID = 0;
        private int _Sample_Veh_ID = 0;

        /// <summary>
        /// 车样ID
        /// </summary> 
        [DisplayName("车样ID")]
        public int Sample_Veh_ID
        {
            get { return _Sample_Veh_ID; }
            set
            {
                if (_Sample_Veh_ID != value)
                {
                    _Sample_Veh_ID = value;
                    RaisePropertyChanged("Sample_Veh_ID", true);
                }
            }
        }
        #endregion

        #region
        private string _CheckVal = "";
        private string _Ori_CheckVal = "";

        public string ActualVal
        {
            get { return _CheckVal; }
            set
            {
                if (_CheckVal != value)
                {
                    _CheckVal = value;
                    RaisePropertyChanged("CheckVal", true);
                }
            }
        }
        #endregion

        #region Source
        private string _Source="";
        private string _Ori_Source="";
        public string Source
        {
            get { return _Source; }
            set
            {
                if (_Source != value)
                {
                    _Source = value;
                    RaisePropertyChanged("Source", true);
                }
            }
        }
        #endregion

        private int _CheckGroupId;

        [DisplayName("样品分类id")]
        public int CheckGroupId
        {
            get { return _CheckGroupId; }
            set
            {
                if (_CheckGroupId != value)
                {
                    _CheckGroupId = value;
                    RaisePropertyChanged("CheckGroupId", true);
                }
            }
        }

        private string _CheckGroupCode;
        [DbTableColumn("ck.CheckGroupCode")]
        public string CheckGroupCode
        {
            get { return _CheckGroupCode; }
            set
            {
                if (_CheckGroupCode != value)
                {
                    _CheckGroupCode = value;
                    RaisePropertyChanged("CheckGroupCode", true);
                }
            }
        }

        private string _CheckGroupName;
        [DisplayName("样品分类名称")]
        [DbTableColumn("cg.CheckGroupName")]
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


        private string _CheckGroupType = "";

        /// <summary>
        /// 样品分类类型
        /// </summary> 
        [DisplayName("样品分类类型")]
        [DbTableColumn("cg.CheckGroupType")]
        public string CheckGroupType
        {
            get { return _CheckGroupType; }
            set
            {
                if (_CheckGroupType != value)
                {

                    _CheckGroupType = value;
                    RaisePropertyChanged("CheckGroupType", true);
                }
            }
        }


        #region ShortWord  缩写标识
        private string _ShortWord = "";

        /// <summary>
        /// 缩写标识
        /// </summary> 
        [DisplayName("缩写标识")]
        [DbTableColumn("cg.ShortWord")]
        public string CkgShortWord
        {
            get { return _ShortWord; }
            set
            {
                if (_ShortWord != value)
                {
                    _ShortWord = value;
                    RaisePropertyChanged("ShortWord");
                }
            }
        }
        #endregion


        private int _CheckGroupVisIdx=0;
        /// <summary>
        /// 显示顺序
        /// </summary>
        [DbTableColumn("cg.VisIdx")]
        public int CheckGroupVisIdx
        {
            get { return _CheckGroupVisIdx; }
            set
            {
                if (_CheckGroupVisIdx != value)
                {
                    _CheckGroupVisIdx = value;
                    RaisePropertyChanged("CheckGroupVisIdx");
                }
            }
        }


    }

    public class QC_MixCheckItem_Table : DbEntityTable<QC_MixCheckItem>
    {
        public void DeleteBySampleMixId(int SampleMixId)
        {
            if (SampleMixId > 0)
            {
                DbContext.ExeSql("Delete From QC_MixCheckItem where Sample_Mix_ID=@Sample_Mix_ID", SampleMixId);
            }
        }

        public void LoadDataBySampleMixId(int SampleMixId)
        {
            this.LoadDataByWhere("Sample_Mix_ID=@Sample_Mix_ID", SampleMixId);
        }

        public void LoadDataBySampleVehId(int SampleVehId)
        {
           
            this.LoadDataByWhere("Sample_Veh_ID=@Sample_Veh_ID", SampleVehId);
        }

        public void DeleteBySampleVehId(int SampleVehId)
        {
            if (SampleVehId > 0)
            {
                DbContext.ExeSql("Delete From QC_MixCheckItem where Sample_Veh_ID=@Sample_Veh_ID", SampleVehId);
            }
        }
    }
}
