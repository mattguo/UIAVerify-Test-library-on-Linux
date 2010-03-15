using System;
using System.Collections.Generic;

namespace BasicAutomation
{
    public interface IKeybinder
    {
        void Bind(string keystring, EventHandler handler);
        void Unbind(string keystring);
        void UnbindAll();
        //bool GetAccelKeys(string prefs_path, out uint keyval, out Gdk.ModifierType mods);
    }
}
