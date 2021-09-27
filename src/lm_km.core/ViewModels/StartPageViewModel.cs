using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Events;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Events;
using System;
using System.Collections.Generic;

namespace lm_km.core
{
    public class StartPageViewModel : ViewModelBase
    {
        private RelayCommand _fetchKeynotesBtnCommand;
        private readonly MainPageContainerViewModel _mainPageContainerViewModel;

        public RelayCommand FetchKeynotesBtnCommand { get => _fetchKeynotesBtnCommand; set => _fetchKeynotesBtnCommand = value; }

        public StartPageViewModel(MainPageContainerViewModel mainPageContainerViewModel)
        {
            _fetchKeynotesBtnCommand = new RelayCommand(x => FetchKeynotesBtnExec());
            _mainPageContainerViewModel = mainPageContainerViewModel;
        }

        private void FetchKeynotesBtnExec()
        {
            var keynoteRepository = new KeynoteRepository();
            _mainPageContainerViewModel.HomePage = new KeynoteTreeViewModel(keynoteRepository);
            MediatorHelper.NotifyColleagues("NavigateHome", null);
        }
    }
}
