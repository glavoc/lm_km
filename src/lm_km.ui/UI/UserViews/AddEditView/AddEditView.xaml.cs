using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace lm_km.ui
{
    /// <summary>
    /// Interaction logic for AddKeynoteWindow.xaml
    /// </summary>
    public partial class AddEditView : PageBase
    {

        #region constructor
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="action"></param>
        public AddEditView()
        {
            InitializeComponent();
            Animation = PageAnimationType.Fade;
        }
        #endregion
    }
}
