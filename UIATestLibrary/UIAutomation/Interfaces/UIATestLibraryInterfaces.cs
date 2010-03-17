// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
// All other rights reserved.

using System.Windows.Automation;
using System.Windows.Automation.Text;
using System.Collections;

namespace Microsoft.Test.UIAutomation.Interfaces
{
	using InternalHelper;
    using InternalHelper.Enumerations;
	using Microsoft.Test.UIAutomation;
	using Microsoft.Test.UIAutomation.Core;
	using Microsoft.Test.UIAutomation.TestManager;

    /// -----------------------------------------------------------------------
    /// <summary>
    /// Interface so that we can standardize the call to SearchString given two
    /// different applications.
    /// </summary>
    /// -----------------------------------------------------------------------
    public interface IControlLookUp
    {
        /// -------------------------------------------------------------------
        /// <summary>
        /// Method returns an AutomationElement based on some defined ID
        /// </summary>
        /// -------------------------------------------------------------------
        AutomationElement AutomationElementFromCustomId(object ID);
    }

    /// -----------------------------------------------------------------------
    /// <summary>
    /// Interface that determines how to drive some abstract applications menus
    /// </summary>
    /// -----------------------------------------------------------------------
    public interface IUIAMenuCommands
    {
        /// -------------------------------------------------------------------
        /// <summary>
        /// Returns the applications main menu bar
        /// </summary>
        /// -------------------------------------------------------------------
        TestMenu GetMenuBar();

        /// -------------------------------------------------------------------
        /// <summary>
        /// Returns the applications system menu bar
        /// </summary>
        /// -------------------------------------------------------------------
        TestMenu GetSystemMenu();
    }

    /// -----------------------------------------------------------------------
    /// <summary>
    /// Interface that cause an object to change it's properties
    /// </summary>
    /// -----------------------------------------------------------------------
    public interface IUIAPropertyChange
    {
        /// -------------------------------------------------------------------
        /// <summary>
        /// Fire off a change
        /// </summary>
        /// -------------------------------------------------------------------
        void ChangeProperty(AutomationProperty property, object automationID);
    }

    /// -----------------------------------------------------------------------
    /// <summary>
    /// Interface that will cause StructureChange events to occur on some 
    /// abstract application
    /// </summary>
    /// -----------------------------------------------------------------------
    public interface IUIAStructureChange
    {
        /// -------------------------------------------------------------------
        /// <summary>
        /// Call this the wrapper application to cause a specific StructureChange 
        /// to occur.  The wrapper application will need to implement this to 
        /// successfully cause the event to occur
        /// </summary>
        /// -------------------------------------------------------------------
        bool CauseStructureChange(AutomationElement element, StructureChangeType changeType);

        /// -------------------------------------------------------------------
        /// <summary>
        /// Resets the control to it's initial state after adding or deleting 
        /// any elements
        /// </summary>
        /// -------------------------------------------------------------------
        bool ResetControl(AutomationElement element);

        /// -------------------------------------------------------------------
        /// <summary>
        /// Method that will determine if the element supports tests for 
        /// structure change
        /// </summary>
        /// -------------------------------------------------------------------
        bool DoesControlSupportStructureChange(AutomationElement element, StructureChangeType structureChangeType);
    }

    /// -----------------------------------------------------------------------
    /// <summary>
    /// Main interface holder for the different interfaces for an abstract 
    /// application
    /// </summary>
    /// -----------------------------------------------------------------------
    public interface IApplicationCommands
    {
        /// -------------------------------------------------------------------
        /// <summary>
        /// Method that the test application can call to relay any information
        /// such as status information
        /// </summary>
        /// -------------------------------------------------------------------
        void TraceMethod(object information);

        /// -------------------------------------------------------------------
        /// <summary>
        /// Does this support IUIAMenu
        /// </summary>
        /// -------------------------------------------------------------------
        bool SupportsIUIAMenuCommands();
        /// -------------------------------------------------------------------
        /// <summary>
        /// Does this support IUIAStructureChange
        /// </summary>
        /// -------------------------------------------------------------------
        bool SupportsIUIAStructureChange(AutomationElement element);
        /// -------------------------------------------------------------------
        /// <summary>
        /// Does this support IUIAPropertyChange
        /// </summary>
        /// -------------------------------------------------------------------
        bool SupportsIUIAPropertyChange(AutomationElement element);
        /// -------------------------------------------------------------------
        /// <summary>
        /// Returns IUIAMenuCommands
        /// </summary>
        /// -------------------------------------------------------------------
        IUIAMenuCommands GetIUIAMenuCommands();
        /// -------------------------------------------------------------------
        /// <summary>
        /// Returns IUIAStructureChange
        /// </summary>
        /// -------------------------------------------------------------------
        IUIAStructureChange GetIUIAStructureChange();
        /// -------------------------------------------------------------------
        /// <summary>
        /// Return IUIAPropertyChange
        /// </summary>
        /// -------------------------------------------------------------------
        IUIAPropertyChange GetIUIAPropertyChange();
    }
}





           

