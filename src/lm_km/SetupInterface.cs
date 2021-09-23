using Autodesk.Revit.UI;
using System;
using Autodesk.Revit.UI.Events;
using System.IO;
using lm_km.core;
using lm_km.res;
using System.Windows.Media.Imaging;
using lm_km.ui;

namespace lm_km
{
    class SetupInterface
    {
        private UIControlledApplication _application;
        public static PushButton showPushButton;
        public void Initialize(UIControlledApplication application)
        {
            _application = application;

            application.CreateRibbonTab("Luka");
            RibbonPanel ribbonPanel = application.CreateRibbonPanel("Luka", "Keynote Manager");

            // Create Show Button
            var showButtonData = new RevitPushButtonDataModel
            {
                Label = "Show Keynote\nManager",
                Panel = ribbonPanel,
                Tooltip = "This is some sample tooltip text,\nreplace it with real one latter,...",
                CommandNamespacePath = ShowKeynoteManagerCommand.GetPath(),
                IconImageName = "show16.png",
                TooltipImageName = "show32.png"
            };
            var keynoteManagerShowButton = RevitPushButton.Create(showButtonData);
            var hideButtonData = new RevitPushButtonDataModel
            {
                Label = "Hide Family\nManager",
                Panel = ribbonPanel,
                Tooltip = "This is some sample tooltip text,\nreplace it with real one latter,...",
                CommandNamespacePath = HideKeynoteManagerCommand.GetPath(),
                IconImageName = "register16.png",
                TooltipImageName = "register32.png"
            };
            var keynoteManagerHideButton = RevitPushButton.Create(hideButtonData);
    }
    }
}
