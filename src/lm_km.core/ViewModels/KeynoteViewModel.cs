using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lm_km.core
{
    public class KeynoteViewModel : ViewModelBase
    {
        #region private parameters
        private ObservableCollection<KeynoteViewModel> _nestedKeynotes;
        private bool _isExpanded;
        private bool _isSelected;
        private KeynoteStateTypes _state = KeynoteStateTypes.None;
        #endregion

        public KeynoteViewModel(Keynote entry)
        {
            Keynote = entry;
        }

        #region public properties 
        public Keynote Keynote { get; set; }
        public string Text 
        { 
            get 
            { 
                return Keynote.Text; 
            } 
            set 
            { 
                Keynote.Text = value; 
                base.OnPropertyChanged(nameof(Text)); 
            } 
        
        }
        public string Category 
        { 
            get 
            { 
                return Keynote.Category; 
            } 
            set 
            { 
                Keynote.Category = value; 
                base.OnPropertyChanged(nameof(Category)); 
            } 
        }
        public string Parent 
        {
            get 
            { 
                return Keynote.Parent; 
            }
            set 
            {
                Keynote.Parent = value; 
                base.OnPropertyChanged(nameof(Parent)); 
            } 
        }
        public ObservableCollection<KeynoteViewModel> NestedKeynotes 
        { 
            get 
            { 
                return _nestedKeynotes; 
            } 
            set 
            { 
                _nestedKeynotes = value; 
                base.OnPropertyChanged(nameof(NestedKeynotes)); 
            } 
        }

        public bool IsExpanded
        {
            get { return _isExpanded; }
            set
            {
                if (value != _isExpanded)
                {
                    _isExpanded = value;
                    this.OnPropertyChanged("IsExpanded");
                }

                // Expand all the way up to the root.
                //if (_isExpanded && Parent != null)
                    //Parent.IsExpanded = true;
            }
        }

        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                base.OnPropertyChanged("IsSelected");
            }
        }

        public KeynoteStateTypes State 
        { 
            get 
            { 
                return _state; 
            } 
            set 
            { 
                _state = value; 
                base.OnPropertyChanged("State"); 
            } 
        }
        #endregion


        #region ContainsText

        public bool ContainsText(string text)
        {
            if (String.IsNullOrEmpty(text) || String.IsNullOrEmpty(this.Text))
                return false;

            return this.Text.IndexOf(text, StringComparison.InvariantCultureIgnoreCase) > -1;
        }

        #endregion

    }
}
