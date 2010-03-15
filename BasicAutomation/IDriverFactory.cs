using System;
using System.Windows;

namespace BasicAutomation
{
    public interface IDriverFactory
    {
        ISystemDriver System { get; }
        IKeybinder Keybinder { get; }
        IWindowDriver RootWindow { get; }
        IWindowDriver GetWindow(IntPtr handle);
        IWindowDriver FindWindow(string title);
        IWindowDriver WindowFromPoint(Point pt);
        IWindowDriver WindowFromMousePoint();
    }
}
