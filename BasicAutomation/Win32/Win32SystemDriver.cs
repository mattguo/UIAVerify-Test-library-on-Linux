using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Windows.Input;
using System.Diagnostics;

namespace BasicAutomation.Win32
{
    class Win32SystemDriver : ISystemDriver
    {
        #region Singleton
        private static readonly Win32SystemDriver instance = new Win32SystemDriver();

        //Explicit static constructor to tell C# compiler not to mark type as beforefieldinit
        static Win32SystemDriver()
        {
			
        }

        private Win32SystemDriver()
        {
			
        }

        public static Win32SystemDriver Instance
        {
            get
            {
                return instance;
            }
        }
        #endregion

        #region ISystemDriver Members

        public bool Execute(string appPath, string arguments)
        {
            Process p = new Process();
            p.StartInfo.FileName = appPath;
            p.StartInfo.Arguments = arguments;
            return p.Start();
        }

        /*
        public bool ShellExecute(string appPath, string arguments)
        {
            IntPtr hInstance = Win32NativeMethods.ShellExecute(IntPtr.Zero, null, appPath, arguments, null, 1);
            return hInstance.ToInt64() <= 32L;
        }*/

        public void InputKey(Key key, bool press)
        {
            Win32NativeMethods.INPUT ki = new Win32NativeMethods.INPUT();
            ki.type = Win32NativeMethods.INPUT_KEYBOARD;
            ki.union.keyboardInput.wVk = (short)KeyInterop.VirtualKeyFromKey(key);
            ki.union.keyboardInput.wScan = (short)Win32NativeMethods.MapVirtualKey(ki.union.keyboardInput.wVk, 0);
            int dwFlags = 0;
            if (ki.union.keyboardInput.wScan > 0)
                dwFlags |= Win32NativeMethods.KEYEVENTF_SCANCODE;
            if (!press)
                dwFlags |= Win32NativeMethods.KEYEVENTF_KEYUP;
            ki.union.keyboardInput.dwFlags = dwFlags;
            if (IsExtendedKey(key))
            {
                ki.union.keyboardInput.dwFlags |= Win32NativeMethods.KEYEVENTF_EXTENDEDKEY;
            }
            ki.union.keyboardInput.time = 0;
            ki.union.keyboardInput.dwExtraInfo = new IntPtr(0);
            if (Win32NativeMethods.SendInput(1, ref ki, Marshal.SizeOf(ki)) == 0)
                throw new Win32Exception(Marshal.GetLastWin32Error());
        }

        public KeyStates GetKeyState(Key key)
        {
            int keyState = Win32NativeMethods.GetAsyncKeyState(KeyInterop.VirtualKeyFromKey(key));
            if (keyState == 0)
            {
                throw new InvalidOperationException("GetAsyncKeyStateFailed");
            }
            //todo, currently we don't support KeyStates.Toggled
            if (keyState < 0)
                return KeyStates.Down;
            else
                return KeyStates.None;
        }

        public void EnterText(string text)
        {
            char[] charData = text.ToCharArray();

            foreach (char c in charData)
            {
                SendUnicodeKeyboardInput(c, true);
                SendUnicodeKeyboardInput(c, false);
            }
        }

        public void SendMouseMove(double x, double y, bool isAbsCoord)
        {
            int mouseInputFlags = Win32NativeMethods.MOUSEEVENTF_MOVE;
            if (isAbsCoord)
                mouseInputFlags = NativeHelper.SetBit(mouseInputFlags, Win32NativeMethods.MOUSEEVENTF_ABSOLUTE);
            SendMouseInput(x, y, 0, mouseInputFlags);
        }

        public System.Windows.Point MousePostion
        {
            get
			{
				Win32NativeMethods.POINT pt;	
				Win32NativeMethods.GetCursorPos(out pt);
				return new System.Windows.Point(pt.X, pt.Y);
			}
            set
			{
				SendMouseMove(value.X, value.Y, true);
			}
        }

        public void SendMouseWheel(MouseWheel wheel, int delta)
        {
            //int mouseInputFlags = Win32NativeMethods.MOUSEEVENTF_ABSOLUTE;
			int mouseInputFlags = 0;
            if (wheel == MouseWheel.Horizontal)
                throw new NotImplementedException();
            else
                mouseInputFlags |= Win32NativeMethods.MOUSEEVENTF_WHEEL;
            SendMouseInput(0, 0, delta, mouseInputFlags);
        }

        public void ChangeMouseState(double x, double y, MouseButton button, MouseButtonState state)
        {
            int mouseInputFlags = Win32NativeMethods.MOUSEEVENTF_ABSOLUTE;
            switch (button)
            {
                case MouseButton.Left:
                    if (state == MouseButtonState.Pressed)
                        mouseInputFlags |= Win32NativeMethods.MOUSEEVENTF_LEFTDOWN;
                    if (state == MouseButtonState.Released)
                        mouseInputFlags |= Win32NativeMethods.MOUSEEVENTF_LEFTUP;
                    break;
                case MouseButton.Right:
                    if (state == MouseButtonState.Pressed)
                        mouseInputFlags |= Win32NativeMethods.MOUSEEVENTF_RIGHTDOWN;
                    if (state == MouseButtonState.Released)
                        mouseInputFlags |= Win32NativeMethods.MOUSEEVENTF_RIGHTUP;
                    break;
                case MouseButton.Middle:
                    if (state == MouseButtonState.Pressed)
                        mouseInputFlags |= Win32NativeMethods.MOUSEEVENTF_MIDDLEDOWN;
                    if (state == MouseButtonState.Released)
                        mouseInputFlags |= Win32NativeMethods.MOUSEEVENTF_MIDDLEUP;
                    break;
                case MouseButton.XButton1:
                case MouseButton.XButton2:
                    if (state == MouseButtonState.Pressed)
                        mouseInputFlags |= Win32NativeMethods.MOUSEEVENTF_XDOWN;
                    if (state == MouseButtonState.Released)
                        mouseInputFlags |= Win32NativeMethods.MOUSEEVENTF_XUP;
                    break;
            }
            SendMouseInput(x, y, 0, mouseInputFlags);
        }

        public MouseButtonState GetMouseButtonState(MouseButton button)
        {
            throw new NotImplementedException();
        }

        #endregion

        internal static bool IsExtendedKey(Key key)
        {
            // From the SDK:
            // The extended-key flag indicates whether the keystroke message originated from one of
            // the additional keys on the enhanced keyboard. The extended keys consist of the ALT and
            // CTRL keys on the right-hand side of the keyboard; the INS, DEL, HOME, END, PAGE UP,
            // PAGE DOWN, and arrow keys in the clusters to the left of the numeric keypad; the NUM LOCK
            // key; the BREAK (CTRL+PAUSE) key; the PRINT SCRN key; and the divide (/) and ENTER keys in
            // the numeric keypad. The extended-key flag is set if the key is an extended key. 
            //
            // - docs appear to be incorrect. Use of Spy++ indicates that break is not an extended key.
            // Also, menu key and windows keys also appear to be extended.
            return key == Key.RightAlt
                || key == Key.RightCtrl
                || key == Key.NumLock
                || key == Key.Insert
                || key == Key.Delete
                || key == Key.Home
                || key == Key.End
                || key == Key.Prior
                || key == Key.Next
                || key == Key.Up
                || key == Key.Down
                || key == Key.Left
                || key == Key.Right
                || key == Key.Apps
                || key == Key.RWin
                || key == Key.LWin;

            // Note that there are no distinct values for the following keys:
            // numpad divide
            // numpad enter
        }

        /// <summary>
        /// Inject pointer input into the system
        /// </summary>
        /// <param name="x">x coordinate of pointer, if Move flag specified</param>
        /// <param name="y">y coordinate of pointer, if Move flag specified</param>
        /// <param name="data">wheel movement, or mouse X button, depending on flags</param>
        /// <param name="flags">flags to indicate which type of input occurred - move, button press/release, wheel move, etc.</param>
        /// <remarks>x, y are in pixels. If Absolute flag used, are relative to desktop origin.</remarks>
        /// 
        /// <outside_see conditional="false">
        /// This API does not work inside the secure execution environment.
        /// <exception cref="System.Security.Permissions.SecurityPermission"/>
        /// </outside_see>
        private void SendMouseInput(double x, double y, int data, int flags)
        {
            if (NativeHelper.IsBitSet(flags, Win32NativeMethods.MOUSEEVENTF_ABSOLUTE))
            {
                var rect = SystemInfo.VirtualScreen;
                int vscreenWidth = (int)rect.Width;
                int vscreenHeight = (int)rect.Height;
                int vscreenLeft = (int)rect.Left;
                int vscreenTop = (int)rect.Top;

                // Absolute input requires that input is in 'normalized' coords - with the entire
                // desktop being (0,0)...(65535,65536). Need to convert input x,y coords to this
                // first.
                //
                // In this normalized world, any pixel on the screen corresponds to a block of values
                // of normalized coords - eg. on a 1024x768 screen,
                // y pixel 0 corresponds to range 0 to 85.333,
                // y pixel 1 corresponds to range 85.333 to 170.666,
                // y pixel 2 correpsonds to range 170.666 to 256 - and so on.
                // Doing basic scaling math - (x-top)*65536/Width - gets us the start of the range.
                // However, because int math is used, this can end up being rounded into the wrong
                // pixel. For example, if we wanted pixel 1, we'd get 85.333, but that comes out as
                // 85 as an int, which falls into pixel 0's range - and that's where the pointer goes.
                // To avoid this, we add on half-a-"screen pixel"'s worth of normalized coords - to
                // push us into the middle of any given pixel's range - that's the 65536/(Width*2)
                // part of the formula. So now pixel 1 maps to 85+42 = 127 - which is comfortably
                // in the middle of that pixel's block.
                // The key ting here is that unlike points in coordinate geometry, pixels take up
                // space, so are often better treated like rectangles - and if you want to target
                // a particular pixel, target its rectangle's midpoint, not its edge.
                x = ( ( x - vscreenLeft ) * 65536 ) / vscreenWidth + 65536 / ( vscreenWidth * 2 );
                y = ( ( y - vscreenTop ) * 65536 ) / vscreenHeight + 65536 / ( vscreenHeight * 2 );

                flags = NativeHelper.SetBit(flags, Win32NativeMethods.MOUSEEVENTF_VIRTUALDESK);
            }

            Win32NativeMethods.INPUT mi = new Win32NativeMethods.INPUT();
            mi.type = Win32NativeMethods.INPUT_MOUSE;
            mi.union.mouseInput.dx = (int) x;
            mi.union.mouseInput.dy = (int)y;
            mi.union.mouseInput.mouseData = data;
            mi.union.mouseInput.dwFlags = flags;
            mi.union.mouseInput.time = 0;
            mi.union.mouseInput.dwExtraInfo = IntPtr.Zero;
            //Console.WriteLine("Sending");
            if (Win32NativeMethods.SendInput(1, ref mi, Marshal.SizeOf(mi)) == 0)
                throw new Win32Exception(Marshal.GetLastWin32Error());
        }

        private static void SendUnicodeKeyboardInput(char key, bool press)
        {
            Win32NativeMethods.INPUT ki = new Win32NativeMethods.INPUT();

            ki.type = Win32NativeMethods.INPUT_KEYBOARD;
            ki.union.keyboardInput.wVk = (short)0;
            ki.union.keyboardInput.wScan = (short)key;
            ki.union.keyboardInput.dwFlags = Win32NativeMethods.KEYEVENTF_UNICODE | (press ? 0 : Win32NativeMethods.KEYEVENTF_KEYUP);
            ki.union.keyboardInput.time = 0;
            ki.union.keyboardInput.dwExtraInfo = IntPtr.Zero;
            if (Win32NativeMethods.SendInput(1, ref ki, Marshal.SizeOf(ki)) == 0)
                throw new Win32Exception(Marshal.GetLastWin32Error());
        }
    }
}
