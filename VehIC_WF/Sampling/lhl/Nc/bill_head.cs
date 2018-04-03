using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
namespace VehIC_WF.Sampling.Nc
{
    [Serializable]
    public class bill_head
    {
        private header _header = new header();

        [XmlElement]
        public header header
        {
            get { return _header; }
            set { }
        }

        private VehCollection _items = new VehCollection();
        [XmlElement]
        public VehCollection items
        {
            get { return _items; }
            set { }
        }
        private CheckValCollection _b2Items = new CheckValCollection();

        [XmlElement]
        public CheckValCollection b2Items
        {
            get { return _b2Items; }
            set { }
        }

       

    }

    [Serializable]
    public class VehCollection
    {
        private List<VehItem> _item = new List<VehItem>();

        [XmlElement]
        public List<VehItem> item
        {
            get { return _item; }
            set { }
        }
    }

    [Serializable]
    public class CheckValCollection
    {
        private List<CheckValItem> _item = new List<CheckValItem>();

        [XmlElement]
        public List<CheckValItem> item
        {
            get { return _item; }
            set { }
        }
    }
}
