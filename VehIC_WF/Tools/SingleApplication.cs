namespace VehIC
{
    using System;
    using System.IO;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading;
    using System.Windows.Forms;

    public class SingleApplication
    {
        private static Mutex mutex;
        private static string sTitle;
        private const int SW_RESTORE = 9;
        private static IntPtr windowHandle;

        private static bool EnumWindowCallBack(int hwnd, int lParam)
        {
            windowHandle = (IntPtr) hwnd;
            StringBuilder builder = new StringBuilder(0x100);
            GetWindowText((int) windowHandle, builder, builder.Capacity);
            string str = builder.ToString();
            if ((((str == sTitle) || (str == "用户登录")) || (str == "设置应用服务器地址")) || (str == "作业点注册"))
            {
                ShowWindow(windowHandle, 9);
                SetForegroundWindow(windowHandle);
                return false;
            }
            return true;
        }

        [DllImport("user32.Dll")]
        private static extern int EnumWindows(EnumWinCallBack callBackFunc, int lParam);
        [DllImport("User32.Dll")]
        private static extern void GetWindowText(int hWnd, StringBuilder str, int nMaxCount);
        public static bool IsAlreadyRunning()
        {
            FileSystemInfo info = new FileInfo(Assembly.GetExecutingAssembly().Location);
            string name = info.Name;
            mutex = new Mutex(true, name);
            if (mutex.WaitOne(0, false))
            {
                return false;
            }
            return true;
        }

        public static bool Run()
        {
            if (IsAlreadyRunning())
            {
                return false;
            }
            return true;
        }

        public static bool Run(Form frmMain)
        {
            if (IsAlreadyRunning())
            {
                sTitle = frmMain.Text;
                EnumWindows(new EnumWinCallBack(SingleApplication.EnumWindowCallBack), 0);
                return false;
            }
            Application.Run(frmMain);
           return true;
        }

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        private delegate bool EnumWinCallBack(int hwnd, int lParam);
    }
}

