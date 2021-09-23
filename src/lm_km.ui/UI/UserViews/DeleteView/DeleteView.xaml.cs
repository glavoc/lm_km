using Autodesk.Revit.DB;
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
using lm_km.core;

namespace lm_km.ui
{

    /// <summary>
    /// Interaction logic for DeleteKeynoteView.xaml
    /// </summary>
    public partial class DeleteView : PageBase
    {

        #region private fields
        private KeynoteTreeViewModel m_dtCntxt;
        private KeynoteViewModel m_selectedItem;
        #endregion

        #region constructor
        /// <summary>
        /// Main constructor
        /// </summary>
        public DeleteView()
        {
            InitializeComponent();
            Animation = PageAnimationType.Fade;
        }
        #endregion

        #region private methods
        /// <summary>
        /// Activate Revit view containing selected keynote
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteKeynoteListBox_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var lb = (DataGrid)sender;
            var itemStr = (string)lb.SelectedItem;
            int idInt = Convert.ToInt32(itemStr);
            ElementId id = new ElementId(idInt);
            //RVT_App.UIDoc.ShowElements(id);
            e.Handled = true;
        }

        #endregion
    }
}
