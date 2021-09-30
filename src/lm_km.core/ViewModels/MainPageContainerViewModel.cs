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
        private ViewModelBase _currentPage;
        private Document _currentDocument;


        //public ViewModelBase CurrentPage { get { return _currentPage; } set { _currentPage = value; OnPropertyChanged(nameof(CurrentPage)); } }
        public ViewModelBase CurrentPage 
        { 
            get 
            { 
                if (!RVT_App.RVTDocDictContainer.ContainsKey(_currentDocument))
                {
                    return new StartPageViewModel(this); 
                }
                else
                {
                    return RVT_App.RVTDocDictContainer[_currentDocument];
                }
            } 
            set 
            {
                RVT_App.RVTDocDictContainer[_currentDocument] = value; 
                OnPropertyChanged(nameof(CurrentPage)); 
            } 
        }
        
        public ViewModelBase HomePage { get; set; }

        public MainPageContainerViewModel()
        {
            //CurrentPage = new StartPageViewModel(this);
            RVT_App.RVT_UIControlledApp.ViewActivated += new EventHandler<ViewActivatedEventArgs>(OnRevitViewChanged);
            MediatorHelper.Register("ChangeView", OnChangeView);
            MediatorHelper.Register("NavigateHome", OnNavigateHome);

        }

        private void OnRevitViewChanged(object sender, ViewActivatedEventArgs e)
        {
            _currentDocument = e.Document;
            if (RVT_App.RVTDocDictContainer.ContainsKey(_currentDocument))
            {
                CurrentPage = RVT_App.RVTDocDictContainer[_currentDocument];
            }
            else
            {
                CurrentPage = new StartPageViewModel(this);
            }

            /*if ((e.PreviousActiveView != null) && (e.PreviousActiveView.Document != null)) // start screen has neither view nor document
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
            }*/
        }

        private void OnChangeView(object o)
        {
            ViewModelBase viewModel = o as ViewModelBase;
            CurrentPage = viewModel;
        }
        private void OnNavigateHome(object obj)
        {
            CurrentPage = HomePage;
        }

    }
}
