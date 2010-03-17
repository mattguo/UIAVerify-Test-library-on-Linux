using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;
using System.Runtime.InteropServices;
using X11Binding;
//using Xsharp;

namespace BasicAutomation.X11
{
    public class X11WindowDriver : IWindowDriver, IEditWindowDriver
    {
        public X11WindowDriver(IntPtr handle)
        {
            this.Handle = handle;
            //????? how to get display from window?
            
        }

        private void SendNetWMMessage(IntPtr message_type, IntPtr l0, IntPtr l1, IntPtr l2)
        {
            XEvent xev;

            xev = new XEvent();
            xev.ClientMessageEvent.type = XEventName.ClientMessage;
            xev.ClientMessageEvent.send_event = true;
            xev.ClientMessageEvent.window = this.Handle;
            xev.ClientMessageEvent.message_type = message_type;
            xev.ClientMessageEvent.format = 32;
            xev.ClientMessageEvent.ptr1 = l0;
            xev.ClientMessageEvent.ptr2 = l1;
            xev.ClientMessageEvent.ptr3 = l2;
            X11Methods.XSendEvent(Display.Handle, RootWindow.Handle, false, new IntPtr((int)(EventMask.SubstructureRedirectMask | EventMask.SubstructureNotifyMask)), ref xev);
        }

        private void SendNetClientMessage(IntPtr message_type, IntPtr l0, IntPtr l1, IntPtr l2)
        {
            XEvent xev;

            xev = new XEvent();
            xev.ClientMessageEvent.type = XEventName.ClientMessage;
            xev.ClientMessageEvent.send_event = true;
            xev.ClientMessageEvent.window = this.Handle;
            xev.ClientMessageEvent.message_type = message_type;
            xev.ClientMessageEvent.format = 32;
            xev.ClientMessageEvent.ptr1 = l0;
            xev.ClientMessageEvent.ptr2 = l1;
            xev.ClientMessageEvent.ptr3 = l2;
            X11Methods.XSendEvent(Display.Handle, this.Handle, false, new IntPtr((int)EventMask.NoEventMask), ref xev);
        }

        public static X11WindowDriver RootWindow
        {
            get
            {
                int screenNo = X11Methods.XDefaultScreen(Display.Handle);
                IntPtr hRoot = X11Methods.XRootWindow(Display.Handle, screenNo);
                X11WindowDriver rootWindowDriver = new X11WindowDriver(hRoot);
                return rootWindowDriver;
            }
        }

		private MotifWmHints WMHints
		{
			get 
			{
				IntPtr	actual_atom;
				int		actual_format;
				IntPtr	nitems;
				IntPtr	bytes_after;
				IntPtr	prop = IntPtr.Zero;
				X11Methods.XGetWindowProperty(Display.Handle, this.Handle, (IntPtr)Atom.XA_WM_HINTS,
				                              IntPtr.Zero, new IntPtr (0x7fffffff), false, (IntPtr)Atom.AnyPropertyType,
				                              out actual_atom, out actual_format, out nitems, out bytes_after, ref prop);
				MotifWmHints hints;
				if (actual_atom != IntPtr.Zero)
				{
					hints = (MotifWmHints)Marshal.PtrToStructure(prop, typeof(MotifWmHints));
					X11Methods.XFree(prop);
				}
				else
				{
					hints = new MotifWmHints();
				}
				return hints;
			}				
			set
			{
				MotifWmHints hints = this.WMHints;				
				MotifWmHints new_hints = value;
				
				if (this.WMHints.flags == IntPtr.Zero)
					hints = new_hints;
				else
				{
					if (NativeHelper.IsBitSet(new_hints.flags.ToInt32(), (int)MotifFlags.Functions))
					{
						hints.flags = new IntPtr(NativeHelper.SetBit(hints.flags.ToInt32(), (int)MotifFlags.Functions));
						hints.functions = new_hints.functions;
					}
					
					if (NativeHelper.IsBitSet(new_hints.flags.ToInt32(), (int)MotifFlags.Decorations))
					{
						hints.flags = new IntPtr(NativeHelper.SetBit(hints.flags.ToInt32(), (int)MotifFlags.Decorations));
						hints.decorations = new_hints.decorations;
					}
				}
				IntPtr atom = X11Methods.XInternAtom(Display.Handle, "_MOTIF_WM_HINTS", true);
				X11Methods.XChangeProperty(Display.Handle, this.Handle,
				                           atom, atom,
				                           32, PropertyMode.Replace, ref value, 5);
                Display.Flush();
			}
		}

        #region IWindowDriver Members

        public IntPtr Handle { get; protected set; }

        public bool NoBorder
        {
            set
            {
                MotifWmHints hints = new MotifWmHints();
				hints.flags = (IntPtr)MotifFlags.Decorations;
				hints.decorations = value ? IntPtr.Zero : (IntPtr)MotifDecorations.All;
				this.WMHints = hints;
            }
        }

        public bool Topmost
        {
            set 
			{
                if (value)
                {
                    //todo How to decide whether a window is mapped.
                    //lock (XlibLock)
                    //{
                    //    if (hwnd.Mapped)
                    //    {
                    //        SendNetWMMessage(hwnd.WholeWindow, _NET_WM_STATE, (IntPtr)NetWmStateRequest._NET_WM_STATE_ADD, _NET_WM_STATE_ABOVE, IntPtr.Zero);
                    //    }
                    //    else
                    //    {
                    //        int[] atoms = new int[8];
                    //        atoms[0] = _NET_WM_STATE_ABOVE.ToInt32();
                    //        XChangeProperty(DisplayHandle, hwnd.whole_window, _NET_WM_STATE, (IntPtr)Atom.XA_ATOM, 32, PropertyMode.Replace, atoms, 1);
                    //    }
                    //}
                    SendNetWMMessage(X11Atoms._NET_WM_STATE, (IntPtr)NetWmStateRequest._NET_WM_STATE_ADD, X11Atoms._NET_WM_STATE_ABOVE, IntPtr.Zero);
                }
                else
                {
                    SendNetWMMessage(X11Atoms._NET_WM_STATE, (IntPtr)NetWmStateRequest._NET_WM_STATE_REMOVE, X11Atoms._NET_WM_STATE_ABOVE, IntPtr.Zero);
                }
				Display.Flush();
			}
        }

        public bool Visible
        {
            get
            {
                XWindowAttributes attributes = new XWindowAttributes();
                X11Methods.XGetWindowAttributes(Display.Handle, Handle, ref attributes);
                return attributes.map_state == MapState.IsViewable;
            }
            set
            {
                XWindowAttributes attributes = new XWindowAttributes();
                X11Methods.XGetWindowAttributes(Display.Handle, Handle, ref attributes);
                if (value)
                {
                    if (attributes.map_state == MapState.IsUnmapped)
					{
                        X11Methods.XMapWindow(Display.Handle, Handle);
						Display.Flush();
					}
                }
                else
                {
					Console.WriteLine(attributes.map_state);
                    if (attributes.map_state == MapState.IsViewable)
					{
						Console.WriteLine("XUnmapWindow");
                        X11Methods.XUnmapWindow(Display.Handle, Handle);
						Display.Flush();
					}
                }
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
				/*IntPtr root;
				int x;
				int y;
				int width;
				int height;
				int borderWidth;
				int depth;
				
				//XGetGeometry returns relative coordinates.
				 X11Methods.XGetGeometry(Display.Handle, this.Handle,
				                        out root, out x, out y, out width, out height,
				                        out borderWidth, out depth);
				                        */
				XWindowAttributes wndAttr = new XWindowAttributes();
				X11Methods.XGetWindowAttributes (Display.Handle, this.Handle, ref wndAttr);
				IntPtr dummyWin;
				int x, y;
				X11Methods.XTranslateCoordinates (Display.Handle, this.Handle, wndAttr.root, 
				                                  -wndAttr.border_width, -wndAttr.border_width,
				                                  out x, out y, out dummyWin);
				return new System.Windows.Rect(x, y, wndAttr.width, wndAttr.height);
            }
            set
            {
                X11Methods.XMoveResizeWindow(Display.Handle, this.Handle,
				                             (int)value.Left, (int)value.Top,
				                             (uint)value.Width, (uint)value.Height);
				Display.Flush();
            }
        }

        public System.Windows.Point Position
        {
            get
            {
                return this.Bound.TopLeft;
            }
            set
            {
                X11Methods.XMoveWindow(Display.Handle, this.Handle, (int)value.X, (int)value.Y);
				Display.Flush();
            }
        }

        public System.Windows.Size Size
        {
            get
            {
                return this.Bound.Size;
            }
            set
            {
                X11Methods.XResizeWindow(Display.Handle, this.Handle, (uint)value.Width, (uint)value.Height);
				Display.Flush();
            }
        }

        public Color BackgroundColor
        {
            get
            {
                XWindowAttributes wndAttr = new XWindowAttributes();
                X11Methods.XGetWindowAttributes(Display.Handle, this.Handle, ref wndAttr);
                return X11Helper.XPixelToColor(Display.Handle, wndAttr.colormap, wndAttr.backing_pixel);
            }
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
