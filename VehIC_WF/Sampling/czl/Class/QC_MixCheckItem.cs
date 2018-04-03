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
    [DbTable(TableAlias="main")]
  public  class QC_MixCheckItem:DbEntity
    {
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
      
      
      private string _CheckItemNcId;

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

        private string _CheckItemCode;

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


        private string _CheckItemName;

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
     
       private string _CheckItemUnit;

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


        private int _Sample_Mix_ID;

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

        private string _CheckVal = "";

        public string CheckVal
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
        
        private string _Source;

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
        public string ShortWord
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
      
          
 

    }

  public class QC_MixCheckItem_Table : DbEntityTable<QC_MixCheckItem>
  {
      public void DeleteBySampleMixId(int SampleMixId)
      {
          DbContext.ExeSql("Delete From QC_MixCheckItem where Sample_Mix_ID=@Sample_Mix_ID", SampleMixId);
      }

      public void LoadDataBySampleMixId(int SampleMixId)
      {
          this.LoadDataByWhere("Sample_Mix_ID=@Sample_Mix_ID", SampleMixId);
      }
  }
}
