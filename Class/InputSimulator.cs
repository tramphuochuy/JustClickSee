using System;
using System.Collections.Generic;

using System.Text;
using System.Runtime.InteropServices;

namespace GB
{
    public static class InputSimulator
    {

        [DllImport("user32.dll", SetLastError = true)]
        static extern UInt32 SendInput(UInt32 numberOfInputs, INPUT[] inputs, Int32 sizeOfInputStructure);

        [DllImport("user32.dll", SetLastError = true)]
        static extern Int16 GetAsyncKeyState(UInt16 virtualKeyCode);

        [DllImport("user32.dll", SetLastError = true)]
        static extern Int16 GetKeyState(UInt16 virtualKeyCode);

        [DllImport("user32.dll")]
        static extern IntPtr GetMessageExtraInfo();

        public static bool IsKeyDownAsync(VirtualKeyCode keyCode)
        {
            Int16 result = GetAsyncKeyState((UInt16)keyCode);
            return (result < 0);
        }
        public static bool IsKeyDown(VirtualKeyCode keyCode)
        {
            Int16 result = GetKeyState((UInt16)keyCode);
            return (result < 0);
        }
        public static bool IsTogglingKeyInEffect(VirtualKeyCode keyCode)
        {
            Int16 result = GetKeyState((UInt16)keyCode);
            return (result & 0x01) == 0x01;
        }


        public static void SimulateKeyDown(VirtualKeyCode keyCode)
        {
            var down = new INPUT();
            down.Type = (UInt32)InputType.KEYBOARD;
            down.Data.Keyboard = new KEYBDINPUT();
            down.Data.Keyboard.Vk = (UInt16)keyCode;
            down.Data.Keyboard.Scan = 0;
            down.Data.Keyboard.Flags = 0;
            down.Data.Keyboard.Time = 0;
            down.Data.Keyboard.ExtraInfo = IntPtr.Zero;

            INPUT[] inputList = new INPUT[1];
            inputList[0] = down;

            var numberOfSuccessfulSimulatedInputs = SendInput(1, inputList, Marshal.SizeOf(typeof(INPUT)));
            if (numberOfSuccessfulSimulatedInputs == 0) throw new Exception(string.Format("The key down simulation for {0} was not successful.", keyCode));
        }
        public static void SimulateKeyUp(VirtualKeyCode keyCode)
        {
            var up = new INPUT();
            up.Type = (UInt32)InputType.KEYBOARD;
            up.Data.Keyboard = new KEYBDINPUT();
            up.Data.Keyboard.Vk = (UInt16)keyCode;
            up.Data.Keyboard.Scan = 0;
            up.Data.Keyboard.Flags = (UInt32)KeyboardFlag.KEYUP;
            up.Data.Keyboard.Time = 0;
            up.Data.Keyboard.ExtraInfo = IntPtr.Zero;

            INPUT[] inputList = new INPUT[1];
            inputList[0] = up;

            var numberOfSuccessfulSimulatedInputs = SendInput(1, inputList, Marshal.SizeOf(typeof(INPUT)));
            if (numberOfSuccessfulSimulatedInputs == 0) throw new Exception(string.Format("The key up simulation for {0} was not successful.", keyCode));
        }
        public static void SimulateKeyPress(VirtualKeyCode keyCode)
        {
            var down = new INPUT();
            down.Type = (UInt32)InputType.KEYBOARD;
            down.Data.Keyboard = new KEYBDINPUT();
            down.Data.Keyboard.Vk = (UInt16)keyCode;
            down.Data.Keyboard.Scan = 0;
            down.Data.Keyboard.Flags = 0;
            down.Data.Keyboard.Time = 0;
            down.Data.Keyboard.ExtraInfo = IntPtr.Zero;

            var up = new INPUT();
            up.Type = (UInt32)InputType.KEYBOARD;
            up.Data.Keyboard = new KEYBDINPUT();
            up.Data.Keyboard.Vk = (UInt16)keyCode;
            up.Data.Keyboard.Scan = 0;
            up.Data.Keyboard.Flags = (UInt32)KeyboardFlag.KEYUP;
            up.Data.Keyboard.Time = 0;
            up.Data.Keyboard.ExtraInfo = IntPtr.Zero;

            INPUT[] inputList = new INPUT[2];
            inputList[0] = down;
            inputList[1] = up;

            var numberOfSuccessfulSimulatedInputs = SendInput(2, inputList, Marshal.SizeOf(typeof(INPUT)));
            if (numberOfSuccessfulSimulatedInputs == 0) throw new Exception(string.Format("The key press simulation for {0} was not successful.", keyCode));
        }
        public static void SimulateTextEntry(string text)
        {
            if (text.Length > UInt32.MaxValue / 2) throw new ArgumentException(string.Format("The text parameter is too long. It must be less than {0} characters.", UInt32.MaxValue / 2), "text");

            var chars = UTF8Encoding.ASCII.GetBytes(text);
            var len = chars.Length;
            INPUT[] inputList = new INPUT[len * 2];
            for (int x = 0; x < len; x++)
            {
                UInt16 scanCode = chars[x];

                var down = new INPUT();
                down.Type = (UInt32)InputType.KEYBOARD;
                down.Data.Keyboard = new KEYBDINPUT();
                down.Data.Keyboard.Vk = 0;
                down.Data.Keyboard.Scan = scanCode;
                down.Data.Keyboard.Flags = (UInt32)KeyboardFlag.UNICODE;
                down.Data.Keyboard.Time = 0;
                down.Data.Keyboard.ExtraInfo = IntPtr.Zero;

                var up = new INPUT();
                up.Type = (UInt32)InputType.KEYBOARD;
                up.Data.Keyboard = new KEYBDINPUT();
                up.Data.Keyboard.Vk = 0;
                up.Data.Keyboard.Scan = scanCode;
                up.Data.Keyboard.Flags = (UInt32)(KeyboardFlag.KEYUP | KeyboardFlag.UNICODE);
                up.Data.Keyboard.Time = 0;
                up.Data.Keyboard.ExtraInfo = IntPtr.Zero;

                // Handle extended keys:
                // If the scan code is preceded by a prefix byte that has the value 0xE0 (224),
                // we need to include the KEYEVENTF_EXTENDEDKEY flag in the Flags property. 
                if ((scanCode & 0xFF00) == 0xE000)
                {
                    down.Data.Keyboard.Flags |= (UInt32)KeyboardFlag.EXTENDEDKEY;
                    up.Data.Keyboard.Flags |= (UInt32)KeyboardFlag.EXTENDEDKEY;
                }

                inputList[2 * x] = down;
                inputList[2 * x + 1] = up;

            }

            var numberOfSuccessfulSimulatedInputs = SendInput((UInt32)len * 2, inputList, Marshal.SizeOf(typeof(INPUT)));
        }
        public static void SimulateModifiedKeyStroke(VirtualKeyCode modifierKeyCode, VirtualKeyCode keyCode)
        {
            SimulateKeyDown(modifierKeyCode);
            SimulateKeyPress(keyCode);
            SimulateKeyUp(modifierKeyCode);
        }
        public static void SimulateModifiedKeyStroke(VirtualKeyCode modifierKey, IEnumerable<VirtualKeyCode> keyCodes)
        {
            SimulateKeyDown(modifierKey);
            if (keyCodes != null)
            {
                foreach (VirtualKeyCode VC in keyCodes)
                {
                    SimulateKeyPress(VC);
                }
            }
            SimulateKeyUp(modifierKey);
        }
        public static void SimulateModifiedKeyStroke(IEnumerable<VirtualKeyCode> modifierKeyCodes, VirtualKeyCode keyCode)
        {
            if (modifierKeyCodes != null)
            {
                foreach (VirtualKeyCode VC in modifierKeyCodes)
                {
                    SimulateKeyDown(VC);
                }
            }
            SimulateKeyPress(keyCode);
            if (modifierKeyCodes != null)
            {
                foreach (VirtualKeyCode VC in modifierKeyCodes)
                {
                    SimulateKeyUp(VC);
                }
            }
        }
        public static void SimulateModifiedKeyStroke(IEnumerable<VirtualKeyCode> modifierKeyCodes, IEnumerable<VirtualKeyCode> keyCodes)
        {
            if (modifierKeyCodes != null)
                foreach (VirtualKeyCode VC in modifierKeyCodes)
                {
                    SimulateKeyDown(VC);
                }

            if (keyCodes != null)
            {
                foreach (VirtualKeyCode VC in keyCodes)
                {
                    SimulateKeyPress(VC);
                }
            }

            if (modifierKeyCodes != null)
            {
                foreach (VirtualKeyCode VC in keyCodes)
                {
                    SimulateKeyUp(VC);
                }
            }
        }
    }

    #region

#pragma warning disable 649
    struct MOUSEINPUT
    {
        public Int32 X;

        public Int32 Y;

        public UInt32 MouseData;

        public UInt32 Flags;

        public UInt32 Time;

        public IntPtr ExtraInfo;
    }

    struct HARDWAREINPUT
    {
        /// <summary>
        /// Value specifying the message generated by the input hardware. 
        /// </summary>
        public UInt32 Msg;

        /// <summary>
        /// Specifies the low-order word of the lParam parameter for uMsg. 
        /// </summary>
        public UInt16 ParamL;

        /// <summary>
        /// Specifies the high-order word of the lParam parameter for uMsg. 
        /// </summary>
        public UInt16 ParamH;
    }
#pragma warning restore 649

    struct INPUT
    {
        public UInt32 Type;
        public MOUSEKEYBDHARDWAREINPUT Data;
    }
    public enum InputType : uint // UInt32
    {

        MOUSE = 0,
        KEYBOARD = 1,
        HARDWARE = 2,
    }
    struct KEYBDINPUT
    {
        public UInt16 Vk;

        public UInt16 Scan;

        public UInt32 Flags;

        public UInt32 Time;

        public IntPtr ExtraInfo;
    }
    public enum KeyboardFlag : uint // UInt32
    {
        EXTENDEDKEY = 0x0001,

        KEYUP = 0x0002,

        UNICODE = 0x0004,

        SCANCODE = 0x0008,
    }
    public enum MouseFlag : uint
    {
        MOVE = 0x0001,

        LEFTDOWN = 0x0002,

        LEFTUP = 0x0004,

        RIGHTDOWN = 0x0008,

        RIGHTUP = 0x0010,

        MIDDLEDOWN = 0x0020,

        MIDDLEUP = 0x0040,

        XDOWN = 0x0080,

        XUP = 0x0100,

        WHEEL = 0x0800,

        VIRTUALDESK = 0x4000,

        ABSOLUTE = 0x8000,
    }

    [StructLayout(LayoutKind.Explicit)]
    struct MOUSEKEYBDHARDWAREINPUT
    {
        [FieldOffset(0)]
        public MOUSEINPUT Mouse;

        [FieldOffset(0)]
        public KEYBDINPUT Keyboard;

        [FieldOffset(0)]
        public HARDWAREINPUT Hardware;
    }
    public enum VirtualKeyCode : ushort // UInt16
    {
        LBUTTON = 0x01,

        RBUTTON = 0x02,

        CANCEL = 0x03,

        MBUTTON = 0x04,

        XBUTTON1 = 0x05,

        XBUTTON2 = 0x06,

        // 0x07 : Undefined

        BACK = 0x08,

        TAB = 0x09,

        // 0x0A - 0x0B : Reserved

        CLEAR = 0x0C,

        RETURN = 0x0D,

        // 0x0E - 0x0F : Undefined

        SHIFT = 0x10,

        CONTROL = 0x11,

        MENU = 0x12,

        PAUSE = 0x13,

        CAPITAL = 0x14,

        KANA = 0x15,

        HANGEUL = 0x15,

        HANGUL = 0x15,

        // 0x16 : Undefined

        JUNJA = 0x17,

        FINAL = 0x18,

        HANJA = 0x19,

        KANJI = 0x19,

        // 0x1A : Undefined

        ESCAPE = 0x1B,

        CONVERT = 0x1C,

        NONCONVERT = 0x1D,

        ACCEPT = 0x1E,

        MODECHANGE = 0x1F,

        SPACE = 0x20,

        PRIOR = 0x21,

        NEXT = 0x22,

        END = 0x23,

        HOME = 0x24,

        LEFT = 0x25,

        UP = 0x26,

        RIGHT = 0x27,

        DOWN = 0x28,

        SELECT = 0x29,

        PRINT = 0x2A,

        EXECUTE = 0x2B,

        SNAPSHOT = 0x2C,

        INSERT = 0x2D,

        DELETE = 0x2E,

        HELP = 0x2F,

        VK_0 = 0x30,

        VK_1 = 0x31,

        VK_2 = 0x32,

        VK_3 = 0x33,

        VK_4 = 0x34,

        VK_5 = 0x35,

        VK_6 = 0x36,

        VK_7 = 0x37,

        VK_8 = 0x38,

        VK_9 = 0x39,

        //
        // 0x3A - 0x40 : Udefined
        //

        VK_A = 0x41,

        VK_B = 0x42,

        VK_C = 0x43,

        VK_D = 0x44,

        VK_E = 0x45,

        VK_F = 0x46,

        VK_G = 0x47,

        VK_H = 0x48,

        VK_I = 0x49,

        VK_J = 0x4A,

        VK_K = 0x4B,

        VK_L = 0x4C,

        VK_M = 0x4D,

        VK_N = 0x4E,

        VK_O = 0x4F,

        VK_P = 0x50,

        VK_Q = 0x51,

        VK_R = 0x52,

        VK_S = 0x53,

        VK_T = 0x54,

        VK_U = 0x55,

        VK_V = 0x56,

        VK_W = 0x57,

        VK_X = 0x58,

        VK_Y = 0x59,

        VK_Z = 0x5A,

        LWIN = 0x5B,

        RWIN = 0x5C,

        APPS = 0x5D,

        // 0x5E : reserved

        SLEEP = 0x5F,

        NUMPAD0 = 0x60,

        NUMPAD1 = 0x61,

        NUMPAD2 = 0x62,

        NUMPAD3 = 0x63,

        NUMPAD4 = 0x64,

        NUMPAD5 = 0x65,

        NUMPAD6 = 0x66,

        NUMPAD7 = 0x67,

        NUMPAD8 = 0x68,

        NUMPAD9 = 0x69,

        MULTIPLY = 0x6A,

        ADD = 0x6B,

        SEPARATOR = 0x6C,

        SUBTRACT = 0x6D,

        DECIMAL = 0x6E,

        DIVIDE = 0x6F,

        F1 = 0x70,

        F2 = 0x71,

        F3 = 0x72,

        F4 = 0x73,

        F5 = 0x74,

        F6 = 0x75,

        F7 = 0x76,

        F8 = 0x77,

        F9 = 0x78,

        F10 = 0x79,

        F11 = 0x7A,

        F12 = 0x7B,

        F13 = 0x7C,

        F14 = 0x7D,

        F15 = 0x7E,

        F16 = 0x7F,

        F17 = 0x80,

        F18 = 0x81,

        F19 = 0x82,

        F20 = 0x83,

        F21 = 0x84,

        F22 = 0x85,

        F23 = 0x86,

        F24 = 0x87,

        //
        // 0x88 - 0x8F : Unassigned
        //

        NUMLOCK = 0x90,

        SCROLL = 0x91,

        // 0x92 - 0x96 : OEM Specific

        // 0x97 - 0x9F : Unassigned

        //
        // L* & R* - left and right Alt, Ctrl and Shift virtual keys.
        // Used only as parameters to GetAsyncKeyState() and GetKeyState().
        // No other API or message will distinguish left and right keys in this way.
        //

        LSHIFT = 0xA0,

        RSHIFT = 0xA1,

        LCONTROL = 0xA2,

        RCONTROL = 0xA3,

        LMENU = 0xA4,

        RMENU = 0xA5,

        BROWSER_BACK = 0xA6,

        BROWSER_FORWARD = 0xA7,

        BROWSER_REFRESH = 0xA8,

        BROWSER_STOP = 0xA9,

        BROWSER_SEARCH = 0xAA,

        BROWSER_FAVORITES = 0xAB,

        BROWSER_HOME = 0xAC,

        VOLUME_MUTE = 0xAD,

        VOLUME_DOWN = 0xAE,

        VOLUME_UP = 0xAF,

        MEDIA_NEXT_TRACK = 0xB0,

        MEDIA_PREV_TRACK = 0xB1,

        MEDIA_STOP = 0xB2,

        MEDIA_PLAY_PAUSE = 0xB3,

        LAUNCH_MAIL = 0xB4,

        LAUNCH_MEDIA_SELECT = 0xB5,

        LAUNCH_APP1 = 0xB6,

        LAUNCH_APP2 = 0xB7,

        //
        // 0xB8 - 0xB9 : Reserved
        //

        OEM_1 = 0xBA,

        OEM_PLUS = 0xBB,

        OEM_COMMA = 0xBC,

        OEM_MINUS = 0xBD,

        OEM_PERIOD = 0xBE,

        OEM_2 = 0xBF,

        OEM_3 = 0xC0,

        //
        // 0xC1 - 0xD7 : Reserved
        //

        //
        // 0xD8 - 0xDA : Unassigned
        //

        OEM_4 = 0xDB,

        OEM_5 = 0xDC,

        OEM_6 = 0xDD,

        OEM_7 = 0xDE,

        OEM_8 = 0xDF,

        //
        // 0xE0 : Reserved
        //

        //
        // 0xE1 : OEM Specific
        //

        OEM_102 = 0xE2,

        //
        // (0xE3-E4) : OEM specific
        //

        PROCESSKEY = 0xE5,

        //
        // 0xE6 : OEM specific
        //

        PACKET = 0xE7,

        //
        // 0xE8 : Unassigned
        //

        //
        // 0xE9-F5 : OEM specific
        //

        ATTN = 0xF6,

        CRSEL = 0xF7,

        EXSEL = 0xF8,

        EREOF = 0xF9,

        PLAY = 0xFA,

        ZOOM = 0xFB,

        NONAME = 0xFC,

        PA1 = 0xFD,

        OEM_CLEAR = 0xFE,
    }
    #endregion


}