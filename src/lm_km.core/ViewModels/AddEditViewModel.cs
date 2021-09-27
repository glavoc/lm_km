using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace lm_km.core
{
    public class AddEditViewModel : ViewModelBase
    {
        #region fields
        private ICommand _applyBtnCommand;
        private ICommand _discardBtnCommand;
        private KeynoteTreeViewModel _keynoteTreeViewModel;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="keynoteViewModel"></param>
        /// <param name="parentKeynoteViewModel"></param>
        /// <param name="keynoteTreeViewModel"></param>
        public AddEditViewModel(KeynoteViewModel keynoteViewModel, KeynoteViewModel parentKeynoteViewModel, KeynoteTreeViewModel keynoteTreeViewModel)
        {
            _keynoteTreeViewModel = keynoteTreeViewModel;

            if(keynoteViewModel == null) //Adding keynote
            {
                IsComboBoxEnabled = false;
                CurrentKeynote = new KeynoteViewModel(
                    new Keynote()
                    {
                        Parent = parentKeynoteViewModel.Category,
                        Text = "",
                        Category = "",
                    });
            }
            else //Editing keynote
            {
                IsComboBoxEnabled = true;
                CurrentKeynote = keynoteViewModel;
            }

            KeynoteList = keynoteTreeViewModel.KeynoteList;

            _applyBtnCommand = new RelayCommand(x => this.ApplyBtnExec(), x => CurrentKeynote.Category != "");
            _discardBtnCommand = new RelayCommand(x => this.DiscardBtnExec());

        }
        #endregion

        #region Public properties

        /// <summary>
        /// Gets or sets active keynote
        /// </summary>
        public KeynoteViewModel CurrentKeynote { get; set; }
        /// <summary>
        /// Gets or sets backup keynote for discarding changes
        /// </summary>
        public KeynoteViewModel BackupKeynote { get; set; }
        /// <summary>
        /// List of all keynotes
        /// </summary>
        public ObservableCollection<KeynoteViewModel> KeynoteList { get; set; }
        /// <summary>
        /// Enable or disable views keynote combobox
        /// </summary>
        public bool IsComboBoxEnabled { get; set; }
        /// <summary>
        /// Returns <see cref="KeynoteViewModel"/> parent of selected keynote
        /// </summary>
        public KeynoteViewModel KeynoteParent
        {
            get => KeynoteList.ToList().Find(x => CurrentKeynote.Parent == x.Category);
        }

        #endregion

        #region Command properties
        public ICommand ApplyBtnCommand { get => _applyBtnCommand; set => _applyBtnCommand = value; }
        public ICommand DiscardBtnCommand { get => _discardBtnCommand; set => _discardBtnCommand = value; }
        #endregion

        #region Command methods

        private void DiscardBtnExec()
        {
            CurrentKeynote = BackupKeynote;
            MediatorHelper.NotifyColleagues("NavigateHome", null);
        }

        private void ApplyBtnExec()
        {
            if (!IsComboBoxEnabled) //keynote added
            {
                _keynoteTreeViewModel.Insert(CurrentKeynote);
                CurrentKeynote.State = KeynoteStateTypes.Add;
            }
            else // keynote edited
            {
                CurrentKeynote.State = KeynoteStateTypes.Edit;
            }
            //return to treeview page
            MediatorHelper.NotifyColleagues("NavigateHome", null);
        }
        #endregion
    }
}