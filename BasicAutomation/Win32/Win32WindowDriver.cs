using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;
//using InternalHelper;

namespace BasicAutomation.Win32
{
    public class Win32WindowDriver : IWindowDriver, IEditWindowDriver
    {
        public Win32WindowDriver(IntPtr handle)
        {
            this.Handle = handle;
        }

        public static Win32WindowDriver RootWindow
        {
            get
            {
                //todo, Shall we cache/lazy_create the root window driver
                IntPtr hRoot = Win32NativeMethods.GetDesktopWindow();
                Win32WindowDriver rootWindowDriver = new Win32WindowDriver(hRoot);
                return rootWindowDriver;
            }
        }

        public static Win32WindowDriver FindWindow(string title)
        {
            IntPtr hWnd = Win32NativeMethods.FindWindow(null, title);
            Win32WindowDriver windowDriver = new Win32WindowDriver(hWnd);
            return windowDriver;
        }

        public static Win32WindowDriver WindowFromPoint(System.Windows.Point pt)
        {
            IntPtr hWnd = Win32NativeMethods.WindowFromPoint(new Win32NativeMethods.POINT((int)pt.X, (int)pt.Y));
            Win32WindowDriver windowDriver = new Win32WindowDriver(hWnd);
            return windowDriver;
        }

        #region IWindowDriver Members

        public IntPtr Handle { get; protected set; }

        public bool NoBorder
        {
            set
            {
                if (value)
                    Win32NativeMethods.SetWindowStyleEx(Handle, Win32NativeMethods.WS_EX_TOOLWINDOW);
                else
                    Win32NativeMethods.ResetWindowStyleEx(Handle, Win32NativeMethods.WS_EX_TOOLWINDOW);
            }
        }

        public bool Topmost
        {
            set
            {
                IntPtr zorder = new IntPtr(value ? Win32NativeMethods.HWND_TOPMOST : Win32NativeMethods.HWND_NOTOPMOST);
                Win32NativeMethods.SetWindowPos(Handle, zorder, 0, 0, 0, 0,
                    Win32NativeMethods.SWP_NOSIZE | Win32NativeMethods.SWP_NOMOVE | Win32NativeMethods.SWP_NOACTIVATE);
            }
        }

        public bool Visible
        {
            get
            {
                return Win32NativeMethods.IsWindowVisible(Handle);
            }
            set
            {
                if (value)
                    Win32NativeMethods.ShowWindow(Handle, Win32NativeMethods.SW_SHOW);
                else
                    Win32NativeMethods.ShowWindow(Handle, Win32NativeMethods.SW_HIDE);
            }
        }

        public bool Enabled
        {
            get
            {
                return Win32NativeMethods.IsWindowEnabled(Handle);
            }
            set
            {
                Win32NativeMethods.EnableWindow(Handle, value);
            }
        }

        public bool IsRightToLeftLayout
        {
            get { return Win32NativeMethods.CheckWindowStyle(Handle, Win32NativeMethods.WS_EX_LAYOUTRTL); }
        }

        public System.Windows.Rect Bound
        {
            get
            {
                Win32NativeMethods.RECT rect;
                Win32NativeMethods.GetWindowRect(Handle, out rect);
                return new System.Windows.Rect(rect.Left, rect.Top, rect.Width, rect.Height);
            }
            set
            {
                Win32NativeMethods.SetWindowPos(Handle, IntPtr.Zero, (int)value.Left, (int)value.Top, (int)value.Width, (int)value.Height,
                    Win32NativeMethods.SWP_NOZORDER | Win32NativeMethods.SWP_NOACTIVATE);
            }
        }

        public System.Windows.Point Position
        {
            get
            {
                return Bound.TopLeft;
            }
            set
            {
                Win32NativeMethods.SetWindowPos(Handle, IntPtr.Zero, (int)value.X, (int)value.Y, 0, 0,
                    Win32NativeMethods.SWP_NOZORDER | Win32NativeMethods.SWP_NOSIZE | Win32NativeMethods.SWP_NOACTIVATE);
            }
        }

        public System.Windows.Size Size
        {
            get
            {
                return Bound.Size;
            }
            set
            {
                Win32NativeMethods.SetWindowPos(Handle, IntPtr.Zero, 0, 0, (int)value.Width, (int)value.Height,
                    Win32NativeMethods.SWP_NOZORDER | Win32NativeMethods.SWP_NOSIZE | Win32NativeMethods.SWP_NOACTIVATE);
            }
        }

        public Color BackgroundColor
        {
            get
            {
                IntPtr hdc = Win32NativeMethods.GetDC(Handle);
                var color = Win32NativeMethods.GetBkColor(hdc);
                Win32NativeMethods.ReleaseDC(Handle, hdc);
                return Color.FromRgb(color.R, color.G, color.B);
            }
        }

        public Color TextColor
        {
            get
            {
                IntPtr hdc = Win32NativeMethods.GetDC(Handle);
                var color = Win32NativeMethods.GetTextColor(hdc);
                Win32NativeMethods.ReleaseDC(Handle, hdc);
                return Color.FromRgb(color.R, color.G, color.B);
            }
        }

        public IWindowDriver Buddy
        {
            get
            {
                IntPtr hwndBuddy = Win32NativeMethods.SendMessage(Handle, Win32NativeMethods.UDM_GETBUDDY, IntPtr.Zero, IntPtr.Zero);
                if (hwndBuddy != IntPtr.Zero)
                    return new Win32WindowDriver(hwndBuddy);
                else
                    return null;
            }
        }

        public IEditWindowDriver AsEditWindow()
        {
			//todo cuurently I found no way to detect whether a window is an edit control.
            return this;
        }

        #endregion

        #region IEditWindowDriver Members

        public int LineCount
        {
            get
            {
                return Win32NativeMethods.SendMessage(Handle, Win32NativeMethods.EM_GETLINECOUNT, IntPtr.Zero, IntPtr.Zero).ToInt32();
            }
        }

        public int TextLimit
        {
            get
            {
                IntPtr result;
                IntPtr resultSendMessage = Win32NativeMethods.SendMessageTimeout(Handle, Win32NativeMethods.EM_GETLIMITTEXT, IntPtr.Zero, IntPtr.Zero, 1, 10000, out result);
                if (resultSendMessage == IntPtr.Zero)
                {
                    throw new InvalidOperationException("SendMessageTimeout() timed out");
                }
                return result.ToInt32();
            }
        }

        public bool IsMultiLine
        {
            get
            {
                return Win32NativeMethods.CheckWindowStyle(Handle, Win32NativeMethods.ES_MULTILINE);
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return Win32NativeMethods.CheckWindowStyle(Handle, Win32NativeMethods.ES_READONLY);
            }
        }

        public bool IsRichEdit
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string Text
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                IntPtr result;
                IntPtr resultSendMessage = Win32NativeMethods.SendMessageTimeout(Handle, Win32NativeMethods.WM_SETTEXT, IntPtr.Zero, new StringBuilder(value), 1, 10000, out result);
                if (resultSendMessage == IntPtr.Zero)
                {
                    throw new InvalidOperationException("SendMessageTimeout() timed out");
                }
                if (result.ToInt32() != 1)
                {
                    throw new InvalidOperationException("Unable to set the text of the control, text = " + value);
                }
            }
        }

        #endregion
    }
}
