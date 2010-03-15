// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
// All other rights reserved.

using System;
using System.Collections.Generic;
using System.Text;

//this makes easier for custom loggers to find logging objects
namespace Microsoft.Test.UIAutomation.Logging.InfoObjects
{
    public class CommentInfo : BaseInfo
    {
        string _comment;

        public CommentInfo(string comment)
        {
            this._comment = comment;
        }

        public override string ToString()
        {
            return string.Format("{0}:{1}", base.ToString(), this._comment);
        }
    }
}