using System;
using System.Collections.Generic;
using System.Text;

namespace X11Binding
{
    public class X11Atoms
    {
        // Atoms
        public static IntPtr WM_PROTOCOLS;
        public static IntPtr WM_DELETE_WINDOW;
        public static IntPtr WM_TAKE_FOCUS;
        //public static IntPtr _NET_SUPPORTED;
        //public static IntPtr _NET_CLIENT_LIST;
        //public static IntPtr _NET_NUMBER_OF_DESKTOPS;
        public static IntPtr _NET_DESKTOP_GEOMETRY;
        //public static IntPtr _NET_DESKTOP_VIEWPORT;
        public static IntPtr _NET_CURRENT_DESKTOP;
        //public static IntPtr _NET_DESKTOP_NAMES;
        public static IntPtr _NET_ACTIVE_WINDOW;
        public static IntPtr _NET_WORKAREA;
        //public static IntPtr _NET_SUPPORTING_WM_CHECK;
        //public static IntPtr _NET_VIRTUAL_ROOTS;
        //public static IntPtr _NET_DESKTOP_LAYOUT;
        //public static IntPtr _NET_SHOWING_DESKTOP;
        //public static IntPtr _NET_CLOSE_WINDOW;
        //public static IntPtr _NET_MOVERESIZE_WINDOW;
        //public static IntPtr _NET_WM_MOVERESIZE;
        //public static IntPtr _NET_RESTACK_WINDOW;
        //public static IntPtr _NET_REQUEST_FRAME_EXTENTS;
        public static IntPtr _NET_WM_NAME;
        //public static IntPtr _NET_WM_VISIBLE_NAME;
        //public static IntPtr _NET_WM_ICON_NAME;
        //public static IntPtr _NET_WM_VISIBLE_ICON_NAME;
        //public static IntPtr _NET_WM_DESKTOP;
        public static IntPtr _NET_WM_WINDOW_TYPE;
        public static IntPtr _NET_WM_STATE;
        //public static IntPtr _NET_WM_ALLOWED_ACTIONS;
        //public static IntPtr _NET_WM_STRUT;
        //public static IntPtr _NET_WM_STRUT_PARTIAL;
        //public static IntPtr _NET_WM_ICON_GEOMETRY;
        public static IntPtr _NET_WM_ICON;
        //public static IntPtr _NET_WM_PID;
        //public static IntPtr _NET_WM_HANDLED_ICONS;
        public static IntPtr _NET_WM_USER_TIME;
        public static IntPtr _NET_FRAME_EXTENTS;
        //public static IntPtr _NET_WM_PING;
        //public static IntPtr _NET_WM_SYNC_REQUEST;
        public static IntPtr _NET_SYSTEM_TRAY_S;
        //public static IntPtr _NET_SYSTEM_TRAY_ORIENTATION;
        public static IntPtr _NET_SYSTEM_TRAY_OPCODE;
        public static IntPtr _NET_WM_STATE_MAXIMIZED_HORZ;
        public static IntPtr _NET_WM_STATE_MAXIMIZED_VERT;
        public static IntPtr _XEMBED;
        public static IntPtr _XEMBED_INFO;
        public static IntPtr _MOTIF_WM_HINTS;
        public static IntPtr _NET_WM_STATE_SKIP_TASKBAR;
        public static IntPtr _NET_WM_STATE_ABOVE;
        public static IntPtr _NET_WM_STATE_MODAL;
        public static IntPtr _NET_WM_STATE_HIDDEN;
        public static IntPtr _NET_WM_CONTEXT_HELP;
        public static IntPtr _NET_WM_WINDOW_OPACITY;
        //public static IntPtr _NET_WM_WINDOW_TYPE_DESKTOP;
        //public static IntPtr _NET_WM_WINDOW_TYPE_DOCK;
        //public static IntPtr _NET_WM_WINDOW_TYPE_TOOLBAR;
        //public static IntPtr _NET_WM_WINDOW_TYPE_MENU;
        public static IntPtr _NET_WM_WINDOW_TYPE_UTILITY;
        //public static IntPtr _NET_WM_WINDOW_TYPE_SPLASH;
        // public static IntPtr _NET_WM_WINDOW_TYPE_DIALOG;
        public static IntPtr _NET_WM_WINDOW_TYPE_NORMAL;
        public static IntPtr CLIPBOARD;
        public static IntPtr PRIMARY;
        //public static IntPtr DIB;
        public static IntPtr OEMTEXT;
        public static IntPtr UTF8_STRING;
        public static IntPtr UTF16_STRING;
        public static IntPtr RICHTEXTFORMAT;
        public static IntPtr TARGETS;

        public static void SetupAtoms(IntPtr dpy)
        {
            string[] atom_names = new string[] {
				"WM_PROTOCOLS",
				"WM_DELETE_WINDOW",
				"WM_TAKE_FOCUS",
				//"_NET_SUPPORTED",
				//"_NET_CLIENT_LIST",
				//"_NET_NUMBER_OF_DESKTOPS",
				"_NET_DESKTOP_GEOMETRY",
				//"_NET_DESKTOP_VIEWPORT",
				"_NET_CURRENT_DESKTOP",
				//"_NET_DESKTOP_NAMES",
				"_NET_ACTIVE_WINDOW",
				"_NET_WORKAREA",
				//"_NET_SUPPORTING_WM_CHECK",
				//"_NET_VIRTUAL_ROOTS",
				//"_NET_DESKTOP_LAYOUT",
				//"_NET_SHOWING_DESKTOP",
				//"_NET_CLOSE_WINDOW",
				//"_NET_MOVERESIZE_WINDOW",
				//"_NET_WM_MOVERESIZE",
				//"_NET_RESTACK_WINDOW",
				//"_NET_REQUEST_FRAME_EXTENTS",
				"_NET_WM_NAME",
				//"_NET_WM_VISIBLE_NAME",
				//"_NET_WM_ICON_NAME",
				//"_NET_WM_VISIBLE_ICON_NAME",
				//"_NET_WM_DESKTOP",
				"_NET_WM_WINDOW_TYPE",
				"_NET_WM_STATE",
				//"_NET_WM_ALLOWED_ACTIONS",
				//"_NET_WM_STRUT",
				//"_NET_WM_STRUT_PARTIAL",
				//"_NET_WM_ICON_GEOMETRY",
				"_NET_WM_ICON",
				//"_NET_WM_PID",
				//"_NET_WM_HANDLED_ICONS",
				"_NET_WM_USER_TIME",
				"_NET_FRAME_EXTENTS",
				//"_NET_WM_PING",
				//"_NET_WM_SYNC_REQUEST",
				"_NET_SYSTEM_TRAY_OPCODE",
				//"_NET_SYSTEM_TRAY_ORIENTATION",
				"_NET_WM_STATE_MAXIMIZED_HORZ",
				"_NET_WM_STATE_MAXIMIZED_VERT",
				"_NET_WM_STATE_HIDDEN",
				"_XEMBED",
				"_XEMBED_INFO",
				"_MOTIF_WM_HINTS",
				"_NET_WM_STATE_SKIP_TASKBAR",
				"_NET_WM_STATE_ABOVE",
				"_NET_WM_STATE_MODAL",
				"_NET_WM_CONTEXT_HELP",
				"_NET_WM_WINDOW_OPACITY",
				//"_NET_WM_WINDOW_TYPE_DESKTOP",
				//"_NET_WM_WINDOW_TYPE_DOCK",
				//"_NET_WM_WINDOW_TYPE_TOOLBAR",
				//"_NET_WM_WINDOW_TYPE_MENU",
				"_NET_WM_WINDOW_TYPE_UTILITY",
				// "_NET_WM_WINDOW_TYPE_DIALOG",
				//"_NET_WM_WINDOW_TYPE_SPLASH",
				"_NET_WM_WINDOW_TYPE_NORMAL",
				"CLIPBOARD",
				"PRIMARY",
				"COMPOUND_TEXT",
				"UTF8_STRING",
				"UTF16_STRING",
				"RICHTEXTFORMAT",
				"TARGETS"
			};
            IntPtr[] atoms = new IntPtr[atom_names.Length];
            X11Methods.XInternAtoms(dpy, atom_names, atom_names.Length, false, atoms);

            int off = 0;
            WM_PROTOCOLS = atoms[off++];
            WM_DELETE_WINDOW = atoms[off++];
            WM_TAKE_FOCUS = atoms[off++];
            //_NET_SUPPORTED = atoms [off++];
            //_NET_CLIENT_LIST = atoms [off++];
            //_NET_NUMBER_OF_DESKTOPS = atoms [off++];
            _NET_DESKTOP_GEOMETRY = atoms[off++];
            //_NET_DESKTOP_VIEWPORT = atoms [off++];
            _NET_CURRENT_DESKTOP = atoms[off++];
            //_NET_DESKTOP_NAMES = atoms [off++];
            _NET_ACTIVE_WINDOW = atoms[off++];
            _NET_WORKAREA = atoms[off++];
            //_NET_SUPPORTING_WM_CHECK = atoms [off++];
            //_NET_VIRTUAL_ROOTS = atoms [off++];
            //_NET_DESKTOP_LAYOUT = atoms [off++];
            //_NET_SHOWING_DESKTOP = atoms [off++];
            //_NET_CLOSE_WINDOW = atoms [off++];
            //_NET_MOVERESIZE_WINDOW = atoms [off++];
            //_NET_WM_MOVERESIZE = atoms [off++];
            //_NET_RESTACK_WINDOW = atoms [off++];
            //_NET_REQUEST_FRAME_EXTENTS = atoms [off++];
            _NET_WM_NAME = atoms[off++];
            //_NET_WM_VISIBLE_NAME = atoms [off++];
            //_NET_WM_ICON_NAME = atoms [off++];
            //_NET_WM_VISIBLE_ICON_NAME = atoms [off++];
            //_NET_WM_DESKTOP = atoms [off++];
            _NET_WM_WINDOW_TYPE = atoms[off++];
            _NET_WM_STATE = atoms[off++];
            //_NET_WM_ALLOWED_ACTIONS = atoms [off++];
            //_NET_WM_STRUT = atoms [off++];
            //_NET_WM_STRUT_PARTIAL = atoms [off++];
            //_NET_WM_ICON_GEOMETRY = atoms [off++];
            _NET_WM_ICON = atoms[off++];
            //_NET_WM_PID = atoms [off++];
            //_NET_WM_HANDLED_ICONS = atoms [off++];
            _NET_WM_USER_TIME = atoms[off++];
            _NET_FRAME_EXTENTS = atoms[off++];
            //_NET_WM_PING = atoms [off++];
            //_NET_WM_SYNC_REQUEST = atoms [off++];
            _NET_SYSTEM_TRAY_OPCODE = atoms[off++];
            //_NET_SYSTEM_TRAY_ORIENTATION = atoms [off++];
            _NET_WM_STATE_MAXIMIZED_HORZ = atoms[off++];
            _NET_WM_STATE_MAXIMIZED_VERT = atoms[off++];
            _NET_WM_STATE_HIDDEN = atoms[off++];
            _XEMBED = atoms[off++];
            _XEMBED_INFO = atoms[off++];
            _MOTIF_WM_HINTS = atoms[off++];
            _NET_WM_STATE_SKIP_TASKBAR = atoms[off++];
            _NET_WM_STATE_ABOVE = atoms[off++];
            _NET_WM_STATE_MODAL = atoms[off++];
            _NET_WM_CONTEXT_HELP = atoms[off++];
            _NET_WM_WINDOW_OPACITY = atoms[off++];
            //_NET_WM_WINDOW_TYPE_DESKTOP = atoms [off++];
            //_NET_WM_WINDOW_TYPE_DOCK = atoms [off++];
            //_NET_WM_WINDOW_TYPE_TOOLBAR = atoms [off++];
            //_NET_WM_WINDOW_TYPE_MENU = atoms [off++];
            _NET_WM_WINDOW_TYPE_UTILITY = atoms[off++];
            // _NET_WM_WINDOW_TYPE_DIALOG = atoms [off++];
            //_NET_WM_WINDOW_TYPE_SPLASH = atoms [off++];
            _NET_WM_WINDOW_TYPE_NORMAL = atoms[off++];
            CLIPBOARD = atoms[off++];
            PRIMARY = atoms[off++];
            OEMTEXT = atoms[off++];
            UTF8_STRING = atoms[off++];
            UTF16_STRING = atoms[off++];
            RICHTEXTFORMAT = atoms[off++];
            TARGETS = atoms[off++];
        }
    }
}
