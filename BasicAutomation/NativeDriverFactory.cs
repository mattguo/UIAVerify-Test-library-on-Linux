using System;
using System.Windows;

namespace BasicAutomation
{
    public class NativeDriverFactory
    {
        private static IDriverFactory factory = null;

        static NativeDriverFactory()
        {
            switch (SystemInfo.CurrentOS)
            {
                case OperatingSystemType.Windows:
                    factory = Win32.Win32DriverFactory.Instance;
                    break;
                case OperatingSystemType.Unix:
                    throw new NotImplementedException();
                    //break;
                default:
                    throw new NotImplementedException();
            }
        }

        public static ISystemDriver System
        {
            get { return factory.System; }
        }

        public static IKeybinder Keybinder
        {
            get { return factory.Keybinder; }
        }

        public static IWindowDriver GetWindow (IntPtr handle)
        {
            return factory.GetWindow(handle);
        }

        public static IWindowDriver FindWindow(string title)
        {
            return factory.FindWindow(title);
        }

        public static IWindowDriver RootWindow
        {
            get { return factory.RootWindow; }
        }

        public IWindowDriver WindowFromPoint(Point pt)
        {
            return factory.WindowFromPoint(pt);
        }

        public IWindowDriver WindowFromMousePoint()
        {
            return factory.WindowFromMousePoint();
        }
    }
}
