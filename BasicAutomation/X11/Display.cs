using System;
using X11Binding;

namespace BasicAutomation
{
	public class Display
	{
		private static IntPtr handle = IntPtr.Zero;
		static Display()
		{
			handle = X11Methods.XOpenDisplay(IntPtr.Zero);
            X11Atoms.SetupAtoms(handle);
		}
		
		public static IntPtr Handle
		{
			get { return handle; }
		}
		
		public static void Flush()
		{
			X11Methods.XFlush(Handle);
		}
	}
}
