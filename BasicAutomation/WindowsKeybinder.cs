/* 
 * Copy from Tomboy/Keybinder.cs
 * (git clone git://git.gnome.org/tomboy)
 */

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using UIATestLibrary.Common.NativeDriver;
using ManagedWinapi;

namespace Tomboy
{
    public class WindowsKeybinder : IKeybinder
    {
        #region Private Member

        private Dictionary<string, Hotkey> bindings;

        #endregion

        #region Singleton
        private static readonly WindowsKeybinder instance = new WindowsKeybinder();

        //Explicit static constructor to tell C# compiler not to mark type as beforefieldinit
        static WindowsKeybinder()
        {
        }

        private WindowsKeybinder()
        {
            bindings = new Dictionary<string, Hotkey>();
        }

        public static WindowsKeybinder Instance
        {
            get
            {
                return instance;
            }
        }
        #endregion

        #region IKeybinder Members

        public void Bind(string keystring, EventHandler handler)
        {
            Hotkey hotkey = ParseHotkey(keystring);
            if (hotkey == null)
                return;

            hotkey.HotkeyPressed += handler;
            hotkey.Enabled = true;

            bindings[keystring] = hotkey;
        }

        public void Unbind(string keystring)
        {
            Hotkey hotkey;
            if (bindings.TryGetValue(keystring, out hotkey))
            {
                hotkey.Enabled = false;
                bindings.Remove(keystring);
            }
        }

        public void UnbindAll()
        {
            foreach (string keystring in bindings.Keys)
                Unbind(keystring);
        }

        #endregion

        #region Private Methods

        private Hotkey ParseHotkey(string keystring)
        {
            keystring = keystring.ToUpper();

            // TODO: Really, is this the same behavior as XKeybinder?
            if (string.IsNullOrEmpty(keystring) ||
                bindings.ContainsKey(keystring))
                return null;

            Regex bindingExp = new Regex(
                "^(<((ALT)|(CTRL)|(SUPER)|(WIN)|(SHIFT))>)+((F(([1-9])|(1[0-2])))|[A-Z])$");

            if (bindingExp.Matches(keystring).Count == 0)
                return null;

            Hotkey hotkey = new Hotkey();
            hotkey.KeyCode = (Keys)Enum.Parse(
                typeof(Keys),
                keystring.Substring(keystring.LastIndexOf(">") + 1));
            hotkey.Alt = keystring.Contains("<ALT>");
            hotkey.Ctrl = keystring.Contains("<CTRL>");
            hotkey.Shift = keystring.Contains("<SHIFT>");
            hotkey.WindowsKey = keystring.Contains("<SUPER>") ||
                keystring.Contains("<WIN>");

            return hotkey;
        }

        #endregion
    }
}
