namespace VehIC_WF.ICManage
{
    using System;
    using System.Collections;
    using System.Reflection;

    public class CardList : CollectionBase
    {
        public void Add(Card sigle)
        {
            if (!this.ContainCard(sigle.ICID))
            {
                base.List.Add(sigle);
                if (base.Count > 10)
                {
                    base.RemoveAt(0);
                }
                if (base.Count > 10)
                {
                    base.RemoveAt(0);
                }
            }
        }

        public bool CheckCard(string icid)
        {
            for (int i = 0; i < base.Count; i++)
            {
                if ((this[i].ICID == icid) && (((DateTime.Now.Ticks - this[i].RecTime) / 0x989680L) < 300L))
                {
                    return false;
                }
            }
            return true;
        }

        public bool ContainCard(string icid)
        {
            for (int i = 0; i < base.Count; i++)
            {
                if (this[i].ICID == icid)
                {
                    return true;
                }
            }
            return false;
        }

        public void DeleteCard(string icid)
        {
            for (int i = 0; i < base.Count; i++)
            {
                if (this[i].ICID == icid)
                {
                    base.RemoveAt(i);
                    break;
                }
            }
        }

        public Card this[int index]
        {
            get
            {
                return (Card) base.List[index];
            }
            set
            {
                base.List[index] = value;
            }
        }
    }
}

