using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zhc.Data;
using System.Data;

namespace Xg.Lab.Sample
{
    public class SampleManager
    {
        public static readonly SampleManager Instance = new SampleManager(); 
       
        public string Test()
        {
            string result = "Ok";

            //DbEntity.Create<QC_Sample_Veh>(true);
            //DbEntity.Create<QC_Sample_Mix>(true);
            //DbEntity.Create<QC_Sample_Lab>(true);
            //DbEntity.Create<QC_Sample_Value>(true);
            //DbEntity.Create<QC_Sample_TempID>(true);
            //DbEntity.Create<QC_Lab_Type>(true);
            //DbEntity.Create<QC_Lab_Type_Content>(true);
            //DbEntity.Create<QC_IC_Info>(true);

            return result;

        }

        public string To32Str(int val)
        {
            StringBuilder result = new StringBuilder();
            string c32 = "0123456789ABCDEFGHJKLMNPQRTUVWXY";
            int mask = 0x1F;
            for (int i = 5; i >= 0; i--)
            {
                int n = (val >> (i * 5)) & mask;
                result.Append(c32[n]);
            }
            return result.ToString();
        }
    }
}
