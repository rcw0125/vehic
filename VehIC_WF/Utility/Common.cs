namespace VehIC_WF.Utility
{
    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading;
    using System.Windows.Forms;
    using VehIC_WF.CommonService;

    public class Common
    {
        public static string[] ScaleStatusDesc = new string[] { "故障", "静止", "非静止", "零点", "超重", "未知" };
        public const int SND_ASYNC = 1;
        public const int SND_FILENAME = 0x20000;

        public static bool CheckDate(string begindate, string enddate)
        {
            try
            {
                DateTime time = DateTime.Parse(begindate + " 00:01:00");
                DateTime time2 = DateTime.Parse(enddate + " 23:59:00");
                return ((DateTime.Now > time) && (DateTime.Now < time2));
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool CheckTime(string begintime, string endtime)
        {
            try
            {
                string str = string.Format("{0:yyyy-MM-dd}", DateTime.Now);
                DateTime time = DateTime.Parse(str + " " + begintime);
                DateTime time2 = DateTime.Parse(str + " " + endtime);
                return ((DateTime.Now > time) && (DateTime.Now < time2));
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static int[] GetColsWidth(DataGridView dataGridView)
        {
            int[] numArray = null;
            int num2;
            int num = 0;
            for (num2 = 0; num2 < dataGridView.ColumnCount; num2++)
            {
                if (dataGridView.Columns[num2].Visible)
                {
                    num++;
                }
            }
            numArray = new int[num];
            int index = 0;
            for (num2 = 0; num2 < dataGridView.ColumnCount; num2++)
            {
                if (dataGridView.Columns[num2].Visible)
                {
                    numArray[index] = dataGridView.Columns[num2].Width;
                    index++;
                }
            }
            return numArray;
        }

        public static string GetNoticeStatusDesc(int status)
        {
            switch (status)
            {
                case -2:
                    return "终止";

                case -1:
                    return "暂停";

                case 0:
                    return "生成";

                case 1:
                    return "发卡";

                case 2:
                    return "进厂";

                case 3:
                    return "开始作业";

                case 10:
                    return "完成所有作业";

                case 11:
                    return "出厂";

                case -11:
                    return "终止完成";
            }
            return "未知";
        }

        public static string Getwctypedesc(RouteNodeType wctype)
        {
            switch (wctype)
            {
                case RouteNodeType.door:
                    return "门岗";

                case RouteNodeType.sampling:
                    return "取样";

                case RouteNodeType.scales:
                    return "计量";

                case RouteNodeType.goodssite:
                    return "货场";
            }
            return "未知";
        }

        public static bool IPAddressCheck(string addressString)
        {
            try
            {
                Regex regex = new Regex(@"^(\d+)\.(\d+)\.(\d+)\.(\d+)$");
                string input = addressString;
                input = input.Trim();
                if (regex.Match(input).Success)
                {
                    char[] separator = new char[] { '.' };
                    int num = 0;
                    string[] strArray = input.Split(separator);
                    for (int i = 0; i < strArray.Length; i++)
                    {
                        if (int.Parse(strArray[i]) > 0xff)
                        {
                            break;
                        }
                        num++;
                    }
                    return (num == 4);
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [DllImport("winmm.dll")]
        public static extern bool PlaySound(string pszSound, int hmod, int fdwSound);
        public static void RegSvrFastReport()
        {
            try
            {
                Process process = Process.Start("regsvr32.exe", "-s   FastReport3.dll");
                process.WaitForInputIdle();
                process.Kill();
            }
            catch
            {
            }
        }

        public static string SimpleDecrypt(string text)
        {
            try
            {
                byte[] bytes = Convert.FromBase64String(text);
                return Encoding.ASCII.GetString(bytes, 0, bytes.Length);
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
                return string.Empty;
            }
        }

        public static string SimpleEncrypt(string text)
        {
            try
            {
                byte[] bytes = Encoding.ASCII.GetBytes(text);
                return Convert.ToBase64String(bytes, 0, bytes.Length);
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
                return string.Empty;
            }
        }

        public static void SoundFault()
        {
            PlaySound("Bad.WAV", 0, 0x20001);
        }

        public static void SoundOK()
        {
            PlaySound("Good.WAV", 0, 0x20001);
        }

        public static void SoundWarning()
        {
            PlaySound("Warning.WAV", 0, 0x20001);
            Thread.Sleep(500);
            PlaySound("Warning.WAV", 0, 0x20001);
            Thread.Sleep(500);
            PlaySound("Warning.WAV", 0, 0x20001);
        }

        public static string[,] ToStringArray(DataGridView dataGridView, bool includeColumnText)
        {
            string[,] strArray = null;
            int num5;
            int num6;
            int count = dataGridView.Rows.Count;
            int num2 = 0;
            for (int i = 0; i < dataGridView.ColumnCount; i++)
            {
                if (dataGridView.Columns[i].Visible)
                {
                    num2++;
                }
            }
            if ((count > 0) && dataGridView.Rows[count - 1].IsNewRow)
            {
                count--;
            }
            int num4 = 0;
            if (includeColumnText)
            {
                count++;
                strArray = new string[count, num2];
                num5 = 0;
                num6 = 0;
                while (num6 < dataGridView.ColumnCount)
                {
                    if (dataGridView.Columns[num6].Visible)
                    {
                        strArray[0, num5] = dataGridView.Columns[num6].HeaderText;
                        num5++;
                    }
                    num6++;
                }
                num4 = 1;
            }
            else
            {
                strArray = new string[count, num2];
            }
            for (int j = 0; num4 < count; j++)
            {
                num5 = 0;
                for (num6 = 0; num6 < dataGridView.ColumnCount; num6++)
                {
                    if (dataGridView.Columns[num6].Visible)
                    {
                        strArray[num4, num5] = dataGridView.Rows[j].Cells[num6].Value.ToString();
                        num5++;
                    }
                }
                num4++;
            }
            return strArray;
        }
    }
}

