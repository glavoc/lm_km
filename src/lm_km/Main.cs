using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.UI;
using lm_km.ui;
using lm_km.core;

namespace lm_km
{
    /// <summary>
    /// Main External Application Class
    /// </summary>
    public class Main : IExternalApplication
    {
        #region external application public methods
        /// <summary>
        /// Called on Revit starts up.
        /// </summary>
        /// <param name="application">The application.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>

        public Result OnStartup(UIControlledApplication application)
        {
            // Assign to singleton
            RVT_App.RVT_ControlledApp = application;
            
            // Initialize whole plugin's user interface.
            var ui = new SetupInterface();
            ui.Initialize(RVT_App.RVT_ControlledApp);

            application.ControlledApplication.ApplicationInitialized += DockablePaneRegisters;

            return Result.Succeeded;
        }
        /// <summary>
        /// Called on Revit shutdown.
        /// </summary>
        /// <param name="application">The application.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>

        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        #endregion

        #region private methods

        /// <summary>
        /// Register dockable panes in zero state document.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="Autodesk.Revit.DB.Events.ApplicationInitializedEventArgs"/> instance containing the event data.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        private void DockablePaneRegisters(object sender, Autodesk.Revit.DB.Events.ApplicationInitializedEventArgs e)
        {
            // Register dockable pane.
            var familyManagerRegisterCommand = new RegisterKMCommand();
            familyManagerRegisterCommand.Execute(new UIApplication(sender as Application));
        }

        #endregion
    }
}
