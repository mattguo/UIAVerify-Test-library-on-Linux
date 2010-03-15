using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;
//using Xsharp;

namespace BasicAutomation.X11
{
    public class X11WindowDriver : IWindowDriver, IEditWindowDriver
    {
        private IntPtr display = IntPtr.Zero;

        public X11WindowDriver(IntPtr handle)
        {
            this.Handle = handle;
            //????? how to get display from window?
            
        }

        #region IWindowDriver Members

        public IntPtr Handle { get; protected set; }

        public bool NoBorder
        {
            set
            {
                throw new NotImplementedException();
            }
        }

        public bool Topmost
        {
            set { throw new NotImplementedException(); }
        }

        public bool Visible
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public bool Enabled
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public bool IsRightToLeftLayout
        {
            get { throw new NotImplementedException(); }
        }

        public System.Windows.Rect Bound
        {
            get
            {
                //Xlib.XGetGeometry(X11Display.Default.Handle, this.Handle
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public System.Windows.Point Position
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public System.Windows.Size Size
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public Color BackgroundColor
        {
            get { throw new NotImplementedException(); }
        }

        public Color TextColor
        {
            get { throw new NotImplementedException(); }
        }

        public IWindowDriver Buddy
        {
            get { throw new NotImplementedException(); }
        }

        public IEditWindowDriver AsEditWindow()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IEditWindowDriver Members

        public int LineCount
        {
            get { throw new NotImplementedException(); }
        }

        public int TextLimit
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsMultiLine
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsRichEdit
        {
            get { throw new NotImplementedException(); }
        }

        public string Text
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        #endregion
    }
}
