﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace GB
{
    public class MouseHook2
    {

        public static LowLevelMouseProc _proc = HookCallback;

        public static IntPtr _hookID = IntPtr.Zero;


        public static void Main()
        {

            _hookID = SetHook(_proc);

            //UnhookWindowsHookEx(_hookID);
        }

        public static IntPtr SetHook(LowLevelMouseProc proc)
        {

            using (Process curProcess = Process.GetCurrentProcess())

            using (ProcessModule curModule = curProcess.MainModule)
            {

                return SetWindowsHookEx(WH_MOUSE_LL, proc,

                    GetModuleHandle(curModule.ModuleName), 0);

            }

        }

        public delegate IntPtr LowLevelMouseProc(int nCode, IntPtr wParam, IntPtr lParam);

        public static IntPtr HookCallback(

            int nCode, IntPtr wParam, IntPtr lParam)
        {

            if (nCode >= 0 &&

                MouseMessages.WM_LBUTTONDOWN == (MouseMessages)wParam)
            {

                MSLLHOOKSTRUCT hookStruct = (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT));

                Console.WriteLine(hookStruct.pt.x + ", " + hookStruct.pt.y);

            }

            return CallNextHookEx(_hookID, nCode, wParam, lParam);

        }

        public const int WH_MOUSE_LL = 14;

        public enum MouseMessages
        {

            WM_LBUTTONDOWN = 0x0201,

            WM_LBUTTONUP = 0x0202,

            WM_MOUSEMOVE = 0x0200,

            WM_MOUSEWHEEL = 0x020A,

            WM_RBUTTONDOWN = 0x0204,

            WM_RBUTTONUP = 0x0205

        }

        [StructLayout(LayoutKind.Sequential)]

        public struct POINT
        {

            public int x;

            public int y;

        }

        [StructLayout(LayoutKind.Sequential)]

        public struct MSLLHOOKSTRUCT
        {

            public POINT pt;

            public uint mouseData;

            public uint flags;

            public uint time;

            public IntPtr dwExtraInfo;

        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]

        public static extern IntPtr SetWindowsHookEx(int idHook,

            LowLevelMouseProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]

        [return: MarshalAs(UnmanagedType.Bool)]

        public static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]

        public static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,

            IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]

        public static extern IntPtr GetModuleHandle(string lpModuleName);

    }
}
