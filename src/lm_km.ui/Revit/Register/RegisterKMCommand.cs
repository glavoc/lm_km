using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using lm_km.core;
using System.Windows;

namespace lm_km.ui
{
    // external command class
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class RegisterKMCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            return Result.Succeeded;
        }

        public Result Execute(UIApplication uiapp)
        {
            var data = new DockablePaneProviderData();
            var managerPage = new MainPageContainerView(uiapp);

            data.FrameworkElement = managerPage as FrameworkElement;

            // create a new dockable pane id
            var dpid = new DockablePaneId(PaneIdentifiers.GetManagerPaneIdentifier());
            try
            {
                // register dockable pane
                uiapp.RegisterDockablePane(dpid, "Keynote Manager", managerPage as IDockablePaneProvider);
            }
            catch (Exception ex)
            {
                // show error info dialog
                TaskDialog.Show("Info Message", ex.Message);
            }
            // return result
            return Result.Succeeded;
        }

    }

}
