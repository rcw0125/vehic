namespace VehIC_WF.ICManage
{
    using System;
    using System.Collections;
    using System.Reflection;

    public class UIDUNAMES : CollectionBase
    {
        public void Add(UIDUNAME sigle)
        {
            base.List.Add(sigle);
        }

        public int IndexOf(string uid)
        {
            for (int i = 0; i < base.Count; i++)
            {
                if (this[i].UID == uid)
                {
                    return i;
                }
            }
            return -1;
        }

        public UIDUNAME this[int index]
        {
            get
            {
                return (UIDUNAME) base.List[index];
            }
            set
            {
                base.List[index] = value;
            }
        }
    }
}

