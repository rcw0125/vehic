namespace VehIC_WF.Setting
{
    using System;
    using System.Collections;
    using System.Reflection;

    public class ItemPropertyList : CollectionBase
    {
        public void Add(ItemProperty sigle)
        {
            base.List.Add(sigle);
        }

        public int IndexOf(string name)
        {
            for (int i = 0; i < base.Count; i++)
            {
                if (this[i].name == name)
                {
                    return i;
                }
            }
            return -1;
        }

        public ItemProperty this[int index]
        {
            get
            {
                return (ItemProperty) base.List[index];
            }
            set
            {
                base.List[index] = value;
            }
        }
    }
}

