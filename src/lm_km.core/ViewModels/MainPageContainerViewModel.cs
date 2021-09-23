using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace lm_km.core
{
    public class MainPageContainerViewModel : ViewModelBase
    {
        private ViewModelBase _currentPage;
         public ViewModelBase CurrentPage { get { return _currentPage; } set { _currentPage = value; OnPropertyChanged(nameof(CurrentPage)); } }


        public MainPageContainerViewModel()
        {
            CurrentPage = new KeynoteTreeViewModel();
            MediatorHelper.Register("ChangeView", OnChangeView);
        }


        private void OnChangeView(object o)
        {
            ViewModelBase viewModel = o as ViewModelBase;
            CurrentPage = viewModel;
        }
    }
}
