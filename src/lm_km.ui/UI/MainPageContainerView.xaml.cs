using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using lm_km.core;

namespace lm_km.ui
{
    /// <summary>
    /// Interaction logic for MainPageContainerView.xaml
    /// </summary>
    public partial class MainPageContainerView : Page, IDisposable, IDockablePaneProvider
    {

        public MainPageContainerView()
        {
            InitializeComponent();
            DataContext = new MainPageContainerViewModel();
            // TODO Repopulate treeview on RVT active document change
        }



        // IDockablePaneProvider abstrat method
        public void SetupDockablePane(DockablePaneProviderData data)
        {
            ///wpf object with pane's interface
            data.FrameworkElement = this as FrameworkElement;
            data.InitialState = new DockablePaneState
            {
                DockPosition = DockPosition.Right
            };
        }

        public void Dispose() { }
    }
}
