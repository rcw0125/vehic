namespace VehIC_WF
{
    using System;
    using System.Collections;
    using System.Reflection;
    using System.Text.RegularExpressions;

    public class AuthorityList : CollectionBase
    {
        public AuthorityList()
        {
        }

        public AuthorityList(string data)
        {
            if ((data != null) && !(data == string.Empty))
            {
                string[] strArray = Regex.Split(data, "\n", RegexOptions.IgnoreCase);
                for (int i = 0; i < strArray.Length; i++)
                {
                    Authority sigle = new Authority();
                    string[] strArray2 = Regex.Split(strArray[i], "\t", RegexOptions.IgnoreCase);
                    sigle.Code = strArray2[0];
                    sigle.Desc = strArray2[1];
                    this.Add(sigle);
                }
                this.Merge();
            }
        }

        public void Add(Authority sigle)
        {
            base.List.Add(sigle);
        }

        public bool HaveAuth(string Code)
        {
            for (int i = 0; i < base.Count; i++)
            {
                if (this[i].Code == Code)
                {
                    return true;
                }
            }
            return false;
        }

        public int indexof(string Code)
        {
            for (int i = 0; i < base.Count; i++)
            {
                if (this[i].Code == Code)
                {
                    return i;
                }
            }
            return -1;
        }

        public void Merge()
        {
            for (int i = base.Count - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (!(this[i].Code != this[j].Code))
                    {
                        base.List.RemoveAt(i);
                        break;
                    }
                }
            }
        }

        public Authority this[int index]
        {
            get
            {
                return (Authority) base.List[index];
            }
            set
            {
                base.List[index] = value;
            }
        }
    }
}

