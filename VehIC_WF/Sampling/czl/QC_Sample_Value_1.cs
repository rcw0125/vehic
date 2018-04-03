using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zhc.Data;
using System.ComponentModel;
using Zhc.CalFramework;
namespace Xg.Lab.Sample
{
    public partial class QC_Sample_Value : DbEntity  
     { 
   

         private string _JYCODE;

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
       
    }
}
