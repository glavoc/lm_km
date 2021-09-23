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
        private ICommand _applyBtnCommand;
        private ICommand _discardBtnCommand;

        private KeynoteViewModel _currentKeynote;

        public DeleteViewModel(KeynoteViewModel currentKeynote)
        {
            _currentKeynote = currentKeynote;
        }
        public KeynoteViewModel CurrentKeynote { get => _currentKeynote; }

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
            CurrentKeynote.State = KeynoteStateTypes.Delete;
            //_pageStore.ChangeCurrentPage(_pageStore.MainPage);
        }

        private void DiscardBtnExec()
        {
           // _pageStore.ChangeCurrentPage(_pageStore.MainPage);
        }

    }
}
