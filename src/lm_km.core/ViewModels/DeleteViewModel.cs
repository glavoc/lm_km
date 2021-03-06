using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace lm_km.core
{
    public class DeleteViewModel : ViewModelBase
    {
        private readonly KeynoteTreeViewModel _keynoteTreeViewModel;
        private ICommand _applyBtnCommand;
        private ICommand _discardBtnCommand;

        public DeleteViewModel(KeynoteViewModel currentKeynote, KeynoteTreeViewModel keynoteTreeViewModel)
        {
            CurrentKeynote = currentKeynote;
            _keynoteTreeViewModel = keynoteTreeViewModel;
        }
        public KeynoteViewModel CurrentKeynote { get; }

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



        /// <summary>
        /// Deletes <see cref="SelectedKeynote"/>
        /// </summary>
        internal void ApplyBtnExec()
        {
            _keynoteTreeViewModel.Delete(CurrentKeynote);
            CurrentKeynote.State = KeynoteStateTypes.Delete;
            MediatorHelper.NotifyColleagues("NavigateHome", null);
        }

        private void DiscardBtnExec()
        {
            MediatorHelper.NotifyColleagues("NavigateHome", null);
        }
    }
}
