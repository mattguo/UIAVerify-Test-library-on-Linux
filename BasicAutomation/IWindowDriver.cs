using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace BasicAutomation
{
    public interface IWindowDriver
    {
        IntPtr Handle { get; }

        //todo Linux: GtkWindow.Decorated = false;
        bool NoBorder { set; }
        bool Topmost { set; }
        bool Visible { get; set; }
        bool Enabled { get; set; }
        //todo on X: XGetWindowAttriibutes/XSetWindowAttributes;
        bool IsRightToLeftLayout { get; }

        //todo Get/Set window bound on X: XGetGeometry(), XMoveWindow();
        Rect Bound { get; set; }
        Point Position { get; set; }
        Size Size { get; set; }

        Color BackgroundColor { get; }
        Color TextColor { get; }

        IWindowDriver Buddy { get; }
        IEditWindowDriver AsEditWindow();
    }
}
