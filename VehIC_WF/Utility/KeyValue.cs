namespace VehIC_WF.Utility
{
    using System;
    using System.Collections;
    using System.Reflection;

    public class KeyValue : CollectionBase
    {
        public void Add(KeyValueItem sigle)
        {
            base.List.Add(sigle);
        }

        public int IndexOf(string key)
        {
            for (int i = 0; i < base.Count; i++)
            {
                if (this[i].Key == key)
                {
                    return i;
                }
            }
            return -1;
        }

        public int IndexOfValue(string Value)
        {
            for (int i = 0; i < base.Count; i++)
            {
                if (this[i].Value == Value)
                {
                    return i;
                }
            }
            return -1;
        }

        public KeyValueItem this[int index]
        {
            get
            {
                return (KeyValueItem) base.List[index];
            }
            set
            {
                base.List[index] = value;
            }
        }
    }
}

