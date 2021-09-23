using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace lm_km.core
{
    // external command class
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class ShowKeynoteManagerCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            // dockable window id
            var dpid = new DockablePaneId(PaneIdentifiers.GetManagerPaneIdentifier());
            var dp = commandData.Application.GetDockablePane(dpid);
            dp.Show();
            return Result.Succeeded;
        }

        /// <summary>
        /// Gets the full namespace path to this command.
        /// </summary>
        /// <returns></returns>
        public static string GetPath()
        {
            // Return constructed namespace path.
            return typeof(ShowKeynoteManagerCommand).Namespace + "." + nameof(ShowKeynoteManagerCommand);
        }
    }
}