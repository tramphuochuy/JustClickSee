/// KEYBOARD.CS
/// (c) 2006 by Emma Burrows
/// This file contains the following items:
///  - KeyboardHook: class to enable low-level keyboard hook using
///    the Windows API.
///  - KeyboardHookEventHandler: delegate to handle the KeyIntercepted
///    event raised by the KeyboardHook class.
///  - KeyboardHookEventArgs: EventArgs class to contain the information
///    returned by the KeyIntercepted event.
///    
/// Change history:
/// 17/06/06: 1.0 - First version.
/// 18/06/06: 1.1 - Modified proc assignment in constructor to make class backward 
///                 compatible with 2003.
/// 10/07/06: 1.2 - Added support for modifier keys:
///                 -Changed filter in HookCallback to WM_KEYUP instead of WM_KEYDOWN
///                 -Imported GetKeyState from user32.dll
///                 -Moved native DLL imports to a separate internal class as this 
///                  is a Good Idea according to Microsoft's guidelines
/// 13/02/07: 1.3 - Improved modifier key support:
///                 -Added CheckModifiers() method
///                 -Deleted LoWord/HiWord methods as they weren't necessary
///                 -Implemented Barry Dorman's suggestion to AND GetKeyState
///                  values with 0x8000 to get their result
/// 23/03/07: 1.4 - Fixed bug which made the Alt key appear stuck
///                 - Changed the line
///                     if (nCode >= 0 && (wParam == (IntPtr)WM_KEYUP || wParam == (IntPtr)WM_SYSKEYUP))
///                   to
///                     if (nCode >= 0)
///                     {
///                        if (wParam == (IntPtr)WM_KEYUP || wParam == (IntPtr)WM_SYSKEYUP)
///                        ...
///                   Many thanks to "Scottie Numbnuts" for the solution.


using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Text;

namespace  GB
{
    public class KeyboardHook : IDisposable
    {

        public enum Parameters
        {
            None,
            AllowAltTab,
            AllowWindowsKey,
            AllowAltTabAndWindows,
            PassAllKeysToNextApp
        }

        //Internal parameters
        private bool PassAllKeysToNextApp = false;
        private bool AllowAltTab = false;
        private bool AllowWindowsKey = true;

        //Keyboard API constants
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYUP = 0x0101;
        private const int WM_SYSKEYUP = 0x0105;

        //Modifier key constants
        private const int VK_SHIFT = 0x10;
        private const int VK_CONTROL = 0x11;
        private const int VK_MENU = 0x12;
        private const int VK_CAPITAL = 0x14;

        //Variables used in the call to SetWindowsHookEx
        private HookHandlerDelegate proc;
        private IntPtr hookID = IntPtr.Zero;
        internal delegate IntPtr HookHandlerDelegate(
            int nCode, IntPtr wParam, ref KBDLLHOOKSTRUCT lParam);

        // Event triggered when a keystroke is intercepted by the  low-level hook.
        public event KeyboardHookEventHandler KeyIntercepted;

        // Structure returned by the hook whenever a key is pressed
        internal struct KBDLLHOOKSTRUCT
        {
            public int vkCode;
            int scanCode;
            public int flags;
            int time;
            int dwExtraInfo;
        }

        /// Sets up a keyboard hook to trap all keystrokes without  passing any to other applications.
        public KeyboardHook()
        {
            proc = new HookHandlerDelegate(HookCallback);
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                hookID = NativeMethods.SetWindowsHookEx(WH_KEYBOARD_LL, proc,
                    NativeMethods.GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        /// Sets up a keyboard hook with custom parameters./ <param name="param">A valid name from the Parameter enum; otherwise, the default parameter Parameter.None will be used.</param>
        public KeyboardHook(string param)
            : this()
        {
            if (!String.IsNullOrEmpty(param) && Enum.IsDefined(typeof(Parameters), param))
            {
                SetParameters((Parameters)Enum.Parse(typeof(Parameters), param));
            }
        }

        //Sets up a keyboard hook with custom parameters. <param name="param">A value from the Parameters enum.</param>
        public KeyboardHook(Parameters param)
            : this()
        {
            SetParameters(param);
        }

        private void SetParameters(Parameters param)
        {
            switch (param)
            {
                case Parameters.None:
                    break;
                case Parameters.AllowAltTab:
                    AllowAltTab = true;
                    break;
                case Parameters.AllowWindowsKey:
                    AllowWindowsKey = true;
                    break;
                case Parameters.AllowAltTabAndWindows:
                    AllowAltTab = true;
                    AllowWindowsKey = true;
                    break;
                case Parameters.PassAllKeysToNextApp:
                    PassAllKeysToNextApp = true;
                    break;
            }
        }
    
        /// Checks whether Alt, Shift, Control or CapsLock is enabled at the same time as another key. Modify the relevant sections and return type   depending on what you want to do with modifier keys.

        public static string ShiftKey = "";
        private void CheckModifiers()
        {
            ShiftKey = "";
            StringBuilder sb = new StringBuilder();

            if ((NativeMethods.GetKeyState(VK_CAPITAL) & 0x0001) != 0)
            {
                //CAPSLOCK is ON
                sb.AppendLine("Capslock is enabled.");
            }

            if ((NativeMethods.GetKeyState(VK_SHIFT) & 0x8000) != 0)
            {
                //SHIFT is pressed
                ShiftKey = "ShiftKey";
                sb.AppendLine("Shift is pressed.");
            }
            if ((NativeMethods.GetKeyState(VK_CONTROL) & 0x8000) != 0)
            {
                //CONTROL is pressed
                sb.AppendLine("Control is pressed.");
            }
            if ((NativeMethods.GetKeyState(VK_MENU) & 0x8000) != 0)
            {
                //ALT is pressed
                sb.AppendLine("Alt is pressed.");
            }
            Console.WriteLine(sb.ToString());
        }
      
        private IntPtr HookCallback(
        int nCode, IntPtr wParam, ref KBDLLHOOKSTRUCT lParam)
        {
            bool AllowKey = PassAllKeysToNextApp;

            //Filter wParam for KeyUp events only
            if (nCode >= 0)
            {
                if (wParam == (IntPtr)WM_KEYUP || wParam == (IntPtr)WM_SYSKEYUP)
                {

                    // Check for modifier keys, but only if the key being
                    // currently processed isn't a modifier key (in other
                    // words, CheckModifiers will only run if Ctrl, Shift,
                    // CapsLock or Alt are active at the same time as
                    // another key)
                    if (!(lParam.vkCode >= 160 && lParam.vkCode <= 164))
                    {
                        CheckModifiers();
                    }

                    // Check for key combinations that are allowed to 
                    // get through to Windows
                    //
                    // Ctrl+Esc or Windows key
                    if (AllowWindowsKey)
                    {
                        switch (lParam.flags)
                        {
                            //Ctrl+Esc
                            case 0:
                                if (lParam.vkCode == 27)
                                    AllowKey = true;
                                break;

                            //Windows keys
                            case 1:
                                if ((lParam.vkCode == 91) || (lParam.vkCode == 92))
                                    AllowKey = true;
                                break;
                        }
                    }
                    // Alt+Tab
                    if (AllowAltTab)
                    {
                        if ((lParam.flags == 32) && (lParam.vkCode == 9))
                            AllowKey = true;
                    }

                    OnKeyIntercepted(new KeyboardHookEventArgs(lParam.vkCode, AllowKey));
                }

                //If this key is being suppressed, return a dummy value
                if (AllowKey == false)
                    return (System.IntPtr)1;
            }
            //Pass key to next application
            return NativeMethods.CallNextHookEx(hookID, nCode, wParam, ref lParam);

        }
    
        public void OnKeyIntercepted(KeyboardHookEventArgs e)
        {
            if (KeyIntercepted != null)
                KeyIntercepted(e);
        }
        public delegate void KeyboardHookEventHandler(KeyboardHookEventArgs e);
        public class KeyboardHookEventArgs : System.EventArgs
        {

            private string keyName;
            private int keyCode;
            private bool passThrough;
            public string KeyName
            {
                get { return keyName; }
            }
            public int KeyCode
            {
                get { return keyCode; }
            }
            public bool PassThrough
            {
                get { return passThrough; }
            }
            public KeyboardHookEventArgs(int evtKeyCode, bool evtPassThrough)
            {
                keyName = ((Keys)evtKeyCode).ToString();
                //if (keyName == "LSHIFT") return;
                //DWindow.SendKey(ShiftKey, "", keyName, true, "");
                passThrough = evtPassThrough;
            }

        }

        
        public void Dispose()
        {
            NativeMethods.UnhookWindowsHookEx(hookID);
        }
      

        [ComVisibleAttribute(false),
         System.Security.SuppressUnmanagedCodeSecurity()]
        internal class NativeMethods
        {
            [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern IntPtr GetModuleHandle(string lpModuleName);

            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern IntPtr SetWindowsHookEx(int idHook,
                HookHandlerDelegate lpfn, IntPtr hMod, uint dwThreadId);

            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool UnhookWindowsHookEx(IntPtr hhk);

            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
                IntPtr wParam, ref KBDLLHOOKSTRUCT lParam);

            [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true, CallingConvention = CallingConvention.Winapi)]
            public static extern short GetKeyState(int keyCode);

        }


     

    }
}


