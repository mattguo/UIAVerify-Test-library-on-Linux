using System;
using System.Collections.Generic;
using System.Text;

namespace BasicAutomation
{
    public interface IEditWindowDriver : IWindowDriver
    {
        int LineCount { get; }
        //A result <0 means that no limit is set. (on Windows we will return -1 to indicate no-text-limit.
        int TextLimit { get; }
        bool IsMultiLine { get; }
        bool IsReadOnly { get; }
        bool IsRichEdit { get; }
        string Text { get; set; }
    }
}
