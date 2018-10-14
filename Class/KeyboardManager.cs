using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Forms;

namespace GB
{
    sealed class KeyboardManager
    {
       

        private delegate IntPtr HookHandlerDelegate(int nCode, IntPtr wParam, ref KBHookStruct lParam);
        private static HookHandlerDelegate callbackPtr;
        private static IntPtr hookPtr = IntPtr.Zero;
        private const int LowLevelKeyboardHook = 13;

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, HookHandlerDelegate callbackPtr, IntPtr hInstance, uint dwThreadId);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, ref KBHookStruct lParam);

      

        public static void DisableSystemKeys()
        {
            if (callbackPtr == null)
            {
                callbackPtr = new HookHandlerDelegate(KeyboardHookHandler);
            }

            if (hookPtr == IntPtr.Zero)
            {
                // Note: This does not work in the VS host environment.  To run in debug mode:
                // Project -> Properties -> Debug -> Uncheck "Enable the Visual Studio hosting process"
                IntPtr hInstance = Marshal.GetHINSTANCE(Application.CurrentCulture.GetType().Module);
                hookPtr = SetWindowsHookEx(LowLevelKeyboardHook, callbackPtr, hInstance, 0);
            }
        }

        public static void EnableSystemKeys()
        {
            if (hookPtr != IntPtr.Zero)
            {
                UnhookWindowsHookEx(hookPtr);
                hookPtr = IntPtr.Zero;
            }
        }

        private static IntPtr KeyboardHookHandler(int nCode, IntPtr wParam, ref KBHookStruct lParam)
        {
            if (nCode == 0)
            {
             

                if (((lParam.vkCode == 0x09) && (lParam.flags == 0x20)) ||  // Alt+Tab
                ((lParam.vkCode == 0x1B) & (lParam.flags == 0x20)) ||      // Alt+Esc
                ((lParam.vkCode == 0x1B) & (lParam.flags == 0x00)) ||      // Ctrl+Esc
                ((lParam.vkCode == 0x5B) && (lParam.flags == 0x01)) ||      // Left Windows Key
                ((lParam.vkCode == 0x5C) && (lParam.flags == 0x01)) ||      // Right Windows Key
                ((lParam.vkCode == 0x73) && (lParam.flags == 0x20)) ||      // Alt+F4 // Process at keydown
                ((lParam.vkCode == 0x20) && (lParam.flags == 0x20)))        // Alt+Space
                {
                    if (((lParam.vkCode == 0x5B) && (lParam.flags == 0x01))|| ((lParam.vkCode == 0x5C) && (lParam.flags == 0x01)))
                    {
                        DBase.isWindowKeyDown = 1;
                        string cmd = "RUN_WINDOW_KEY;";
                        if (DBase.CurrentSessionID > 0) DHuy.AddCommand(DBase.CurrentSessionID, cmd);
                    }

                    if (((lParam.vkCode == 0x73) && (lParam.flags == 0x20)))
                    {
                        string cmd = "RUN_ALT_F4;";
                        DHuy.AddCommand(DBase.CurrentSessionID, cmd);
                    }
                   

                    if (((lParam.vkCode == 0x09) && (lParam.flags == 0x20)))
                    {
                    string cmd = "RUN_ALT_TAB;";
                    if ( DBase.CurrentSessionID>0) DHuy.AddCommand(DBase.CurrentSessionID, cmd);
                    }


                    if (((lParam.vkCode == 0x1B) & (lParam.flags == 0x00)))
                    {
                        string cmd = "RUN_ESCAPE;";
                        if (DBase.CurrentSessionID > 0) DHuy.AddCommand(DBase.CurrentSessionID, cmd);
                    }


                    return new IntPtr(1);
                }
            }
            return CallNextHookEx(hookPtr, nCode, wParam, ref lParam);
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct KBHookStruct
        {
            public int vkCode;
            public int scanCode;
            public int flags;
            public int time;
            public int dwExtraInfo;
        }
    }

   
}
