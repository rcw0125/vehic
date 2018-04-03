using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace VehIC_WF.Device
{
    public class SY230NT
    {
        [DllImport("SY230NT.dll", CharSet = CharSet.Ansi)]
        public static extern int Open_COMMS(int CommMode, int ComNo, string Baud, string IP, int Port, int TimeOut);

        [DllImport("SY230NT.dll")]
        public static extern int Close_COMMS(int HANDLEID);

        [DllImport("SY230NT.dll")]
        public static extern int Close_COMMSAll();

        [DllImport("SY230NT.dll", CharSet = CharSet.Ansi)]
        public static extern int GetCardData(int HANDLEID, int ID, int CardNo, StringBuilder CardID, ref int App, ref int Type, StringBuilder Pin, StringBuilder APB);

        [DllImport("SY230NT.dll")]
        public static extern int DeleteAllCard(int HANDLEID, int ID);

        [DllImport("SY230NT.dll")]
        public static extern int RemoteOpenDoorControl(int HANDLEID, int ID, int Door, int ActTime);

        [DllImport("SY230NT.dll", CharSet = CharSet.Ansi)]
        public static extern int DirectCommunicate(int HANDLEID, int ID, string ModuleProtocol, StringBuilder RModuleProtocol);

        [DllImport("SY230NT.dll", CharSet = CharSet.Ansi)]
        public static extern int GetModuleTable(int HANDLEID, int ID, StringBuilder TypeIdModelMax);

        [DllImport("SY230NT.dll", CharSet = CharSet.Ansi)]
        public static extern int GetInvalidCardID(int HANDLEID, int ID, int nn, StringBuilder CardID);

        /// <summary>
        /// 获取一笔查询资料
        /// </summary>
        /// <param name="HANDLEID"></param>
        /// <param name="ID"></param>
        /// <param name="ModuleID"></param>
        /// <param name="YYYY"></param>
        /// <param name="MM"></param>
        /// <param name="DD"></param>
        /// <param name="hh"></param>
        /// <param name="nn"></param>
        /// <param name="ss"></param>
        /// <param name="No"></param>
        /// <param name="Status"></param>
        /// <returns></returns>
        [DllImport("SY230NT.dll", CharSet = CharSet.Ansi)]
        public static extern int GetOneInOut(int HANDLEID, int ID, ref int ModuleID, ref int YYYY, ref int MM, ref int DD, ref int hh, ref int nn, ref int ss, StringBuilder No, StringBuilder Status);

        /// <summary>
        /// 读取进出资料总笔数
        /// </summary>
        /// <param name="HANDLEID"></param>
        /// <param name="ID"></param>
        /// <param name="NNNN"></param>
        /// <returns></returns>
        [DllImport("SY230NT.dll", CharSet = CharSet.Ansi)]
        public static extern int GetInOutRecordCount(int HANDLEID, int ID, ref int NNNN);

        /// <summary>
        /// 删除所有进出资料
        /// </summary>
        /// <param name="HANDLEID"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        [DllImport("SY230NT.dll", CharSet = CharSet.Ansi)]
        public static extern int DeleteAllInOut(int HANDLEID, int ID);

        [DllImport("SY230NT.dll", CharSet = CharSet.Ansi)]
        public static extern int SetAlarm(int HANDLEID, int ID, int N);

        /// <summary>
        /// 读取目前已设定之流程控制总数(流程控制)
        /// </summary>
        /// <param name="HANDLEID">OPN_COMMS回传的HANDLEID</param>
        /// <param name="ID">控制器ID，范围: 1 ~ 9999</param>
        /// <param name="NNN">目前已设定之流程控制总数</param>
        /// <returns></returns>
        [DllImport("SY230NT.dll", CharSet = CharSet.Ansi)]
        public static extern int GetMaxFlowControl(int HANDLEID, int ID, ref int NNN);

        //获取当前控制流数
        [DllImport("SY230NT.dll", CharSet = CharSet.Ansi)]
        public static extern int GetCurrentFlowControl(int HANDLEID, int ID, ref int NNN);

        //清除所有控制流
        [DllImport("SY230NT.dll", CharSet = CharSet.Ansi)]
        public static extern int ClearFlowControl(int HANDLEID, int ID);

        /// <summary>
        /// 读取1笔控制流资料
        /// </summary>
        /// <param name="HANDLEID">OPN_COMMS回传的HANDLEID</param>
        /// <param name="ID">控制器ID，范围: 1 ~ 9999</param>
        /// <param name="NNN">预设定之流程控制项次，范围： 1~ 250</param>
        /// <param name="AA">事件代码(Event)，范围： 0 ~ 99</param>
        /// <param name="B">事件来源模组代码(Event ID)，范围：0~ 9</param>
        /// <param name="CC">事件来源模组通道(Event ID)，范围：0~ 63</param>
        /// <param name="DD">动作延迟时间(Action Delay Time)，范围： 0 ~99</param>
        /// <param name="EE">动作代码(Action)，范围： 0 ~ 99</param>
        /// <param name="F">动作模组代码(Action ID)，范围： 0~9</param>
        /// <param name="GG">动作模组通道(Action Channel)，范围： 0 ~ 63</param>
        /// <param name="H">动作方法(Action Method)，范围： 0 ~4</param>
        /// <param name="TTT">动作时间(Action Time)，范围： 0 ~ 999</param>
        /// <returns></returns>
        [DllImport("SY230NT.dll", CharSet = CharSet.Ansi)]
        public static extern int GetOneFlowControl(int HANDLEID, int ID, int NNN, ref int AA, ref int B, ref int CC, ref int DD, ref int EE, ref int F, ref int GG, ref int H, ref int TTT);

        /// <summary>
        /// 设定1笔控制流资料
        /// </summary>
        /// <param name="HANDLEID">OPN_COMMS回传的HANDLEID</param>
        /// <param name="ID">控制器ID，范围: 1 ~ 9999</param>
        /// <param name="NNN">预设定之流程控制项次，范围： 1~ 250</param>
        /// <param name="AA">事件代码(Event)，范围： 0 ~ 99</param>
        /// <param name="B">事件来源模组代码(Event ID)，范围：0~ 9</param>
        /// <param name="CC">事件来源模组通道(Event ID)，范围：0~ 63</param>
        /// <param name="DD">动作延迟时间(Action Delay Time)，范围： 0 ~99</param>
        /// <param name="EE">动作代码(Action)，范围： 0 ~ 99</param>
        /// <param name="F">动作模组代码(Action ID)，范围： 0~9</param>
        /// <param name="GG">动作模组通道(Action Channel)，范围： 0 ~ 63</param>
        /// <param name="H">动作方法(Action Method)，范围： 0 ~4</param>
        /// <param name="TTT">动作时间(Action Time)，范围： 0 ~ 999</param>
        /// <returns></returns>
        [DllImport("SY230NT.dll", CharSet = CharSet.Ansi)]
        public static extern int SetOneFlowControl(int HANDLEID, int ID, int NNN, int AA, int B, int CC, int DD, int EE, int F, int GG, int H, int TTT);

        public static byte[] CommPakage(string cmd)
        {

            MemoryStream ms = new MemoryStream();
            byte[] cmdBuf = Encoding.ASCII.GetBytes(cmd);
            ms.WriteByte(0x09);
            ms.Write(cmdBuf, 0, cmdBuf.Length);
            byte[] temp = ms.ToArray();

            byte bcc = 0;
            for (int i = 0; i < temp.Length; i++)
            {
                bcc = (byte)(bcc ^ temp[i]);
            }
            string bccStr = bcc.ToString("X2");
            ms.Write(Encoding.ASCII.GetBytes(bccStr), 0, 2);
            ms.WriteByte(0x0D);
            return ms.ToArray();
        }

        public static string ToHexString(byte[] buf)
        {
            StringBuilder hexString = new StringBuilder();
            foreach (var item in buf)
            {
                hexString.Append(item.ToString("X2"));
            }
            return hexString.ToString();
        }

        public static string GetPakageData(byte[] buf)
        {
            string result = "";

            if (buf.Length > 7)
            {
                if (buf[0] == 0x0A && buf[buf.Length - 1] == 0x0D)
                {
                    result = Encoding.ASCII.GetString(buf, 4, buf.Length - 7);
                }
                else
                {
                    // result = ToHexString(buf);
                }
            }
            else
            {
                //  result = ToHexString(buf);
            }
            if (result.Length == 9)
                return result.Substring(1);
            else
                return "";
        }
    }

}
