using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
namespace VehIC_WF.Sampling.Nc
{
    [Serializable]
    public class ufinterface
    {
        [XmlAttribute]
        public string billtype { get { return "T9WQ"; } set { } } //T8WQ
        [XmlAttribute]
        public string filename { get { return ""; } set { } }
        [XmlAttribute]
        public string isexchange { get { return "Y"; } set { } }
        [XmlAttribute]
        public string operation { get { return "req"; } set { } }
        [XmlAttribute]
        public string proc { get { return "add"; } set { } }
        [XmlAttribute]
        public string receiver { get { return "101"; } set { } }
        [XmlAttribute]
        public string replace { get { return "Y"; } set { } }
        [XmlAttribute]
        public string roottag { get { return "bill"; } set { } }
        [XmlAttribute]
        public string sender { get { return "1105"; } set { } }

        private bill _bill = new bill();
        [XmlElement]
        public bill bill
        {
            get { return _bill; }
            set { }
        }

    }

    [Serializable]
    public class bill
    {
         [XmlAttribute]
        public string id { get; set; }
        
        private bill_head _bill_head = new bill_head();
        [XmlElement]
        public bill_head bill_head
        {
            get { return _bill_head; }
            set { }
        }
    }
}
