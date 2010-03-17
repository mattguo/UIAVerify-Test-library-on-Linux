using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace BasicAutomation
{
    public interface ISystemDriver
    {
        //todo, ShellExecute on Windows, execl on Linux
        bool Execute(string appPath, string arguments);

        void InputKey(Key key, bool press);
        //todo, return KeyStates instead of bool? KeyStates has an additonal state of "toggled"
        //Return whether the key is down
        KeyStates GetKeyState(Key key);
        void EnterText(string text);

        //todo, shall we support click multiple button simultaniously?
        void SendMouseMove(double x, double y, bool isAbsCoord);
        Point MousePostion { get; set; }
        void SendMouseWheel(MouseWheel wheel, int delta);
        void ChangeMouseState(double x, double y, MouseButton button, MouseButtonState state);
        MouseButtonState GetMouseButtonState(MouseButton button);
    }

    //todo, MouseButton and MouseButtonStaet are in PresentationCore, System.Windows.Input
    //public enum MouseButton
    //{
    //    Left,
    //    Middle,
    //    Right,
    //    XButton1,
    //    XButton2
    //}

    //public enum MouseButtonState
    //{
    //    Released,
    //    Pressed
    //}

    public enum MouseWheel
    {
        Default = 0,
        Vertical = 0,
        Horizontal = 1
    }
}
