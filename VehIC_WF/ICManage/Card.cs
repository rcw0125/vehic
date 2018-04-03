namespace VehIC_WF.ICManage
{
    using System;

    public class Card
    {
        public string ICID = string.Empty;
        public long RecTime = 0L;

        public Card(string id, long time)
        {
            this.ICID = id;
            this.RecTime = time;
        }
    }
}

