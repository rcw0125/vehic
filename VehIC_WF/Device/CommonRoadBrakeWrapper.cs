using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace VehIC_WF.Device
{
    public class CommonRoadBrakeWrapper : IPortDevice
    {
        public string errmsg = string.Empty;
        public bool InDoor = true;
        public bool isopen = true;
        public VehIC_Device.DeviceType m_type;
        public int macno = 5;
        public bool motorcade = false;
        public string msg = "";
        public int port = 1;
        private static string[] resultstr = new string[] { "成功", "打开端口出错", "初始化端口异常", "命令超时", "发送端口命令出错", "读取端口数据出错", "关闭端口出错", "数据校验出错", "设备功能异常或没有功能完成的条件" };
        public static object SynchronizeVariable = "WorkFan";
        public bool torun = true;

        public CommonRoadBrakeWrapper(int portid, int baudrate)
        {
            this.port = portid;
            this.m_type = VehIC_Device.DeviceType.RoadBrake;
        }

        public bool Available()
        {
            return (this.ToRun() && this.ISConnected());
        }

        public bool CloseDevice()
        {
            return this.CloseDeviceEx();
        }

        public bool CloseDeviceEx()
        {
            try
            {
                if (VehIC_Device.RBAPI.ClosePort(this.port) != 0)
                {
                    this.isopen = false;
                    return false;
                }
                this.isopen = false;
                return true;
            }
            catch (Exception exception)
            {
                this.errmsg = exception.ToString();
                return false;
            }
        }

        public void Dispose()
        {
            this.CloseDeviceEx();
        }

        public string Excute()
        {
            try
            {
                if (this.torun)
                {
                    try
                    {
                        int recordcount = VehIC_Device.RBAPI.CountRecord(this.port, this.macno);
                        if (recordcount <= 0)
                        {
                            return string.Empty;
                        }
                        byte[] array = new byte[4 * recordcount];
                        Array.Clear(array, 0, 4 * recordcount);
                        if (VehIC_Device.RBAPI.TakeTcRecords(this.port, this.macno, recordcount, array) != 0)
                        {
                            return string.Empty;
                        }
                        string str = array[0].ToString("X2") + array[1].ToString("X2") + array[2].ToString("X2") + array[3].ToString("X2");
                        VehIC_Device.RBAPI.ClearRecord(this.port, this.macno);
                        return str;
                    }
                    catch (Exception exception)
                    {
                        this.errmsg = exception.ToString();
                        return string.Empty;
                    }
                }
                return string.Empty;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        public static string GetResultDesc(int result)
        {
            return resultstr[Math.Abs(result)];
        }


        public bool ISConnected()
        {
            return this.isopen;
        }

        public bool KZ()
        {
            try
            {
                int num = 0;
                while (!this.KZEx() && (num < 5))
                {
                    System.Threading.Thread.Sleep(50);
                    num++;
                }
                return (num < 5);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool KZEx()
        {
            try
            {
                return (VehIC_Device.RBAPI.TcKz(this.port, this.macno) == 0);
            }
            catch (Exception)
            {
                return false;
            }
        }


        public bool KZEx(int addr)
        {
            try
            {
                return (VehIC_Device.RBAPI.TcKz(this.port, addr) == 0);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool OpenDevice()
        {
            this.CloseDeviceEx();
            return this.OpenDeviceEx();
        }

        public bool OpenDeviceEx()
        {
            try
            {
                if (VehIC_Device.RBAPI.OpenPort(this.port) != 0)
                {
                    this.msg = "failed";
                    this.isopen = false;
                    return false;
                }
                this.msg = "ok";
                this.isopen = true;
                return true;
            }
            catch (Exception exception)
            {
                this.msg = this.errmsg = exception.ToString();
                return false;
            }
        }

        public bool ToRun()
        {
            return this.torun;
        }

        public string Excute(int controlid)
        {
            return this.Excute();
        }

        public bool Kz(int controlid, int addr)
        {
            try
            {
                int num = 0;
                while (!this.KZEx(controlid) && (num < 5))
                {
                    System.Threading.Thread.Sleep(50);
                    num++;
                }
                return (num < 5);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public PortDeviceType GetDeviceType()
        {
            return PortDeviceType.RoadBrake;
        }
    }
}
