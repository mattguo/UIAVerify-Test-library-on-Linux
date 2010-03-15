using System;
using System.Collections.Generic;

namespace BasicAutomation
{
    public class NativeHelper
    {
        public static bool IsBitSet(int flags, int bit)
        {
            return ((flags & bit) == bit);
        }

        public static int SetBit(int flags, int bit)
        {
            return flags | bit;
        }

        public static int ResetBit(int flags, int bit)
        {
            return flags & ~bit;
        }
    }
}
