using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Tools
{
    public enum RawInputDeviceType : uint
    {
        RIM_TYPEMOUSE = 0,
        RIM_TYPEKEYBOARD = 1,
        RIM_TYPEHID = 2,
    }

    public enum RawInputDeviceInfoType : uint
    {
        RIDI_DEVICENAME = 0x20000007,
        RIDI_DEVICEINFO = 0x2000000b,
        RIDI_PREPARSEDDATA = 0x20000005,
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RAWINPUTDEVICELIST
    {
        public IntPtr DeviceHandle;
        public RawInputDeviceType DeviceType;
    }
  
    [StructLayout(LayoutKind.Sequential)]
    public struct RAWINPUTDEVICE
    {
        [MarshalAs(UnmanagedType.U2)]
        public ushort usUsagePage;

        [MarshalAs(UnmanagedType.U2)]
        public ushort usUsage;

        [MarshalAs(UnmanagedType.U4)]
        public uint dwFlags;

        public IntPtr hwndTarget;

    }

    public enum RAWINPUTDEVICEFlags
    {
        RIDEV_APPKEYS = 0x400,
        RIDEV_CAPTUREMOUSE = 0x200,
        RIDEV_EXCLUDE = 0x10,
        RIDEV_EXINPUTSINK = 0x1000,
        RIDEV_INPUTSINK = 0x100,
        RIDEV_NOHOTKEYS = 0x200,
        RIDEV_NOLEGACY = 0x30,
        RIDEV_PAGEONLY = 0x20,
        RIDEV_REMOVE = 0x1
    }

    public enum DeviceTypes
    {
        RIM_TYPEHID = 2,
        RIM_TYPEKEYBOARD = 1,
        RIM_TYPEMOUSE = 0
    }

    [StructLayout(LayoutKind.Sequential, Size = 16)]
    public struct RAWINPUTHEADER
    {
        public uint dwType;
        public uint dwSize;
        public IntPtr hDevice;
        public int wParam;
    }

    public enum RAWMOUSEFlags : ushort
    {

    }
   
    [StructLayout(LayoutKind.Explicit)]
    public struct RAWMOUSE
    {
        [FieldOffset(0)]
        public ushort usFlags;
        [FieldOffset(2)]
        public uint ulButtons;
        [FieldOffset(2)]
        public ushort usButtonFlags;
        [FieldOffset(4)]
        public ushort usButtonData;
        [FieldOffset(6)]
        public uint ulRawButtons;
        [FieldOffset(10)]
        public uint lLastX;
        [FieldOffset(14)]
        public uint lLastY;
        [FieldOffset(18)]
        public uint ulExtraInformation;
    }
  
    [StructLayout(LayoutKind.Sequential)]
    public struct RAWKEYBOARD
    {
        public ushort MakeCode;
        public ushort Flags;
        public ushort Reserved;
        public ushort VKey;
        public uint Message;
        public uint ExtraInformation;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RAWHID_Marshalling
    {
        public int dwSizeHid;
        public int dwCount;
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct RAWINPUT_Marshalling
    {
        [FieldOffset(0)]
        public RAWINPUTHEADER header;
        [FieldOffset(16)]
        public RAWMOUSE mouse;
        [FieldOffset(16)]
        public RAWKEYBOARD keyboard;
        [FieldOffset(16)]
        public RAWHID_Marshalling hid;
    }

    public enum RawInputDataCommand : uint
    {
        RID_INPUT = 0x10000003,
        RID_HEADER = 0x10000005
    }

    public class RawInput
    {

        [DllImport("user32.dll", SetLastError = true)]
        public static extern int GetRawInputDeviceList(
                   [In, Out] RAWINPUTDEVICELIST[] InputdeviceList,
                   [In, Out] ref uint puiNumDevices,
                   [In] uint cbSize);

        [DllImport("user32.dll")]
        public static extern uint GetRawInputDeviceInfo(IntPtr hDevice,
                                           uint uiCommand,
                                           IntPtr pData,
                                           ref uint pcbSize);
        [DllImport("user32.dll")]
        public static extern bool RegisterRawInputDevices(RAWINPUTDEVICE[] pRawInputDevices,
                                            uint uiNumDevices,
                                            uint cbSize);

        [DllImport("user32.dll")]
        public static extern uint GetRawInputData(
            IntPtr hRawInput,
            uint uiCommnad,
            [In, Out] IntPtr pData,
            [In, Out] ref uint pcbSize,
            uint cbSizeHeader);

        public static void Init()
        {
            uint NumberOfDevices = 0;
            RAWINPUTDEVICELIST[] RawDevices = null;

            //get devices buffer size needed
            GetRawInputDeviceList(
                RawDevices,
                ref NumberOfDevices,
                (uint)Marshal.SizeOf((typeof(RAWINPUTDEVICELIST))));

            //alloc array
            RawDevices = new RAWINPUTDEVICELIST[NumberOfDevices];

            //get devices
            if (GetRawInputDeviceList(
                 RawDevices,
                 ref NumberOfDevices,
                 (uint)Marshal.SizeOf((typeof(RAWINPUTDEVICELIST)))) == -1)
                throw new Win32Exception();


        }


        public static bool RegRawInput()
        {
            RAWINPUTDEVICE[] Rid = new RAWINPUTDEVICE[1];
            Rid[0].usUsagePage = 0x01;
            Rid[0].usUsage = 0x06;
            Rid[0].dwFlags = (uint)RAWINPUTDEVICEFlags.RIDEV_NOLEGACY;
            Rid[0].hwndTarget = IntPtr.Zero;

            return RegisterRawInputDevices(Rid, 1, (uint)Marshal.SizeOf((typeof(RAWINPUTDEVICE))));
        }

        public static void GetInput(IntPtr hRawInput)
        {
            uint dwSize=0;
            GetRawInputData(hRawInput,(uint)RawInputDataCommand.RID_INPUT, IntPtr.Zero, ref dwSize, (uint)Marshal.SizeOf(typeof(RAWINPUT_Marshalling)));
        }
    }

    public class RawInputMessageFilter : IMessageFilter
    {
        private const int WM_INPUT = 0x00FF;

        public bool PreFilterMessage(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_INPUT:
                    RawInput.GetInput(m.LParam);
                    return true;
                default:
                    return false;
            }
        }
    }

}
