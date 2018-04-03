using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using VehIC_WF;
using Xg.Lab.Sample;
using Zhc;
using Zhc.Data;
namespace Xg.Lab.ViewModel
{
    public class VM_VerifSample : EntityBase
    {
        private QC_Sample_Mix head = new QC_Sample_Mix();
        public QC_Sample_Mix QC_Sample_Mix
        {
            get
            {
                return head;
            }
        }

        private DbEntityTable<QC_Sample_Veh> body1 = new DbEntityTable<QC_Sample_Veh>();
        private DbEntityTable<QC_Sample_Value> body2 = new DbEntityTable<QC_Sample_Value>();

        /// <summary>
        /// 作业点编码
        /// </summary>
        [DisplayName("作业点编码")]
        public string WpCode
        {
            get { return head.WpCode; }
            set
            {
                if (head.WpCode != value)
                {
                    head.WpCode = value;
                    RaisePropertyChanged();
                    WpDisplayText = "";
                }
            }
        }


        [DisplayName("作业点名称")]
        public string WpName
        {
            get { return head.WpName; }
            set
            {
                if (head.WpName != value)
                {
                    head.WpName = value;
                    RaisePropertyChanged();
                    WpDisplayText = "";
                }
            }
        }

        [DisplayName("作业点")]
        public string WpDisplayText
        {
            get
            {
                if (string.IsNullOrEmpty(WpCode))
                {
                    return "";
                }
                else
                {
                    return string.Format("({0}){1}", WpCode, WpName);
                }
            }
            set {
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 物料主键
        /// </summary>
        [DisplayName("物料主键")]
        public string MatPK
        {
            get { return head.MatPK; }
            set
            {
                if (head.MatPK != value)
                {
                    head.MatPK = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// 物料编码
        /// </summary>
        [DisplayName("物料编码")]
        public string MatCode
        {
            get { return head.MatCode; }
            set
            {
                if (head.MatCode != value)
                {
                    head.MatCode = value;
                    RaisePropertyChanged();
                    MatDisplayText = "";
                }
            }
        }

        [DisplayName("物料名称")]
        public string MatName
        {
            get { return head.MatName; }
            set
            {
                if (head.MatName != value)
                {
                    head.MatName = value;
                    RaisePropertyChanged();
                    MatDisplayText = "";
                }
            }
        }
        
        [DisplayName("物料")]
        public string MatDisplayText
        {
            get
            {
                if (string.IsNullOrEmpty(MatPK))
                {
                    return "";
                }
                else
                {
                    return string.Format("({0}){1}", MatCode, MatName);
                }
               
            }
            set
            {
                RaisePropertyChanged();
            }
        }

    
        /// <summary>
        /// 创建时间
        /// </summary>
        [DisplayName("创建时间")]
        public DateTime? CreateTime
        {
            get { return head.CreateTime; }
            set
            {
                if (head.CreateTime != value)
                {
                    head.CreateTime = value;
                    RaisePropertyChanged();
                }
            }
        }

        public bool InsertButtonVisible
        {
            get { return true; }
        }

        public bool UpdateButtonVisible
        {
            get { return true; }
        }

        public bool DeleteButtonVisible
        {
            get { return true; }
        }

        public DbEntityTable<QC_Sample_Veh> VehSamples
        {
            get { return body1; }
        }

        public DbEntityTable<QC_Sample_Value> CheckOldValues
        {
            get { return body2; }
        }

        public VM_VerifSample()
        {
          
        }

        public VM_VerifSample(QC_Sample_Mix mixSample)
        {
            this.head = mixSample;
            body1.LoadDataByWhere("Sample_Mix_ID=@Sample_Mix_ID", head.Sample_Mix_ID);
            body2.LoadDataByWhere("Sample_Mix_ID=@Sample_Mix_ID", head.Sample_Mix_ID);
        }

        public void Save()
        {
            head.SampleType = SampleType.校验样;
            CreateTime = DateTime.Now;
            head.CreateUser = LocalInfo.Current.user.ID;
            head.SaveVehSamples = true;
            head.SaveCheckItems = true;
            head.Save();

        }

        

        public void CopyData(QC_Sample_Mix original)
        {
            head.MatPK = original.MatPK;
            head.MatCode = original.MatCode;
            head.MatName = original.MatName;

            body2.Empty();
            DbEntityTable<QC_Sample_Value> orignalSample_CheckVals = new DbEntityTable<QC_Sample_Value>();
            orignalSample_CheckVals.LoadDataByWhere("Sample_Mix_ID=@Sample_Mix_ID", original.Sample_Mix_ID);
            foreach (var item in orignalSample_CheckVals)
            {
                QC_Sample_Value sv = new QC_Sample_Value();
                sv.Sample_Lab_ID = -1;
                sv.CheckItemNcId = item.CheckItemNcId;
                sv.CheckItemCode = item.CheckItemCode;
                sv.CheckItemName = item.CheckItemName;
                sv.CheckItemUnit = item.CheckItemUnit;
                sv.CheckUser = item.CheckUser;
                sv.CheckTime = item.CheckTime;
                body2.Add(sv);
            }
        }
    }
}
