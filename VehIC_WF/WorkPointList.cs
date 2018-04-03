namespace VehIC_WF
{
    using System;
    using System.Collections;
    using System.Reflection;
    using System.Text.RegularExpressions;
    using VehIC_BL;

    public class WorkPointList : CollectionBase
    {
        public WorkPointList(string data)
        {
            if ((data != null) && !(data == string.Empty))
            {
                string[] strArray = Regex.Split(data, "\n", RegexOptions.IgnoreCase);
                for (int i = 0; i < strArray.Length; i++)
                {
                    string[] strArray2 = Regex.Split(strArray[i], "\t", RegexOptions.IgnoreCase);
                    if (strArray2.Length >= 5)
                    {
                        WorkPointInfo sigle = new WorkPointInfo();
                        sigle.Code = strArray2[0];
                        sigle.Name = strArray2[1];
                        sigle.TypeCode = strArray2[2];
                        sigle.type = RouteNode.GetRouteType(sigle.TypeCode);
                        sigle.TypeDesc = strArray2[3];
                        sigle.Enable = strArray2[4] == "True";
                        this.Add(sigle);
                    }
                }
            }
        }

        public WorkPointList(string[] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                string[] strArray = Regex.Split(data[i], "\t", RegexOptions.IgnoreCase);
                if (strArray.Length >= 6)
                {
                    WorkPointInfo sigle = new WorkPointInfo();
                    sigle.SH = "1" == strArray[0].Trim();
                    sigle.Enable = strArray[1] == "True";
                    sigle.Code = strArray[2];
                    sigle.Name = strArray[3];
                    sigle.TypeCode = strArray[4];
                    sigle.type = RouteNode.GetRouteType(sigle.TypeCode);
                    sigle.TypeDesc = strArray[5];
                    this.Add(sigle);
                }
            }
        }

        public void Add(WorkPointInfo sigle)
        {
            base.List.Add(sigle);
        }

        public int GetAvailableCount()
        {
            int num = 0;
            for (int i = 0; i < base.Count; i++)
            {
                if (this[i].SH && this[i].Enable)
                {
                    num++;
                }
            }
            return num;
        }

        public WorkPointInfo GetFirstAvailableWP()
        {
            for (int i = 0; i < base.Count; i++)
            {
                if (this[i].SH && this[i].Enable)
                {
                    return this[i];
                }
            }
            return null;
        }

        public string[] GetStringLists()
        {
            string[] strArray = new string[base.Count];
            for (int i = 0; i < base.Count; i++)
            {
                strArray[i] = this[i].Code;
            }
            return strArray;
        }

        public int GetUserAvailableWorkPointCount(string[] wpcodes)
        {
            int num = 0;
            for (int i = 0; i < wpcodes.Length; i++)
            {
                for (int j = 0; j < base.Count; j++)
                {
                    if (this[j].Code == wpcodes[i])
                    {
                        num++;
                    }
                }
            }
            return num;
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

        public WorkPointInfo this[int index]
        {
            get
            {
                return (WorkPointInfo) base.List[index];
            }
            set
            {
                base.List[index] = value;
            }
        }
    }
}

