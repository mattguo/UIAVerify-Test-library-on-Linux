using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace BasicAutomation.Win32
{
    internal class Win32NativeMethods
    {
        internal static readonly IntPtr INVALID_HANDLE_VALUE = new IntPtr(-1);
        //
        // Window style information
        //
        internal const int GWL_STYLE = -16;
        internal const int GWL_EXSTYLE = -20;

        internal const int WS_VSCROLL = 0x00200000;
        internal const int WS_HSCROLL = 0x00100000;
        internal const int ES_MULTILINE = 0x0004;
        internal const int ES_READONLY = 0x0800;
        internal const int ES_NUMBER = 0x2000;
        internal const int ES_AUTOVSCROLL = 0x0040;
        internal const int ES_AUTOHSCROLL = 0x0080;
        internal const int WS_EX_LAYOUTRTL = 0x00400000;
        internal const int WS_EX_TOOLWINDOW = 0x00000080;

        //
        // ShowWindow parameters
        //
        internal const int SW_HIDE = 0;
        internal const int SW_NORMAL = 1;
        internal const int SW_SHOWMINIMIZED = 2;
        internal const int SW_MAXIMIZE = 3;
        internal const int SW_SHOW = 5;
        internal const int SW_MINIMIZE = 6;

        //
        // SetWindowPos parameters
        //
        internal const int HWND_TOP = 0;
        internal const int HWND_BOTTOM = 1;
        internal const int HWND_TOPMOST = -1;
        internal const int HWND_NOTOPMOST = -2;

        //
        // Window Messages
        //
        internal const int WM_USER = 0x0400;
        internal const int WM_SETTEXT = 0x000C;
        internal const int EM_GETLINECOUNT = 0xBA;
        internal const int EM_GETLIMITTEXT = 0xD5;
        internal const int UDM_GETBUDDY = (WM_USER + 106);

        //
        // SetWindowPos, uFlags parameter
        //
        internal const uint SWP_NOSIZE = 0x0001;
        internal const uint SWP_NOMOVE = 0x0002;
        internal const uint SWP_NOZORDER = 0x0004;
        internal const uint SWP_NOREDRAW = 0x0008;
        internal const uint SWP_NOACTIVATE = 0x0010;
        internal const uint SWP_FRAMECHANGED = 0x0020; /* The frame changed: send WM_NCCALCSIZE */
        internal const uint SWP_SHOWWINDOW = 0x0040;
        internal const uint SWP_HIDEWINDOW = 0x0080;
        internal const uint SWP_NOCOPYBITS = 0x0100;
        internal const uint SWP_NOOWNERZORDER = 0x0200; /* Don't do owner Z ordering */
        internal const uint SWP_NOSENDCHANGING = 0x0400;/* Don't send WM_WINDOWPOSCHANGING */

        [StructLayout(LayoutKind.Sequential)]
        internal struct POINT
        {
            public int X;
            public int Y;

            public POINT(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct SIZE
        {
            public int cx;
            public int cy;

            public SIZE(int cx, int cy)
            {
                this.cx = cx;
                this.cy = cy;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;

            public RECT(int left, int top, int right, int bottom)
            {
                this.Left = left;
                this.Top = top;
                this.Right = right;
                this.Bottom = bottom;
            }

            public bool IsEmpty
            {
                get
                {
                    return Left >= Right || Top >= Bottom;
                }
            }

            public int Width
            {
                get { return Right - Left; }
            }

            public int Height
            {
                get { return Bottom - Top; }
            }

            public RECT Empty
            {
                get
                {
                    return new RECT(0, 0, 0, 0);
                }
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct COLORREF
        {
            public byte R;
            public byte G;
            public byte B;

            public override string ToString()
            {
                return string.Format("R={0},G={1},B={2}", R, G, B);
            }
        }

        [DllImport("user32.dll")]
        internal static extern int SetWindowLong(IntPtr hWnd, int nIndex, int value);

        internal static void SetWindowStyle(IntPtr hWnd, int style)
        {
            int styles = GetWindowLong(hWnd, GWL_STYLE);
            SetWindowLong(hWnd, GWL_STYLE, NativeHelper.SetBit(styles, style));
        }

        internal static void ResetWindowStyle(IntPtr hWnd, int style)
        {
            int styles = GetWindowLong(hWnd, GWL_STYLE);
            SetWindowLong(hWnd, GWL_STYLE, NativeHelper.ResetBit(styles, style));
        }

        internal static void SetWindowStyleEx(IntPtr hWnd, int style)
        {
            int exstyles = GetWindowLong(hWnd, GWL_EXSTYLE);
            SetWindowLong(hWnd, GWL_STYLE, NativeHelper.SetBit(exstyles, style));
        }

        internal static void ResetWindowStyleEx(IntPtr hWnd, int style)
        {
            int exstyles = GetWindowLong(hWnd, GWL_EXSTYLE);
            SetWindowLong(hWnd, GWL_STYLE, NativeHelper.ResetBit(exstyles, style));
        }

        [DllImport("user32.dll")]
        internal static extern bool GetWindowRect(IntPtr hwnd, out Win32NativeMethods.RECT rc);

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        internal static extern IntPtr FindWindow(string className, string windowName);

        [DllImport("user32.dll")]
        internal static extern bool IsWindowVisible(IntPtr hWnd);

        [DllImport("user32.dll")]
        internal static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        internal static extern bool IsWindowEnabled(IntPtr hWnd);

        [DllImport("user32.dll")]
        internal static extern bool EnableWindow(IntPtr hWnd, bool enabled);

        [DllImport("user32.dll")]
        internal static extern IntPtr GetDesktopWindow();

        [DllImport("user32.dll")]
        internal static extern IntPtr SendMessage(IntPtr hWnd, int nMsg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern IntPtr SendMessageTimeout(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, int flags, int uTimeout, out IntPtr pResult);

        [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern IntPtr SendMessageTimeout(IntPtr hwnd, int uMsg, IntPtr wParam, StringBuilder lParam, int flags, int uTimeout, out IntPtr result);

        [DllImport("user32.dll")]
        internal static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        [DllImport("shell32.dll", CharSet = CharSet.Unicode)]
        internal static extern IntPtr ShellExecute(IntPtr hwnd, string lpOperation, string lpFile, string lpParameters, string lpDirectory, int nShowCmd);

        [DllImport("user32.dll")]
        internal static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        internal static extern IntPtr GetDC(IntPtr hWnd);
        
        //1: indicates that the device context is released.
        //Zero: indicates that the device context is not released.
        [DllImport("user32.dll")]
        internal static extern int ReleaseDC(IntPtr hWnd, IntPtr hdc);

        [DllImport("gdi32.dll")]
        internal static extern COLORREF GetBkColor(IntPtr hdc);

        [DllImport("gdi32.dll")]
        internal static extern COLORREF GetTextColor(IntPtr hdc);

        [DllImport("user32.dll")]
        internal static extern IntPtr WindowFromPoint(POINT point);

        internal static bool CheckWindowStyle(IntPtr hWnd, int style)
        {
            int styles = GetWindowLong(hWnd, GWL_STYLE);
            return NativeHelper.IsBitSet(styles, style);
        }

        internal static bool CheckWindowStyleEx(IntPtr hWnd, int style)
        {
            int exstyles = GetWindowLong(hWnd, GWL_EXSTYLE);
            return NativeHelper.IsBitSet(exstyles, style);
        }

        //
        // The INPUT struct
        //
        internal const int INPUT_MOUSE = 0;
        internal const int INPUT_KEYBOARD = 1;

        [StructLayout(LayoutKind.Sequential)]
        internal struct INPUT
        {
            public int type;
            public INPUTUNION union;
        };

        [StructLayout(LayoutKind.Explicit)]
        internal struct INPUTUNION
        {
            [FieldOffset(0)]
            public MOUSEINPUT mouseInput;
            [FieldOffset(0)]
            public KEYBDINPUT keyboardInput;
        };

        [StructLayout(LayoutKind.Sequential)]
        internal struct MOUSEINPUT
        {
            public int dx;
            public int dy;
            public int mouseData;
            public int dwFlags;
            public int time;
            public IntPtr dwExtraInfo;
        };

        internal const int KEYEVENTF_EXTENDEDKEY = 0x0001;
        internal const int KEYEVENTF_KEYUP = 0x0002;
        internal const int KEYEVENTF_UNICODE = 0x0004;
        internal const int KEYEVENTF_SCANCODE = 0x0008;

        internal const int MOUSEEVENTF_MOVE = 0x0001;
        internal const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        internal const int MOUSEEVENTF_LEFTUP = 0x0004;
        internal const int MOUSEEVENTF_RIGHTDOWN = 0x0008;
        internal const int MOUSEEVENTF_RIGHTUP = 0x0010;
        internal const int MOUSEEVENTF_MIDDLEDOWN = 0x0020;
        internal const int MOUSEEVENTF_MIDDLEUP = 0x0040;
        internal const int MOUSEEVENTF_XDOWN = 0x0080;
        internal const int MOUSEEVENTF_XUP = 0x0100;
        internal const int MOUSEEVENTF_WHEEL = 0x0800;
        internal const int MOUSEEVENTF_ABSOLUTE = 0x8000;
        internal const int MOUSEEVENTF_VIRTUALDESK = 0x4000;

        [StructLayout(LayoutKind.Sequential)]
        internal struct KEYBDINPUT
        {
            public short wVk;
            public short wScan;
            public int dwFlags;
            public int time;
            public IntPtr dwExtraInfo;
        };

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern int SendInput(int nInputs, ref INPUT mi, int cbSize);

        [DllImport("user32.dll")]
        internal static extern int MapVirtualKey(int nVirtKey, int nMapType);

        [DllImport("user32.dll")]
        internal static extern int GetAsyncKeyState(int nVirtKey);
    }
}
