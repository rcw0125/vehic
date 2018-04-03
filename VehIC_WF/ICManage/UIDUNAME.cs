namespace VehIC_WF.ICManage
{
    using System;

    public class UIDUNAME
    {
        public string UID = string.Empty;
        public string UNAME = string.Empty;

        public UIDUNAME(string[] field)
        {
            this.UID = field[0];
            this.UNAME = field[1];
        }
    }
}

