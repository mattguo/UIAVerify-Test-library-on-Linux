//ported from http://www.tronche.com/gui/x/xlib-tutorial/prog-2.cc

using System;
using System.Threading;
using X11Binding;

namespace X11Binding.Tests
{
	class SimpleXApp
	{
		[STAThread]
		public static void Main(string[] args)
		{
			IntPtr dpy = X11Methods.XOpenDisplay(IntPtr.Zero);
			Console.WriteLine("0X{0:X}", dpy.ToInt32());
			int screenNo = X11Methods.XDefaultScreen(dpy);
            IntPtr defaultColorMap = X11Methods.XDefaultColormap(dpy, screenNo);

            XColor xc = new XColor();
            xc.red = (ushort)(255 << 8);
            xc.green = (ushort)(127 << 8);
            xc.blue = (ushort)(127 << 8);
            xc.flags = X11Consts.DoRed | X11Consts.DoGreen | X11Consts.DoBlue;
            X11Methods.XAllocColor(dpy, defaultColorMap, ref xc);

			UIntPtr blackColor = X11Methods.XBlackPixel(dpy, screenNo);
      		UIntPtr whiteColor = X11Methods.XWhitePixel(dpy, screenNo);
			IntPtr rootWin = X11Methods.XRootWindow(dpy, screenNo);
			
			IntPtr w = X11Methods.XCreateSimpleWindow(dpy, rootWin, 0, 0,
                     200, 100, 0, blackColor, xc.pixel);
			X11Methods.XSelectInput(dpy, w, new IntPtr(X11Consts.StructureNotifyMask));
			X11Methods.XMapWindow(dpy, w);
			
			XGCValues nil = new XGCValues();
			IntPtr gc = X11Methods.XCreateGC(dpy, w, IntPtr.Zero, ref nil);
			X11Methods.XSetForeground(dpy, gc, whiteColor);
			
			while(true) {
		    	XEvent e = new XEvent();
		    	X11Methods.XNextEvent(dpy, ref e);
		    	if (e.type == XEventName.MapNotify)
			  		break;
			}
			X11Methods.XMoveResizeWindow(dpy, w, 50, 50, 400, 400);
			X11Methods.XFlush(dpy);
			while(true) {
		    	XEvent e = new XEvent();
		    	X11Methods.XNextEvent(dpy, ref e);
				Console.WriteLine(e.type);
		    	if (e.type == XEventName.ConfigureNotify)
			  		break;
			}
			//int ret = X11Methods.XMoveResizeWindow(dpy, w, 50, 50, 400, 400);
			X11Methods.XDrawLine(dpy, w, gc, 10, 60, 280, 20);
			X11Methods.XFlush(dpy);
			
			//X11Methods.XCloseDisplay(dpy);
			Thread.Sleep(3000);
		}
		
		static void Test2()
		{
			IntPtr dpy = X11Methods.XOpenDisplay(IntPtr.Zero);//new IntPtr(0x804b008);
			//int screenNo = X11Methods.X
			//IntPtr w = X11Methods.XRootWindow(
			//Console.WriteLine(X11Methods.XMoveResizeWindow(dpy, w, 30, 20, 800, 900));
		}
	}
}