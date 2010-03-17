// Ripped from Mono source code SVN v135711 (/mcs/class/Managed.Windows.Forms/System.Windows.Forms/XPlayUIStructs.cs),
// Minor modifications are made
// Matt Guo		rguo@novell.com

using System;
using System.Text;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace X11Binding
{	
	public class X11Methods
	{
		#region XTest imports
		[DllImport ("libXtst")]
		public extern static bool XTestCompareCursorWithWindow(IntPtr dpy, IntPtr window, IntPtr cursor);
			//Display *dpy; Window window; Cursor cursor;

		[DllImport ("libXtst")]
		public extern static bool XTestCompareCurrentCursorWithWindow(IntPtr dpy, IntPtr window);
			//Display *dpy; Window window;
		
		[DllImport ("libXtst")]
		public extern static int XTestFakeKeyEvent(IntPtr dpy, uint keycode, bool is_press, UIntPtr delay);
			//Display *dpy; unsigned int keycode; Bool is_press; unsigned long delay;

		[DllImport ("libXtst")]
		public extern static int XTestFakeButtonEvent(IntPtr dpy, uint button, bool is_press, UIntPtr delay);
			//Display *dpy; unsigned int button; Bool is_press; unsigned long delay;

		[DllImport ("libXtst")]
		public extern static int XTestFakeMotionEvent(IntPtr dpy, int screen, int x, int y, UIntPtr delay);
			//Display *dpy; int screen; int x, y; unsigned long delay;

		[DllImport ("libXtst")]
		public extern static int XTestFakeRelativeMotionEvent(IntPtr dpy, int dx, int dy, UIntPtr delay);
			//Display *dpy; int dx, dy; unsigned long delay;
		
		[DllImport ("libXtst")]
		public extern static int XTestGrabControl(IntPtr dpy, bool impervious);
       		//Display *dpy;  Bool impervious;

		/* XTest functions not wrapped:
		 * 
			XTestFakeDeviceKeyEvent
			XTestFakeDeviceButtonEvent
			XTestFakeProximityEvent
			XTestFakeDeviceMotionEvent
			XTestSetGContextOfGC
			XTestSetVisualIDOfVisual
			XTestDiscard
			XTestQueryExtension
		 */
		
		#endregion
		
		#region Xcursor imports
		[DllImport ("libXcursor", EntryPoint = "XcursorLibraryLoadCursor")]
		public extern static IntPtr XcursorLibraryLoadCursor (IntPtr display, [MarshalAs (UnmanagedType.LPStr)] string name);

		[DllImport ("libXcursor", EntryPoint = "XcursorLibraryLoadImages")]
		public extern static IntPtr XcursorLibraryLoadImages ([MarshalAs (UnmanagedType.LPStr)] string file, IntPtr theme, int size);
		
		[DllImport ("libXcursor", EntryPoint = "XcursorImagesDestroy")]
		public extern static void XcursorImagesDestroy (IntPtr images);
		
		[DllImport ("libXcursor", EntryPoint = "XcursorGetDefaultSize")]
		public extern static int XcursorGetDefaultSize (IntPtr display);

		[DllImport ("libXcursor", EntryPoint = "XcursorImageLoadCursor")]
		public extern static IntPtr XcursorImageLoadCursor (IntPtr display, IntPtr image);

		[DllImport ("libXcursor", EntryPoint = "XcursorGetTheme")]
		public extern static IntPtr XcursorGetTheme (IntPtr display);
		#endregion
		
		#region X11 Imports
		[DllImport ("libX11", EntryPoint="XOpenDisplay")]
		public extern static IntPtr XOpenDisplay(IntPtr display);
		[DllImport ("libX11", EntryPoint="XCloseDisplay")]
		public extern static int XCloseDisplay(IntPtr display);						    
		[DllImport ("libX11", EntryPoint="XSynchronize")]
		public extern static IntPtr XSynchronize(IntPtr display, bool onoff);

		[DllImport ("libX11", EntryPoint="XCreateWindow")]
		public extern static IntPtr XCreateWindow(IntPtr display, IntPtr parent, int x, int y, int width, int height, int border_width, int depth, int xclass, IntPtr visual, UIntPtr valuemask, ref XSetWindowAttributes attributes);
		
		[DllImport ("libX11", EntryPoint="XCreateSimpleWindow")]
		public extern static IntPtr XCreateSimpleWindow(IntPtr display, IntPtr parent, int x, int y, int width, int height, int border_width, UIntPtr border, UIntPtr background);
		
		[DllImport ("libX11", EntryPoint="XMapWindow")]
		public extern static int XMapWindow(IntPtr display, IntPtr window);
		
		[DllImport ("libX11", EntryPoint="XUnmapWindow")]
		public extern static int XUnmapWindow(IntPtr display, IntPtr window);
		
		[DllImport ("libX11", EntryPoint="XMapSubwindows")]
		public extern static int XMapSubindows(IntPtr display, IntPtr window);
		
		[DllImport ("libX11", EntryPoint="XUnmapSubwindows")]
		public extern static int XUnmapSubwindows(IntPtr display, IntPtr window);
		
		[DllImport ("libX11", EntryPoint="XRootWindow")]
		public extern static IntPtr XRootWindow(IntPtr display, int screen_number);
		
		[DllImport ("libX11", EntryPoint="XNextEvent")]
		public extern static IntPtr XNextEvent(IntPtr display, ref XEvent xevent);

		[DllImport ("libX11", EntryPoint="XConnectionNumber")]
		public extern static int XConnectionNumber (IntPtr display);
		
		[DllImport ("libX11", EntryPoint="XPending")]
		public extern static int XPending (IntPtr display);
		
		[DllImport ("libX11", EntryPoint="XSelectInput")]
		public extern static IntPtr XSelectInput(IntPtr display, IntPtr window, IntPtr mask);
		
		[DllImport ("libX11", EntryPoint="XDestroyWindow")]
		public extern static int XDestroyWindow(IntPtr display, IntPtr window);
		
		[DllImport ("libX11", EntryPoint="XReparentWindow")]
		public extern static int XReparentWindow(IntPtr display, IntPtr window, IntPtr parent, int x, int y);
		
		[DllImport ("libX11", EntryPoint="XMoveResizeWindow")]
		public extern static int XMoveResizeWindow(IntPtr display, IntPtr window, int x, int y, uint width, uint height);
		
		[DllImport ("libX11")]
		public extern static int XMoveWindow(IntPtr display, IntPtr window, int x, int y);
		
		[DllImport ("libX11")]
		public extern static int XResizeWindow(IntPtr display, IntPtr window, uint width, uint height);
		/*?????
		//todo
		public static int MoveResizeWindow(IntPtr display, IntPtr window, int x, int y, int width, int height)
		{
			int ret = XMoveResizeWindow (display, window, x, y, width, height);
			Keyboard.MoveCurrentCaretPos ();
			return ret;
		}*/

		[DllImport ("libX11", EntryPoint="XResizeWindow")]
		public extern static int XResizeWindow(IntPtr display, IntPtr window, int width, int height);

		[DllImport ("libX11", EntryPoint="XGetWindowAttributes")]
		public extern static int XGetWindowAttributes(IntPtr display, IntPtr window, ref XWindowAttributes attributes);

		[DllImport ("libX11", EntryPoint="XFlush")]
		public extern static int XFlush(IntPtr display);

		[DllImport ("libX11", EntryPoint="XSetWMName")]
		public extern static int XSetWMName(IntPtr display, IntPtr window, ref XTextProperty text_prop);

		[DllImport ("libX11", EntryPoint="XStoreName")]
		public extern static int XStoreName(IntPtr display, IntPtr window, string window_name);

		[DllImport ("libX11", EntryPoint="XFetchName")]
		public extern static int XFetchName(IntPtr display, IntPtr window, ref IntPtr window_name);

		[DllImport ("libX11", EntryPoint="XSendEvent")]
		public extern static int XSendEvent(IntPtr display, IntPtr window, bool propagate, IntPtr event_mask, ref XEvent send_event);

		[DllImport ("libX11", EntryPoint="XQueryTree")]
		public extern static int XQueryTree(IntPtr display, IntPtr window, out IntPtr root_return, out IntPtr parent_return, out IntPtr children_return, out int nchildren_return);

		[DllImport ("libX11", EntryPoint="XFree")]
		public extern static int XFree(IntPtr data);

		[DllImport ("libX11", EntryPoint="XRaiseWindow")]
		public extern static int XRaiseWindow(IntPtr display, IntPtr window);

		[DllImport ("libX11", EntryPoint="XLowerWindow")]
		public extern static uint XLowerWindow(IntPtr display, IntPtr window);

		[DllImport ("libX11", EntryPoint="XConfigureWindow")]
		public extern static uint XConfigureWindow(IntPtr display, IntPtr window, ChangeWindowFlags value_mask, ref XWindowChanges values);

		[DllImport ("libX11", EntryPoint="XInternAtom")]
		public extern static IntPtr XInternAtom(IntPtr display, string atom_name, bool only_if_exists);

		[DllImport ("libX11", EntryPoint="XInternAtoms")]
		public extern static int XInternAtoms(IntPtr display, string[] atom_names, int atom_count, bool only_if_exists, IntPtr[] atoms);

		[DllImport ("libX11", EntryPoint="XSetWMProtocols")]
		public extern static int XSetWMProtocols(IntPtr display, IntPtr window, IntPtr[] protocols, int count);

		[DllImport ("libX11", EntryPoint="XGrabPointer")]
		public extern static int XGrabPointer(IntPtr display, IntPtr window, bool owner_events, EventMask event_mask, GrabMode pointer_mode, GrabMode keyboard_mode, IntPtr confine_to, IntPtr cursor, IntPtr timestamp);

		[DllImport ("libX11", EntryPoint="XUngrabPointer")]
		public extern static int XUngrabPointer(IntPtr display, IntPtr timestamp);

		[DllImport ("libX11", EntryPoint="XQueryPointer")]
		public extern static bool XQueryPointer(IntPtr display, IntPtr window, out IntPtr root, out IntPtr child, out int root_x, out int root_y, out int win_x, out int win_y, out uint keys_buttons);

		[DllImport ("libX11", EntryPoint="XTranslateCoordinates")]
		public extern static bool XTranslateCoordinates (IntPtr display, IntPtr src_w, IntPtr dest_w, int src_x, int src_y, out int intdest_x_return, out int dest_y_return, out IntPtr child_return);

		[DllImport ("libX11", EntryPoint="XGetGeometry")]
		public extern static bool XGetGeometry(IntPtr display, IntPtr window, out IntPtr root, out int x, out int y, out int width, out int height, out int border_width, out int depth);

		[DllImport ("libX11", EntryPoint="XGetGeometry")]
		public extern static bool XGetGeometry(IntPtr display, IntPtr window, IntPtr root, out int x, out int y, out int width, out int height, IntPtr border_width, IntPtr depth);

		[DllImport ("libX11", EntryPoint="XGetGeometry")]
		public extern static bool XGetGeometry(IntPtr display, IntPtr window, IntPtr root, out int x, out int y, IntPtr width, IntPtr height, IntPtr border_width, IntPtr depth);

		[DllImport ("libX11", EntryPoint="XGetGeometry")]
		public extern static bool XGetGeometry(IntPtr display, IntPtr window, IntPtr root, IntPtr x, IntPtr y, out int width, out int height, IntPtr border_width, IntPtr depth);

		[DllImport ("libX11", EntryPoint="XWarpPointer")]
		public extern static uint XWarpPointer(IntPtr display, IntPtr src_w, IntPtr dest_w, int src_x, int src_y, uint src_width, uint src_height, int dest_x, int dest_y);

		[DllImport ("libX11", EntryPoint="XClearWindow")]
		public extern static int XClearWindow(IntPtr display, IntPtr window);

		[DllImport ("libX11", EntryPoint="XClearArea")]
		public extern static int XClearArea(IntPtr display, IntPtr window, int x, int y, int width, int height, bool exposures);

		// Colormaps
		[DllImport ("libX11", EntryPoint="XDefaultScreenOfDisplay")]
		public extern static IntPtr XDefaultScreenOfDisplay(IntPtr display);

		[DllImport ("libX11", EntryPoint="XScreenNumberOfScreen")]
		public extern static int XScreenNumberOfScreen(IntPtr display, IntPtr Screen);

		[DllImport ("libX11", EntryPoint="XDefaultVisual")]
		public extern static IntPtr XDefaultVisual(IntPtr display, int screen_number);

		[DllImport ("libX11", EntryPoint="XDefaultDepth")]
		public extern static uint XDefaultDepth(IntPtr display, int screen_number);

		[DllImport ("libX11", EntryPoint="XDefaultScreen")]
		public extern static int XDefaultScreen(IntPtr display);

		[DllImport ("libX11", EntryPoint="XDefaultColormap")]
		public extern static IntPtr XDefaultColormap(IntPtr display, int screen_number);

		[DllImport ("libX11", EntryPoint="XLookupColor")]
		public extern static int XLookupColor(IntPtr display, IntPtr Colormap, string Coloranem, ref XColor exact_def_color, ref XColor screen_def_color);

		[DllImport ("libX11", EntryPoint="XAllocColor")]
		public extern static int XAllocColor(IntPtr display, IntPtr Colormap, ref XColor colorcell_def);

		[DllImport ("libX11", EntryPoint="XSetTransientForHint")]
		public extern static int XSetTransientForHint(IntPtr display, IntPtr window, IntPtr prop_window);

		[DllImport ("libX11", EntryPoint="XChangeProperty")]
		public extern static int XChangeProperty(IntPtr display, IntPtr window, IntPtr property, IntPtr type, int format, PropertyMode mode, ref MotifWmHints data, int nelements);

		[DllImport ("libX11", EntryPoint="XChangeProperty")]
		public extern static int XChangeProperty(IntPtr display, IntPtr window, IntPtr property, IntPtr type, int format, PropertyMode mode, ref uint value, int nelements);

		[DllImport ("libX11", EntryPoint="XChangeProperty")]
		public extern static int XChangeProperty(IntPtr display, IntPtr window, IntPtr property, IntPtr type, int format, PropertyMode mode, ref IntPtr value, int nelements);

		[DllImport ("libX11", EntryPoint="XChangeProperty")]
		public extern static int XChangeProperty(IntPtr display, IntPtr window, IntPtr property, IntPtr type, int format, PropertyMode mode, uint[] data, int nelements);

		[DllImport ("libX11", EntryPoint="XChangeProperty")]
		public extern static int XChangeProperty(IntPtr display, IntPtr window, IntPtr property, IntPtr type, int format, PropertyMode mode, int[] data, int nelements);

		[DllImport ("libX11", EntryPoint="XChangeProperty")]
		public extern static int XChangeProperty(IntPtr display, IntPtr window, IntPtr property, IntPtr type, int format, PropertyMode mode, IntPtr[] data, int nelements);

		[DllImport ("libX11", EntryPoint="XChangeProperty")]
		public extern static int XChangeProperty(IntPtr display, IntPtr window, IntPtr property, IntPtr type, int format, PropertyMode mode, IntPtr atoms, int nelements);

		[DllImport ("libX11", EntryPoint="XChangeProperty", CharSet=CharSet.Ansi)]
		public extern static int XChangeProperty(IntPtr display, IntPtr window, IntPtr property, IntPtr type, int format, PropertyMode mode, string text, int text_length);

		[DllImport ("libX11", EntryPoint="XDeleteProperty")]
		public extern static int XDeleteProperty(IntPtr display, IntPtr window, IntPtr property);

		// Drawing
		[DllImport ("libX11", EntryPoint="XCreateGC")]
		public extern static IntPtr XCreateGC(IntPtr display, IntPtr window, IntPtr valuemask, ref XGCValues values);

		[DllImport ("libX11", EntryPoint="XFreeGC")]
		public extern static int XFreeGC(IntPtr display, IntPtr gc);

		[DllImport ("libX11", EntryPoint="XSetFunction")]
		public extern static int XSetFunction(IntPtr display, IntPtr gc, GXFunction function);

		[DllImport ("libX11", EntryPoint="XSetLineAttributes")]
		public extern static int XSetLineAttributes(IntPtr display, IntPtr gc, int line_width, GCLineStyle line_style, GCCapStyle cap_style, GCJoinStyle join_style);

		[DllImport ("libX11", EntryPoint="XDrawLine")]
		public extern static int XDrawLine(IntPtr display, IntPtr drawable, IntPtr gc, int x1, int y1, int x2, int y2);

		[DllImport ("libX11", EntryPoint="XDrawRectangle")]
		public extern static int XDrawRectangle(IntPtr display, IntPtr drawable, IntPtr gc, int x1, int y1, int width, int height);

		[DllImport ("libX11", EntryPoint="XFillRectangle")]
		public extern static int XFillRectangle(IntPtr display, IntPtr drawable, IntPtr gc, int x1, int y1, int width, int height);

		[DllImport ("libX11", EntryPoint="XSetWindowBackground")]
		public extern static int XSetWindowBackground(IntPtr display, IntPtr window, IntPtr background);

		[DllImport ("libX11", EntryPoint="XCopyArea")]
		public extern static int XCopyArea(IntPtr display, IntPtr src, IntPtr dest, IntPtr gc, int src_x, int src_y, int width, int height, int dest_x, int dest_y);

		[DllImport ("libX11", EntryPoint="XGetWindowProperty")]
		public extern static int XGetWindowProperty(IntPtr display, IntPtr window, IntPtr atom, IntPtr long_offset, IntPtr long_length, bool delete, IntPtr req_type, out IntPtr actual_type, out int actual_format, out IntPtr nitems, out IntPtr bytes_after, ref IntPtr prop);

		[DllImport ("libX11", EntryPoint="XSetInputFocus")]
		public extern static int XSetInputFocus(IntPtr display, IntPtr window, RevertTo revert_to, IntPtr time);

		[DllImport ("libX11", EntryPoint="XIconifyWindow")]
		public extern static int XIconifyWindow(IntPtr display, IntPtr window, int screen_number);

		[DllImport ("libX11", EntryPoint="XDefineCursor")]
		public extern static int XDefineCursor(IntPtr display, IntPtr window, IntPtr cursor);

		[DllImport ("libX11", EntryPoint="XUndefineCursor")]
		public extern static int XUndefineCursor(IntPtr display, IntPtr window);

		[DllImport ("libX11", EntryPoint="XFreeCursor")]
		public extern static int XFreeCursor(IntPtr display, IntPtr cursor);

		[DllImport ("libX11", EntryPoint="XCreateFontCursor")]
		public extern static IntPtr XCreateFontCursor(IntPtr display, CursorFontShape shape);

		[DllImport ("libX11", EntryPoint="XCreatePixmapCursor")]
		public extern static IntPtr XCreatePixmapCursor(IntPtr display, IntPtr source, IntPtr mask, ref XColor foreground_color, ref XColor background_color, int x_hot, int y_hot);

		[DllImport ("libX11", EntryPoint="XCreatePixmapFromBitmapData")]
		public extern static IntPtr XCreatePixmapFromBitmapData(IntPtr display, IntPtr drawable, byte[] data, int width, int height, IntPtr fg, IntPtr bg, int depth);

		[DllImport ("libX11", EntryPoint="XCreatePixmap")]
		public extern static IntPtr XCreatePixmap(IntPtr display, IntPtr d, int width, int height, int depth);

		[DllImport ("libX11", EntryPoint="XFreePixmap")]
		public extern static IntPtr XFreePixmap(IntPtr display, IntPtr pixmap);

		[DllImport ("libX11", EntryPoint="XQueryBestCursor")]
		public extern static int XQueryBestCursor(IntPtr display, IntPtr drawable, int width, int height, out int best_width, out int best_height);

		[DllImport ("libX11", EntryPoint="XQueryExtension")]
		public extern static int XQueryExtension(IntPtr display, string extension_name, ref int major, ref int first_event, ref int first_error);

		[DllImport ("libX11", EntryPoint="XWhitePixel")]
		public extern static UIntPtr XWhitePixel(IntPtr display, int screen_no);

		[DllImport ("libX11", EntryPoint="XBlackPixel")]
		public extern static UIntPtr XBlackPixel(IntPtr display, int screen_no);

		[DllImport ("libX11", EntryPoint="XGrabServer")]
		public extern static void XGrabServer(IntPtr display);

		[DllImport ("libX11", EntryPoint="XUngrabServer")]
		public extern static void XUngrabServer(IntPtr display);

		[DllImport ("libX11", EntryPoint="XGetWMNormalHints")]
		public extern static void XGetWMNormalHints(IntPtr display, IntPtr window, ref XSizeHints hints, out IntPtr supplied_return);

		[DllImport ("libX11", EntryPoint="XSetWMNormalHints")]
		public extern static void XSetWMNormalHints(IntPtr display, IntPtr window, ref XSizeHints hints);

		[DllImport ("libX11", EntryPoint="XSetZoomHints")]
		public extern static void XSetZoomHints(IntPtr display, IntPtr window, ref XSizeHints hints);

		[DllImport ("libX11", EntryPoint="XSetWMHints")]
		public extern static void XSetWMHints(IntPtr display, IntPtr window, ref XWMHints wmhints);

		[DllImport ("libX11", EntryPoint="XGetIconSizes")]
		public extern static int XGetIconSizes(IntPtr display, IntPtr window, out IntPtr size_list, out int count);

		[DllImport ("libX11", EntryPoint="XSetErrorHandler")]
		public extern static IntPtr XSetErrorHandler(XErrorHandler error_handler);

		[DllImport ("libX11", EntryPoint="XGetErrorText")]
		public extern static IntPtr XGetErrorText(IntPtr display, byte code, StringBuilder buffer, int length);

		[DllImport ("libX11", EntryPoint="XInitThreads")]
		public extern static int XInitThreads();

		[DllImport ("libX11", EntryPoint="XConvertSelection")]
		public extern static int XConvertSelection(IntPtr display, IntPtr selection, IntPtr target, IntPtr property, IntPtr requestor, IntPtr time);

		[DllImport ("libX11", EntryPoint="XGetSelectionOwner")]
		public extern static IntPtr XGetSelectionOwner(IntPtr display, IntPtr selection);

		[DllImport ("libX11", EntryPoint="XSetSelectionOwner")]
		public extern static int XSetSelectionOwner(IntPtr display, IntPtr selection, IntPtr owner, IntPtr time);

		[DllImport ("libX11", EntryPoint="XSetPlaneMask")]
		public extern static int XSetPlaneMask(IntPtr display, IntPtr gc, IntPtr mask);

		[DllImport ("libX11", EntryPoint="XSetForeground")]
		public extern static int XSetForeground(IntPtr display, IntPtr gc, UIntPtr foreground);

		[DllImport ("libX11", EntryPoint="XSetBackground")]
		public extern static int XSetBackground(IntPtr display, IntPtr gc, UIntPtr background);

		[DllImport ("libX11", EntryPoint="XBell")]
		public extern static int XBell(IntPtr display, int percent);

		[DllImport ("libX11", EntryPoint="XChangeActivePointerGrab")]
		public extern static int XChangeActivePointerGrab (IntPtr display, EventMask event_mask, IntPtr cursor, IntPtr time);

		[DllImport ("libX11", EntryPoint="XFilterEvent")]
		public extern static bool XFilterEvent(ref XEvent xevent, IntPtr window);

		[DllImport ("libX11", EntryPoint="XkbSetDetectableAutoRepeat")]
		public extern static void XkbSetDetectableAutoRepeat (IntPtr display, bool detectable, IntPtr supported);

		[DllImport ("libX11", EntryPoint="XPeekEvent")]
		public extern static void XPeekEvent (IntPtr display, ref XEvent xevent);

		[DllImport ("libX11", EntryPoint="XIfEvent")]
		public extern static void XIfEvent (IntPtr display, ref XEvent xevent, Delegate event_predicate, IntPtr arg);

        [DllImport("libX11")]
        public extern static void XQueryColor(IntPtr dpy, IntPtr colormap, ref XColor def_in_out);

		[DllImport ("libX11")]
		public static extern IntPtr XGetKeyboardMapping (IntPtr display, byte first_keycode, int keycode_count, 
				out int keysyms_per_keycode_return);

		[DllImport ("libX11")]
		public static extern void XDisplayKeycodes (IntPtr display, out int min, out int max);

		[DllImport ("libX11")]
		public static extern UIntPtr XKeycodeToKeysym (IntPtr display, byte keycode, int index);

		[DllImport ("libX11")]
		public static extern byte XKeysymToKeycode (IntPtr display, UIntPtr keysym);
		
		#endregion
	}
}
