using System;
using BasicAutomation;
using System.Windows.Input;
using System.Threading;

namespace BasicAutomation.Test
{
	class MainClass
	{
		[STAThread]
		public static void Main(string[] args)
		{
			//IntPtr brainyWnd = new IntPtr(0x4000007);
			//IWindowDriver wnd = NativeDriverFactory.GetWindow(brainyWnd);
			//Console.WriteLine(wnd.Bound);
			//wnd.Position = new System.Windows.Point(160, 160);
			//Console.WriteLine(wnd.Bound);
			//wnd.Topmost = true;
			//wnd.Visible = true;
			//wnd.Bound = new System.Windows.Rect(25, 25, 800, 800);
			//NativeDriverFactory.System.MousePostion = new System.Windows.Point(200, 400);
			
			NativeDriverFactory.System.MousePostion = new System.Windows.Point(200, 250);
			NativeDriverFactory.System.SendMouseWheel(MouseWheel.Vertical, -2);
			System.Threading.Thread.Sleep(1000);
			NativeDriverFactory.System.MousePostion = new System.Windows.Point(500, 500);
			System.Threading.Thread.Sleep(1000);
			NativeDriverFactory.System.SendMouseMove (50, 50, false);
			Thread.Sleep (500);
			NativeDriverFactory.System.SendMouseMove (-50, -100, false);
			Thread.Sleep (500);
			NativeDriverFactory.System.ChangeMouseState (500, 500, MouseButton.Right, MouseButtonState.Pressed);
			Thread.Sleep (500);
			NativeDriverFactory.System.ChangeMouseState (500, 500, MouseButton.Right, MouseButtonState.Released);
			Thread.Sleep (2000);
			Console.WriteLine ("Over");
		}
	}
}