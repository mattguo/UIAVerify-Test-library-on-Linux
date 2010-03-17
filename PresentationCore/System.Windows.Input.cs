using System;

namespace System.Windows.Input
{
    [Flags]
    public enum KeyStates
    {
        None = 0,
        Down = 1,
        Toggled = 2
    }

    public enum MouseButton
    {
        Left,
        Middle,
        Right,

        XButton1,
        XButton2
    }

    public enum MouseButtonState
    {
        Released,
        Pressed
    }

}
