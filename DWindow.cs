using System;
using System.Collections.Generic;

using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using Microsoft.Win32;
using System.Threading;
using System.Management;
using System.Security.Principal;
using System.Diagnostics;
using System.IO;
using System.Data;


namespace GB
{
    public static class DWindow
    {

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetWindowThreadProcessId(IntPtr handle, out int processId);

        public static bool ApplicationIsActivated()
        {
            var activatedHandle = GetForegroundWindow();
            if (activatedHandle == IntPtr.Zero)
            {
                return false;       // No window is currently activated
            }

            var procId = Process.GetCurrentProcess().Id;
            int activeProcId;
            GetWindowThreadProcessId(activatedHandle, out activeProcId);

            return activeProcId == procId;
        }

        private const UInt32 MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const UInt32 MOUSEEVENTF_LEFTUP = 0x0004;

        private const UInt32 MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const UInt32 MOUSEEVENTF_RIGHTUP = 0x10;
        private const UInt32 MOUSEEVENTF_MIDDLEDOWN = 0x0020;  //The middle button was pressed
        private const UInt32 MOUSEEVENTF_MIDDLEUP = 0x0040;

        [DllImport("user32.dll")]
        private static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, uint dwExtraInf);

        [DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

        [DllImport("Shel32.dll")]
        public static extern void ToggleDesktop();

        public static void ShowDesktop()
        {
            ToggleDesktop();
        }

        [DllImport("user32.dll", SetLastError = true)]
        static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        public const int KEYEVENTF_EXTENDEDKEY2 = 0x0001; //Key down flag //https://msdn.microsoft.com/en-us/library/dd375731%28v=vs.85%29.aspx?f=255&MSPPError=-2147217396
        public const int KEYEVENTF_KEYUP2 = 0x0002; //Key up flag
        public const int KEYEVENTF_CRTCANCEL2 = 0x03;

        private const int KEY_PRESSED = 0x8000;
        private const int VK_CONTROL = 0x11;
        public static bool IsControlKeyDown()
        {
            return (GetKeyState(VK_CONTROL) & KEY_PRESSED) != 0;
        }

        public static bool IsAltKeyDown()
        {
            return (GetKeyState(VK_ALT) & KEY_PRESSED) != 0;
        }
        public static bool IsShiftKeyDown()
        {
            return (GetKeyState(VK_SHIFT) & KEY_PRESSED) != 0;
        }


        public const int VK_RCONTROL = 0xA3; //Right Control key code
        public const int VK_SHIFT = 0x10; //Right Control key 
        public const int VK_ALT = 0x12;
        public const int VK_LWIN = 0x5B;
        //KEYSTATE
        [DllImport("user32.dll")]
        public static extern int GetKeyboardState(byte[] keystate);



        //Resolution

        public static void SetResolution(int X, int Y)
        {
            CResolution ChangeRes = new CResolution(X, Y);
        }
        public static void GetNativeRes(out int X, out int Y, out int Hz)
        {
            CResolution.GetMaxResolutionWithRefreshRate(out X, out Y, out Hz);
        }
        //Mouse & Postion
        public static void SetMouseLocation(int X, int Y)
        {
            Cursor.Position = new Point(X, Y);
        }

        //DOWN
        public static void SetMouseDown(int X, int Y)
        {

            Cursor.Position = new Point(X, Y);
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);//make left button down
        }
        public static void SetMouseDownWithSysKey(int X, int Y, String CTRL_SHIFT_ALT)
        {

            Cursor.Position = new Point(X, Y);
            if (CTRL_SHIFT_ALT == "CTRL") keybd_event(VK_RCONTROL, 0, KEYEVENTF_EXTENDEDKEY2, 0);
            if (CTRL_SHIFT_ALT == "SHIFT") keybd_event(VK_SHIFT, 0, KEYEVENTF_EXTENDEDKEY2, 0); 
            if (CTRL_SHIFT_ALT == "ALT") keybd_event(VK_ALT, 0, KEYEVENTF_EXTENDEDKEY2, 0);
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);

        }

        public static void SetMouseUp(int X, int Y)
        {

            Cursor.Position = new Point(X, Y);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }
        public static void SetMouseUpWithSysKey(int X, int Y, String CTRL_SHIFT_ALT)
        {

            Cursor.Position = new Point(X, Y);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
            if (CTRL_SHIFT_ALT == "CTRL") keybd_event(VK_RCONTROL, 0, KEYEVENTF_CRTCANCEL2, 0);
            if (CTRL_SHIFT_ALT == "SHIFT") keybd_event(VK_SHIFT, 0, KEYEVENTF_CRTCANCEL2, 0);
            if (CTRL_SHIFT_ALT == "ALT") keybd_event(VK_ALT, 0, KEYEVENTF_CRTCANCEL2, 0);
        }

        public static void Scroll(int Delta)
        {
            // this will cause a vertical scroll
            mouse_event(0x0800, 0, 0, Delta, 0);
        }
        public static void Scroll_WithSysKey(int Delta, String CTRL_SHIFT_ALT)
        {
            // this will cause a vertical scroll
            if (CTRL_SHIFT_ALT == "CTRL") keybd_event(VK_RCONTROL, 0, KEYEVENTF_EXTENDEDKEY2, 0);
            if (CTRL_SHIFT_ALT == "SHIFT") keybd_event(VK_SHIFT, 0, KEYEVENTF_EXTENDEDKEY2, 0);
            if (CTRL_SHIFT_ALT == "ALT") keybd_event(VK_ALT, 0, KEYEVENTF_EXTENDEDKEY2, 0);
            mouse_event(0x0800, 0, 0, Delta, 0);
            if (CTRL_SHIFT_ALT == "CTRL") keybd_event(VK_RCONTROL, 0, KEYEVENTF_CRTCANCEL2, 0);
            if (CTRL_SHIFT_ALT == "SHIFT") keybd_event(VK_SHIFT, 0, KEYEVENTF_CRTCANCEL2, 0);
            if (CTRL_SHIFT_ALT == "VK_ALT") keybd_event(VK_ALT, 0, KEYEVENTF_CRTCANCEL2, 0);
        }

        public static void SendAltTab()
        {
            //SendKeys.SendWait("%{Alt Down}");

            SendKeys.SendWait("%{TAB}");

            //SendKeys.SendWait("%{Alt Up}");
        }



        public static void SetClick(int X, int Y)
        {

            Cursor.Position = new Point(X, Y);
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);//make left button down
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);//make left button up
        }
        public static void SetDoubleClick(int X, int Y)
        {

            Cursor.Position = new Point(X, Y);
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);//make left button down
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);//make left button up

            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);//make left button down
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);//make left button up
        }
        public static void SetRightClick(int X, int Y)
        {
            Cursor.Position = new Point(X, Y);
            mouse_event(MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, 0);//make left button down
            mouse_event(MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0);//make left button up

        }

        public static void SetRightClick_NoMoveCursor(int X, int Y)
        {
            mouse_event(MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, 0);//make left button down
            mouse_event(MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0);//make left button up

        }


        public static void MidMouseDown(int X, int Y)
        {
            Cursor.Position = new Point(X, Y);
            mouse_event(MOUSEEVENTF_MIDDLEDOWN, 0, 0, 0, 0);//make left button down
        }
        public static void MidMouseUp(int X, int Y)
        {
            Cursor.Position = new Point(X, Y);
            mouse_event(MOUSEEVENTF_MIDDLEUP, 0, 0, 0, 0);//make left button down



        }


        //Keys Simullator
        public static void SendKey(string SysKey1, string SysKey2, String value, bool Caplock, string SysKey3)
        {
            try
            {
                bool NoneShift = !SysKey1.ToLower().Contains("ShiftKey".ToLower());
                bool NoneCrt = !SysKey2.ToLower().Contains("ControlKey".ToLower());
                bool NoneAlt = !SysKey3.ToLower().Contains("AltKey".ToLower());
                value = Caplock ? value.ToUpper() : value.ToLower();
                if (!NoneShift)
                {
                    value = value == value.ToUpper() ? value.ToLower() : value.ToUpper();
                }

                if (value.ToLower() == "packet".ToLower()) return;
                if (value.ToLower() == "capital".ToLower()) value = "{CAPSLOCK}";
                if (value.ToLower() == "back".ToLower()) value = "{BKSP}";
                if (value.ToLower() == "space".ToLower()) value = " ";
                if (value.ToLower() == "tab".ToLower()) value = "{TAB}";
                if (value.ToLower() == "enter".ToLower()) value = "{ENTER}";
                if (value.ToLower() == "return".ToLower()) value = "{ENTER}";
                if (value.ToLower() == "CAPS LOCK".ToLower()) value = "{CAPSLOCK}";
                if (value.ToLower() == "DELETE".ToLower()) value = "{DELETE}";
                if (value.ToLower() == "up".ToLower()) value = "{UP}";
                if (value.ToLower() == "down".ToLower()) value = "{DOWN}";
                if (value.ToLower() == "left".ToLower()) value = "{LEFT}";
                if (value.ToLower() == "right".ToLower()) value = "{RIGHT}";

                if (value.ToLower() == "lwin".ToLower()) value = "{LWIN}";
                if (value.ToLower() == "rwin".ToLower()) value = "{RWIN}";
                if (value.ToLower() == "printscreen".ToLower()) value = "{PRINTSCREEN}";
                if (value.ToLower() == "pause".ToLower()) value = "{PAUSE}";
                if (value.ToLower() == "numlock".ToLower()) value = "{NUMLOCK}";
                if (value.ToLower() == "scroll".ToLower()) value = "{SCROLLLOCK}";
                if (value.ToLower() == "apps".ToLower()) value = "{APPSKEY}";

                if (value.ToLower() == "divide".ToLower()) value = "{/}";
                if (value.ToLower() == "multiply".ToLower()) value = "{*}";
                if (value.ToLower() == "add".ToLower()) value = "{+}";
                if (value.ToLower() == "subtract".ToLower()) value = "{-}";
                if (value.ToLower() == "decimal".ToLower()) value = "{.}";

                if (value.ToLower() == "numpad0".ToLower()) value = "{0}";
                if (value.ToLower() == "numpad1".ToLower()) value = "{1}";
                if (value.ToLower() == "numpad2".ToLower()) value = "{2}";
                if (value.ToLower() == "numpad3".ToLower()) value = "{3}";
                if (value.ToLower() == "numpad4".ToLower()) value = "{4}";
                if (value.ToLower() == "numpad5".ToLower()) value = "{5}";
                if (value.ToLower() == "numpad6".ToLower()) value = "{6}";
                if (value.ToLower() == "numpad7".ToLower()) value = "{7}";
                if (value.ToLower() == "numpad8".ToLower()) value = "{8}";
                if (value.ToLower() == "numpad9".ToLower()) value = "{9}";



                if (value.ToLower() == "f1".ToLower()) value = "{F1}";
                if (value.ToLower() == "f2".ToLower()) value = "{F2}";
                if (value.ToLower() == "f3".ToLower()) value = "{F3}";
                if (value.ToLower() == "f4".ToLower()) value = "{F4}";
                if (value.ToLower() == "f5".ToLower()) value = "{F5}";
                if (value.ToLower() == "f6".ToLower()) value = "{F6}";
                if (value.ToLower() == "f7".ToLower()) value = "{F7}";
                if (value.ToLower() == "f8".ToLower()) value = "{F8}";
                if (value.ToLower() == "f9".ToLower()) value = "{F9}";
                if (value.ToLower() == "f10".ToLower()) value = "{F10}";
                if (value.ToLower() == "f11".ToLower()) value = "{F11}";
                if (value.ToLower() == "f12".ToLower()) value = "{F12}";

                if (value.ToLower() == "escape".ToLower()) value = "{ESC}";
                if (value.ToLower() == "oemtilde".ToLower()) value = "`";
                if (value.ToLower() == "D1".ToLower()) value = "1";
                if (value.ToLower() == "D2".ToLower()) value = "2";
                if (value.ToLower() == "D3".ToLower()) value = "3";
                if (value.ToLower() == "D4".ToLower()) value = "4";
                if (value.ToLower() == "D5".ToLower()) value = "5";
                if (value.ToLower() == "D6".ToLower()) value = "6";
                if (value.ToLower() == "D7".ToLower()) value = "7";
                if (value.ToLower() == "D8".ToLower()) value = "8";
                if (value.ToLower() == "D9".ToLower()) value = "9";
                if (value.ToLower() == "D0".ToLower()) value = "0";



                if (value.ToLower() == "OemQuestion".ToLower()) value = "{/}";
                if (value.ToLower() == "OemPeriod".ToLower()) value = "{.}";
                if (value.ToLower() == "Oemcomma".ToLower()) value = "{,}";
                if (value.ToLower() == "Oem1".ToLower()) value = "{;}";
                if (value.ToLower() == "Oem7".ToLower()) value = "{'}";
                if (value.ToLower() == "OemOpenBrackets".ToLower()) value = "{[}";
                if (value.ToLower() == "Oem6".ToLower()) value = "{]}";
                if (value.ToLower() == "Oem5".ToLower()) value = "{\\}";
                if (value.ToLower() == "OemMinus".ToLower()) value = "{-}";
                if (value.ToLower() == "OemPlus".ToLower()) value = "{=}";
                if (value.ToLower() == "Insert".ToLower()) value = "{INSERT}";
                if (value.ToLower() == "Home".ToLower()) value = "{HOME}";
                if (value.ToLower() == "PageUp".ToLower()) value = "{PGUP}";
                if (value.ToLower() == "Next".ToLower()) value = "{PGDN}";
                if (value.ToLower() == "Del".ToLower()) value = "{DELETE}";
                if (value.ToLower() == "End".ToLower()) value = "{END}";


                if (!NoneCrt)
                {
                    value = "^" + value;
                }

                if (!NoneShift)
                {
                    value = "+" + value;
                }

                if (!NoneAlt)
                {
                    value = "%" + value;
                }

              
                if      (value == "1") InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_1);
                else if (value == "2") InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_2);
                else if (value == "3") InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_3);
                else if (value == "4") InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_4);
                else if (value == "5") InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_5);
                else if (value == "6") InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_6);
                else if (value == "7") InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_7);
                else if (value == "8") InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_8);
                else if (value == "9") InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_9);
           
                else SendKeys.SendWait(value);


            }
            catch (Exception ex)
            {
                //  MessageBox.Show(ex.ToString()); 
            }

        }

        public static void SendKeyWithKeyPress(String Keycode, String CTRL_SHIFT_ALT_LWIN)
        {
            if (CTRL_SHIFT_ALT_LWIN == "CTRL") keybd_event(VK_RCONTROL, 0, KEYEVENTF_EXTENDEDKEY2, 0);
            if (CTRL_SHIFT_ALT_LWIN == "SHIFT") keybd_event(VK_SHIFT, 0, KEYEVENTF_EXTENDEDKEY2, 0);
            if (CTRL_SHIFT_ALT_LWIN == "LWIN") keybd_event(VK_LWIN, 0, KEYEVENTF_EXTENDEDKEY2, 0);

            SendKeys.Send(Keycode);

            //if (CTRL_SHIFT_ALT_LWIN == "CTRL") keybd_event(VK_RCONTROL, 0, KEYEVENTF_CRTCANCEL2, 0);
            //if (CTRL_SHIFT_ALT_LWIN == "SHIFT") keybd_event(VK_SHIFT, 0, KEYEVENTF_CRTCANCEL2, 0);
            //if (CTRL_SHIFT_ALT_LWIN == "LWIN") keybd_event(VK_LWIN, 0, KEYEVENTF_CRTCANCEL2, 0);
        }

        public static void KeyRelease(String CTRL_SHIFT_ALT_LWIN)
        {
            if (CTRL_SHIFT_ALT_LWIN == "CTRL") keybd_event(VK_RCONTROL, 0, KEYEVENTF_CRTCANCEL2, 0);
            if (CTRL_SHIFT_ALT_LWIN == "SHIFT") keybd_event(VK_SHIFT, 0, KEYEVENTF_CRTCANCEL2, 0);
            if (CTRL_SHIFT_ALT_LWIN == "LWIN") keybd_event(VK_LWIN, 0, KEYEVENTF_CRTCANCEL2, 0);

            //SendKeys.Send(Keycode);

            //if (CTRL_SHIFT_ALT_LWIN == "CTRL") keybd_event(VK_RCONTROL, 0, KEYEVENTF_CRTCANCEL2, 0);
            //if (CTRL_SHIFT_ALT_LWIN == "SHIFT") keybd_event(VK_SHIFT, 0, KEYEVENTF_CRTCANCEL2, 0);
            //if (CTRL_SHIFT_ALT_LWIN == "LWIN") keybd_event(VK_LWIN, 0, KEYEVENTF_CRTCANCEL2, 0);
        }
        private const int KEYEVENTF_EXTENDEDKEY = 0x1;
        private const int KEYEVENTF_KEYUP = 0x2;

        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, int dwExtraInfo);
        public static void PressKey(byte keyCode) //https://msdn.microsoft.com/en-us/library/windows/desktop/dd375731(v=vs.85).aspx
        {
            keybd_event(keyCode, 0x45, KEYEVENTF_EXTENDEDKEY, 0);
            keybd_event(keyCode, 0x45, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        internal static extern int MapVirtualKey(int uCode, int uMapType);

       






        //==> Capture Screen with mouse
        public const Int32 CURSOR_SHOWING = 0x00000001;

        [StructLayout(LayoutKind.Sequential)]
        public struct ICONINFO
        {
            public bool fIcon;
            public Int32 xHotspot;
            public Int32 yHotspot;
            public IntPtr hbmMask;
            public IntPtr hbmColor;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public Int32 x;
            public Int32 y;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct CURSORINFO
        {
            public Int32 cbSize;
            public Int32 flags;
            public IntPtr hCursor;
            public POINT ptScreenPos;
        }

        [DllImport("user32.dll")]
        public static extern bool GetCursorInfo(out CURSORINFO pci);

        [DllImport("user32.dll")]
        public static extern IntPtr CopyIcon(IntPtr hIcon);

        [DllImport("user32.dll")]
        public static extern bool DrawIcon(IntPtr hdc, int x, int y, IntPtr hIcon);

        [DllImport("user32.dll")]
        public static extern bool GetIconInfo(IntPtr hIcon, out ICONINFO piconinfo);

        public static Bitmap bitmapDrawIcon = null;

        public static int DetectCursor()
        {
            int kq = 0;
            try
            {
                bitmapDrawIcon = new Bitmap(50, 50, PixelFormat.Format24bppRgb);
                using (Graphics g = Graphics.FromImage(bitmapDrawIcon))
                {

                    CURSORINFO cursorInfo;
                    cursorInfo.cbSize = Marshal.SizeOf(typeof(CURSORINFO));
                    if (GetCursorInfo(out cursorInfo))
                    {
                        var iconPointer = CopyIcon(cursorInfo.hCursor);
                        ICONINFO iconInfo;
                        int iconX, iconY;
                        GetIconInfo(iconPointer, out iconInfo);
                        iconX = cursorInfo.ptScreenPos.x - ((int)iconInfo.xHotspot);
                        iconY = cursorInfo.ptScreenPos.y - ((int)iconInfo.yHotspot);
                        DrawIcon(g.GetHdc(), 0, 0, cursorInfo.hCursor);
                        g.ReleaseHdc();
                      
                    }

                }
               kq = (int)DBase.getObjectLenght(bitmapDrawIcon);
                //MemoryStream ms = new MemoryStream();
                //bitmapDrawIcon.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                //kq = ms.ToArray().Length;
              
            }
            catch (Exception ex) { }
            return kq;
        }

        public static IntPtr DetectCursorID2()
        {
            IntPtr kq = (IntPtr)0;
            try
            {
                    CURSORINFO cursorInfo;
                    cursorInfo.cbSize = Marshal.SizeOf(typeof(CURSORINFO));
                    if (GetCursorInfo(out cursorInfo))
                    {
                        var iconPointer = CopyIcon(cursorInfo.hCursor);
                        ICONINFO iconInfo;
                        GetIconInfo(iconPointer, out iconInfo);
                        kq = iconInfo.hbmColor;
                    }
            }
            catch (Exception ex) { }
            return kq;
        }

        public static int DetectCursorID()
        {
            int kq = 0;
            try
            {
                bitmapDrawIcon = new Bitmap(50, 50, PixelFormat.Format24bppRgb);
                using (Graphics g = Graphics.FromImage(bitmapDrawIcon))
                {

                    CURSORINFO cursorInfo;
                    cursorInfo.cbSize = Marshal.SizeOf(typeof(CURSORINFO));
                    if (GetCursorInfo(out cursorInfo))
                    {
                        var iconPointer = CopyIcon(cursorInfo.hCursor);
                        ICONINFO iconInfo;
                        int iconX, iconY;
                        GetIconInfo(iconPointer, out iconInfo);
                        iconX = cursorInfo.ptScreenPos.x - ((int)iconInfo.xHotspot);
                        iconY = cursorInfo.ptScreenPos.y - ((int)iconInfo.yHotspot);
                        DrawIcon(g.GetHdc(), 0, 0, cursorInfo.hCursor);
                        g.ReleaseHdc();

                    }

                }
                kq = (int)DBase.getObjectLenght(bitmapDrawIcon);
                //MemoryStream ms = new MemoryStream();
                //bitmapDrawIcon.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                //kq = ms.ToArray().Length;

            }
            catch (Exception ex) { }
            return kq;
        }

        public static void DrawCursorOnBMP(Bitmap bmp)
        {
            using (Graphics g = Graphics.FromImage(bmp))
            {
                CURSORINFO cursorInfo;
                cursorInfo.cbSize = Marshal.SizeOf(typeof(CURSORINFO));
                if (GetCursorInfo(out cursorInfo))
                {
                    var iconPointer = CopyIcon(cursorInfo.hCursor);
                    ICONINFO iconInfo;
                    int iconX, iconY;
                    GetIconInfo(iconPointer, out iconInfo);
                    iconX = cursorInfo.ptScreenPos.x - ((int)iconInfo.xHotspot);
                    iconY = cursorInfo.ptScreenPos.y - ((int)iconInfo.yHotspot);
                    DrawIcon(g.GetHdc(), iconX, iconY, cursorInfo.hCursor);
                    g.ReleaseHdc();
                }

            }

        }

        public static Dictionary<int, Cursor> GetCursorSizeList()
        {
            Dictionary<int, Cursor> kq = new Dictionary<int, Cursor>();
            Cursor[] Curo = new Cursor[] { Cursors.Default,Cursors.HSplit ,Cursors.VSplit,Cursors.WaitCursor , Cursors.SizeNS , Cursors.SizeWE , Cursors.SizeAll  };

            for (int i = 0; i < Curo.Length; i++)
            {
                Cursor.Current = Curo[2];
                //int size = DetectCursor();

                //try
                //{
                //    kq.Add(size, Curo[i]);
                //}
                //catch (Exception ex) { }
            }

            return kq;
        }
        public static Bitmap Capture_Cursor(int x, int y, int width, int height)
        {
            var bitmap = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.CopyFromScreen(x, y, 0, 0, bitmap.Size, CopyPixelOperation.SourceCopy);

                CURSORINFO cursorInfo;
                cursorInfo.cbSize = Marshal.SizeOf(typeof(CURSORINFO));

                if (GetCursorInfo(out cursorInfo))
                {
                    // if the cursor is showing draw it on the screen shot
                    if (cursorInfo.flags == CURSOR_SHOWING)
                    {
                        // we need to get hotspot so we can draw the cursor in the correct position
                        var iconPointer = CopyIcon(cursorInfo.hCursor);
                        ICONINFO iconInfo;
                        int iconX, iconY;

                        if (GetIconInfo(iconPointer, out iconInfo))
                        {
                            // calculate the correct position of the cursor
                            iconX = cursorInfo.ptScreenPos.x - ((int)iconInfo.xHotspot);
                            iconY = cursorInfo.ptScreenPos.y - ((int)iconInfo.yHotspot);

                            // draw the cursor icon on top of the captured screen image
                            DrawIcon(g.GetHdc(), iconX, iconY, cursorInfo.hCursor);
                           
                            // release the handle created by call to g.GetHdc()
                            g.ReleaseHdc();
                        }
                    }
                }
            }
            return bitmap;
        }
        //Detech Caplock Numlock
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true, CallingConvention = CallingConvention.Winapi)]
        public static extern short GetKeyState(int keyCode);
        //ShowScrollbar
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool ShowScrollBar(IntPtr hWnd, int wBar, bool bShow);
        private enum ScrollBarDirection
        {
            SB_HORZ = 0,
            SB_VERT = 1,
            SB_CTL = 2,
            SB_BOTH = 3
        }
        public static void SetWallpaperSolidColor(Color color)
        {

            // Remove the current wallpaper
            NativeMethods.SystemParametersInfo(
                NativeMethods.SPI_SETDESKWALLPAPER,
                0,
                "",
                NativeMethods.SPIF_UPDATEINIFILE | NativeMethods.SPIF_SENDWININICHANGE);

            // Set the new desktop solid color for the current session
            int[] elements = { NativeMethods.COLOR_DESKTOP };
            int[] colors = { System.Drawing.ColorTranslator.ToWin32(color) };
            NativeMethods.SetSysColors(elements.Length, elements, colors);

            // Save value in registry so that it will persist
            RegistryKey key = Registry.CurrentUser.OpenSubKey("Control Panel\\Colors", true);
            key.SetValue(@"Background", string.Format("{0} {1} {2}", color.R, color.G, color.B));
        }
        public static void SetWallpaper(String path)
        {
            NativeMethods.SystemParametersInfo(
                NativeMethods.SPI_SETDESKWALLPAPER,
                0,
                path,
                NativeMethods.SPIF_UPDATEINIFILE | NativeMethods.SPIF_SENDWININICHANGE);


        }
        private static class NativeMethods
        {
            public const int COLOR_DESKTOP = 1;
            public const int SPI_SETDESKWALLPAPER = 20;
            public const int SPIF_UPDATEINIFILE = 0x01;
            public const int SPIF_SENDWININICHANGE = 0x02;

            [DllImport("user32.dll")]
            public static extern bool SetSysColors(int cElements, int[] lpaElements, int[] lpaRgbValues);

            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);
        }

        [DllImport("dwmapi.dll", PreserveSig = false)]
        public static extern int DwmEnableComposition(bool fEnable);

        public static void AreoToogle(bool Enable)
        {
            try
            {
                DwmEnableComposition(Enable);
            }
            catch (Exception ex) { }
        }

        public static bool AreoIsEnabled()
        {
            // Check to see if composition is Enabled
            if (Environment.OSVersion.Version.Major >= 6 && DwmIsCompositionEnabled())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        [DllImport("dwmapi.dll", PreserveSig = false)]

        public static extern bool DwmIsCompositionEnabled();



        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern bool LogonUser(
            string lpszUsername,
            string lpszDomain,
            string lpszPassword,
            int dwLogonType,
            int dwLogonProvider,
            out IntPtr phToken
            );

        const int LOGON32_LOGON_INTERACTIVE = 2;
        const int LOGON32_LOGON_NETWORK = 3;
        const int LOGON32_LOGON_BATCH = 4;
        const int LOGON32_LOGON_SERVICE = 5;
        const int LOGON32_LOGON_UNLOCK = 7;
        const int LOGON32_LOGON_NETWORK_CLEARTEXT = 8;
        const int LOGON32_LOGON_NEW_CREDENTIALS = 9;
        const int LOGON32_PROVIDER_DEFAULT = 0;


        public static bool ValidateLogOn(string Username, string password)
        {
            bool kq = false;
            IntPtr hToken;
            kq = LogonUser(Username, Environment.MachineName, password,
                                    LOGON32_LOGON_INTERACTIVE, LOGON32_PROVIDER_DEFAULT, out hToken);

            return kq;
        }


        //WMI
        public static List<String> GetUsers()
        {
            List<String> kq = new List<string>();
            SelectQuery sQuery = new SelectQuery("Win32_UserAccount", "Domain='" + Environment.MachineName + "'");
            try
            {
                ManagementObjectSearcher mSearcher = new ManagementObjectSearcher(sQuery);
                // Console.WriteLine("User Accounts\n");

                foreach (ManagementObject mObject in mSearcher.Get())
                {
                    kq.Add(DBase.StringReturn(mObject["Name"]));
                }
            }
            catch (Exception ex)
            {

            }


            return kq;
        }
        public static string GetHardDisksInfo()
        {
            String kq = "";
            try
            {
                string systemLogicalDiskDeviceId = Environment.GetFolderPath(Environment.SpecialFolder.System).Substring(0, 2);
                ManagementObjectSearcher searcher = new
                ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_DiskDrive  WHERE INDEX = 0");
                foreach (ManagementObject wmi in searcher.Get())
                {
                    try
                    {
                        kq = wmi.GetPropertyValue("Model").ToString() + "-" + wmi.GetPropertyValue("SerialNumber").ToString();
                        break;
                    }
                    catch
                    {

                    }
                }
                if (kq == "")
                {
                      ManagementObjectSearcher M = new  ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_DiskDrive ");
                        foreach (ManagementObject wmi in M.Get())
                        {
                            try
                            {
                                kq = wmi.GetPropertyValue("Model").ToString() + "-" + wmi.GetPropertyValue("SerialNumber").ToString();
                                break;
                            }
                            catch
                            {

                            }
                        }
                }
            }
            catch (Exception ex) { }
            return kq;
        }
        public static string GetMainboardInfo()
        {
            String kq = "";
            try
            {
                ManagementObjectSearcher searcher = new
                ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BaseBoard");
                foreach (ManagementObject wmi in searcher.Get())
                {
                    try
                    {
                        kq = wmi.GetPropertyValue("Manufacturer").ToString() + "-" + wmi.GetPropertyValue("Product").ToString() + "-" + wmi.GetPropertyValue("SerialNumber").ToString();
                    }
                    catch
                    {

                    }
                }
            }
            catch (Exception ex) { }
            return kq;
        }
        public static string GetBiosInfo()
        {
            String kq = "";
            try
            {
                ManagementObjectSearcher searcher = new
                ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BIOS");
                foreach (ManagementObject wmi in searcher.Get())
                {
                    try
                    {
                        kq = wmi.GetPropertyValue("SMBIOSBIOSVersion").ToString() + "-" + wmi.GetPropertyValue("Version").ToString();
                    }
                    catch
                    {

                    }
                }
            }
            catch (Exception ex) { }
            return kq;
        }


        //DIsplayMode
        public static void SetDisplayMode(DisplayMode mode)
        {
            var proc = new Process();
            proc.StartInfo.FileName = "DisplaySwitch.exe";
            switch (mode)
            {
                case DisplayMode.External:
                    proc.StartInfo.Arguments = "/external";
                    break;
                case DisplayMode.Internal:
                    proc.StartInfo.Arguments = "/internal";
                    break;
                case DisplayMode.Extend:
                    proc.StartInfo.Arguments = "/extend";
                    break;
                case DisplayMode.Duplicate:
                    proc.StartInfo.Arguments = "/clone";
                    break;
            }
            proc.Start();
        }
        public static void ShowDisplayMode()
        {
            var proc = new Process();
            proc.StartInfo.FileName = "DisplaySwitch.exe";
            proc.Start();
        }
        public static void SetNextDisplayMode(DisplayMode mode)
        {
            var proc = new Process();
            proc.StartInfo.FileName = "DisplaySwitch.exe";
            switch (mode)
            {
                case DisplayMode.External:
                    proc.StartInfo.Arguments = "/external";
                    break;
                case DisplayMode.Internal:
                    proc.StartInfo.Arguments = "/internal";
                    break;
                case DisplayMode.Extend:
                    proc.StartInfo.Arguments = "/extend";
                    break;
                case DisplayMode.Duplicate:
                    proc.StartInfo.Arguments = "/clone";
                    break;
            }
            proc.Start();
        }
        public enum DisplayMode
        {
            Internal,
            External,
            Extend,
            Duplicate
        }



        public static int WM_SYSCOMMAND = 0x0112;
        public static int SC_MONITORPOWER = 0xF170;

        [DllImport("user32.dll")]
        private static extern int SendMessage(int hWnd, int hMsg, int wParam, int lParam);




        [DllImport("user32.dll", EntryPoint = "GetKeyboardState", SetLastError = true)]
        private static extern bool NativeGetKeyboardState([Out] byte[] keyStates);


        [DllImport("user32.dll")]
        static extern IntPtr LoadIcon(IntPtr hInstance, IntPtr lpIconName);

        [DllImport("user32.dll", EntryPoint = "GetClassLong")]
        static extern uint GetClassLong32(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll", EntryPoint = "GetClassLongPtr")]
        static extern IntPtr GetClassLong64(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);


        static IntPtr GetClassLongPtr(IntPtr hWnd, int nIndex)
        {
            if (IntPtr.Size == 4)
                return new IntPtr((long)GetClassLong32(hWnd, nIndex));
            else
                return GetClassLong64(hWnd, nIndex);
        }


        static uint WM_GETICON = 0x007f;
        static IntPtr ICON_SMALL2 = new IntPtr(2);
        static IntPtr IDI_APPLICATION = new IntPtr(0x7F00);
        static int GCL_HICON = -14;

        public static Image GetSmallWindowIcon(IntPtr hWnd)
        {
            try
            {
                IntPtr hIcon = default(IntPtr);

                hIcon = SendMessage(hWnd, WM_GETICON, ICON_SMALL2, IntPtr.Zero);

                if (hIcon == IntPtr.Zero)
                    hIcon = GetClassLongPtr(hWnd, GCL_HICON);

                if (hIcon == IntPtr.Zero)
                    hIcon = LoadIcon(IntPtr.Zero, (IntPtr)0x7F00/*IDI_APPLICATION*/);

                if (hIcon != IntPtr.Zero)
                    return new Bitmap(Icon.FromHandle(hIcon).ToBitmap(), 16, 16);
                else
                    return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static DataTable UseWMIToGetProcesses()
        {
            DataTable dt = new DataTable();
            DBase.AddColumn(dt, "ProcessId");
            DBase.AddColumn(dt, "Caption");
            DBase.AddColumn(dt, "CommandLine");
            DBase.AddColumn(dt, "ExecutablePath");

            string remoteMachine = "localhost";
            string queryStr = "select * from win32_process";

            ConnectionOptions co = new ConnectionOptions();
            co.Username = @"domain\username";
            co.Password = "the password";

            ManagementScope ms = new ManagementScope(string.Format(@"\\{0}\root\cimv2", remoteMachine), null);
            ms.Connect();
            if (ms.IsConnected)
            {
                int process_count = 0;
                ObjectQuery query = new ObjectQuery(queryStr);
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(ms, query))
                {
                    using (ManagementObjectCollection searchResult = searcher.Get())
                    {
                        foreach (ManagementObject mo in searchResult)
                        {
                            ////PrintProperties(mo);
                            //Console.WriteLine(mo["ProcessId"] + " : " + mo["Caption"]);
                            ////Console.WriteLine(mo["CommandLine"]);
                           
                            DataRow dr = dt.NewRow();
                            dr["ProcessId"] = mo["ProcessId"];
                            dr["Caption"] = mo["Caption"];
                            dr["CommandLine"] = mo["CommandLine"];
                            dr["ExecutablePath"] = mo["ExecutablePath"];
                            dt.Rows.Add(dr);
                            process_count++;
                        }
                    }
                }
   
            }

            return dt;
                
        }

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        

    }

























    public static class ScreenExtensions
    {
        

        ////https://msdn.microsoft.com/en-us/library/windows/desktop/dd145062(v=vs.85).aspx
        //[DllImport("User32.dll")]
        //private static extern IntPtr MonitorFromPoint([In]System.Drawing.Point pt, [In]uint dwFlags);

        ////https://msdn.microsoft.com/en-us/library/windows/desktop/dn280510(v=vs.85).aspx
        //[DllImport("Shcore.dll")]
        //private static extern IntPtr GetDpiForMonitor([In]IntPtr hmonitor, [In]DpiType dpiType, [Out]out uint dpiX, [Out]out uint dpiY);

        //public static void GetDpi(this System.Windows.Forms.Screen screen, DpiType dpiType, out uint dpiX, out uint dpiY)
        //{
        //    var pnt = new System.Drawing.Point(screen.Bounds.Left + 1, screen.Bounds.Top + 1);
        //    var mon = MonitorFromPoint(pnt, 2/*MONITOR_DEFAULTTONEAREST*/);
        //    GetDpiForMonitor(mon, dpiType, out dpiX, out dpiY);
        //}
        //public enum DpiType
        //{
        //    Effective = 0,
        //    Angular = 1,
        //    Raw = 2,
        //}
    }

    //https://msdn.microsoft.com/en-us/library/windows/desktop/dn280511(v=vs.85).aspx
   
}
