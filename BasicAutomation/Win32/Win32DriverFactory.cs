using System;
using System.Windows;

namespace BasicAutomation.Win32
{
    internal class Win32DriverFactory : IDriverFactory
    {
        #region Singleton
        private static readonly Win32DriverFactory instance = new Win32DriverFactory();

        //Explicit static constructor to tell C# compiler not to mark type as beforefieldinit
        static Win32DriverFactory()
        {
        }

        private Win32DriverFactory()
        {
        }

        public static Win32DriverFactory Instance
        {
            get
            {
                return instance;
            }
        }
        #endregion

        #region IDriverFactory Members

        public ISystemDriver System
        {
            get { return Win32SystemDriver.Instance; }
        }

        public IKeybinder Keybinder
        {
            get { return Win32KeyBinder.Instance; }
        }

        public IWindowDriver RootWindow
        {
            get { return Win32WindowDriver.RootWindow; }
        }

        public IWindowDriver GetWindow(IntPtr handle)
        {
            if (handle == IntPtr.Zero)
                return null;
            return new Win32WindowDriver(handle);
        }

        public IWindowDriver FindWindow(string title)
        {
            return Win32WindowDriver.FindWindow(title);
        }

        public IWindowDriver WindowFromPoint(Point pt)
        {
            return Win32WindowDriver.WindowFromPoint(pt);
        }

        public IWindowDriver WindowFromMousePoint()
        {
            return Win32WindowDriver.WindowFromPoint(System.MousePostion);
        }

        #endregion
    }
}
