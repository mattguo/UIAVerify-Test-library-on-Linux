////---------------------------------------------------------------------------
////
//// <copyright file="Input.cs" company="Microsoft">
//// (c) Copyright Microsoft Corporation.
//// This source is subject to the Microsoft Permissive License.
//// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
//// All other rights reserved.
//// </copyright>
//// 
////
//// Description: Provides mouse and keyboard input functionality
////
////---------------------------------------------------------------------------

//using System.Globalization;
//using System.Text;
//using System.Threading;
//using System.Windows;
//using System.Windows.Automation;
//using System.Windows.Input;
//using System.Security.Permissions;
//using System.ComponentModel;
//using System.Runtime.InteropServices;
//using System.Collections;

using System;
using BasicAutomation;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Input;
using System.Threading;
using System.Collections.Generic;
using InternalHelper;

namespace ATGTestInput
{
    public class Input
    {
        //in millisecond
        public const int KEYBOARD_DELAY = 10;

        public static void MoveTo(AutomationElement el)
        {
            if (el == null)
            {
                throw new ArgumentNullException("el");
            }
            NativeDriverFactory.System.MousePostion = el.GetClickablePoint();
        }

        public static void MoveToAndClick(AutomationElement el)
        {
            if (el == null)
            {
                throw new ArgumentNullException("el");
            }
            Point p = el.GetClickablePoint();
            MoveToAndClick(p.X, p.Y);
        }

        //todo andd some delay between move, down and up?
        public static void MoveToAndClick(double x, double y)
        {
            NativeDriverFactory.System.MousePostion = new Point(x, y);
            MouseButton button =  SystemInfo.MouseButtonsSwapped ? MouseButton.Right : MouseButton.Left;
            MouseClick(x, y, button);
        }

        public static void MouseClick(double x, double y, MouseButton button)
        {
            NativeDriverFactory.System.ChangeMouseState(x, y, button, MouseButtonState.Pressed);
            //todo, shall we need to wait some time here?
            NativeDriverFactory.System.ChangeMouseState(x, y, button, MouseButtonState.Released);
        }

        public static void MouseDoubleClick(double x, double y, MouseButton button)
        {
            MouseClick(x, y, button);
            MouseClick(x, y, button);
        }

        public static void SendKeyboardInput(string keyCombination)
        {
            SendKeyboardInput(keyCombination, KEYBOARD_DELAY);
        }

        public static void SendKeyboardInput(string keyCombination, int millisecondDelay)
        {
            List<Key> keysSequence = new List<Key>();
            string[] keys = keyCombination.Split(new char[] { '+' }, StringSplitOptions.RemoveEmptyEntries);

            try
            {
                foreach (string key in keys)
                {
                    switch (key.Trim().ToLower())
                    {
                        case "space":
                            keysSequence.Add(Key.Space);
                            break;
                        case "~":
                            keysSequence.Add(Key.OemTilde);
                            break;
                        case "alt":
                            keysSequence.Add(Key.LeftAlt);
                            break;
                        case "shift":
                            keysSequence.Add(Key.LeftShift);
                            break;
                        case "ctrl":
                            keysSequence.Add(Key.LeftCtrl);
                            break;
                        case "0":
                            keysSequence.Add(Key.D0);
                            break;
                        case "1":
                            keysSequence.Add(Key.D1);
                            break;
                        case "2":
                            keysSequence.Add(Key.D2);
                            break;
                        case "3":
                            keysSequence.Add(Key.D3);
                            break;
                        case "4":
                            keysSequence.Add(Key.D4);
                            break;
                        case "5":
                            keysSequence.Add(Key.D5);
                            break;
                        case "6":
                            keysSequence.Add(Key.D6);
                            break;
                        case "7":
                            keysSequence.Add(Key.D7);
                            break;
                        case "8":
                            keysSequence.Add(Key.D8);
                            break;
                        case "9":
                            keysSequence.Add(Key.D9);
                            break;
                        case "!":
                            keysSequence.Add(Key.LeftShift);
                            keysSequence.Add(Key.D1);
                            break;
                        case "@":
                            keysSequence.Add(Key.LeftShift);
                            keysSequence.Add(Key.D2);
                            break;
                        case "#":
                            keysSequence.Add(Key.LeftShift);
                            keysSequence.Add(Key.D3);
                            break;
                        case "$":
                            keysSequence.Add(Key.LeftShift);
                            keysSequence.Add(Key.D4);
                            break;
                        case "%":
                            keysSequence.Add(Key.LeftShift);
                            keysSequence.Add(Key.D5);
                            break;
                        case "^":
                            keysSequence.Add(Key.LeftShift);
                            keysSequence.Add(Key.D6);
                            break;
                        case "&":
                            keysSequence.Add(Key.LeftShift);
                            keysSequence.Add(Key.D7);
                            break;
                        case "*":
                            keysSequence.Add(Key.LeftShift);
                            keysSequence.Add(Key.D8);
                            break;
                        default:
                            keysSequence.Add((Key)Enum.Parse(typeof(Key), key.ToUpper()));
                            break;

                    }
                }

                if (keysSequence.Count > 0)
                {
                    SendKeyboardInput(keysSequence.ToArray(), millisecondDelay);
                }
            }
            catch (Exception error)
            {
                System.Diagnostics.Trace.WriteLine(error);
            }
        }

        public static void SendKeyboardInput(Key key)
        {
            SendKeyboardInput(key, KEYBOARD_DELAY);
        }

        public static void SendKeyboardInput(Key key, int millisecondDelay)
        {
            SendKeyboardInput(new Key[] { key }, millisecondDelay);
        }

        public static void SendKeyboardInput(Key[] key, int millisecondDelay)
        {
            for (int i = 0; i < key.Length; i++)
            {
                SendKeyboardInput(key[i], true);
                if (millisecondDelay > 0)
                    Thread.Sleep(millisecondDelay);
            }
            for (int i = key.Length; i > 0; i--)
            {
                SendKeyboardInput(key[i - 1], false);
                if (millisecondDelay > 0)
                    Thread.Sleep(millisecondDelay);
            }
        }

        public static void SendKeyboardInput(Key key, bool press)
        {
            NativeDriverFactory.System.InputKey(key, press);
        }

        public static KeyStates GetKeyState(Key key)
        {
            return NativeDriverFactory.System.GetKeyState(key) ;
        }

        /// <summary>
        /// Injects a string of Unicode characters using simulated keyboard input
        /// It should be noted that this overload just sends the whole string
        /// with no pauses, depending on the recieving applications input processing
        /// it may not be able to keep up with the speed, resulting in corruption or
        /// loss of the input data.
        /// </summary>
        /// <param name="data">The unicode string to be sent</param>
        public static void SendUnicodeString(string data)
        {
            NativeDriverFactory.System.EnterText(data);
        }

        /// <summary>
        /// This is a hyrbird of the ValuePattern.SetValue code extracted from the UI Automation sources
        /// NOTE: Requires the ability to set focus to the current automation element
        /// </summary>
        public static void SetValue(AutomationElement element, string value)
        {
            IntPtr _hwnd = IntPtr.Zero;

            // Validate arguments / initial setup
            if (value == null)
                throw new ArgumentNullException("string parameter 'value' must not be null");

            if (element == null)
                throw new ArgumentNullException("AutomationElement parameter 'element' must not be null");

            _hwnd = Helpers.CastNativeWindowHandleToIntPtr(element);
            IWindowDriver wnd = NativeDriverFactory.GetWindow(_hwnd);

            // Sanity check #1: Is window enabled???
            if (!wnd.Enabled)
            {
                throw new ElementNotEnabledException();
            }

            // Sanity check #2: Are there styles that prohibit us sending text to this control?
            IEditWindowDriver editWnd = wnd.AsEditWindow();
            if (editWnd.IsReadOnly)
                throw new InvalidOperationException("Cannot set text to a read-only field");

            // Sanity check #3: Is the size of the text we want to set greater than what the control accepts?
            int textLimit = editWnd.TextLimit;

            // A result of -1 means that no limit is set.
            if (textLimit >= 0 && textLimit < value.Length)
            {
                throw new InvalidOperationException("Length of text (" + value.Length + ") is greater than upper limit of control (" + textLimit.ToString() + ")");
            }
            editWnd.Text = value;
        }
    }
}