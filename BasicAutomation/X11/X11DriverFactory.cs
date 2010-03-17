using System;
using System.Windows;

namespace BasicAutomation.X11
{
    internal class X11DriverFactory : IDriverFactory
    {
        #region Singleton
        private static readonly X11DriverFactory instance = new X11DriverFactory();

        //Explicit static constructor to tell C# compiler not to mark type as beforefieldinit
        static X11DriverFactory()
        {
        }

        private X11DriverFactory()
        {
        }

        public static X11DriverFactory Instance
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
            get { return X11SystemDriver.Instance; }
        }

        public IKeybinder Keybinder
        {
            get { throw new NotImplementedException(); }
        }

        public IWindowDriver RootWindow
        {
            get { throw new NotImplementedException(); }
        }

        public IWindowDriver GetWindow(IntPtr handle)
        {
            if (handle == IntPtr.Zero)
                return null;
            return new X11WindowDriver(handle);
        }

        public IWindowDriver FindWindow(string title)
        {
            throw new NotImplementedException();
        }

        public IWindowDriver WindowFromPoint(Point pt)
        {
           throw new NotImplementedException();
        }

        public IWindowDriver WindowFromMousePoint()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
