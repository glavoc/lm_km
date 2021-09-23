using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Events;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Events;
using System;
using System.Collections.Generic;

namespace lm_km.core
{
    public class MainPageContainerViewModel : ViewModelBase
    {
        private Autodesk.Revit.ApplicationServices.Application _app;
        private ViewModelBase _currentPage;
        private Dictionary<Document, ViewModelBase> _RVTDocDict = new Dictionary<Document, ViewModelBase>();
        public ViewModelBase CurrentPage { get { return _currentPage; } set { _currentPage = value; OnPropertyChanged(nameof(CurrentPage)); } }


        public MainPageContainerViewModel(UIApplication uiapp)
        {
            _app = uiapp.Application;
            CurrentPage = new KeynoteTreeViewModel();
            uiapp.ViewActivated += new EventHandler<ViewActivatedEventArgs>(OnRevitViewChanged);
            MediatorHelper.Register("ChangeView", OnChangeView);
        }

        private void OnRevitViewChanged(object sender, ViewActivatedEventArgs e)
        {
            if ((e.PreviousActiveView != null) && (e.PreviousActiveView.Document != null)) // start screen has neither view nor document
            {
                if (!e.PreviousActiveView.Document.Equals(e.CurrentActiveView.Document))
                {
                    if (_RVTDocDict.ContainsKey(e.CurrentActiveView.Document))
                    {
                        TaskDialog.Show("Title", "Document Exists");
                    }
                    else
                    {
                        TaskDialog.Show("Title", "Document doesnot exist");
                    }
                }
            }
        }

        private void OnChangeView(object o)
        {
            ViewModelBase viewModel = o as ViewModelBase;
            CurrentPage = viewModel;
        }
    }
}
