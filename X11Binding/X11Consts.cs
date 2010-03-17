// Ripped from Mono source code SVN v135711 (/mcs/class/Managed.Windows.Forms/System.Windows.Forms/XPlayUIStructs.cs),
// Minor modifications are made
// Matt Guo		rguo@novell.com

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace X11Binding
{
	public class X11Consts
	{
		/*****************************************************************
	     * RESERVED RESOURCE AND CONSTANT DEFINITIONS
	     *****************************************************************/
	
	    public const long None = 0L ; /* universal null resource or null atom */
	
	    /* background pixmap in CreateWindow and ChangeWindowAttributes */
	    public const long ParentRelative = 1L ;
	
	    /* border pixmap in CreateWindow and ChangeWindowAttributes special
	     * VisualID and special window class passed to CreateWindow */
	    public const long CopyFromParent = 0L ;
	
	    public const long PointerWindow = 0L ; /* destination window in SendEvent */
	    public const long InputFocus = 1L ; /* destination window in SendEvent */
	
	    public const long PointerRoot = 1L ; /* focus window in SetInputFocus */
	
	    public const long AnyPropertyType = 0L ; /* special Atom, passed to GetProperty */
	
	    public const long AnyKey = 0L ; /* special Key Code, passed to GrabKey */
	
	    public const long AnyButton = 0L ; /* special Button Code, passed to GrabButton */
	
	    public const long AllTemporary = 0L ; /* special Resource ID passed to KillClient */
	
	    public const ulong CurrentTime = 0L ; /* special Time */
	
	    public const long NoSymbol = 0L ; /* special KeySym */
	
	    /*****************************************************************
	     * EVENT DEFINITIONS
	     *****************************************************************/
	
	    /* Input Event Masks. Used as event-mask window attribute and as arguments
	       to Grab requests.  Not to be confused with event names.  */
	
	    public const long NoEventMask = 0L ;
	    public const long KeyPressMask = (1L<<0) ;
	    public const long KeyReleaseMask = (1L<<1) ;
	    public const long ButtonPressMask = (1L<<2) ;
	    public const long ButtonReleaseMask = (1L<<3) ;
	    public const long EnterWindowMask = (1L<<4) ;
	    public const long LeaveWindowMask = (1L<<5) ;
	    public const long PointerMotionMask = (1L<<6) ;
	    public const long PointerMotionHintMask = (1L<<7) ;
	    public const long Button1MotionMask = (1L<<8) ;
	    public const long Button2MotionMask = (1L<<9) ;
	    public const long Button3MotionMask = (1L<<10) ;
	    public const long Button4MotionMask = (1L<<11) ;
	    public const long Button5MotionMask = (1L<<12) ;
	    public const long ButtonMotionMask = (1L<<13) ;
	    public const long KeymapStateMask = (1L<<14) ;
	    public const long ExposureMask = (1L<<15) ;
	    public const long VisibilityChangeMask = (1L<<16) ;
	    public const long StructureNotifyMask = (1L<<17) ;
	    public const long ResizeRedirectMask = (1L<<18) ;
	    public const long SubstructureNotifyMask = (1L<<19) ;
	    public const long SubstructureRedirectMask = (1L<<20) ;
	    public const long FocusChangeMask = (1L<<21) ;
	    public const long PropertyChangeMask = (1L<<22) ;
	    public const long ColormapChangeMask = (1L<<23) ;
	    public const long OwnerGrabButtonMask = (1L<<24) ;
	
	    /* Event names.  Used in "type" field in XEvent structures.  Not to be
	    confused with event masks above.  They start from 2 because 0 and 1
	    are reserved in the protocol for errors and replies. */
	
	    public const int KeyPress = 2 ;
	    public const int KeyRelease = 3 ;
	    public const int ButtonPress = 4 ;
	    public const int ButtonRelease = 5 ;
	    public const int MotionNotify = 6 ;
	    public const int EnterNotify = 7 ;
	    public const int LeaveNotify = 8 ;
	    public const int FocusIn = 9 ;
	    public const int FocusOut = 10 ;
	    public const int KeymapNotify = 11 ;
	    public const int Expose = 12 ;
	    public const int GraphicsExpose = 13 ;
	    public const int NoExpose = 14 ;
	    public const int VisibilityNotify = 15 ;
	    public const int CreateNotify = 16 ;
	    public const int DestroyNotify = 17 ;
	    public const int UnmapNotify = 18 ;
	    public const int MapNotify = 19 ;
	    public const int MapRequest = 20 ;
	    public const int ReparentNotify = 21 ;
	    public const int ConfigureNotify = 22 ;
	    public const int ConfigureRequest = 23 ;
	    public const int GravityNotify = 24 ;
	    public const int ResizeRequest = 25 ;
	    public const int CirculateNotify = 26 ;
	    public const int CirculateRequest = 27 ;
	    public const int PropertyNotify = 28 ;
	    public const int SelectionClear = 29 ;
	    public const int SelectionRequest = 30 ;
	    public const int SelectionNotify = 31 ;
	    public const int ColormapNotify = 32 ;
	    public const int ClientMessage = 33 ;
	    public const int MappingNotify = 34 ;
	    public const int LASTEvent = 35 ; /* must be bigger than any event # */
	
	
	    /* Key masks. Used as modifiers to GrabButton and GrabKey, results of QueryPointer,
	       state in various key-, mouse-, and button-related events. */
	
	    public const int ShiftMask = (1<<0) ;
	    public const int LockMask = (1<<1) ;
	    public const int ControlMask = (1<<2) ;
	    public const int Mod1Mask = (1<<3) ;
	    public const int Mod2Mask = (1<<4) ;
	    public const int Mod3Mask = (1<<5) ;
	    public const int Mod4Mask = (1<<6) ;
	    public const int Mod5Mask = (1<<7) ;
	
	    /* modifier names.  Used to build a SetModifierMapping request or
	       to read a GetModifierMapping request.  These correspond to the
	       masks defined above. */
	    public const int ShiftMapIndex = 0 ;
	    public const int LockMapIndex = 1 ;
	    public const int ControlMapIndex = 2 ;
	    public const int Mod1MapIndex = 3 ;
	    public const int Mod2MapIndex = 4 ;
	    public const int Mod3MapIndex = 5 ;
	    public const int Mod4MapIndex = 6 ;
	    public const int Mod5MapIndex = 7 ;
	
	
	    /* button masks.  Used in same manner as Key masks above. Not to be confused
	       with button names below. */
	
	    public const int Button1Mask = (1<<8) ;
	    public const int Button2Mask = (1<<9) ;
	    public const int Button3Mask = (1<<10) ;
	    public const int Button4Mask = (1<<11) ;
	    public const int Button5Mask = (1<<12) ;
	
	    public const int AnyModifier = (1<<15) ; /* used in GrabButton, GrabKey */
	
	
	    /* button names. Used as arguments to GrabButton and as detail in ButtonPress
	       and ButtonRelease events.  Not to be confused with button masks above.
	       Note that 0 is already defined above as "AnyButton".  */
	
	    public const int Button1 = 1 ;
	    public const int Button2 = 2 ;
	    public const int Button3 = 3 ;
	    public const int Button4 = 4 ;
	    public const int Button5 = 5 ;
	
	    /* Notify modes */
	
	    public const int NotifyNormal = 0 ;
	    public const int NotifyGrab = 1 ;
	    public const int NotifyUngrab = 2 ;
	    public const int NotifyWhileGrabbed = 3 ;
	
	    public const int NotifyHint = 1 ; /* for MotionNotify events */
	
	    /* Notify detail */
	
	    public const int NotifyAncestor = 0 ;
	    public const int NotifyVirtual = 1 ;
	    public const int NotifyInferior = 2 ;
	    public const int NotifyNonlinear = 3 ;
	    public const int NotifyNonlinearVirtual = 4 ;
	    public const int NotifyPointer = 5 ;
	    public const int NotifyPointerRoot = 6 ;
	    public const int NotifyDetailNone = 7 ;
	
	    /* Visibility notify */
	
	    public const int VisibilityUnobscured = 0 ;
	    public const int VisibilityPartiallyObscured = 1 ;
	    public const int VisibilityFullyObscured = 2 ;
	
	    /* Circulation request */
	
	    public const int PlaceOnTop = 0 ;
	    public const int PlaceOnBottom = 1 ;
	
	    /* protocol families */
	
	    public const int FamilyInternet = 0 ;
	    public const int FamilyDECnet = 1 ;
	    public const int FamilyChaos = 2 ;
	
	    /* Property notification */
	
	    public const int PropertyNewValue = 0 ;
	    public const int PropertyDelete = 1 ;
	
	    /* Color Map notification */
	
	    public const int ColormapUninstalled = 0 ;
	    public const int ColormapInstalled = 1 ;
	
	    /* GrabPointer, GrabButton, GrabKeyboard, GrabKey Modes */
	
	    public const int GrabModeSync = 0 ;
	    public const int GrabModeAsync = 1 ;
	
	    /* GrabPointer, GrabKeyboard reply status */
	
	    public const int GrabSuccess = 0 ;
	    public const int AlreadyGrabbed = 1 ;
	    public const int GrabInvalidTime = 2 ;
	    public const int GrabNotViewable = 3 ;
	    public const int GrabFrozen = 4 ;
	
	    /* AllowEvents modes */
	
	    public const int AsyncPointer = 0 ;
	    public const int SyncPointer = 1 ;
	    public const int ReplayPointer = 2 ;
	    public const int AsyncKeyboard = 3 ;
	    public const int SyncKeyboard = 4 ;
	    public const int ReplayKeyboard = 5 ;
	    public const int AsyncBoth = 6 ;
	    public const int SyncBoth = 7 ;
	
	    /* Used in SetInputFocus, GetInputFocus */
	
	    public const int RevertToNone = (int)None ;
	    public const int RevertToPointerRoot = (int)PointerRoot ;
	    public const int RevertToParent = 2 ;
	
	    /* Used in XEventsQueued */
	    public const int QueuedAlready = 0;
	    public const int QueuedAfterReading = 1;
	    public const int QueuedAfterFlush = 2;
	
	
	    /*****************************************************************
	     * ERROR CODES
	     *****************************************************************/
	
	    public const int Success = 0 ; /* everything's okay */
	    public const int BadRequest = 1 ; /* bad request code */
	    public const int BadValue = 2 ; /* int parameter out of range */
	    public const int BadWindow = 3 ; /* parameter not a Window */
	    public const int BadPixmap = 4 ; /* parameter not a Pixmap */
	    public const int BadAtom = 5 ; /* parameter not an Atom */
	    public const int BadCursor = 6 ; /* parameter not a Cursor */
	    public const int BadFont = 7 ; /* parameter not a Font */
	    public const int BadMatch = 8 ; /* parameter mismatch */
	    public const int BadDrawable = 9 ; /* parameter not a Pixmap or Window */
	    public const int BadAccess = 10 ; /* depending on context:
	                     - key/button already grabbed
	                     - attempt to free an illegal
	                       cmap entry
	                    - attempt to store into a read-only
	                       color map entry.
	                    - attempt to modify the access control
	                       list from other than the local host.
	                    */
	    public const int BadAlloc = 11 ; /* insufficient resources */
	    public const int BadColor = 12 ; /* no such colormap */
	    public const int BadGC = 13 ; /* parameter not a GC */
	    public const int BadIDChoice = 14 ; /* choice not in range or already used */
	    public const int BadName = 15 ; /* font or color name doesn't exist */
	    public const int BadLength = 16 ; /* Request length incorrect */
	    public const int BadImplementation = 17 ; /* server is defective */
	
	    public const int FirstExtensionError = 128 ;
	    public const int LastExtensionError = 255 ;
	
	    /*****************************************************************
	     * WINDOW DEFINITIONS
	     *****************************************************************/
	
	    /* Window classes used by CreateWindow */
	    /* Note that CopyFromParent is already defined as 0 above */
	
	    public const int InputOutput = 1 ;
	    public const int InputOnly = 2 ;
	
	    /* Window attributes for CreateWindow and ChangeWindowAttributes */
	
	    public const long CWBackPixmap = (1L<<0) ;
	    public const long CWBackPixel = (1L<<1) ;
	    public const long CWBorderPixmap = (1L<<2) ;
	    public const long CWBorderPixel = (1L<<3) ;
	    public const long CWBitGravity = (1L<<4) ;
	    public const long CWWinGravity = (1L<<5) ;
	    public const long CWBackingStore = (1L<<6) ;
	    public const long CWBackingPlanes = (1L<<7) ;
	    public const long CWBackingPixel = (1L<<8) ;
	    public const long CWOverrideRedirect = (1L<<9) ;
	    public const long CWSaveUnder = (1L<<10) ;
	    public const long CWEventMask = (1L<<11) ;
	    public const long CWDontPropagate = (1L<<12) ;
	    public const long CWColormap = (1L<<13) ;
	    public const long CWCursor = (1L<<14) ;
	
	    /* ConfigureWindow structure */
	
	    public const int CWX = (1<<0) ;
	    public const int CWY = (1<<1) ;
	    public const int CWWidth = (1<<2) ;
	    public const int CWHeight = (1<<3) ;
	    public const int CWBorderWidth = (1<<4) ;
	    public const int CWSibling = (1<<5) ;
	    public const int CWStackMode = (1<<6) ;
	
	
	    /* Bit Gravity */
	
	    public const int ForgetGravity = 0 ;
	    public const int NorthWestGravity = 1 ;
	    public const int NorthGravity = 2 ;
	    public const int NorthEastGravity = 3 ;
	    public const int WestGravity = 4 ;
	    public const int CenterGravity = 5 ;
	    public const int EastGravity = 6 ;
	    public const int SouthWestGravity = 7 ;
	    public const int SouthGravity = 8 ;
	    public const int SouthEastGravity = 9 ;
	    public const int StaticGravity = 10 ;
	
	    /* Window gravity + bit gravity above */
	
	    public const int UnmapGravity = 0 ;
	
	    /* Used in CreateWindow for backing-store hint */
	
	    public const int NotUseful = 0 ;
	    public const int WhenMapped = 1 ;
	    public const int Always = 2 ;
	
	    /* Used in GetWindowAttributes reply */
	
	    public const int IsUnmapped = 0 ;
	    public const int IsUnviewable = 1 ;
	    public const int IsViewable = 2 ;
	
	    /* Used in ChangeSaveSet */
	
	    public const int SetModeInsert = 0 ;
	    public const int SetModeDelete = 1 ;
	
	    /* Used in ChangeCloseDownMode */
	
	    public const int DestroyAll = 0 ;
	    public const int RetainPermanent = 1 ;
	    public const int RetainTemporary = 2 ;
	
	    /* Window stacking method (in configureWindow) */
	
	    public const int Above = 0 ;
	    public const int Below = 1 ;
	    public const int TopIf = 2 ;
	    public const int BottomIf = 3 ;
	    public const int Opposite = 4 ;
	
	    /* Circulation direction */
	
	    public const int RaiseLowest = 0 ;
	    public const int LowerHighest = 1 ;
	
	    /* Property modes */
	
	    public const int PropModeReplace = 0 ;
	    public const int PropModePrepend = 1 ;
	    public const int PropModeAppend = 2 ;
	
	    /*****************************************************************
	     * GRAPHICS DEFINITIONS
	     *****************************************************************/
	
	    /* graphics functions, as in GC.alu */
	
	    public const int GXclear = 0x0 ; /* 0 */
	    public const int GXand = 0x1 ; /* src AND dst */
	    public const int GXandReverse = 0x2 ; /* src AND NOT dst */
	    public const int GXcopy = 0x3 ; /* src */
	    public const int GXandInverted = 0x4 ; /* NOT src AND dst */
	    public const int GXnoop = 0x5 ; /* dst */
	    public const int GXxor = 0x6 ; /* src XOR dst */
	    public const int GXor = 0x7 ; /* src OR dst */
	    public const int GXnor = 0x8 ; /* NOT src AND NOT dst */
	    public const int GXequiv = 0x9 ; /* NOT src XOR dst */
	    public const int GXinvert = 0xa ; /* NOT dst */
	    public const int GXorReverse = 0xb ; /* src OR NOT dst */
	    public const int GXcopyInverted = 0xc ; /* NOT src */
	    public const int GXorInverted = 0xd ; /* NOT src OR dst */
	    public const int GXnand = 0xe ; /* NOT src OR NOT dst */
	    public const int GXset = 0xf ; /* 1 */
	
	    /* LineStyle */
	
	    public const int LineSolid = 0 ;
	    public const int LineOnOffDash = 1 ;
	    public const int LineDoubleDash = 2 ;
	
	    /* capStyle */
	
	    public const int CapNotLast = 0 ;
	    public const int CapButt = 1 ;
	    public const int CapRound = 2 ;
	    public const int CapProjecting = 3 ;
	
	    /* joinStyle */
	
	    public const int JoinMiter = 0 ;
	    public const int JoinRound = 1 ;
	    public const int JoinBevel = 2 ;
	
	    /* fillStyle */
	
	    public const int FillSolid = 0 ;
	    public const int FillTiled = 1 ;
	    public const int FillStippled = 2 ;
	    public const int FillOpaqueStippled = 3 ;
	
	    /* fillRule */
	
	    public const int EvenOddRule = 0 ;
	    public const int WindingRule = 1 ;
	
	    /* subwindow mode */
	
	    public const int ClipByChildren = 0 ;
	    public const int IncludeInferiors = 1 ;
	
	    /* SetClipRectangles ordering */
	
	    public const int Unsorted = 0 ;
	    public const int YSorted = 1 ;
	    public const int YXSorted = 2 ;
	    public const int YXBanded = 3 ;
	
	    /* CoordinateMode for drawing routines */
	
	    public const int CoordModeOrigin = 0 ; /* relative to the origin */
	    public const int CoordModePrevious = 1 ; /* relative to previous point */
	
	    /* Polygon shapes */
	
	    public const int Complex = 0 ; /* paths may intersect */
	    public const int Nonconvex = 1 ; /* no paths intersect, but not convex */
	    public const int Convex = 2 ; /* wholly convex */
	
	    /* Arc modes for PolyFillArc */
	
	    public const int ArcChord = 0 ; /* join endpoints of arc */
	    public const int ArcPieSlice = 1 ; /* join endpoints to center of arc */
	
	    /* GC components: masks used in CreateGC, CopyGC, ChangeGC, OR'ed into
	       GC.stateChanges */
	
	    public const long GCFunction = (1L<<0) ;
	    public const long GCPlaneMask = (1L<<1) ;
	    public const long GCForeground = (1L<<2) ;
	    public const long GCBackground = (1L<<3) ;
	    public const long GCLineWidth = (1L<<4) ;
	    public const long GCLineStyle = (1L<<5) ;
	    public const long GCCapStyle = (1L<<6) ;
	    public const long GCJoinStyle = (1L<<7) ;
	    public const long GCFillStyle = (1L<<8) ;
	    public const long GCFillRule = (1L<<9) ;
	    public const long GCTile = (1L<<10) ;
	    public const long GCStipple = (1L<<11) ;
	    public const long GCTileStipXOrigin = (1L<<12) ;
	    public const long GCTileStipYOrigin = (1L<<13) ;
	    public const long GCFont = (1L<<14) ;
	    public const long GCSubwindowMode = (1L<<15) ;
	    public const long GCGraphicsExposures = (1L<<16) ;
	    public const long GCClipXOrigin = (1L<<17) ;
	    public const long GCClipYOrigin = (1L<<18) ;
	    public const long GCClipMask = (1L<<19) ;
	    public const long GCDashOffset = (1L<<20) ;
	    public const long GCDashList = (1L<<21) ;
	    public const long GCArcMode = (1L<<22) ;
	
	    public const int GCLastBit = 22 ;
	    /*****************************************************************
	     * FONTS
	     *****************************************************************/
	
	    /* used in QueryFont -- draw direction */
	
	    public const int FontLeftToRight = 0 ;
	    public const int FontRightToLeft = 1 ;
	
	    public const int FontChange = 255 ;
	
	    /*****************************************************************
	     *  IMAGING
	     *****************************************************************/
	
	    /* ImageFormat -- PutImage, GetImage */
	
	    public const int XYBitmap = 0 ; /* depth 1, XYFormat */
	    public const int XYPixmap = 1 ; /* depth == drawable depth */
	    public const int ZPixmap = 2 ; /* depth == drawable depth */
	
	    /*****************************************************************
	     *  COLOR MAP STUFF
	     *****************************************************************/
	
	    /* For CreateColormap */
	
	    public const int AllocNone = 0 ; /* create map with no entries */
	    public const int AllocAll = 1 ; /* allocate entire map writeable */
	
	
	    /* Flags used in StoreNamedColor, StoreColors */
	
	    public const int DoRed = (1<<0) ;
	    public const int DoGreen = (1<<1) ;
	    public const int DoBlue = (1<<2) ;
	
	    /*****************************************************************
	     * CURSOR STUFF
	     *****************************************************************/
	
	    /* QueryBestSize Class */
	
	    public const int CursorShape = 0 ; /* largest size that can be displayed */
	    public const int TileShape = 1 ; /* size tiled fastest */
	    public const int StippleShape = 2 ; /* size stippled fastest */
	
	    /*****************************************************************
	     * KEYBOARD/POINTER STUFF
	     *****************************************************************/
	
	    public const int AutoRepeatModeOff = 0 ;
	    public const int AutoRepeatModeOn = 1 ;
	    public const int AutoRepeatModeDefault = 2 ;
	
	    public const int LedModeOff = 0 ;
	    public const int LedModeOn = 1 ;
	
	    /* masks for ChangeKeyboardControl */
	
	    public const long KBKeyClickPercent = (1L<<0) ;
	    public const long KBBellPercent = (1L<<1) ;
	    public const long KBBellPitch = (1L<<2) ;
	    public const long KBBellDuration = (1L<<3) ;
	    public const long KBLed = (1L<<4) ;
	    public const long KBLedMode = (1L<<5) ;
	    public const long KBKey = (1L<<6) ;
	    public const long KBAutoRepeatMode = (1L<<7) ;
	
	    public const int MappingSuccess = 0 ;
	    public const int MappingBusy = 1 ;
	    public const int MappingFailed = 2 ;
	
	    public const int MappingModifier = 0 ;
	    public const int MappingKeyboard = 1 ;
	    public const int MappingPointer = 2 ;
	
	    /*****************************************************************
	     * SCREEN SAVER STUFF
	     *****************************************************************/
	
	    public const int DontPreferBlanking = 0 ;
	    public const int PreferBlanking = 1 ;
	    public const int DefaultBlanking = 2 ;
	
	    public const int DisableScreenSaver = 0 ;
	    public const int DisableScreenInterval = 0 ;
	
	    public const int DontAllowExposures = 0 ;
	    public const int AllowExposures = 1 ;
	    public const int DefaultExposures = 2 ;
	
	    /* for ForceScreenSaver */
	
	    public const int ScreenSaverReset = 0 ;
	    public const int ScreenSaverActive = 1 ;
	
	    /*****************************************************************
	     * HOSTS AND CONNECTIONS
	     *****************************************************************/
	
	    /* for ChangeHosts */
	
	    public const int HostInsert = 0 ;
	    public const int HostDelete = 1 ;
	
	    /* for ChangeAccessControl */
	
	    public const int EnableAccess = 1 ;
	    public const int DisableAccess = 0 ;
	
	    /* Display classes  used in opening the connection
	     * Note that the statically allocated ones are even numbered and the
	     * dynamically changeable ones are odd numbered */
	
	    public const int StaticGray = 0 ;
	    public const int GrayScale = 1 ;
	    public const int StaticColor = 2 ;
	    public const int PseudoColor = 3 ;
	    public const int TrueColor = 4 ;
	    public const int DirectColor = 5 ;
	
	
	    /* Byte order  used in imageByteOrder and bitmapBitOrder */
	
	    public const int LSBFirst = 0 ;
	    public const int MSBFirst = 1 ;
		
		/* Mouse Wheel button code */
		public const uint MouseWheelUp = 4;
	    public const uint MouseWheelDown = 5;
	}
	
	public enum Msg {
		WM_NULL                   = 0x0000,
		WM_CREATE                 = 0x0001,
		WM_DESTROY                = 0x0002,
		WM_MOVE                   = 0x0003,
		WM_SIZE                   = 0x0005,
		WM_ACTIVATE               = 0x0006,
		WM_SETFOCUS               = 0x0007,
		WM_KILLFOCUS              = 0x0008,
		//              public const uint WM_SETVISIBLE           = 0x0009;
		WM_ENABLE                 = 0x000A,
		WM_SETREDRAW              = 0x000B,
		WM_SETTEXT                = 0x000C,
		WM_GETTEXT                = 0x000D,
		WM_GETTEXTLENGTH          = 0x000E,
		WM_PAINT                  = 0x000F,
		WM_CLOSE                  = 0x0010,
		WM_QUERYENDSESSION        = 0x0011,
		WM_QUIT                   = 0x0012,
		WM_QUERYOPEN              = 0x0013,
		WM_ERASEBKGND             = 0x0014,
		WM_SYSCOLORCHANGE         = 0x0015,
		WM_ENDSESSION             = 0x0016,
		//              public const uint WM_SYSTEMERROR          = 0x0017;
		WM_SHOWWINDOW             = 0x0018,
		WM_CTLCOLOR               = 0x0019,
		WM_WININICHANGE           = 0x001A,
		WM_SETTINGCHANGE          = 0x001A,
		WM_DEVMODECHANGE          = 0x001B,
		WM_ACTIVATEAPP            = 0x001C,
		WM_FONTCHANGE             = 0x001D,
		WM_TIMECHANGE             = 0x001E,
		WM_CANCELMODE             = 0x001F,
		WM_SETCURSOR              = 0x0020,
		WM_MOUSEACTIVATE          = 0x0021,
		WM_CHILDACTIVATE          = 0x0022,
		WM_QUEUESYNC              = 0x0023,
		WM_GETMINMAXINFO          = 0x0024,
		WM_PAINTICON              = 0x0026,
		WM_ICONERASEBKGND         = 0x0027,
		WM_NEXTDLGCTL             = 0x0028,
		//              public const uint WM_ALTTABACTIVE         = 0x0029;
		WM_SPOOLERSTATUS          = 0x002A,
		WM_DRAWITEM               = 0x002B,
		WM_MEASUREITEM            = 0x002C,
		WM_DELETEITEM             = 0x002D,
		WM_VKEYTOITEM             = 0x002E,
		WM_CHARTOITEM             = 0x002F,
		WM_SETFONT                = 0x0030,
		WM_GETFONT                = 0x0031,
		WM_SETHOTKEY              = 0x0032,
		WM_GETHOTKEY              = 0x0033,
		//              public const uint WM_FILESYSCHANGE        = 0x0034;
		//              public const uint WM_ISACTIVEICON         = 0x0035;
		//              public const uint WM_QUERYPARKICON        = 0x0036;
		WM_QUERYDRAGICON          = 0x0037,
		WM_COMPAREITEM            = 0x0039,
		//              public const uint WM_TESTING              = 0x003a;
		//              public const uint WM_OTHERWINDOWCREATED = 0x003c;
		WM_GETOBJECT              = 0x003D,
		//                      public const uint WM_ACTIVATESHELLWINDOW        = 0x003e;
		WM_COMPACTING             = 0x0041,
		WM_COMMNOTIFY             = 0x0044 ,
		WM_WINDOWPOSCHANGING      = 0x0046,
		WM_WINDOWPOSCHANGED       = 0x0047,
		WM_POWER                  = 0x0048,
		WM_COPYDATA               = 0x004A,
		WM_CANCELJOURNAL          = 0x004B,
		WM_NOTIFY                 = 0x004E,
		WM_INPUTLANGCHANGEREQUEST = 0x0050,
		WM_INPUTLANGCHANGE        = 0x0051,
		WM_TCARD                  = 0x0052,
		WM_HELP                   = 0x0053,
		WM_USERCHANGED            = 0x0054,
		WM_NOTIFYFORMAT           = 0x0055,
		WM_CONTEXTMENU            = 0x007B,
		WM_STYLECHANGING          = 0x007C,
		WM_STYLECHANGED           = 0x007D,
		WM_DISPLAYCHANGE          = 0x007E,
		WM_GETICON                = 0x007F,

		// Non-Client messages
		WM_SETICON                = 0x0080,
		WM_NCCREATE               = 0x0081,
		WM_NCDESTROY              = 0x0082,
		WM_NCCALCSIZE             = 0x0083,
		WM_NCHITTEST              = 0x0084,
		WM_NCPAINT                = 0x0085,
		WM_NCACTIVATE             = 0x0086,
		WM_GETDLGCODE             = 0x0087,
		WM_SYNCPAINT              = 0x0088,
		//              public const uint WM_SYNCTASK       = 0x0089;
		WM_NCMOUSEMOVE            = 0x00A0,
		WM_NCLBUTTONDOWN          = 0x00A1,
		WM_NCLBUTTONUP            = 0x00A2,
		WM_NCLBUTTONDBLCLK        = 0x00A3,
		WM_NCRBUTTONDOWN          = 0x00A4,
		WM_NCRBUTTONUP            = 0x00A5,
		WM_NCRBUTTONDBLCLK        = 0x00A6,
		WM_NCMBUTTONDOWN          = 0x00A7,
		WM_NCMBUTTONUP            = 0x00A8,
		WM_NCMBUTTONDBLCLK        = 0x00A9,
		//              public const uint WM_NCXBUTTONDOWN    = 0x00ab;
		//              public const uint WM_NCXBUTTONUP      = 0x00ac;
		//              public const uint WM_NCXBUTTONDBLCLK  = 0x00ad;
		WM_KEYDOWN                = 0x0100,
		WM_KEYFIRST               = 0x0100,
		WM_KEYUP                  = 0x0101,
		WM_CHAR                   = 0x0102,
		WM_DEADCHAR               = 0x0103,
		WM_SYSKEYDOWN             = 0x0104,
		WM_SYSKEYUP               = 0x0105,
		WM_SYSCHAR                = 0x0106,
		WM_SYSDEADCHAR            = 0x0107,
		WM_KEYLAST                = 0x0108,
		WM_IME_STARTCOMPOSITION   = 0x010D,
		WM_IME_ENDCOMPOSITION     = 0x010E,
		WM_IME_COMPOSITION        = 0x010F,
		WM_IME_KEYLAST            = 0x010F,
		WM_INITDIALOG             = 0x0110,
		WM_COMMAND                = 0x0111,
		WM_SYSCOMMAND             = 0x0112,
		WM_TIMER                  = 0x0113,
		WM_HSCROLL                = 0x0114,
		WM_VSCROLL                = 0x0115,
		WM_INITMENU               = 0x0116,
		WM_INITMENUPOPUP          = 0x0117,
		//              public const uint WM_SYSTIMER       = 0x0118;
		WM_MENUSELECT             = 0x011F,
		WM_MENUCHAR               = 0x0120,
		WM_ENTERIDLE              = 0x0121,
		WM_MENURBUTTONUP          = 0x0122,
		WM_MENUDRAG               = 0x0123,
		WM_MENUGETOBJECT          = 0x0124,
		WM_UNINITMENUPOPUP        = 0x0125,
		WM_MENUCOMMAND            = 0x0126,
		
		WM_CHANGEUISTATE          = 0x0127,
		WM_UPDATEUISTATE          = 0x0128,
		WM_QUERYUISTATE           = 0x0129,

		//              public const uint WM_LBTRACKPOINT     = 0x0131;
		WM_CTLCOLORMSGBOX         = 0x0132,
		WM_CTLCOLOREDIT           = 0x0133,
		WM_CTLCOLORLISTBOX        = 0x0134,
		WM_CTLCOLORBTN            = 0x0135,
		WM_CTLCOLORDLG            = 0x0136,
		WM_CTLCOLORSCROLLBAR      = 0x0137,
		WM_CTLCOLORSTATIC         = 0x0138,
		WM_MOUSEMOVE              = 0x0200,
		WM_MOUSEFIRST                     = 0x0200,
		WM_LBUTTONDOWN            = 0x0201,
		WM_LBUTTONUP              = 0x0202,
		WM_LBUTTONDBLCLK          = 0x0203,
		WM_RBUTTONDOWN            = 0x0204,
		WM_RBUTTONUP              = 0x0205,
		WM_RBUTTONDBLCLK          = 0x0206,
		WM_MBUTTONDOWN            = 0x0207,
		WM_MBUTTONUP              = 0x0208,
		WM_MBUTTONDBLCLK          = 0x0209,
		WM_MOUSEWHEEL             = 0x020A,
		WM_MOUSELAST             = 0x020D,
		//              public const uint WM_XBUTTONDOWN      = 0x020B;
		//              public const uint WM_XBUTTONUP        = 0x020C;
		//              public const uint WM_XBUTTONDBLCLK    = 0x020D;
		WM_PARENTNOTIFY           = 0x0210,
		WM_ENTERMENULOOP          = 0x0211,
		WM_EXITMENULOOP           = 0x0212,
		WM_NEXTMENU               = 0x0213,
		WM_SIZING                 = 0x0214,
		WM_CAPTURECHANGED         = 0x0215,
		WM_MOVING                 = 0x0216,
		//              public const uint WM_POWERBROADCAST   = 0x0218;
		WM_DEVICECHANGE           = 0x0219,
		WM_MDICREATE              = 0x0220,
		WM_MDIDESTROY             = 0x0221,
		WM_MDIACTIVATE            = 0x0222,
		WM_MDIRESTORE             = 0x0223,
		WM_MDINEXT                = 0x0224,
		WM_MDIMAXIMIZE            = 0x0225,
		WM_MDITILE                = 0x0226,
		WM_MDICASCADE             = 0x0227,
		WM_MDIICONARRANGE         = 0x0228,
		WM_MDIGETACTIVE           = 0x0229,
		/* D&D messages */
		//              public const uint WM_DROPOBJECT     = 0x022A;
		//              public const uint WM_QUERYDROPOBJECT  = 0x022B;
		//              public const uint WM_BEGINDRAG      = 0x022C;
		//              public const uint WM_DRAGLOOP       = 0x022D;
		//              public const uint WM_DRAGSELECT     = 0x022E;
		//              public const uint WM_DRAGMOVE       = 0x022F;
		WM_MDISETMENU             = 0x0230,
		WM_ENTERSIZEMOVE          = 0x0231,
		WM_EXITSIZEMOVE           = 0x0232,
		WM_DROPFILES              = 0x0233,
		WM_MDIREFRESHMENU         = 0x0234,
		WM_IME_SETCONTEXT         = 0x0281,
		WM_IME_NOTIFY             = 0x0282,
		WM_IME_CONTROL            = 0x0283,
		WM_IME_COMPOSITIONFULL    = 0x0284,
		WM_IME_SELECT             = 0x0285,
		WM_IME_CHAR               = 0x0286,
		WM_IME_REQUEST            = 0x0288,
		WM_IME_KEYDOWN            = 0x0290,
		WM_IME_KEYUP              = 0x0291,
		WM_NCMOUSEHOVER           = 0x02A0,
		WM_MOUSEHOVER             = 0x02A1,
		WM_NCMOUSELEAVE           = 0x02A2,
		WM_MOUSELEAVE             = 0x02A3,
		WM_CUT                    = 0x0300,
		WM_COPY                   = 0x0301,
		WM_PASTE                  = 0x0302,
		WM_CLEAR                  = 0x0303,
		WM_UNDO                   = 0x0304,
		WM_RENDERFORMAT           = 0x0305,
		WM_RENDERALLFORMATS       = 0x0306,
		WM_DESTROYCLIPBOARD       = 0x0307,
		WM_DRAWCLIPBOARD          = 0x0308,
		WM_PAINTCLIPBOARD         = 0x0309,
		WM_VSCROLLCLIPBOARD       = 0x030A,
		WM_SIZECLIPBOARD          = 0x030B,
		WM_ASKCBFORMATNAME        = 0x030C,
		WM_CHANGECBCHAIN          = 0x030D,
		WM_HSCROLLCLIPBOARD       = 0x030E,
		WM_QUERYNEWPALETTE        = 0x030F,
		WM_PALETTEISCHANGING      = 0x0310,
		WM_PALETTECHANGED         = 0x0311,
		WM_HOTKEY                 = 0x0312,
		WM_PRINT                  = 0x0317,
		WM_PRINTCLIENT            = 0x0318,
		WM_HANDHELDFIRST          = 0x0358,
		WM_HANDHELDLAST           = 0x035F,
		WM_AFXFIRST               = 0x0360,
		WM_AFXLAST                = 0x037F,
		WM_PENWINFIRST            = 0x0380,
		WM_PENWINLAST             = 0x038F,
		WM_APP                    = 0x8000,
		WM_USER                   = 0x0400,

		// Our "private" ones
		WM_MOUSE_ENTER            = 0x0401,
		WM_ASYNC_MESSAGE          = 0x0403,
		WM_REFLECT                = WM_USER + 0x1c00,
		WM_CLOSE_INTERNAL         = WM_USER + 0x1c01,

		// NotifyIcon (Systray) Balloon messages 
		NIN_BALLOONSHOW           = WM_USER + 0x0002,
		NIN_BALLOONHIDE           = WM_USER + 0x0003,
		NIN_BALLOONTIMEOUT        = WM_USER + 0x0004,
		NIN_BALLOONUSERCLICK      = WM_USER + 0x0005 
	}

	public enum MsgButtons {
		MK_LBUTTON		= 0x0001,
		MK_RBUTTON		= 0x0002,
		MK_SHIFT		= 0x0004,
		MK_CONTROL		= 0x0008,
		MK_MBUTTON          	= 0x0010,
		MK_XBUTTON1		= 0x0020,
		MK_XBUTTON2		= 0x0040,
	}
	
	public enum MsgUIState {
		UIS_SET        = 1,
		UIS_CLEAR      = 2,
		UIS_INITIALIZE = 3,
		UISF_HIDEFOCUS = 0x1,
		UISF_HIDEACCEL = 0x2,
		UISF_ACTIVE    = 0x4
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public struct POINT {
		public int x;
		public int y;

		public POINT (int x, int y)
		{
			this.x = x;
			this.y = y;
		}

		public override string ToString ()
		{
			return "Point {" + x.ToString () + ", " + y.ToString () + "}";
		}
	}
	
	[StructLayout(LayoutKind.Sequential)] 
	public struct MSG {
		public IntPtr	hwnd;
		public Msg	message;
		public IntPtr	wParam; 
		public IntPtr	lParam;
		public uint	time;  
		public POINT	pt;
		public object refobject;

		public override string ToString ()
		{
			return String.Format ("msg=0x{0:x} ({1}) hwnd=0x{2:x} wparam=0x{3:x} lparam=0x{4:x} pt={5}", (int) message, message.ToString (), hwnd.ToInt32 (), wParam.ToInt32 (), lParam.ToInt32 (), pt);
		}
	}

	[Flags]
	public enum TransparencySupport {
		None = 0x00,
		Get = 0x01,
		Set = 0x02,
		GetSet = 0x03
	}

	public enum WindowActiveFlags {
		WA_INACTIVE		= 0,
		WA_ACTIVE		= 1,
		WA_CLICKACTIVE		= 2
	}

	public enum KeybdEventFlags {
		None			= 0,
		ExtendedKey		= 0x0001,
		KeyUp			= 0x0002
	}

	public enum VirtualKeys {
		VK_LBUTTON		= 0x01,
		VK_RBUTTON              = 0x02,
		VK_CANCEL		= 0x03,
		VK_MBUTTON              = 0x04,
		VK_XBUTTON1             = 0x05,
		VK_XBUTTON2             = 0x06,
		VK_BACK			= 0x08,
		VK_TAB			= 0x09,
		VK_CLEAR		= 0x0C,
		VK_RETURN		= 0x0D,
		VK_SHIFT		= 0x10,
		VK_CONTROL		= 0x11,
		VK_MENU			= 0x12,
		VK_PAUSE		= 0x13,
		VK_CAPITAL		= 0x14,
		VK_ESCAPE		= 0x1B,
		VK_CONVERT		= 0x1C,
		VK_NONCONVERT	= 0x1D,
		VK_SPACE		= 0x20,
		VK_PRIOR		= 0x21,
		VK_NEXT			= 0x22,
		VK_END			= 0x23,
		VK_HOME			= 0x24,
		VK_LEFT			= 0x25,
		VK_UP			= 0x26,
		VK_RIGHT		= 0x27,
		VK_DOWN			= 0x28,
		VK_SELECT		= 0x29,
		VK_PRINT		= 0x2A,
		VK_EXECUTE		= 0x2B,
		VK_SNAPSHOT		= 0x2C,
		VK_INSERT		= 0x2D,
		VK_DELETE		= 0x2E,
		VK_HELP			= 0x2F,
		VK_0			= 0x30,
		VK_1			= 0x31,
		VK_2			= 0x32,
		VK_3			= 0x33,
		VK_4			= 0x34,
		VK_5			= 0x35,
		VK_6			= 0x36,
		VK_7			= 0x37,
		VK_8			= 0x38,
		VK_9			= 0x39,
		VK_A			= 0x41,
		VK_B			= 0x42,
		VK_C			= 0x43,
		VK_D			= 0x44,
		VK_E			= 0x45,
		VK_F			= 0x46,
		VK_G			= 0x47,
		VK_H			= 0x48,
		VK_I			= 0x49,
		VK_J			= 0x4A,
		VK_K			= 0x4B,
		VK_L			= 0x4C,
		VK_M			= 0x4D,
		VK_N			= 0x4E,
		VK_O			= 0x4F,
		VK_P			= 0x50,
		VK_Q			= 0x51,
		VK_R			= 0x52,
		VK_S			= 0x53,
		VK_T			= 0x54,
		VK_U			= 0x55,
		VK_V			= 0x56,
		VK_W			= 0x57,
		VK_X			= 0x58,
		VK_Y			= 0x59,
		VK_Z			= 0x5A,
		VK_LWIN			= 0x5B,
		VK_RWIN			= 0x5C,
		VK_APPS			= 0x5D,
		VK_NUMPAD0		= 0x60,
		VK_NUMPAD1		= 0x61,
		VK_NUMPAD2		= 0x62,
		VK_NUMPAD3		= 0x63,
		VK_NUMPAD4		= 0x64,
		VK_NUMPAD5		= 0x65,
		VK_NUMPAD6		= 0x66,
		VK_NUMPAD7		= 0x67,
		VK_NUMPAD8		= 0x68,
		VK_NUMPAD9		= 0x69,
		VK_MULTIPLY		= 0x6A,
		VK_ADD			= 0x6B,
		VK_SEPARATOR		= 0x6C,
		VK_SUBTRACT		= 0x6D,
		VK_DECIMAL		= 0x6E,
		VK_DIVIDE		= 0x6F,
		VK_F1			= 0x70,
		VK_F2			= 0x71,
		VK_F3			= 0x72,
		VK_F4			= 0x73,
		VK_F5			= 0x74,
		VK_F6			= 0x75,
		VK_F7			= 0x76,
		VK_F8			= 0x77,
		VK_F9			= 0x78,
		VK_F10			= 0x79,
		VK_F11			= 0x7A,
		VK_F12			= 0x7B,
		VK_F13			= 0x7C,
		VK_F14			= 0x7D,
		VK_F15			= 0x7E,
		VK_F16			= 0x7F,
		VK_F17			= 0x80,
		VK_F18			= 0x81,
		VK_F19			= 0x82,
		VK_F20			= 0x83,
		VK_F21			= 0x84,
		VK_F22			= 0x85,
		VK_F23			= 0x86,
		VK_F24			= 0x87,
		VK_NUMLOCK		= 0x90,
		VK_SCROLL		= 0x91,
		VK_LSHIFT		= 0xA0,   
		VK_RSHIFT		= 0xA1,   
		VK_LCONTROL		= 0xA2,   
		VK_RCONTROL		= 0xA3,   
		VK_LMENU		= 0xA4,   
		VK_RMENU		= 0xA5,
		VK_OEM_1		= 0xBA,
		VK_OEM_PLUS		= 0xBB,
		VK_OEM_COMMA		= 0xBC,
		VK_OEM_MINUS		= 0xBD,
		VK_OEM_PERIOD		= 0xBE,
		VK_OEM_2		= 0xBF, 
		VK_OEM_3		= 0xC0,
		VK_OEM_4		= 0xDB,
		VK_OEM_5		= 0xDC,
		VK_OEM_6		= 0xDD,
		VK_OEM_7		= 0xDE,
		VK_OEM_8		= 0xDF,
		VK_OEM_AX		= 0xE1,
		VK_OEM_102		= 0xE2,
		VK_ICO_HELP		= 0xE3,
		VK_ICO_00		= 0xE4,
		VK_PROCESSKEY		= 0xE5,
		VK_OEM_ATTN		= 0xF0,
		VK_OEM_COPY		= 0xF2,
		VK_OEM_AUTO		= 0xF3,
		VK_OEM_ENLW		= 0xF4,
		VK_OEM_BACKTAB		= 0xF5,
		VK_ATTN			= 0xF6,
		VK_CRSEL		= 0xF7,
		VK_EXSEL		= 0xF8,
		VK_EREOF		= 0xF9,
		VK_PLAY			= 0xFA,
		VK_ZOOM			= 0xFB,
		VK_NONAME		= 0xFC,
		VK_PA1			= 0xFD,
		VK_OEM_CLEAR		= 0xFE,
	}

	public enum TtyKeys {
		XK_BackSpace		= 0xff08,  /* Back space, back char */
		XK_Tab			= 0xff09,
		XK_Linefeed		= 0xff0a,  /* Linefeed, LF */
		XK_Clear		= 0xff0b,
		XK_Return		= 0xff0d,  /* Return, enter */
		XK_Pause		= 0xff13,  /* Pause, hold */
		XK_Scroll_Lock		= 0xff14,
		XK_Sys_Req		= 0xff15,
		XK_Escape		= 0xff1b,
		XK_Delete		= 0xffff  /* Delete, rubout */
	}

	public enum MiscKeys {
		XK_ISO_Lock             = 0xfe01,
		XK_ISO_Last_Group_Lock	= 0xfe0f,
		XK_Select		= 0xff60,
		XK_Print		= 0xff61,
		XK_Execute		= 0xff62,
		XK_Insert		= 0xff63,
		XK_Undo			= 0xff65,
		XK_Redo			= 0xff66,
		XK_Menu			= 0xff67,
		XK_Find			= 0xff68,
		XK_Cancel		= 0xff69,
		XK_Help			= 0xff6a,
		XK_Break		= 0xff6b,
		XK_Mode_switch		= 0xff7e,
		XK_script_switch	= 0xff7e,
		XK_Num_Lock		= 0xff7f
	}

	public enum KeypadKeys {
		XK_KP_Space		= 0xff80,
		XK_KP_Tab		= 0xff89,
		XK_KP_Enter		= 0xff8d,  /* Enter */
		XK_KP_F1		= 0xff91,  /* PF1, KP_A, ... */
		XK_KP_F2		= 0xff92,
		XK_KP_F3		= 0xff93,
		XK_KP_F4		= 0xff94,
		XK_KP_Home		= 0xff95,
		XK_KP_Left		= 0xff96,
		XK_KP_Up		= 0xff97,
		XK_KP_Right		= 0xff98,
		XK_KP_Down		= 0xff99,
		XK_KP_Prior		= 0xff9a,
		XK_KP_Page_Up		= 0xff9a,
		XK_KP_Next		= 0xff9b,
		XK_KP_Page_Down		= 0xff9b,
		XK_KP_End		= 0xff9c,
		XK_KP_Begin		= 0xff9d,
		XK_KP_Insert		= 0xff9e,
		XK_KP_Delete		= 0xff9f,
		XK_KP_Equal		= 0xffbd,  /* Equals */
		XK_KP_Multiply		= 0xffaa,
		XK_KP_Add		= 0xffab,
		XK_KP_Separator		= 0xffac,  /* Separator, often comma */
		XK_KP_Subtract		= 0xffad,
		XK_KP_Decimal		= 0xffae,
		XK_KP_Divide		= 0xffaf,

		XK_KP_0			= 0xffb0,
		XK_KP_1			= 0xffb1,
		XK_KP_2			= 0xffb2,
		XK_KP_3			= 0xffb3,
		XK_KP_4			= 0xffb4,
		XK_KP_5			= 0xffb5,
		XK_KP_6			= 0xffb6,
		XK_KP_7			= 0xffb7,
		XK_KP_8			= 0xffb8,
		XK_KP_9			= 0xffb9
	}

        public enum DeadKeys {
                XK_dead_grave           = 0xfe50,
                XK_dead_acute           = 0xfe51,
                XK_dead_circumflex      = 0xfe52,
                XK_dead_tilde           = 0xfe53,
                XK_dead_macron          = 0xfe54,
                XK_dead_breve           = 0xfe55,
                XK_dead_abovedot        = 0xfe56,
                XK_dead_diaeresis       = 0xfe57,
                XK_dead_abovering       = 0xfe58,
                XK_dead_doubleacute     = 0xfe59,
                XK_dead_caron           = 0xfe5a,
                XK_dead_cedilla         = 0xfe5b,
                XK_dead_ogonek          = 0xfe5c,
                XK_dead_iota            = 0xfe5d,
                XK_dead_voiced_sound    = 0xfe5e,
                XK_dead_semivoiced_sound  = 0xfe5f,
                XK_dead_belowdot        = 0xfe60,
                XK_dead_hook            = 0xfe61,
                XK_dead_horn            = 0xfe62

        }

	[StructLayout(LayoutKind.Sequential)]
	public struct HELPINFO {
		public uint		cbSize;
		public int		iContextType;
		public int		iCtrlId;
		public IntPtr		hItemHandle;
		public uint		dwContextId;
		public POINT		MousePos;
	}

	public enum PeekMessageFlags {
		PM_NOREMOVE			= 0x00000000,
		PM_REMOVE			= 0x00000001,
		PM_NOYIELD			= 0x00000002
	}

	public enum StdCursor {
		Default				= 0,
		AppStarting			= 1,
		Arrow				= 2,
		Cross				= 3,
		Hand				= 4,
		Help				= 5,
		HSplit				= 6,
		IBeam				= 7,
		No				= 8,
		NoMove2D			= 9,
		NoMoveHoriz			= 10,
		NoMoveVert			= 11,
		PanEast				= 12,
		PanNE				= 13,
		PanNorth			= 14,
		PanNW				= 15,
		PanSE				= 16,
		PanSouth			= 17,
		PanSW				= 18,
		PanWest				= 19,
		SizeAll				= 20,
		SizeNESW			= 21,
		SizeNS				= 22,
		SizeNWSE			= 23,
		SizeWE				= 24,
		UpArrow				= 25,
		VSplit				= 26,
		WaitCursor			= 27
	}

	public enum HitTest {
		HTERROR				= -2,
		HTTRANSPARENT			= -1,
		HTNOWHERE			= 0,
		HTCLIENT			= 1,
		HTCAPTION			= 2,
		HTSYSMENU			= 3,
		HTGROWBOX			= 4,
		HTSIZE				= HTGROWBOX,
		HTMENU				= 5,
		HTHSCROLL			= 6,
		HTVSCROLL			= 7,
		HTMINBUTTON			= 8,
		HTMAXBUTTON			= 9,
		HTLEFT				= 10,
		HTRIGHT				= 11,
		HTTOP				= 12,
		HTTOPLEFT			= 13,
		HTTOPRIGHT			= 14,
		HTBOTTOM			= 15,
		HTBOTTOMLEFT			= 16,
		HTBOTTOMRIGHT			= 17,
		HTBORDER			= 18,
		HTREDUCE			= HTMINBUTTON,
		HTZOOM				= HTMAXBUTTON,
		HTSIZEFIRST			= HTLEFT,
		HTSIZELAST			= HTBOTTOMRIGHT,
		HTOBJECT			= 19,
		HTCLOSE				= 20,
		HTHELP				= 21
	}

	public enum TitleStyle {
		None				= 0,
		Normal				= 1,
		Tool				= 2
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct BITMAPINFOHEADER {
		public uint     biSize;
		public int      biWidth;
		public int      biHeight;
		public ushort   biPlanes;
		public ushort   biBitCount;
		public uint     biCompression;
		public uint     biSizeImage;
		public int      biXPelsPerMeter;
		public int      biYPelsPerMeter;
		public uint     biClrUsed;
		public uint     biClrImportant;
	}

	public enum ClipboardFormats : ushort {
		CF_TEXT				= 1,
		CF_BITMAP           		= 2,
		CF_METAFILEPICT     		= 3,
		CF_SYLK             		= 4,
		CF_DIF             		= 5,
		CF_TIFF            		= 6,
		CF_OEMTEXT         		= 7,
		CF_DIB              		= 8,
		CF_PALETTE          		= 9,
		CF_PENDATA          		= 10,
		CF_RIFF             		= 11,
		CF_WAVE             		= 12,
		CF_UNICODETEXT      		= 13,
		CF_ENHMETAFILE      		= 14,
		CF_HDROP            		= 15,
		CF_LOCALE           		= 16,
		CF_DIBV5            		= 17
	}
}