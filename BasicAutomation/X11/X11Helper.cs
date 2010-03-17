using System;
using System.Windows.Media;
using X11Binding;
using System.Windows.Input;

namespace BasicAutomation.X11
{
    class X11Helper
    {
        internal static Color XPixelToColor(IntPtr dpy, IntPtr colormap, UIntPtr pixel)
        {
            XColor xc = new XColor();
            xc.pixel = pixel;
            X11Methods.XQueryColor(dpy, colormap, ref xc);
            return Color.FromRgb((byte)(xc.red >> 8), (byte)(xc.green >> 8), (byte)(xc.blue >> 8));
        }

        internal static UIntPtr XColorToPixel(IntPtr dpy, IntPtr colormap, Color color)
        {
            XColor xc = new XColor();
            xc.red = (ushort)(color.R << 8);
            xc.green = (ushort)(color.G << 8);
            xc.blue = (ushort)(color.B << 8);
            xc.flags = X11Consts.DoRed | X11Consts.DoGreen | X11Consts.DoBlue;
            X11Methods.XAllocColor(dpy, colormap, ref xc);
            return xc.pixel;
        }
		
		internal static uint KeySymFromKey(Key key)
		{
		    switch (key)
		    {
	        case Key.Cancel:
	            return 3;
	
	        case Key.Back:
	            return 8;
	
	        case Key.Tab:
	            return 9;
	
	        case Key.Clear:
	            return 12;
	
	        case Key.Return:
	            return 13;
	
	        case Key.Pause:
	            return 0x13;
	
	        case Key.Capital:
	            return 20;
	
	        case Key.KanaMode:
	            return 0x15;
	
	        case Key.JunjaMode:
	            return 0x17;
	
	        case Key.FinalMode:
	            return 0x18;
	
	        case Key.HanjaMode:
	            return 0x19;
	
	        case Key.Escape:
	            return 0x1b;
	
	        case Key.ImeConvert:
	            return 0x1c;
	
	        case Key.ImeNonConvert:
	            return 0x1d;
	
	        case Key.ImeAccept:
	            return 30;
	
	        case Key.ImeModeChange:
	            return 0x1f;
	
	        case Key.Space:
	            return 0x20;
	
	        case Key.Prior:
	            return 0x21;
	
	        case Key.Next:
	            return 0x22;
	
	        case Key.End:
	            return 0x23;
	
	        case Key.Home:
	            return 0x24;
	
	        case Key.Left:
	            return 0x25;
	
	        case Key.Up:
	            return 0x26;
	
	        case Key.Right:
	            return 0x27;
	
	        case Key.Down:
	            return 40;
	
	        case Key.Select:
	            return 0x29;
	
	        case Key.Print:
	            return 0x2a;
	
	        case Key.Execute:
	            return 0x2b;
	
	        case Key.Snapshot:
	            return 0x2c;
	
	        case Key.Insert:
	            return 0x2d;
	
	        case Key.Delete:
	            return 0x2e;
	
	        case Key.Help:
	            return 0x2f;
	
	        case Key.D0:
	            return 0x30;
	
	        case Key.D1:
	            return 0x31;
	
	        case Key.D2:
	            return 50;
	
	        case Key.D3:
	            return 0x33;
	
	        case Key.D4:
	            return 0x34;
	
	        case Key.D5:
	            return 0x35;
	
	        case Key.D6:
	            return 0x36;
	
	        case Key.D7:
	            return 0x37;
	
	        case Key.D8:
	            return 0x38;
	
	        case Key.D9:
	            return 0x39;
	
	        case Key.A:
	            return 0x41;
	
	        case Key.B:
	            return 0x42;
	
	        case Key.C:
	            return 0x43;
	
	        case Key.D:
	            return 0x44;
	
	        case Key.E:
	            return 0x45;
	
	        case Key.F:
	            return 70;
	
	        case Key.G:
	            return 0x47;
	
	        case Key.H:
	            return 0x48;
	
	        case Key.I:
	            return 0x49;
	
	        case Key.J:
	            return 0x4a;
	
	        case Key.K:
	            return 0x4b;
	
	        case Key.L:
	            return 0x4c;
	
	        case Key.M:
	            return 0x4d;
	
	        case Key.N:
	            return 0x4e;
	
	        case Key.O:
	            return 0x4f;
	
	        case Key.P:
	            return 80;
	
	        case Key.Q:
	            return 0x51;
	
	        case Key.R:
	            return 0x52;
	
	        case Key.S:
	            return 0x53;
	
	        case Key.T:
	            return 0x54;
	
	        case Key.U:
	            return 0x55;
	
	        case Key.V:
	            return 0x56;
	
	        case Key.W:
	            return 0x57;
	
	        case Key.X:
	            return 0x58;
	
	        case Key.Y:
	            return 0x59;
	
	        case Key.Z:
	            return 90;
	
	        case Key.LWin:
	            return 0x5b;
	
	        case Key.RWin:
	            return 0x5c;
	
	        case Key.Apps:
	            return 0x5d;
	
	        case Key.Sleep:
	            return 0x5f;
	
	        case Key.NumPad0:
	            return 0x60;
	
	        case Key.NumPad1:
	            return 0x61;
	
	        case Key.NumPad2:
	            return 0x62;
	
	        case Key.NumPad3:
	            return 0x63;
	
	        case Key.NumPad4:
	            return 100;
	
	        case Key.NumPad5:
	            return 0x65;
	
	        case Key.NumPad6:
	            return 0x66;
	
	        case Key.NumPad7:
	            return 0x67;
	
	        case Key.NumPad8:
	            return 0x68;
	
	        case Key.NumPad9:
	            return 0x69;
	
	        case Key.Multiply:
	            return 0x6a;
	
	        case Key.Add:
	            return 0x6b;
	
	        case Key.Separator:
	            return 0x6c;
	
	        case Key.Subtract:
	            return 0x6d;
	
	        case Key.Decimal:
	            return 110;
	
	        case Key.Divide:
	            return 0x6f;
	
	        case Key.F1:
	            return 0x70;
	
	        case Key.F2:
	            return 0x71;
	
	        case Key.F3:
	            return 0x72;
	
	        case Key.F4:
	            return 0x73;
	
	        case Key.F5:
	            return 0x74;
	
	        case Key.F6:
	            return 0x75;
	
	        case Key.F7:
	            return 0x76;
	
	        case Key.F8:
	            return 0x77;
	
	        case Key.F9:
	            return 120;
	
	        case Key.F10:
	            return 0x79;
	
	        case Key.F11:
	            return 0x7a;
	
	        case Key.F12:
	            return 0x7b;
	
	        case Key.F13:
	            return 0x7c;
	
	        case Key.F14:
	            return 0x7d;
	
	        case Key.F15:
	            return 0x7e;
	
	        case Key.F16:
	            return 0x7f;
	
	        case Key.F17:
	            return 0x80;
	
	        case Key.F18:
	            return 0x81;
	
	        case Key.F19:
	            return 130;
	
	        case Key.F20:
	            return 0x83;
	
	        case Key.F21:
	            return 0x84;
	
	        case Key.F22:
	            return 0x85;
	
	        case Key.F23:
	            return 0x86;
	
	        case Key.F24:
	            return 0x87;
	
	        case Key.NumLock:
	            return 0x90;
	
	        case Key.Scroll:
	            return 0x91;
	
	        case Key.LeftShift:
	            return 160;
	
	        case Key.RightShift:
	            return 0xa1;
	
	        case Key.LeftCtrl:
	            return 0xa2;
	
	        case Key.RightCtrl:
	            return 0xa3;
	
	        case Key.LeftAlt:
	            return 0xa4;
	
	        case Key.RightAlt:
	            return 0xa5;
	
	        case Key.BrowserBack:
	            return 0xa6;
	
	        case Key.BrowserForward:
	            return 0xa7;
	
	        case Key.BrowserRefresh:
	            return 0xa8;
	
	        case Key.BrowserStop:
	            return 0xa9;
	
	        case Key.BrowserSearch:
	            return 170;
	
	        case Key.BrowserFavorites:
	            return 0xab;
	
	        case Key.BrowserHome:
	            return 0xac;
	
	        case Key.VolumeMute:
	            return 0xad;
	
	        case Key.VolumeDown:
	            return 0xae;
	
	        case Key.VolumeUp:
	            return 0xaf;
	
	        case Key.MediaNextTrack:
	            return 0xb0;
	
	        case Key.MediaPreviousTrack:
	            return 0xb1;
	
	        case Key.MediaStop:
	            return 0xb2;
	
	        case Key.MediaPlayPause:
	            return 0xb3;
	
	        case Key.LaunchMail:
	            return 180;
	
	        case Key.SelectMedia:
	            return 0xb5;
	
	        case Key.LaunchApplication1:
	            return 0xb6;
	
	        case Key.LaunchApplication2:
	            return 0xb7;
	
	        case Key.Oem1:
	            return 0xba;
	
	        case Key.OemPlus:
	            return 0xbb;
	
	        case Key.OemComma:
	            return 0xbc;
	
	        case Key.OemMinus:
	            return 0xbd;
	
	        case Key.OemPeriod:
	            return 190;
	
	        case Key.Oem2:
	            return 0xbf;
	
	        case Key.Oem3:
	            return 0xc0;
	
	        case Key.AbntC1:
	            return 0xc1;
	
	        case Key.AbntC2:
	            return 0xc2;
	
	        case Key.Oem4:
	            return 0xdb;
	
	        case Key.Oem5:
	            return 220;
	
	        case Key.Oem6:
	            return 0xdd;
	
	        case Key.Oem7:
	            return 0xde;
	
	        case Key.Oem8:
	            return 0xdf;
	
	        case Key.Oem102:
	            return 0xe2;
	
	        case Key.ImeProcessed:
	            return 0xe5;
	
	        case Key.OemAttn:
	            return 240;
	
	        case Key.OemFinish:
	            return 0xf1;
	
	        case Key.OemCopy:
	            return 0xf2;
	
	        case Key.OemAuto:
	            return 0xf3;
	
	        case Key.OemEnlw:
	            return 0xf4;
	
	        case Key.OemBackTab:
	            return 0xf5;
	
	        case Key.Attn:
	            return 0xf6;
	
	        case Key.CrSel:
	            return 0xf7;
	
	        case Key.ExSel:
	            return 0xf8;
	
	        case Key.EraseEof:
	            return 0xf9;
	
	        case Key.Play:
	            return 250;
	
	        case Key.Zoom:
	            return 0xfb;
	
	        case Key.NoName:
	            return 0xfc;
	
	        case Key.Pa1:
	            return 0xfd;
	
	        case Key.OemClear:
	            return 0xfe;
				
			default:
				throw new NotImplementedException("Unknown Key");
			}
		}
    }
}
