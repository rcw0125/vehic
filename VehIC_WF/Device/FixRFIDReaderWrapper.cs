using System;
using System.Collections.Generic;
using System.Text;
using VehIC_Device;
using System.Threading;

namespace VehIC_WF.Device
{
    public class FixRFIDReaderWrapper : IPortDevice
    {
        public int port = 1;
        public int baud = 0x2580;

        public string errmsg = string.Empty;
        public IntPtr porthandle = IntPtr.Zero;
        public bool torun = true;

        public FixRFIDReaderWrapper(int portid, int baudrate)
        {
            this.port = portid;
            this.baud = baudrate;
        }

        public bool OpenDevice()
        {
            this.CloseDevice();
            try
            {
                this.porthandle = FRRAPT.OpenCardReader(this.port, this.baud);
                if (!this.ISConnected())
                {
                    this.errmsg = "打开读写器串口失败!";
                    return false;
                }
                return true;
            }
            catch (Exception exception)
            {
                this.porthandle = IntPtr.Zero;
                this.errmsg = exception.ToString();
                return false;
            }
        }

        public bool CloseDevice()
        {
            bool flag;
            try
            {
                FRRAPT.CloseCardReader(this.porthandle);
                this.porthandle = IntPtr.Zero;
                flag = true;
            }
            catch (Exception exception)
            {
                this.errmsg = exception.ToString();
                flag = false;
            }
            finally
            {
                this.porthandle = IntPtr.Zero;
            }
            return flag;
        }

        public bool Available()
        {
            return (this.torun && this.ISConnected());
        }

        public bool ISConnected()
        {
            return ((this.porthandle != IntPtr.Zero) && !(this.porthandle.ToString() == "0"));
        }

        public void Dispose()
        {
            this.CloseDevice();
        }

        public string Excute()
        {
            if (!this.Available())
            {
                return string.Empty;
            }
            try
            {
                string str = string.Empty;
                byte[] bufData = new byte[0x80];
                for (int i = 0; i < 0x80; i++)
                {
                    bufData[i] = 0;
                }
                byte ret = FRRAPT.QueryRFCard(this.porthandle, 0x52, bufData);
                switch (ret)
                {
                    case 0xfe:
                    case 0xff:
                        this.errmsg = "通讯失败";
                        return string.Empty;

                    default:
                        {
                            int num3;
                            if ((((bufData[2] == 0) && (bufData[3] == 0)) && (bufData[4] == 0)) && (0 == bufData[5]))
                            {
                                this.errmsg = "没有卡片";
                                return string.Empty;
                            }
                            string str2 = string.Empty;
                            string str3 = string.Empty;
                            for (num3 = 0; num3 < 4; num3++)
                            {
                                str2 = str2 + bufData[num3 + 4].ToString("X2");
                            }
                            for (num3 = 0; num3 < 7; num3++)
                            {
                                str3 = str3 + bufData[num3 + 4].ToString("X2");
                            }
                            switch (bufData[1])
                            {
                                case 8:
                                    str = str2;
                                    break;

                                case 0x10:
                                    str = string.Empty;
                                    this.Beep(3, 200);
                                    break;

                                case 1:
                                    str = string.Empty;
                                    this.Beep(3, 200);
                                    break;

                                case 4:
                                    str = string.Empty;
                                    this.Beep(3, 200);
                                    break;
                            }
                            break;
                        }
                }
                return str;
            }
            catch (Exception exception)
            {
                this.errmsg = exception.ToString();
                return null;
            }
        }

        public void Beep(int times, int timespan)
        {
            if (this.ISConnected())
            {
                try
                {
                    for (int i = 0; i < times; i++)
                    {
                        FRRAPT.RFReaderBeep(this.porthandle);
                        Thread.Sleep(timespan);
                    }
                }
                catch (Exception exception)
                {
                    this.errmsg = exception.ToString();
                }
            }
        }

        public void Lamp(int lamppos, int times)
        {
            if (this.ISConnected())
            {
                try
                {
                    for (int i = 0; i < times; i++)
                    {
                        VehIC_Device.FRRAPT.RFReaderLed(this.porthandle, lamppos, 1);
                        Thread.Sleep(500);
                        FRRAPT.RFReaderLed(this.porthandle, lamppos, 0);
                        Thread.Sleep(500);
                    }
                }
                catch (Exception exception)
                {
                    this.errmsg = exception.ToString();
                }
            }
        }

        public string Excute(int controlid)
        {
            return this.Excute();
        }

        public bool Kz(int controlid, int addr)
        {
            return false;
        }

        public PortDeviceType GetDeviceType()
        {
            return PortDeviceType.FixRFIDReader;
        }
    
    }

}
