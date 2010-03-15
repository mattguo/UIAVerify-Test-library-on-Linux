using System;
using SWFSysInfo = System.Windows.Forms.SystemInformation;
using System.Windows;

namespace BasicAutomation
{
    public enum RuntimeType
    {
        MSDotNet,
        Mono,
        DotGNU
    }

    public enum OperatingSystemType
    {
        Windows,
        Unix
    }

    public enum Architecture
    {
        Bit32,
        Bit64
    }

    public class SystemInfo
    {
        public static RuntimeType CurrentRuntime
        {
            get
            {
                if (Type.GetType("Mono.Runtime") != null)
                    return RuntimeType.Mono;
                if (Type.GetType("DotGNU.Platform.BlockingOperation") != null)
                    return RuntimeType.DotGNU;
                return RuntimeType.MSDotNet;
            }
        }

        //Reference: http://www.mono-project.com/FAQ:_Technical#How_to_detect_the_execution_platform_.3F
        public static OperatingSystemType CurrentOS
        {
            get
            {
                int p = (int)Environment.OSVersion.Platform;
                if ((p == 4) || (p == 6) || (p == 128))
                {
                    return OperatingSystemType.Unix;
                }
                else
                {
                    return OperatingSystemType.Windows;
                }

            }
        }

        public static Architecture CurrentArch
        {
            get
            {
                if (IntPtr.Size == 4)
                    return Architecture.Bit32;
                else if (IntPtr.Size == 8)
                    return Architecture.Bit64;
                else
                    throw new Exception("Unknown system architecture");
            }
        }

        public static string ComputerName
        {
            get
            {
                return SWFSysInfo.ComputerName;
            }
        }

        public static Rect VirtualScreen
        {
            get
            {
                var rect = SWFSysInfo.VirtualScreen;
                return new Rect(rect.Left, rect.Top, rect.Width, rect.Height);
            }
        }

        public static bool MouseButtonsSwapped
        {
            get
            {
                return SWFSysInfo.MouseButtonsSwapped;
            }
        }

        //in milliseconds
        public static int DoubleClickTime
        {
            get
            {
                return SWFSysInfo.DoubleClickTime;
            }
        }
    }
}
