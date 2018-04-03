namespace VehIC_WF.Utility
{
    using System;
    using System.Text.RegularExpressions;

    public class KeyValueItem
    {
        public string Key;
        public string Value;
        public string ValueEx;

        public KeyValueItem(string[] field)
        {
            this.Key = string.Empty;
            this.Value = string.Empty;
            this.ValueEx = string.Empty;
            this.Key = field[0];
            this.Value = field[1];
        }

        public KeyValueItem(string data)
        {
            this.Key = string.Empty;
            this.Value = string.Empty;
            this.ValueEx = string.Empty;
            string[] strArray = Regex.Split(data, "\t", RegexOptions.IgnoreCase);
            this.Key = strArray[0];
            this.Value = strArray[1];
            if (strArray.Length == 3)
            {
                this.ValueEx = strArray[2];
            }
        }
    }
}

