using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace lm_km.core
{
    public class KeynoteTreeViewModel : ViewModelBase, IDisposable
    {
        #region private fields

        private IEnumerator<KeynoteViewModel> _matchingKeynoteEnumerator;
        private ObservableCollection<KeynoteViewModel> _rootKeynotes;
        private string _searchText = String.Empty;
        private KeynoteViewModel _selectedKeynote;
        private ObservableCollection<KeynoteViewModel> _keynoteList;
        private KeynoteRepository _keynoteRepository;
        private ICommand _addViewBtnCommand;
        private ICommand _editViewBtnCommand;
        private ICommand _deleteViewBtnCommand;
        private ICommand _searchCommand;
        private ICommand _refreshBtnCommand;

        #endregion private fields

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public KeynoteTreeViewModel(KeynoteRepository keynoteRepository)
        {
            _keynoteRepository = keynoteRepository;
            BuildTree();

            _addViewBtnCommand = new RelayCommand(x => AddViewBtnExec());
            _editViewBtnCommand = new RelayCommand(x => EditViewBtnExec(), x => SelectedKeynote != null);
            _deleteViewBtnCommand = new RelayCommand(x => DeleteViewBtnExec(), x => SelectedKeynote != null);
            _refreshBtnCommand = new RelayCommand(x => { RefreshBtnExec(); });
            _searchCommand = new RelayCommand(x => { { PerformSearch(); } });
        }



        #endregion Constructor

        #region Command properties

        public ICommand AddViewBtnCommand { get => _addViewBtnCommand; }
        public ICommand EditViewBtnCommand { get => _editViewBtnCommand; }
        public ICommand DeleteViewBtnCommand { get => _deleteViewBtnCommand; }
        public ICommand RefreshBtnCommand { get => _refreshBtnCommand; }
        public ICommand SearchCommand { get => _searchCommand; }

        #endregion Command properties

        #region Public properties
        public KeynoteViewModel SelectedKeynote
        {
            get
            {
                return _selectedKeynote;
            }

            set
            {
                _selectedKeynote = value;
                OnPropertyChanged(nameof(SelectedKeynote));
            }
        }

        public ObservableCollection<KeynoteViewModel> RootKeynotes 
        { 
            get 
            { 
                return _rootKeynotes; 
            } 
            set 
            { 
                _rootKeynotes = value; 
                OnPropertyChanged(nameof(RootKeynotes)); 
            } 
        }

        public string SearchText
        {
            get { return _searchText; }
            set
            {
                if (value == _searchText)
                    return;

                _searchText = value;

                _matchingKeynoteEnumerator = null;
            }
        }

        public ObservableCollection<KeynoteViewModel> KeynoteList { get => _keynoteList; set => _keynoteList = value; }



        #endregion Public properties

        #region Search Command Methods

        /// <summary>
        /// Performs search
        /// </summary>
        public void PerformSearch()
        {
            if (_matchingKeynoteEnumerator == null || !_matchingKeynoteEnumerator.MoveNext())
                this.VerifyMatchingEnumerator();

            var keynote = _matchingKeynoteEnumerator.Current;

            if (keynote == null)
                return;

            // Ensure that this person is in view.
            /*            if (keynote.KeynoteParent != null)
                            keynote.KeynoteParent.IsExpanded = true;*/

            keynote.IsSelected = true;
        }

        /// <summary>
        /// Finds and returns list of matching results
        /// </summary>
        /// <param name="searchText"></param>
        /// <param name="keynotes"></param>
        /// <returns></returns>
        private IEnumerable<KeynoteViewModel> FindMatches(string searchText, List<KeynoteViewModel> keynotes)
        {
            foreach (KeynoteViewModel keynote in keynotes)
            {
                if (keynote.ContainsText(searchText))
                    yield return keynote;
            }
        }

        /// <summary>
        /// Logic for results found
        /// </summary>
        private void VerifyMatchingEnumerator()
        {
            var matches = this.FindMatches(_searchText, _keynoteList.ToList());
            _matchingKeynoteEnumerator = matches.GetEnumerator();

            if (!_matchingKeynoteEnumerator.MoveNext())
            {
                MessageBox.Show(
                    "No matching names were found.",
                    "Try Again",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information
                    );
            }
        }

        #endregion Search Command Methods

        #region Command Methods

        private void AddViewBtnExec()
        {
            var parentKeynoteViewModel = SelectedKeynote;
            MediatorHelper.NotifyColleagues("ChangeView", new AddEditViewModel(null, parentKeynoteViewModel, this));
        }

        private void EditViewBtnExec()
        {
            var parentKeynoteViewModel = _keynoteList.ToList().Find(x => x.Category == SelectedKeynote.Parent);
            MediatorHelper.NotifyColleagues("ChangeView", new AddEditViewModel(SelectedKeynote, parentKeynoteViewModel, this));
        }

        private void DeleteViewBtnExec()
        {
            MediatorHelper.NotifyColleagues("ChangeView", new DeleteViewModel(SelectedKeynote, this));
        }

        /// <summary>
        /// Repopulate <see cref="TreeView"/> from database
        /// </summary>
        private void RefreshBtnExec()
        {
            MediatorHelper.NotifyColleagues("OnKeynoteRepositorySaved", null);
        }

        #endregion Command Methods

        #region Private Methods

        /// <summary>
        /// Builds the tree
        /// </summary>
        private void BuildTree()
        {
            try
            {
                _keynoteList = new ObservableCollection<KeynoteViewModel>(_keynoteRepository.GetItems().Select(x => new KeynoteViewModel(x)).ToList());
                // convert category parent string to object
                //_keynoteList.ForEach(item => item.Parent = _keynoteList.Find(parent => item.Parent == parent.Category));
                RootKeynotes = new ObservableCollection<KeynoteViewModel>(_keynoteList.Where(x => x.Parent == "").ToList());
                // build hierarchy tree as observablecollection, assign nested keynotes
                _keynoteList.ToList()
                    .ForEach(
                    item => item.NestedKeynotes = new ObservableCollection<KeynoteViewModel>(
                        _keynoteList
                        .Where(child => child.Parent == item.Category)
                        .ToList()
                        ));
            }
            catch (Exception)
            {

                MessageBox.Show("Error", "No Keynote file loaded to Revit");
            }
        }

        internal void Insert(KeynoteViewModel newKeynote)
        {
            KeynoteList.Add(newKeynote);
            //Add new keynote to parents nested keynotes list
            KeynoteList.ToList().Find(x => newKeynote.Parent == x.Category).NestedKeynotes.Add(newKeynote);
            //Notify all subscribers
            MediatorHelper.NotifyColleagues("OnKeynoteAdd", newKeynote.Keynote);
        }

        internal void Delete(KeynoteViewModel keynote)
        {
            KeynoteList.ToList().Find(x => keynote.Parent == x.Category).NestedKeynotes.Remove(keynote);
            KeynoteList.Remove(keynote);
            //Notify all subscribers
            MediatorHelper.NotifyColleagues("OnKeynoteDelete", keynote.Keynote);

        }


        #endregion Private Methods

    }
}