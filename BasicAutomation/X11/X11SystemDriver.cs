using System;
using System.Diagnostics;
using System.Windows.Input;
using X11Binding;

namespace BasicAutomation.X11
{
	public class X11SystemDriver : ISystemDriver
	{		
		#region Singleton
        private static readonly X11SystemDriver instance = new X11SystemDriver();

        //Explicit static constructor to tell C# compiler not to mark type as beforefieldinit
        static X11SystemDriver()
        {
			
        }

        private X11SystemDriver()
        {
			
        }

        public static X11SystemDriver Instance
        {
            get
            {
                return instance;
            }
        }
        #endregion
		
		#region ISystemDriver Members

        public bool Execute(string appPath, string arguments)
        {
            Process p = new Process();
            p.StartInfo.FileName = appPath;
            p.StartInfo.Arguments = arguments;
            return p.Start();
        }

        public void InputKey(Key key, bool press)
        {
			IntPtr dpy = Display.Handle;
			uint keySym = X11Helper.KeySymFromKey(key);
			Console.WriteLine(keySym);
			byte keyCode = X11Methods.XKeysymToKeycode(Display.Handle, new UIntPtr(keySym));
			Console.WriteLine(keyCode);
			X11Methods.XTestFakeKeyEvent(dpy, keyCode, true, UIntPtr.Zero);
			X11Methods.XTestFakeKeyEvent(dpy, keyCode, false, UIntPtr.Zero);
			Display.Flush();
        }

        public KeyStates GetKeyState(Key key)
        {
			//XQueryKeymap
            throw new NotImplementedException();
        }

        public void EnterText(string text)
        {
            throw new NotImplementedException();
        }

        public void SendMouseMove(double x, double y, bool isAbsCoord)
        {
			int screenNo = X11Methods.XDefaultScreen(Display.Handle);
			if (isAbsCoord)
				X11Methods.XTestFakeMotionEvent(Display.Handle, screenNo, (int)x, (int)y, new UIntPtr(X11Consts.CurrentTime));
			else
				X11Methods.XTestFakeRelativeMotionEvent(Display.Handle, (int)x, (int)y, new UIntPtr(X11Consts.CurrentTime));
			Display.Flush();
        }

        public System.Windows.Point MousePostion
        {
            get
			{
				IntPtr root;
				IntPtr child;
				int rootx, rooty;
				int winx, winy;
				uint mask;
				X11Methods.XQueryPointer(Display.Handle, X11WindowDriver.RootWindow.Handle,
				                         out root, out child,
				                         out rootx, out rooty,
				                         out winx, out winy,
				                         out mask);
				return new System.Windows.Point(rootx, rooty);
			}
            set
			{
				int screenNo = X11Methods.XDefaultScreen(Display.Handle);
				X11Methods.XTestFakeMotionEvent(Display.Handle, screenNo, (int)value.X, (int)value.Y, UIntPtr.Zero);
				/*
				var currentPos = MousePostion;
				int x = (int)(value.X - currentPos.X);
				int y = (int)(value.Y - currentPos.Y);
				Console.WriteLine("X:{0}, Y:{1}", x, y);
				X11Methods.XWarpPointer(Display.Handle, IntPtr.Zero, IntPtr.Zero, 0, 0, 0, 0, x, y);*/
				Display.Flush();
			}
        }

        public void SendMouseWheel(MouseWheel wheel, int delta)
        {
			if (delta == 0)
				return;
			if (wheel == MouseWheel.Horizontal)
                throw new NotImplementedException();
			uint wheelButtonCode = X11Consts.MouseWheelDown;
			if (delta < 0)
			{
				delta = -delta;
				wheelButtonCode = X11Consts.MouseWheelUp;
			}
			for (int i = 0; i < delta; i++)
            	WheelAction(wheelButtonCode);
			Display.Flush();
        }

		private void WheelAction(uint wheelButtonCode)
		{
			IntPtr dpy = Display.Handle;
    		X11Methods.XTestFakeButtonEvent(dpy, wheelButtonCode, true, new UIntPtr(X11Consts.CurrentTime));
    		X11Methods.XTestFakeRelativeMotionEvent(dpy, 0, 0, new UIntPtr(X11Consts.CurrentTime));
    		X11Methods.XTestFakeButtonEvent (dpy, wheelButtonCode, false, new UIntPtr(X11Consts.CurrentTime));
		}
		
        public void ChangeMouseState(double x, double y, MouseButton button, MouseButtonState state)
        {
			uint buttonId = 0;
			switch (button)
			{
			case MouseButton.Left:
				buttonId = 1;
				break;
			case MouseButton.Middle:
				buttonId = 2;
				break;
			case MouseButton.Right:
				buttonId = 3;
				break;
			case MouseButton.XButton1:
			case MouseButton.XButton2:
				throw new NotImplementedException("XButtons are not supported on X11");
			}
			bool isPressed = (state == MouseButtonState.Pressed);
			X11Methods.XTestFakeButtonEvent(Display.Handle, buttonId, isPressed, new UIntPtr(X11Consts.CurrentTime));
			Display.Flush();
        }

        public MouseButtonState GetMouseButtonState(MouseButton button)
        {
			//XQueryPointer
            throw new NotImplementedException();
        }

        #endregion
	}
}
