using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xg.Tools
{
    public class StringTool
    {
        /// <summary>
        /// 全角转半角
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string SBCToDBC(string input)
        {
            char[] cc = input.ToCharArray();
            for (int i = 0; i < cc.Length; i++)
            {
                if (cc[i] == 12288)
                {
                    //空格
                    cc[i] = (char)32;
                }
                else if (cc[i] > 65280 && cc[i] < 65375)
                {
                    cc[i] = (char)(cc[i] - 65248);
                }
            }
            return new string(cc);
        }

        public static double? FNumVal(string value)
        {
            string strVal = StringTool.SBCToDBC(value.Trim()).Replace(" ", "");

            double result;
            if (double.TryParse(strVal, out result))
                return result;
            else
                return null;
        }

    }
}
