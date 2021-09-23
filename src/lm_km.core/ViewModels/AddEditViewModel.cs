using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace lm_km.core
{
    public class AddEditViewModel : ViewModelBase
    {
        private ICommand _applyBtnCommand;
        private ICommand _discardBtnCommand;

        public AddEditViewModel(KeynoteViewModel keynoteViewModel)
        {
            CurrentKeynote = keynoteViewModel;
        }

        public KeynoteViewModel CurrentKeynote { get; set; }
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
            MediatorHelper.NotifyColleagues("ChangeView", new KeynoteTreeViewModel());
        }


        internal void ApplyBtnExec()
        {
            CurrentKeynote.State = KeynoteStateTypes.Add;
            MediatorHelper.NotifyColleagues("ChangeView", new KeynoteTreeViewModel());
        }

    }
}
