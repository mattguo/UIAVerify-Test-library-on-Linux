using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicAutomation.Win32
{
    internal class Win32KeyBinder : IKeybinder
    {
        #region Singleton
        private static readonly Win32KeyBinder instance = new Win32KeyBinder();

        //Explicit static constructor to tell C# compiler not to mark type as beforefieldinit
        static Win32KeyBinder()
        {
        }

        private Win32KeyBinder()
        {
        }

        public static Win32KeyBinder Instance
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
            //throw new NotImplementedException();
        }

        public void Unbind(string keystring)
        {
            //throw new NotImplementedException();
        }

        public void UnbindAll()
        {
            //throw new NotImplementedException();
        }

        #endregion
    }
}
