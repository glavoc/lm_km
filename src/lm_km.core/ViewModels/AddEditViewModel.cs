using System.Windows.Input;

namespace lm_km.core
{
    public class AddEditViewModel : ViewModelBase
    {
        private ICommand _applyBtnCommand;
        private ICommand _discardBtnCommand;

        public AddEditViewModel(KeynoteViewModel keynoteViewModel, KeynoteViewModel parentKeynoteViewModel, KeynoteRepository keynoteRepository)
        {
            if(keynoteViewModel == null)
            {
                CurrentKeynote = new KeynoteViewModel(
                    new Keynote()
                    {
                        Parent = parentKeynoteViewModel.Category,
                        Text = "",
                        Category = "",
                    });
            }
            else
            {
                CurrentKeynote = keynoteViewModel;
            }
            KeynoteRepository = keynoteRepository;
        }

        public KeynoteViewModel CurrentKeynote { get; set; }
        public KeynoteRepository KeynoteRepository { get; set; }
        public bool IsComboBoxEnabled { get => false; }

        public ICommand DiscardBtnCommand
        {
            get
            {
                if (_discardBtnCommand == null)
                {
                    _discardBtnCommand = new RelayCommand(x => this.DiscardBtnExec());
                }
                return _discardBtnCommand;
            }
        }

        public ICommand ApplyBtnCommand
        {
            get
            {
                if (_applyBtnCommand == null)
                {
                    _applyBtnCommand = new RelayCommand(x => this.ApplyBtnExec());
                }
                return _applyBtnCommand;
            }
        }

        private void DiscardBtnExec()
        {
            MediatorHelper.NotifyColleagues("NavigateHome", null);
        }

        internal void ApplyBtnExec()
        {
            KeynoteRepository.Add(CurrentKeynote.Keynote);
            CurrentKeynote.State = KeynoteStateTypes.Add;
            MediatorHelper.NotifyColleagues("NavigateHome", null);
        }
    }
}