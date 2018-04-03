using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xg.Lab.ViewModel
{
    public class TreeViewModel:ITreeViewModel
    {
        private string _id = "";

        public string ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _ParentId;

        public string ParentID
        {
            get { return _ParentId; }
            set { _ParentId = value; }
        }


        private string _DisplayText = "";
        public string DisplayText
        {
            get
            {
                return _DisplayText;
            }
            set
            {
                _DisplayText = value;
            }
        }

        private int _imageIndex = 0;
        public int ImageIndex
        {
            get
            {
                return _imageIndex;
            }
            set
            {
                _imageIndex = value;
            }
        }
    }
}
