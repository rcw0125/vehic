using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xg.Lab.ViewModel
{
    public interface ITreeViewModel
    {
         string ID
        {
            get;
            set;
        }

         string ParentID
        {
            get;
            set;
        }

         string DisplayText
        {
            get;
            set;
        }

         int ImageIndex { get; set; }
    }
}
