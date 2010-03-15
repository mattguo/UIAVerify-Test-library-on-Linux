using System;
using System.Collections.Generic;
using System.Text;
using Xsharp;

namespace BasicAutomation.X11
{
    class X11Display : IDisposable
    {
        IntPtr handle = IntPtr.Zero;
        private bool disposed = false;
        private static X11Display defaultDisplay = null;

        public X11Display() : this(string.Empty)
        {

        }

        public X11Display(string displayName)
        {
            handle = Xlib.XOpenDisplay(displayName);
        }

        public static X11Display Default
        {
            get
            {
                if (defaultDisplay == null)
                {
                    defaultDisplay = new X11Display();
                }
                return defaultDisplay;
            }
        }

        public IntPtr Handle
        {
            get { return handle; }
        }

        #region IDisposable Members

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    // Dispose managed resources.
                }

                Xlib.XCloseDisplay(handle);
                handle = IntPtr.Zero;
                disposed = true;

            }
        }

        ~X11Display()
        {
            Dispose(false);
        }
    }
}
