using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zhc.Data;

namespace Xg.Lab.Sample.View
{
    [DbTable(IsView = true)]
    public class QC_CardUseType : DbEntity
    {
        private string _CardUseTypeCode = "";
        /// <summary>
        /// 磁扣使用类型编码
        /// </summary>
        public string CUTCode
        {
            get { return _CardUseTypeCode; }
            set
            {
                if (_CardUseTypeCode != value)
                {
                    _CardUseTypeCode = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string _CardUseTypeName = "";
        /// <summary>
        /// 磁扣使用类型名称
        /// </summary>
        public string CUTName
        {
            get { return _CardUseTypeName; }
            set
            {
                if (_CardUseTypeName != value)
                {
                    _CardUseTypeName = value;
                    RaisePropertyChanged();
                }
            }
        }

        public static DbEntityTable<QC_CardUseType> LoadCardUseType()
        {
            DbEntityTable<QC_CardUseType> result = new DbEntityTable<QC_CardUseType>();
            QC_CardUseType cut1 = new QC_CardUseType();
            cut1.CUTCode = QC_IC_Info.CardUseType_Veh;
            cut1.CUTName = "车取样扣";
            result.Add(cut1);
            QC_CardUseType cut2 = new QC_CardUseType();
            cut2.CUTCode = "CUT002";
            cut2.CUTName = "组批样扣";
            result.Add(cut2);

            DbEntityTable<QC_CheckGroup> groups = new DbEntityTable<QC_CheckGroup>();
            groups.LoadData();
            foreach (var item in groups)
            {
                QC_CardUseType cut = new QC_CardUseType();
                cut.CUTCode = "CUT_" + item.CheckGroupCode;
                cut.CUTName = item.CheckGroupName + "扣";
                result.Add(cut);
            }
            return result;
        }

        public override string ToString()
        {
            return this.CUTName;
        }
    }
}
