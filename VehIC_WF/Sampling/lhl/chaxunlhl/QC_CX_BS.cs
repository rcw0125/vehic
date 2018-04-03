using System;
using Zhc.Data;
using System.ComponentModel;
using System.Reflection;
using System.Data;
using System.Data.Linq.Mapping;
using VehIC_WF.Sampling.Nc;
using VehIC_WF;
using System.Text;
using System.IO;
using System.Collections.Generic;

namespace Xg.Lab.Sample
{

   [DbTable(TableName = "QC_SampleVeh_Info", IsView = true)]
    public class QC_CX_BS:DbEntity
    {
         public static String  GetName(String id)
         {
             String name = "";
             object result = DbContext.ExecuteScalar("select PSNNAME from BD_PSNDOC where PSNCODE='" + id + "'");
             if (result != null && result != DBNull.Value)
             {
                 name = Convert.ToString(result);  //供应商编码
             }
             return name;
         }
         #region SCFS 上传方式
         private string _Ori_SCFS;
         private string _SCFS;

         /// <summary>
         /// 上传方式
         /// </summary> 
         [DisplayName("上传方式")]
         [DbTableColumn("SCFS")]
         public string SCFS
         {
             get { return _SCFS; }
             set
             {
                 if (_SCFS != value)
                 {
                     if (IsIniting) _Ori_SCFS = value;
                     _SCFS = value;
                     RaisePropertyChanged("SCFS", true);
                 }
             }
         }
         #endregion
         #region Fjdyr 复检调样人
         private string _Ori_Fjdyr;
         private string _Fjdyr;

         /// <summary>
         /// 复检调样人
         /// </summary> 
         [DisplayName("复检调样人")]
         [DbTableColumn("Fjdyr")]
         public string Fjdyr
         {
             get { return _Fjdyr; }
             set
             {
                 if (_Fjdyr != value)
                 {
                     if (IsIniting) _Ori_Fjdyr = value;
                     _Fjdyr = value;
                     RaisePropertyChanged("Fjdyr", true);
                 }
             }
         }
         #endregion
         #region WLLX  物料类型
         private string _Ori_WLLX;
         private string _WLLX;

         /// <summary>
         /// 物料类型
         /// </summary> 
         [DisplayName("物料类型")]
         public string WLLX
         {
             get { return _WLLX; }
             set
             {
                 if (_WLLX != value)
                 {
                     if (IsIniting) _Ori_WLLX = value;
                     _WLLX = value;
                     RaisePropertyChanged("WLLX", true);
                 }
             }
         }
         #endregion
         #region SampleState 状态
     
         private SampleState _SampleState = SampleState.初始状态;

         /// <summary>
         /// 状态
         /// </summary>
         [DisplayName("状态")]
         public SampleState SampleState
         {
             get { return _SampleState; }
             set
             {
                 if (_SampleState != value)
                 {
                     _SampleState = value;
                     RaisePropertyChanged();
                 }
             }
         }
         #endregion

        #region 车牌号
       private string _车牌号 = "";
        /// <summary>
       /// 车牌号
    
       public string 车牌号
        {
            get { return _车牌号; }
            set
            {
                if (_车牌号 != value)
                {
                    _车牌号 = value;
                    RaisePropertyChanged("车牌号");
                }
            }
        }
        #endregion
       #region 实际重量
       private double _实际重量 ;
       /// <summary>
       /// 车牌号

       public double 实际重量
       {
           get { return _实际重量; }
           set
           {
               if (_实际重量 != value)
               {
                   _实际重量 = value;
                   RaisePropertyChanged("实际重量");
               }
           }
       }
       #endregion
       #region 扣水
       private double _扣水 = 0;
       /// <summary>
       /// 扣水
      
       public double 扣水
       {
           get { return _扣水; }
           set
           {
               if (_扣水 != value)
               {
                   _扣水 = value;
                   RaisePropertyChanged("扣水");
               }
           }
       }
       #endregion

       #region 扣杂
       private double _扣杂 = 0;
       /// <summary>
       /// 扣杂
       /// 
        
       public double 扣杂
       {
           get { return _扣杂; }
           set
           {
               if (_扣杂 != value)
               {
                   _扣杂 = value;
                   RaisePropertyChanged("扣杂");
               }
           }
       }
       #endregion

       #region 取样时间
       private DateTime? _取样时间 = null;
       /// <summary>
       /// 取样时间
       /// 

        
       public DateTime? 取样时间
       {
           get { return _取样时间; }
           set
           {
               if (_取样时间 != value)
               {
                   _取样时间 = value;
                   RaisePropertyChanged("取样时间");
               }
           }
       }
       #endregion
       #region 取样人
       private string _取样人 = "";
       /// <summary>
       /// 取样人
       /// 


       public string 取样人
       {
           get { return GetName(_取样人); }
           set
           {
               if (_取样人 != value)
               {
                   _取样人 = value;
                   RaisePropertyChanged("取样人");
               }
           }
       }
       #endregion

       #region 取样点
       private string _取样点 = "";
       /// <summary>
       /// 取样点
       /// 

       public string 取样点
       {
           get { return _取样点; }
           set
           {
               if (_取样点 != value)
               {
                   _取样点 = value;
                   RaisePropertyChanged("取样点");
               }
           }
       }
        #endregion
       #region 大桶顺序号
       private Int32 _大桶顺序号 ;
       /// <summary>
       /// 取样点
       /// 

       public Int32 大桶顺序号
       {
           get { return _大桶顺序号; }
           set
           {
               if (_大桶顺序号 != value)
               {
                   _大桶顺序号 = value;
                   RaisePropertyChanged("大桶顺序号");
               }
           }
       }
       #endregion
       #region 大样号
       private int _SAMPLE_MIX_ID = 0;
        /// <summary>
        /// 大样号
         public int SAMPLE_MIX_ID
        {
            get { return _SAMPLE_MIX_ID; }
            set
            {
                if (_SAMPLE_MIX_ID != value)
                {
                    _SAMPLE_MIX_ID = value;
                    RaisePropertyChanged("SAMPLE_MIX_ID");
                }
            }
        }
        #endregion

        #region SampleType 取样类型
        private SampleType _Ori_SampleType = SampleType.普通样;
        private SampleType _SampleType = SampleType.普通样;
        /// <summary>
        /// 取样类型
        /// </summary>
        [DisplayName("取样类型")]
        public SampleType SampleType
        {
            get { return _SampleType; }
            set
            {
                if (_SampleType != value)
                {
                    if (IsIniting) _Ori_SampleType = value;
                    _SampleType = value;
                    RaisePropertyChanged();
                }
            }
        }
        #endregion
        #region NC单据ID
        private string _NoticeBillId="";
        /// <summary>
        /// 大样号
        public string NoticeBillId
        {
            get { return _NoticeBillId; }
            set
            {
                if (_NoticeBillId != value)
                {
                    _NoticeBillId = value;
                    RaisePropertyChanged("NoticeBillId");
                }
            }
        }
        #endregion
        #region 厂家
        private string _厂家="";
        /// <summary>
        /// 大样号
        public string 厂家
        {
            get { return _厂家; }
            set
            {
                if (_厂家 != value)
                {
                    _厂家 = value;
                    RaisePropertyChanged("厂家");
                }
            }
        }
        #endregion
        #region 物料
        private string _物料="";
        /// <summary>
        /// 大样号
        public string 物料
        {
            get { return _物料; }
            set
            {
                if (_物料 != value)
                {
                    _物料 = value;
                    RaisePropertyChanged("物料");
                }
            }
        }
        #endregion
        #region 质量等级
        private string _质量等级="";
        /// <summary>
        /// 大样号
        public string 质量等级
        {
            get { return _质量等级; }
            set
            {
                if (_质量等级 != value)
                {
                    _质量等级 = value;
                    RaisePropertyChanged("质量等级");
                }
            }
        }
        #endregion
        #region 组批人
        private string _组批人="";
        /// <summary>
        /// 组批人
        public string 组批人
        {
            get { return GetName(_组批人); }
            set
            {
                if (_组批人 != value)
                {
                    _组批人 = value;
                    RaisePropertyChanged("组批人");
                }
            }
        }
        #endregion
        #region 组批时间
        private DateTime? _组批时间=null;
        /// <summary>
        /// 组批时间
        public DateTime? 组批时间
        {
            get { return _组批时间; }
            set
            {
                if (_组批时间 != value)
                {
                    _组批时间 = value;
                    RaisePropertyChanged("组批时间");
                }
            }
        }
        #endregion

        #region 制样单号
        private string _制样单号 = "";
        /// <summary>
        /// 制样单号
        public string 制样单号
        {
            get { return _制样单号; }
            set
            {
                if (_制样单号 != value)
                {
                    _制样单号 = value;
                    RaisePropertyChanged("制样单号");
                }
            }
        }
        #endregion
        #region 大样收样人
        private string _大样收样人 = "";
        /// <summary>
        /// 大样收样人
        public string 大样收样人
        {
            get { return GetName(_大样收样人); }
            set
            {
                if (_大样收样人 != value)
                {
                    _大样收样人 = value;
                    RaisePropertyChanged("大样收样人");
                }
            }
        }
        #endregion
        #region 大样收样时间
        private DateTime? _大样收样时间 =null;
        /// <summary>
        /// 大样收样时间
        public DateTime? 大样收样时间
        {
            get { return _大样收样时间; }
            set
            {
                if (_大样收样时间 != value)
                {
                    _大样收样时间 = value;
                    RaisePropertyChanged("大样收样时间");
                }
            }
        }
        #endregion

        #region 水分样制样码
        private string _水分样制样码 = "";
        /// <summary>
        /// 水分样制样码
        public string 水分样制样码
        {
            get { return _水分样制样码; }
            set
            {
                if (_水分样制样码 != value)
                {
                    _水分样制样码 = value;
                    RaisePropertyChanged("水分样制样码");
                }
            }
        }
        #endregion
        #region 水分样制样人
        private string _水分样制样人 = "";
        /// <summary>
        /// 水分样制样人
        public string 水分样制样人
        {
            get { return GetName(_水分样制样人); }
            set
            {
                if (_水分样制样人 != value)
                {
                    _水分样制样人 = value;
                    RaisePropertyChanged("水分样制样人");
                }
            }
        }
        #endregion
        #region 水分样制样时间
        private DateTime? _水分样制样时间 = null;
        /// <summary>
        /// 水分样制时间
        public DateTime? 水分样制样时间
        {
            get { return _水分样制样时间; }
            set
            {
                if (_水分样制样时间 != value)
                {
                    _水分样制样时间 = value;
                    RaisePropertyChanged("水分样制样时间");
                }
            }
        }
        #endregion
        #region 水分检验值
        private string _水分检验值 = "";
        /// <summary>
        /// 水分检验值
        public string 水分检验值
        {
            get { return _水分检验值; }
            set
            {
                if (_水分检验值 != value)
                {
                    _水分检验值 = value;
                    RaisePropertyChanged("水分检验值");
                }
            }
        }
        #endregion
        #region 水分报检值
        private string _水分报检值 = null;
        /// <summary>
        /// 水分报检值
        public string 水分报检值
        {
            get { return _水分报检值; }
            set
            {
                if (_水分报检值 != value)
                {
                    _水分报检值 = value;
                    RaisePropertyChanged("水分报检值");
                }
            }
        }
        #endregion
        #region 水分复检值
        private string _水分复检值 = null;
        [NonTableField]
        public string 水分复检值
        {
            get { return _水分复检值; }
            set
            {
                if (_水分复检值 != value)
                {
                    _水分复检值 = value;
                    RaisePropertyChanged("水分复检值");
                }
            }
        }
        #endregion
        #region 水分复检人
        private string _水分复检人 = null;
        [NonTableField]
        public string 水分复检人
        {
            get { return _水分复检人; }
            set
            {
                if (_水分复检人 != value)
                {
                    _水分复检人 = value;
                    RaisePropertyChanged("水分复检人");
                }
            }
        }
        #endregion
        #region 水分复检时间
        private DateTime? _水分复检时间 = null;
        [NonTableField]
        public DateTime? 水分复检时间
        {
            get { return _水分复检时间; }
            set
            {
                if (_水分复检时间 != value)
                {
                    _水分复检时间 = value;
                    RaisePropertyChanged("水分复检时间");
                }
            }
        }
        #endregion
        #region 水分取用值
        private string _水分取用值 = null;
        /// <summary>
        /// 水分取用值
        public string 水分取用值
        {
            get { return _水分取用值; }
            set
            {
                if (_水分取用值 != value)
                {
                    _水分取用值 = value;
                    RaisePropertyChanged("水分取用值");
                }
            }
        }
        #endregion
        #region 水分取用类型
        private string _水分取用类型 = null;
        /// <summary>
        /// 水分取用类型
        public string 水分取用类型
        {
            get { return _水分取用类型; }
            set
            {
                if (_水分取用类型 != value)
                {
                    _水分取用类型 = value;
                    RaisePropertyChanged("水分取用类型");
                }
            }
        }
        #endregion
        #region 化验样制样码
        private string _化验样制样码 = "";
        /// <summary>
        /// 化验样制样码
        public string 化验样制样码
        {
            get { return _化验样制样码; }
            set
            {
                if (_化验样制样码 != value)
                {
                    _化验样制样码 = value;
                    RaisePropertyChanged("化验样制样码");
                }
            }
        }
        #endregion
        #region 化验样制样人
        private string _化验样制样人 = "";
        /// <summary>
        /// 化验样制样人
        public string 化验样制样人
        {
            get { return GetName(_化验样制样人); }
            set
            {
                if (_化验样制样人 != value)
                {
                    _化验样制样人 = value;
                    RaisePropertyChanged("化验样制样人");
                }
            }
        }
        #endregion
        #region 化验样制时间
        private DateTime? _化验样制时间 = null;
        /// <summary>
        /// 化验样制样时间
        public DateTime? 化验样制样时间
        {
            get { return _化验样制时间; }
            set
            {
                if (_化验样制时间 != value)
                {
                    _化验样制时间 = value;
                    RaisePropertyChanged("化验样制样时间");
                }
            }
        }
        #endregion
        #region 化验样检验码
        private string _化验样检验码 = "";
        /// <summary>
        /// 化验样检验码
        public string 化验样检验码
        {
            get { return _化验样检验码; }
            set
            {
                if (_化验样检验码 != value)
                {
                    _化验样检验码 = value;
                    RaisePropertyChanged("化验样检验码");
                }
            }
        }
        #endregion
        #region 化验样收样人
        private string _化验样收样人 = "";
        /// <summary>
        /// 化验样收样人
        public string 化验样收样人
        {
            get { return GetName(_化验样收样人); }
            set
            {
                if (_化验样收样人 != value)
                {
                    _化验样收样人 = value;
                    RaisePropertyChanged("化验样收样人");
                }
            }
        }
        #endregion
        #region 化验样收样时间
        private DateTime? _化验样收样时间 = null;
        /// <summary>
        /// 化验样收样时间
        public DateTime? 化验样收样时间
        {
            get { return _化验样收样时间; }
            set
            {
                if (_化验样收样时间 != value)
                {
                    _化验样收样时间 = value;
                    RaisePropertyChanged("化验样收样时间");
                }
            }
        }
        #endregion
        #region 化验样审核人
        private string _化验样审核人 = "";
        /// <summary>
        /// 化验样审核人
        public string 化验样审核人
        {
            get { return _化验样审核人; }
            set
            {
                if (_化验样审核人 != value)
                {
                    _化验样审核人 = value;
                    RaisePropertyChanged("化验样审核人");
                }
            }
        }
        #endregion
        #region 化验样审核时间
        private DateTime? _化验样审核时间 = null;
        /// <summary>
        /// 化验样审核时间
        public DateTime? 化验样审核时间
        {
            get { return _化验样审核时间; }
            set
            {
                if (_化验样审核时间 != value)
                {
                    _化验样审核时间 = value;
                    RaisePropertyChanged("化验样审核时间");
                }
            }
        }
        #endregion
       
        #region 灰分检验人
        private string _灰分检验人 = "";
        /// <summary>
        /// 灰分检验人
        public string 灰分检验人
        {
            get { return GetName(_灰分检验人); }
            set
            {
                if (_灰分检验人 != value)
                {
                    _灰分检验人 = value;
                    RaisePropertyChanged("灰分检验人");
                }
            }
        }
        #endregion
        #region 灰分检验时间
        private DateTime? _灰分检验时间 = null;
        /// <summary>
        /// 灰分检验时间
        public DateTime? 灰分检验时间
        {
            get { return _灰分检验时间; }
            set
            {
                if (_灰分检验时间 != value)
                {
                    _灰分检验时间 = value;
                    RaisePropertyChanged("灰分检验时间");
                }
            }
        }
        #endregion
        #region 灰分检验值
        private string _灰分检验值 = "";
        /// <summary>
        /// 灰分检验值
        public string 灰分检验值
        {
            get { return _灰分检验值; }
            set
            {
                if (_灰分检验值 != value)
                {
                    _灰分检验值 = value;
                    RaisePropertyChanged("灰分检验值");
                }
            }
        }
        #endregion
        #region 灰分报检值
        private string _灰分报检值 = null;
        /// <summary>
        /// 灰分报检值
        public string 灰分报检值
        {
            get { return _灰分报检值; }
            set
            {
                if (_灰分报检值 != value)
                {
                    _灰分报检值 = value;
                    RaisePropertyChanged("灰分报检值");
                }
            }
        }
        #endregion
        #region 灰分复检值
        private string _灰分复检值 = null;
        [NonTableField]
        public string 灰分复检值
        {
            get { return _灰分复检值; }
            set
            {
                if (_灰分复检值 != value)
                {
                    _灰分复检值 = value;
                    RaisePropertyChanged("灰分复检值");
                }
            }
        }
        #endregion
        #region 灰分复检人
        private string _灰分复检人 = null;
        [NonTableField]
        public string 灰分复检人
        {
            get { return _灰分复检人; }
            set
            {
                if (_灰分复检人 != value)
                {
                    _灰分复检人 = value;
                    RaisePropertyChanged("灰分复检人");
                }
            }
        }
        #endregion
        #region 灰分复检时间
        private DateTime? _灰分复检时间 = null;
        [NonTableField]
        public DateTime? 灰分复检时间
        {
            get { return _灰分复检时间; }
            set
            {
                if (_灰分复检时间 != value)
                {
                    _灰分复检时间 = value;
                    RaisePropertyChanged("灰分复检时间");
                }
            }
        }
        #endregion
        #region 灰分取用值
        private string _灰分取用值 = null;
        /// <summary>
        /// 灰分取用值
        public string 灰分取用值
        {
            get { return _灰分取用值; }
            set
            {
                if (_灰分取用值 != value)
                {
                    _灰分取用值 = value;
                    RaisePropertyChanged("灰分取用值");
                }
            }
        }
        #endregion
        #region 灰分取用类型
        private string _灰分取用类型 = null;
        /// <summary>
        /// 水分取用类型
        public string 灰分取用类型
        {
            get { return _灰分取用类型; }
            set
            {
                if (_灰分取用类型 != value)
                {
                    _灰分取用类型 = value;
                    RaisePropertyChanged("灰分取用类型");
                }
            }
        }
        #endregion
        #region 挥发分检验人
        private string _挥发分检验人 = "";
        /// <summary>
        /// 挥发分检验人
        public string 挥发分检验人
        {
            get { return GetName(_挥发分检验人); }
            set
            {
                if (_挥发分检验人 != value)
                {
                    _挥发分检验人 = value;
                    RaisePropertyChanged("挥发分检验人");
                }
            }
        }
        #endregion
        #region 挥发分检验时间
        private DateTime? _挥发分检验时间 = null;
        /// <summary>
        /// 挥发分检验时间
        public DateTime? 挥发分检验时间
        {
            get { return _挥发分检验时间; }
            set
            {
                if (_挥发分检验时间 != value)
                {
                    _挥发分检验时间 = value;
                    RaisePropertyChanged("挥发分检验时间");
                }
            }
        }
        #endregion
        #region 挥发分检验值
        private string _挥发分检验值 = "";
        /// <summary>
        /// 挥发分检验值
        public string 挥发分检验值
        {
            get { return _挥发分检验值; }
            set
            {
                if (_挥发分检验值 != value)
                {
                    _挥发分检验值 = value;
                    RaisePropertyChanged("挥发分检验值");
                }
            }
        }
        #endregion
        #region 挥发分报检值
        private string _挥发分报检值 = null;
        /// <summary>
        /// 挥发分报检值
        public string 挥发分报检值
        {
            get { return _挥发分报检值; }
            set
            {
                if (_挥发分报检值 != value)
                {
                    _挥发分报检值 = value;
                    RaisePropertyChanged("挥发分报检值");
                }
            }
        }
        #endregion
        #region 挥发分复检值
        private string _挥发分复检值 = null;
        [NonTableField]
        public string 挥发分复检值
        {
            get { return _挥发分复检值; }
            set
            {
                if (_挥发分复检值 != value)
                {
                    _挥发分复检值 = value;
                    RaisePropertyChanged("挥发分复检值");
                }
            }
        }
        #endregion
        #region 挥发分复检人
        private string _挥发分复检人 = null;
        [NonTableField]
        public string 挥发分复检人
        {
            get { return _挥发分复检人; }
            set
            {
                if (_挥发分复检人 != value)
                {
                    _挥发分复检人 = value;
                    RaisePropertyChanged("挥发分复检人");
                }
            }
        }
        #endregion
        #region 挥发分复检时间
        private DateTime? _挥发分复检时间 = null;
        [NonTableField]
        public DateTime? 挥发分复检时间
        {
            get { return _挥发分复检时间; }
            set
            {
                if (_挥发分复检时间 != value)
                {
                    _挥发分复检时间 = value;
                    RaisePropertyChanged("挥发分复检时间");
                }
            }
        }
        #endregion
        #region  挥发分取用值
        private string _挥发分取用值 = null;
        /// <summary>
        /// 灰分取用值
        public string 挥发分取用值
        {
            get { return _挥发分取用值; }
            set
            {
                if (_挥发分取用值 != value)
                {
                    _挥发分取用值 = value;
                    RaisePropertyChanged("挥发分取用值");
                }
            }
        }
        #endregion
        #region 挥发分取用类型
        private string _挥发分取用类型 = null;
        /// <summary>
        /// 水分取用类型
        public string 挥发分取用类型
        {
            get { return _挥发分取用类型; }
            set
            {
                if (_挥发分取用类型 != value)
                {
                    _挥发分取用类型 = value;
                    RaisePropertyChanged("挥发分取用类型");
                }
            }
        }
        #endregion
        #region S检验人
        private string _S检验人 = "";
        /// <summary>
        /// S检验人
        public string S检验人
        {
            get { return GetName(_S检验人); }
            set
            {
                if (_S检验人 != value)
                {
                    _S检验人 = value;
                    RaisePropertyChanged("S检验人");
                }
            }
        }
        #endregion
        #region S检验时间
        private DateTime? _S检验时间 = null;
        /// <summary>
        /// S检验时间
        public DateTime? S检验时间
        {
            get { return _S检验时间; }
            set
            {
                if (_S检验时间 != value)
                {
                    _S检验时间 = value;
                    RaisePropertyChanged("S检验时间");
                }
            }
        }
        #endregion
        #region S检验值
        private string _S检验值 = "";
        /// <summary>
        /// S检验值
        public string S检验值
        {
            get { return _S检验值; }
            set
            {
                if (_S检验值 != value)
                {
                    _S检验值 = value;
                    RaisePropertyChanged("S检验值");
                }
            }
        }
        #endregion
        #region S报检值
        private string _S报检值 = null;
        /// <summary>
        /// S报检值
        public string S报检值
        {
            get { return _S报检值; }
            set
            {
                if (_S报检值 != value)
                {
                    _S报检值 = value;
                    RaisePropertyChanged("S报检值");
                }
            }
        }
        #endregion
        #region S复检值
        private string _S复检值 = null;
        [NonTableField]
        public string S复检值
        {
            get { return _S复检值; }
            set
            {
                if (_S复检值 != value)
                {
                    _S复检值 = value;
                    RaisePropertyChanged("S复检值");
                }
            }
        }
        #endregion
        #region S复检人
        private string _S复检人 = null;
        [NonTableField]
        public string S复检人
        {
            get { return _S复检人; }
            set
            {
                if (_S复检人 != value)
                {
                    _S复检人 = value;
                    RaisePropertyChanged("_S复检人");
                }
            }
        }
        #endregion
        #region S复检时间
        private DateTime? _S复检时间 = null;
        [NonTableField]
        public DateTime? S复检时间
        {
            get { return _S复检时间; }
            set
            {
                if (_S复检时间 != value)
                {
                    _S复检时间 = value;
                    RaisePropertyChanged("S复检时间");
                }
            }
        }
        #endregion
        #region  S取用值
        private string _S取用值 = null;
        /// <summary>
        /// 灰分取用值
        public string S取用值
        {
            get { return _S取用值; }
            set
            {
                if (_S取用值 != value)
                {
                    _S取用值 = value;
                    RaisePropertyChanged("S取用值");
                }
            }
        }
        #endregion
        #region S取用类型
        private string _S取用类型 = null;
        /// <summary>
        /// 水分取用类型
        public string S取用类型
        {
            get { return _S取用类型; }
            set
            {
                if (_S取用类型 != value)
                {
                    _S取用类型 = value;
                    RaisePropertyChanged("S取用类型");
                }
            }
        }
        #endregion
        #region X检验人
        private string _X检验人 = "";
        /// <summary>
        /// X检验人
        public string X检验人
        {
            get { return GetName(_X检验人); }
            set
            {
                if (_X检验人 != value)
                {
                    _X检验人 = value;
                    RaisePropertyChanged("X检验人");
                }
            }
        }
        #endregion
        #region X检验时间
        private DateTime? _X检验时间 = null;
        /// <summary>
        /// X检验时间
        public DateTime? X检验时间
        {
            get { return _X检验时间; }
            set
            {
                if (_X检验时间 != value)
                {
                    _X检验时间 = value;
                    RaisePropertyChanged("X检验时间");
                }
            }
        }
        #endregion
        #region X检验值
        private string _X检验值 = "";
        /// <summary>
        /// X检验值
        public string X检验值
        {
            get { return _X检验值; }
            set
            {
                if (_X检验值 != value)
                {
                    _X检验值 = value;
                    RaisePropertyChanged("X检验值");
                }
            }
        }
        #endregion
        #region X报检值
        private string _X报检值 = null;
        /// <summary>
        /// X报检值
        public string X报检值
        {
            get { return _X报检值; }
            set
            {
                if (_X报检值 != value)
                {
                    _X报检值 = value;
                    RaisePropertyChanged("X报检值");
                }
            }
        }
        #endregion
        #region X复检值
        private string _X复检值 = null;
        [NonTableField]
        public string X复检值
        {
            get { return _X复检值; }
            set
            {
                if (_X复检值 != value)
                {
                    _X复检值 = value;
                    RaisePropertyChanged("_X复检值");
                }
            }
        }
        #endregion
        #region X复检人
        private string _X复检人 = null;
        [NonTableField]
        public string X复检人
        {
            get { return _X复检人; }
            set
            {
                if (_X复检人 != value)
                {
                    _X复检人 = value;
                    RaisePropertyChanged("X复检人");
                }
            }
        }
        #endregion
        #region X复检时间
        private DateTime? _X复检时间 = null;
        [NonTableField]
        public DateTime? X复检时间
        {
            get { return _X复检时间; }
            set
            {
                if (_X复检时间 != value)
                {
                    _X复检时间 = value;
                    RaisePropertyChanged("X复检时间");
                }
            }
        }
        #endregion
        #region  X取用值
        private string _X取用值 = null;
        /// <summary>
        /// 灰分取用值
        public string X取用值
        {
            get { return _X取用值; }
            set
            {
                if (_X取用值 != value)
                {
                    _X取用值 = value;
                    RaisePropertyChanged("X取用值");
                }
            }
        }
        #endregion
        #region X取用类型
        private string _X取用类型 = null;
        /// <summary>
        /// 水分取用类型
        public string X取用类型
        {
            get { return _X取用类型; }
            set
            {
                if (_X取用类型 != value)
                {
                    _X取用类型 = value;
                    RaisePropertyChanged("X取用类型");
                }
            }
        }
        #endregion
        #region Y检验人
        private string _Y检验人 = "";
        /// <summary>
        /// Y检验人
        public string Y检验人
        {
            get { return GetName(_Y检验人); }
            set
            {
                if (_Y检验人 != value)
                {
                    _Y检验人 = value;
                    RaisePropertyChanged("Y检验人");
                }
            }
        }
        #endregion
        #region Y检验时间
        private DateTime? _Y检验时间 = null;
        /// <summary>
        /// Y检验时间
        public DateTime? Y检验时间
        {
            get { return _Y检验时间; }
            set
            {
                if (_Y检验时间 != value)
                {
                    _Y检验时间 = value;
                    RaisePropertyChanged("Y检验时间");
                }
            }
        }
        #endregion
        #region Y检验值
        private string _Y检验值 = "";
        /// <summary>
        /// Y检验值
        public string Y检验值
        {
            get { return _Y检验值; }
            set
            {
                if (_Y检验值 != value)
                {
                    _Y检验值 = value;
                    RaisePropertyChanged("Y检验值");
                }
            }
        }
        #endregion
        #region Y报检值
        private string _Y报检值 = null;
        /// <summary>
        /// Y报检值
        public string Y报检值
        {
            get { return _Y报检值; }
            set
            {
                if (_Y报检值 != value)
                {
                    _Y报检值 = value;
                    RaisePropertyChanged("Y报检值");
                }
            }
        }
        #endregion
        #region Y复检值
        private string _Y复检值 = null;
        [NonTableField]
        public string Y复检值
        {
            get { return _Y复检值; }
            set
            {
                if (_Y复检值 != value)
                {
                    _Y复检值 = value;
                    RaisePropertyChanged("Y复检值");
                }
            }
        }
        #endregion
        #region Y复检人
        private string _Y复检人 = null;
        [NonTableField]
        public string Y复检人
        {
            get { return _Y复检人; }
            set
            {
                if (_Y复检人 != value)
                {
                    _Y复检人 = value;
                    RaisePropertyChanged("Y复检人");
                }
            }
        }
        #endregion
        #region Y复检时间
        private DateTime? _Y复检时间 = null;
        [NonTableField]
        public DateTime? Y复检时间
        {
            get { return _Y复检时间; }
            set
            {
                if (_Y复检时间 != value)
                {
                    _Y复检时间 = value;
                    RaisePropertyChanged("Y复检时间");
                }
            }
        }
        #endregion
        #region  Y取用值
        private string _Y取用值 = null;
        /// <summary>
        /// 灰分取用值
        public string Y取用值
        {
            get { return _Y取用值; }
            set
            {
                if (_Y取用值 != value)
                {
                    _Y取用值 = value;
                    RaisePropertyChanged("Y取用值");
                }
            }
        }
        #endregion
        #region Y取用类型
        private string _Y取用类型 = null;
        /// <summary>
        /// 水分取用类型
        public string Y取用类型
        {
            get { return _Y取用类型; }
            set
            {
                if (_Y取用类型 != value)
                {
                    _Y取用类型 = value;
                    RaisePropertyChanged("Y取用类型");
                }
            }
        }
        #endregion
        #region G检验人
        private string _G检验人 = "";
        /// <summary>
        /// G检验人
        public string G检验人
        {
            get { return GetName(_G检验人); }
            set
            {
                if (_G检验人 != value)
                {
                    _G检验人 = value;
                    RaisePropertyChanged("G检验人");
                }
            }
        }
        #endregion
        #region G检验时间
        private DateTime? _G检验时间 = null;
        /// <summary>
        /// G检验时间
        public DateTime? G检验时间
        {
            get { return _G检验时间; }
            set
            {
                if (_G检验时间 != value)
                {
                    _G检验时间 = value;
                    RaisePropertyChanged("G检验时间");
                }
            }
        }
        #endregion
        #region G检验值
        private string _G检验值 = "";
        /// <summary>
        /// G检验值
        public string G检验值
        {
            get { return _G检验值; }
            set
            {
                if (_G检验值 != value)
                {
                    _G检验值 = value;
                    RaisePropertyChanged("G检验值");
                }
            }
        }
        #endregion
        #region G报检值
        private string _G报检值 = null;
        /// <summary>
        /// G报检值
        public string G报检值
        {
            get { return _G报检值; }
            set
            {
                if (_G报检值 != value)
                {
                    _G报检值 = value;
                    RaisePropertyChanged("G报检值");
                }
            }
        }
        #endregion
        #region G复检值
        private string _G复检值 = null;
        [NonTableField]
        public string G复检值
        {
            get { return _G复检值; }
            set
            {
                if (_G复检值 != value)
                {
                    _G复检值 = value;
                    RaisePropertyChanged("G复检值");
                }
            }
        }
        #endregion
        #region G复检人
        private string _G复检人 = null;
        [NonTableField]
        public string G复检人
        {
            get { return _G复检人; }
            set
            {
                if (_G复检人 != value)
                {
                    _G复检人 = value;
                    RaisePropertyChanged("G复检人");
                }
            }
        }
        #endregion
        #region G复检时间
        private DateTime? _G复检时间 = null;
        [NonTableField]
        public DateTime? G复检时间
        {
            get { return _G复检时间; }
            set
            {
                if (_G复检时间 != value)
                {
                    _G复检时间 = value;
                    RaisePropertyChanged("G复检时间");
                }
            }
        }
        #endregion
        #region  G取用值
        private string _G取用值 = null;
        /// <summary>
        /// 灰分取用值
        public string G取用值
        {
            get { return _G取用值; }
            set
            {
                if (_G取用值 != value)
                {
                    _G取用值 = value;
                    RaisePropertyChanged("G取用值");
                }
            }
        }
        #endregion
        #region G取用类型
        private string _G取用类型 = null;
        /// <summary>
        /// 水分取用类型
        public string G取用类型
        {
            get { return _G取用类型; }
            set
            {
                if (_G取用类型 != value)
                {
                    _G取用类型 = value;
                    RaisePropertyChanged("G取用类型");
                }
            }
        }
        #endregion
        #region p检验人
        private string _p检验人 = "";
        /// <summary>
        /// p检验人
        public string p检验人
        {
            get { return GetName(_p检验人); }
            set
            {
                if (_p检验人 != value)
                {
                    _p检验人 = value;
                    RaisePropertyChanged("p检验人");
                }
            }
        }
        #endregion
        #region p检验时间
        private DateTime? _p检验时间 = null;
        /// <summary>
        /// p检验时间
        public DateTime? p检验时间
        {
            get { return _p检验时间; }
            set
            {
                if (_p检验时间 != value)
                {
                    _p检验时间 = value;
                    RaisePropertyChanged("p检验时间");
                }
            }
        }
        #endregion
        #region p检验值
        private string _p检验值 = "";
        /// <summary>
        /// p检验值
        public string p检验值
        {
            get { return _p检验值; }
            set
            {
                if (_p检验值 != value)
                {
                    _p检验值 = value;
                    RaisePropertyChanged("p检验值");
                }
            }
        }
        #endregion
        #region p报检值
        private string _p报检值 = null;
        /// <summary>
        /// p报检值
        public string p报检值
        {
            get { return _p报检值; }
            set
            {
                if (_p报检值 != value)
                {
                    _p报检值 = value;
                    RaisePropertyChanged("p报检值");
                }
            }
        }
        #endregion
        #region p复检值
        private string _p复检值 = null;
        [NonTableField]
        public string p复检值
        {
            get { return _p复检值; }
            set
            {
                if (_p复检值 != value)
                {
                    _p复检值 = value;
                    RaisePropertyChanged("p复检值");
                }
            }
        }
        #endregion
        #region p复检人
        private string _p复检人 = null;
        [NonTableField]
        public string p复检人
        {
            get { return _p复检人; }
            set
            {
                if (_p复检人 != value)
                {
                    _p复检人 = value;
                    RaisePropertyChanged("p复检人");
                }
            }
        }
        #endregion
        #region p复检时间
        private DateTime? _p复检时间 = null;
        [NonTableField]
        public DateTime? p复检时间
        {
            get { return _p复检时间; }
            set
            {
                if (_p复检时间 != value)
                {
                    _p复检时间 = value;
                    RaisePropertyChanged("p复检时间");
                }
            }
        }
        #endregion
        #region  p取用值
        private string _p取用值 = null;
        /// <summary>
        /// 灰分取用值
        public string p取用值
        {
            get { return _p取用值; }
            set
            {
                if (_p取用值 != value)
                {
                    _p取用值 = value;
                    RaisePropertyChanged("p取用值");
                }
            }
        }
        #endregion
        #region p取用类型
        private string _p取用类型 = null;
        /// <summary>
        /// 水分取用类型
        public string p取用类型
        {
            get { return _p取用类型; }
            set
            {
                if (_p取用类型 != value)
                {
                    _p取用类型 = value;
                    RaisePropertyChanged("p取用类型");
                }
            }
        }
        #endregion
        #region 硫分检验人
        private string _硫分检验人 = "";
        /// <summary>
        /// 硫分检验人
        public string 硫分检验人
        {
            get { return GetName(_硫分检验人); }
            set
            {
                if (_硫分检验人 != value)
                {
                    _硫分检验人 = value;
                    RaisePropertyChanged("硫分检验人");
                }
            }
        }
        #endregion
        #region 硫分检验时间
        private DateTime? _硫分检验时间 = null;
        /// <summary>
        /// 硫分检验时间
        public DateTime? 硫分检验时间
        {
            get { return _硫分检验时间; }
            set
            {
                if (_硫分检验时间 != value)
                {
                    _硫分检验时间 = value;
                    RaisePropertyChanged("硫分检验时间");
                }
            }
        }
        #endregion
        #region 硫分检验值
        private string _硫分检验值 = "";
        /// <summary>
        /// 硫分检验值
        public string 硫分检验值
        {
            get { return _硫分检验值; }
            set
            {
                if (_硫分检验值 != value)
                {
                    _硫分检验值 = value;
                    RaisePropertyChanged("硫分检验值");
                }
            }
        }
        #endregion
        #region 硫分报检值
        private string _硫分报检值 = null;
        /// <summary>
        /// 硫分报检值
        public string 硫分报检值
        {
            get { return _硫分报检值; }
            set
            {
                if (_硫分报检值 != value)
                {
                    _硫分报检值 = value;
                    RaisePropertyChanged("硫分报检值");
                }
            }
        }
        #endregion
        #region 硫分复检值
        private string _硫分复检值 = null;
        [NonTableField]
        public string 硫分复检值
        {
            get { return _硫分复检值; }
            set
            {
                if (_硫分复检值 != value)
                {
                    _硫分复检值 = value;
                    RaisePropertyChanged("硫分复检值");
                }
            }
        }
        #endregion
        #region 硫分复检人
        private string _硫分复检人 = null;
        [NonTableField]
        public string 硫分复检人
        {
            get { return _硫分复检人; }
            set
            {
                if (_硫分复检人 != value)
                {
                    _硫分复检人 = value;
                    RaisePropertyChanged("硫分复检人");
                }
            }
        }
        #endregion
        #region 硫分复检时间
        private DateTime? _硫分复检时间 = null;
        [NonTableField]
        public DateTime? 硫分复检时间
        {
            get { return _硫分复检时间; }
            set
            {
                if (_硫分复检时间 != value)
                {
                    _硫分复检时间 = value;
                    RaisePropertyChanged("硫分复检时间");
                }
            }
        }
        #endregion
        #region  硫分取用值
        private string _硫分取用值 = null;
        /// <summary>
        /// 灰分取用值
        public string 硫分取用值
        {
            get { return _硫分取用值; }
            set
            {
                if (_硫分取用值 != value)
                {
                    _硫分取用值 = value;
                    RaisePropertyChanged("硫分取用值");
                }
            }
        }
        #endregion
        #region 硫分取用类型
        private string _硫分取用类型 = null;
        /// <summary>
        /// 水分取用类型
        public string 硫分取用类型
        {
            get { return _硫分取用类型; }
            set
            {
                if (_硫分取用类型 != value)
                {
                    _硫分取用类型 = value;
                    RaisePropertyChanged("硫分取用类型");
                }
            }
        }
        #endregion
        #region 发热量1检验人
        private string _发热量1检验人 = "";
        /// <summary>
        /// 发热量1检验人
        public string 发热量1检验人
        {
            get { return _发热量1检验人; }
            set
            {
                if (_发热量1检验人 != value)
                {
                    _发热量1检验人 = value;
                    RaisePropertyChanged("发热量1检验人");
                }
            }
        }
        #endregion
        #region 发热量1检验时间
        private DateTime? _发热量1检验时间 = null;
        /// <summary>
        /// 发热量1检验时间
        public DateTime? 发热量1检验时间
        {
            get { return _发热量1检验时间; }
            set
            {
                if (_发热量1检验时间 != value)
                {
                    _发热量1检验时间 = value;
                    RaisePropertyChanged("发热量1检验时间");
                }
            }
        }
        #endregion
        #region 发热量1检验值
        private string _发热量1检验值 = "";
        /// <summary>
        /// 发热量1检验值
        public string 发热量1检验值
        {
            get { return _发热量1检验值; }
            set
            {
                if (_发热量1检验值 != value)
                {
                    _发热量1检验值 = value;
                    RaisePropertyChanged("发热量1检验值");
                }
            }
        }
        #endregion
        #region 发热量1报检值
        private string _发热量1报检值 = null;
        /// <summary>
        /// 发热量1报检值
        public string 发热量1报检值
        {
            get { return _发热量1报检值; }
            set
            {
                if (_发热量1报检值 != value)
                {
                    _发热量1报检值 = value;
                    RaisePropertyChanged("发热量1报检值");
                }
            }
        }
        #endregion
        #region 发热量1复检值
        private string _发热量1复检值 = null;
        [NonTableField]
        public string 发热量1复检值
        {
            get { return _发热量1复检值; }
            set
            {
                if (_发热量1复检值 != value)
                {
                    _发热量1复检值 = value;
                    RaisePropertyChanged("发热量1复检值");
                }
            }
        }
        #endregion
        #region 发热量1复检人
        private string _发热量1复检人 = null;
        [NonTableField]
        public string 发热量1复检人
        {
            get { return _发热量1复检人; }
            set
            {
                if (_发热量1复检人 != value)
                {
                    _发热量1复检人 = value;
                    RaisePropertyChanged("发热量1复检人");
                }
            }
        }
        #endregion
        #region 发热量1复检时间
        private DateTime? _发热量1复检时间 = null;
        [NonTableField]
        public DateTime? 发热量1复检时间
        {
            get { return _发热量1复检时间; }
            set
            {
                if (_发热量1复检时间 != value)
                {
                    _发热量1复检时间 = value;
                    RaisePropertyChanged("发热量1复检时间");
                }
            }
        }
        #endregion
        #region  发热量1取用值
        private string _发热量1取用值 = null;
        /// <summary>
        /// 灰分取用值
        public string 发热量1取用值
        {
            get { return _发热量1取用值; }
            set
            {
                if (_发热量1取用值 != value)
                {
                    _发热量1取用值 = value;
                    RaisePropertyChanged("发热量1取用值");
                }
            }
        }
        #endregion
        #region 发热量1取用类型
        private string _发热量1取用类型 = null;
        /// <summary>
        /// 水分取用类型
        public string 发热量1取用类型
        {
            get { return _发热量1取用类型; }
            set
            {
                if (_发热量1取用类型 != value)
                {
                    _发热量1取用类型 = value;
                    RaisePropertyChanged("发热量1取用类型");
                }
            }
        }
        #endregion
        #region 标准差S检验人
        private string _标准差S检验人 = "";
        /// <summary>
        /// 标准差S检验人
        public string 标准差S检验人
        {
            get { return GetName(_标准差S检验人); }
            set
            {
                if (_标准差S检验人 != value)
                {
                    _标准差S检验人 = value;
                    RaisePropertyChanged("标准差S检验人");
                }
            }
        }
        #endregion
        #region 标准差S检验时间
        private DateTime? _标准差S检验时间 = null;
        /// <summary>
        /// 标准差S检验时间
        public DateTime? 标准差S检验时间
        {
            get { return _标准差S检验时间; }
            set
            {
                if (_标准差S检验时间 != value)
                {
                    _标准差S检验时间 = value;
                    RaisePropertyChanged("标准差S检验时间");
                }
            }
        }
        #endregion
        #region 标准差S检验值
        private string _标准差S检验值 = "";
        /// <summary>
        /// 标准差S检验值
        public string 标准差S检验值
        {
            get { return _标准差S检验值; }
            set
            {
                if (_标准差S检验值 != value)
                {
                    _标准差S检验值 = value;
                    RaisePropertyChanged("标准差S检验值");
                }
            }
        }
        #endregion
        #region 标准差S报检值
        private string _标准差S报检值 = null;
        /// <summary>
        /// 标准差S报检值
        public string 标准差S报检值
        {
            get { return _标准差S报检值; }
            set
            {
                if (_标准差S报检值 != value)
                {
                    _标准差S报检值 = value;
                    RaisePropertyChanged("标准差S报检值");
                }
            }
        }
        #endregion
        #region 标准差S复检值
        private string _标准差S复检值 = null;
        [NonTableField]
        public string 标准差S复检值
        {
            get { return _标准差S复检值; }
            set
            {
                if (_标准差S复检值 != value)
                {
                    _标准差S复检值 = value;
                    RaisePropertyChanged("标准差S复检值");
                }
            }
        }
        #endregion
        #region 标准差S复检人
        private string _标准差S复检人 = null;
        [NonTableField]
        public string 标准差S复检人
        {
            get { return _标准差S复检人; }
            set
            {
                if (_标准差S复检人 != value)
                {
                    _标准差S复检人 = value;
                    RaisePropertyChanged("标准差S复检人");
                }
            }
        }
        #endregion
        #region 标准差S复检时间
        private DateTime? _标准差S复检时间 = null;
        [NonTableField]
        public DateTime? 标准差S复检时间
        {
            get { return _标准差S复检时间; }
            set
            {
                if (_标准差S复检时间 != value)
                {
                    _标准差S复检时间 = value;
                    RaisePropertyChanged("标准差S复检时间");
                }
            }
        }
        #endregion
        #region  标准差S取用值
        private string _标准差S取用值 = null;
        /// <summary>
        /// 灰分取用值
        public string 标准差S取用值
        {
            get { return _标准差S取用值; }
            set
            {
                if (_标准差S取用值 != value)
                {
                    _标准差S取用值 = value;
                    RaisePropertyChanged("标准差S取用值");
                }
            }
        }
        #endregion
        #region 标准差S取用类型
        private string _标准差S取用类型 = null;
        /// <summary>
        /// 水分取用类型
        public string 标准差S取用类型
        {
            get { return _标准差S取用类型; }
            set
            {
                if (_标准差S取用类型 != value)
                {
                    _标准差S取用类型 = value;
                    RaisePropertyChanged("标准差S取用类型");
                }
            }
        }
        #endregion
        #region 角质层Y制样码
        private string _角质层Y制样码 = "";
        /// <summary>
        /// 角质层Y制样码
        public string 角质层Y制样码
        {
            get { return _角质层Y制样码; }
            set
            {
                if (_角质层Y制样码 != value)
                {
                    _角质层Y制样码 = value;
                    RaisePropertyChanged("角质层Y制样码");
                }
            }
        }
        #endregion
        #region 角质层Y制样人
        private string _角质层Y制样人 = "";
        /// <summary>
        /// 角质层Y制样人
        public string 角质层Y制样人
        {
            get { return GetName(_角质层Y制样人); }
            set
            {
                if (_角质层Y制样人 != value)
                {
                    _角质层Y制样人 = value;
                    RaisePropertyChanged("角质层Y制样人");
                }
            }
        }
        #endregion
        #region 角质层Y制时间
        private DateTime? _角质层Y制时间 = null;
        /// <summary>
        /// 角质层Y制样时间
        public DateTime? 角质层Y制样时间
        {
            get { return _角质层Y制时间; }
            set
            {
                if (_角质层Y制时间 != value)
                {
                    _角质层Y制时间 = value;
                    RaisePropertyChanged("角质层Y制样时间");
                }
            }
        }
        #endregion
        #region 角质层Y检验码
        private string _角质层Y检验码 = "";
        /// <summary>
        /// 角质层Y检验码
        public string 角质层Y检验码
        {
            get { return _角质层Y检验码; }
            set
            {
                if (_角质层Y检验码 != value)
                {
                    _角质层Y检验码 = value;
                    RaisePropertyChanged("角质层Y检验码");
                }
            }
        }
        #endregion
        #region 角质层Y收样人
        private string _角质层Y收样人 = "";
        /// <summary>
        /// 角质层Y收样人
        public string 角质层Y收样人
        {
            get { return GetName(_角质层Y收样人); }
            set
            {
                if (_角质层Y收样人 != value)
                {
                    _角质层Y收样人 = value;
                    RaisePropertyChanged("角质层Y收样人");
                }
            }
        }
        #endregion
        #region 角质层Y收样时间
        private DateTime? _角质层Y收样时间 = null;
        /// <summary>
        /// 角质层Y收样时间
        public DateTime? 角质层Y收样时间
        {
            get { return _角质层Y收样时间; }
            set
            {
                if (_角质层Y收样时间 != value)
                {
                    _角质层Y收样时间 = value;
                    RaisePropertyChanged("角质层Y收样时间");
                }
            }
        }
        #endregion
        #region 角质层Y审核人
        private string _角质层Y审核人 = "";
        /// <summary>
        /// 角质层Y审核人
        public string 角质层Y审核人
        {
            get { return GetName(_角质层Y审核人); }
            set
            {
                if (_角质层Y审核人 != value)
                {
                    _角质层Y审核人 = value;
                    RaisePropertyChanged("角质层Y审核人");
                }
            }
        }
        #endregion
        #region 角质层Y审核时间
        private DateTime? _角质层Y审核时间 = null;
        /// <summary>
        /// 角质层Y审核时间
        public DateTime? 角质层Y审核时间
        {
            get { return _角质层Y审核时间; }
            set
            {
                if (_角质层Y审核时间 != value)
                {
                    _角质层Y审核时间 = value;
                    RaisePropertyChanged("角质层Y审核时间");
                }
            }
        }
        #endregion
        #region 角质层G制样码
        private string _角质层G制样码 = "";
        /// <summary>
        /// 角质层G制样码
        public string 角质层G制样码
        {
            get { return _角质层G制样码; }
            set
            {
                if (_角质层G制样码 != value)
                {
                    _角质层G制样码 = value;
                    RaisePropertyChanged("角质层G制样码");
                }
            }
        }
        #endregion
        #region 角质层G制样人
        private string _角质层G制样人 = "";
        /// <summary>
        /// 角质层G制样人
        public string 角质层G制样人
        {
            get { return GetName(_角质层G制样人); }
            set
            {
                if (_角质层G制样人 != value)
                {
                    _角质层G制样人 = value;
                    RaisePropertyChanged("角质层G制样人");
                }
            }
        }
        #endregion
        #region 角质层G制时间
        private DateTime? _角质层G制时间 = null;
        /// <summary>
        /// 角质层G制样时间
        public DateTime? 角质层G制样时间
        {
            get { return _角质层G制时间; }
            set
            {
                if (_角质层G制时间 != value)
                {
                    _角质层G制时间 = value;
                    RaisePropertyChanged("角质层G制样时间");
                }
            }
        }
        #endregion
        #region 角质层G检验码
        private string _角质层G检验码 = "";
        /// <summary>
        /// 角质层G检验码
        public string 角质层G检验码
        {
            get { return _角质层G检验码; }
            set
            {
                if (_角质层G检验码 != value)
                {
                    _角质层G检验码 = value;
                    RaisePropertyChanged("角质层G检验码");
                }
            }
        }
        #endregion
        #region 角质层G收样人
        private string _角质层G收样人 = "";
        /// <summary>
        /// 角质层G收样人
        public string 角质层G收样人
        {
            get { return GetName(_角质层G收样人); }
            set
            {
                if (_角质层G收样人 != value)
                {
                    _角质层G收样人 = value;
                    RaisePropertyChanged("角质层G收样人");
                }
            }
        }
        #endregion
        #region 角质层G收样时间
        private DateTime? _角质层G收样时间 = null;
        /// <summary>
        /// 角质层G收样时间
        public DateTime? 角质层G收样时间
        {
            get { return _角质层G收样时间; }
            set
            {
                if (_角质层G收样时间 != value)
                {
                    _角质层G收样时间 = value;
                    RaisePropertyChanged("角质层G收样时间");
                }
            }
        }
        #endregion
        #region 角质层G审核人
        private string _角质层G审核人 = "";
        /// <summary>
        /// 角质层G审核人
        public string 角质层G审核人
        {
            get { return GetName(_角质层G审核人); }
            set
            {
                if (_角质层G审核人 != value)
                {
                    _角质层G审核人 = value;
                    RaisePropertyChanged("角质层G审核人");
                }
            }
        }
        #endregion
        #region 角质层G审核时间
        private DateTime? _角质层G审核时间 = null;
        /// <summary>
        /// 角质层G审核时间
        public DateTime? 角质层G审核时间
        {
            get { return _角质层G审核时间; }
            set
            {
                if (_角质层G审核时间 != value)
                {
                    _角质层G审核时间 = value;
                    RaisePropertyChanged("角质层G审核时间");
                }
            }
        }
        #endregion
        #region 煤岩样制样码
        private string _煤岩样制样码 = "";
        /// <summary>
        /// 煤岩样制样码
        public string 煤岩样制样码
        {
            get { return _煤岩样制样码; }
            set
            {
                if (_煤岩样制样码 != value)
                {
                    _煤岩样制样码 = value;
                    RaisePropertyChanged("煤岩样制样码");
                }
            }
        }
        #endregion
        #region 煤岩样制样人
        private string _煤岩样制样人 = "";
        /// <summary>
        /// 煤岩样制样人
        public string 煤岩样制样人
        {
            get { return GetName(_煤岩样制样人); }
            set
            {
                if (_煤岩样制样人 != value)
                {
                    _煤岩样制样人 = value;
                    RaisePropertyChanged("煤岩样制样人");
                }
            }
        }
        #endregion
        #region 煤岩样制时间
        private DateTime? _煤岩样制时间 = null;
        /// <summary>
        /// 煤岩样制样时间
        public DateTime? 煤岩样制样时间
        {
            get { return _煤岩样制时间; }
            set
            {
                if (_煤岩样制时间 != value)
                {
                    _煤岩样制时间 = value;
                    RaisePropertyChanged("煤岩样制样时间");
                }
            }
        }
        #endregion
        #region 煤岩样检验码
        private string _煤岩样检验码 = "";
        /// <summary>
        /// 煤岩样检验码
        public string 煤岩样检验码
        {
            get { return _煤岩样检验码; }
            set
            {
                if (_煤岩样检验码 != value)
                {
                    _煤岩样检验码 = value;
                    RaisePropertyChanged("煤岩样检验码");
                }
            }
        }
        #endregion
        #region 煤岩样收样人
        private string _煤岩样收样人 = "";
        /// <summary>
        /// 煤岩样收样人
        public string 煤岩样收样人
        {
            get { return GetName(_煤岩样收样人); }
            set
            {
                if (_煤岩样收样人 != value)
                {
                    _煤岩样收样人 = value;
                    RaisePropertyChanged("煤岩样收样人");
                }
            }
        }
        #endregion
        #region 煤岩样收样时间
        private DateTime? _煤岩样收样时间 = null;
        /// <summary>
        /// 煤岩样收样时间
        public DateTime? 煤岩样收样时间
        {
            get { return _煤岩样收样时间; }
            set
            {
                if (_煤岩样收样时间 != value)
                {
                    _煤岩样收样时间 = value;
                    RaisePropertyChanged("煤岩样收样时间");
                }
            }
        }
        #endregion
        #region 煤岩样审核人
        private string _煤岩样审核人 = "";
        /// <summary>
        /// 煤岩样审核人
        public string 煤岩样审核人
        {
            get { return GetName(_煤岩样审核人); }
            set
            {
                if (_煤岩样审核人 != value)
                {
                    _煤岩样审核人 = value;
                    RaisePropertyChanged("煤岩样审核人");
                }
            }
        }
        #endregion
        #region 煤岩样审核时间
        private DateTime? _煤岩样审核时间 = null;
        /// <summary>
        /// 煤岩样审核时间
        public DateTime? 煤岩样审核时间
        {
            get { return _煤岩样审核时间; }
            set
            {
                if (_煤岩样审核时间 != value)
                {
                    _煤岩样审核时间 = value;
                    RaisePropertyChanged("煤岩样审核时间");
                }
            }
        }
        #endregion
        #region Rmax检验值
        private string _Rmax检验值 = "";
        /// <summary>
        /// Rmax检验值
        public string Rmax检验值
        {
            get { return _Rmax检验值; }
            set
            {
                if (_Rmax检验值 != value)
                {
                    _Rmax检验值 = value;
                    RaisePropertyChanged("Rmax检验值");
                }
            }
        }
        #endregion
        #region Rmax报检值
        private string _Rmax报检值 = null;
        /// <summary>
        /// Rmax报检值
        public string Rmax报检值
        {
            get { return _Rmax报检值; }
            set
            {
                if (_Rmax报检值 != value)
                {
                    _Rmax报检值 = value;
                    RaisePropertyChanged("Rmax报检值");
                }
            }
        }
        #endregion
        #region Rmax复检值
        private string _Rmax复检值 = null;
        [NonTableField]
        public string Rmax复检值
        {
            get { return _Rmax复检值; }
            set
            {
                if (_Rmax复检值 != value)
                {
                    _Rmax复检值 = value;
                    RaisePropertyChanged("Rmax复检值");
                }
            }
        }
        #endregion
        #region Rmax复检人
        private string _Rmax复检人 = null;
        [NonTableField]
        public string Rmax复检人
        {
            get { return _Rmax复检人; }
            set
            {
                if (_Rmax复检人 != value)
                {
                    _Rmax复检人 = value;
                    RaisePropertyChanged("Rmax复检人");
                }
            }
        }
        #endregion
        #region Rmax复检时间
        private DateTime? _Rmax复检时间 = null;
        [NonTableField]
        public DateTime? Rmax复检时间
        {
            get { return _Rmax复检时间; }
            set
            {
                if (_Rmax复检时间 != value)
                {
                    _Rmax复检时间 = value;
                    RaisePropertyChanged("Rmax复检时间");
                }
            }
        }
        #endregion
        #region  Rmax取用值
        private string _Rmax取用值 = null;
        /// <summary>
        /// 灰分取用值
        public string Rmax取用值
        {
            get { return _Rmax取用值; }
            set
            {
                if (_Rmax取用值 != value)
                {
                    _Rmax取用值 = value;
                    RaisePropertyChanged("Rmax取用值");
                }
            }
        }
        #endregion
        #region Rmax取用类型
        private string _Rmax取用类型 = null;
        /// <summary>
        /// 水分取用类型
        public string Rmax取用类型
        {
            get { return _Rmax取用类型; }
            set
            {
                if (_Rmax取用类型 != value)
                {
                    _Rmax取用类型 = value;
                    RaisePropertyChanged("Rmax取用类型");
                }
            }
        }
        #endregion
        #region 可磨样制样码
        private string _可磨样制样码 = "";
        /// <summary>
        /// 可磨样制样码
        public string 可磨样制样码
        {
            get { return _可磨样制样码; }
            set
            {
                if (_可磨样制样码 != value)
                {
                    _可磨样制样码 = value;
                    RaisePropertyChanged("可磨样制样码");
                }
            }
        }
        #endregion
        #region 可磨样制样人
        private string _可磨样制样人 = "";
        /// <summary>
        /// 可磨样制样人
        public string 可磨样制样人
        {
            get { return GetName(_可磨样制样人); }
            set
            {
                if (_可磨样制样人 != value)
                {
                    _可磨样制样人 = value;
                    RaisePropertyChanged("可磨样制样人");
                }
            }
        }
        #endregion
        #region 可磨样制时间
        private DateTime? _可磨样制时间 = null;
        /// <summary>
        /// 可磨样制样时间
        public DateTime? 可磨样制样时间
        {
            get { return _可磨样制时间; }
            set
            {
                if (_可磨样制时间 != value)
                {
                    _可磨样制时间 = value;
                    RaisePropertyChanged("可磨样制样时间");
                }
            }
        }
        #endregion
        #region 可磨检验值
        private string _可磨检验值 = "";
        /// <summary>
        /// 可磨检验值
        public string 可磨检验值
        {
            get { return _可磨检验值; }
            set
            {
                if (_可磨检验值 != value)
                {
                    _可磨检验值 = value;
                    RaisePropertyChanged("可磨检验值");
                }
            }
        }
        #endregion
        #region 可磨报检值
        private string _可磨报检值 = null;
        /// <summary>
        /// 可磨报检值
        public string 可磨报检值
        {
            get { return _可磨报检值; }
            set
            {
                if (_可磨报检值 != value)
                {
                    _可磨报检值 = value;
                    RaisePropertyChanged("可磨报检值");
                }
            }
        }
        #endregion
        #region 可磨复检值
        private string _可磨复检值 = null;
        [NonTableField]
        public string 可磨复检值
        {
            get { return _可磨复检值; }
            set
            {
                if (_可磨复检值 != value)
                {
                    _可磨复检值 = value;
                    RaisePropertyChanged("可磨复检值");
                }
            }
        }
        #endregion
        #region 可磨复检人
        private string _可磨复检人 = null;
        [NonTableField]
        public string 可磨复检人
        {
            get { return _可磨复检人; }
            set
            {
                if (_可磨复检人 != value)
                {
                    _可磨复检人 = value;
                    RaisePropertyChanged("可磨复检人");
                }
            }
        }
        #endregion
        #region 可磨复检时间
        private DateTime? _可磨复检时间 = null;
        [NonTableField]
        public DateTime? 可磨复检时间
        {
            get { return _可磨复检时间; }
            set
            {
                if (_可磨复检时间 != value)
                {
                    _可磨复检时间 = value;
                    RaisePropertyChanged("可磨复检时间");
                }
            }
        }
        #endregion
        #region  可磨取用值
        private string _可磨取用值 = null;
        /// <summary>
        /// 灰分取用值
        public string 可磨取用值
        {
            get { return _可磨取用值; }
            set
            {
                if (_可磨取用值 != value)
                {
                    _可磨取用值 = value;
                    RaisePropertyChanged("可磨取用值");
                }
            }
        }
        #endregion
        #region 可磨取用类型
        private string _可磨取用类型 = null;
        /// <summary>
        /// 水分取用类型
        public string 可磨取用类型
        {
            get { return _可磨取用类型; }
            set
            {
                if (_可磨取用类型 != value)
                {
                    _可磨取用类型 = value;
                    RaisePropertyChanged("可磨取用类型");
                }
            }
        }
        #endregion
        #region 是否抽查
        private Boolean _是否抽查;
        /// <summary>
        /// 取样点
        /// 

        public Boolean 是否抽查
        {
            get { return _是否抽查; }
            set
            {
                if (_是否抽查 != value)
                {
                    _是否抽查 = value;
                    RaisePropertyChanged("是否抽查");
                }
            }
        }
        #endregion
    }
}
