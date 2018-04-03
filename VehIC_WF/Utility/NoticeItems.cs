namespace VehIC_WF.Utility
{
    using System;
    using System.Collections;
    using System.Reflection;

    public class NoticeItems : CollectionBase
    {
        public void Add(NoticeItem sigle)
        {
            base.List.Add(sigle);
        }

        public int IndexOf(string billid, string rowid)
        {
            for (int i = 0; i < base.Count; i++)
            {
                if ((this[i].billid == billid) && (this[i].rowid == rowid))
                {
                    return i;
                }
            }
            return -1;
        }

        public int IndexOfRowNo(int no)
        {
            for (int i = 0; i < base.Count; i++)
            {
                if (this[i].rowno == no)
                {
                    return i;
                }
            }
            return -1;
        }

        public NoticeItem this[int index]
        {
            get
            {
                return (NoticeItem) base.List[index];
            }
            set
            {
                base.List[index] = value;
            }
        }
    }
}

