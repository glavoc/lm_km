using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using lm_km.core;

namespace lm_km.ui
{
    /// <summary>
    /// Interaction logic for Viewer.xaml
    /// </summary>
    public partial class TreeView : PageBase
    {
        // constructor
        public TreeView()
        {
            InitializeComponent();
        }

        #region private methods

        private void TreeView1_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            System.Windows.Controls.TreeView tvi = sender as System.Windows.Controls.TreeView;
            KeynoteTreeViewModel cvm = tvi.DataContext as KeynoteTreeViewModel;
            if (cvm != null)
            {
                cvm.SelectedKeynote = tvi.SelectedItem as KeynoteViewModel;
            }
            e.Handled = true;
        }
        private void searchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                var tvi = sender as System.Windows.Controls.TextBox;
                KeynoteTreeViewModel cvm = tvi.DataContext as KeynoteTreeViewModel;
                if (cvm != null)
                {
                    cvm.SearchCommand.Execute(null);
                }
                e.Handled = true;
            }
        }
        private void TreeView1_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (!(e.OriginalSource is TextBlock))
            {
                KeynoteViewModel item = TreeView1.SelectedItem as KeynoteViewModel;
                if (item != null)
                {
                    TreeView1.Focus();
                    item.IsSelected = false;
                }
            }
            else if (e.OriginalSource is TextBlock)
            {
                TreeViewItem treeViewItem = VisualUpwardSearch(e.OriginalSource as DependencyObject);
                if (treeViewItem != null)
                {
                    treeViewItem.Focus();
                    treeViewItem.IsSelected = true;
                }
            }
        }

        static TreeViewItem VisualUpwardSearch(DependencyObject source)
        {
            while (source != null && !(source is TreeViewItem))
                source = VisualTreeHelper.GetParent(source);

            return source as TreeViewItem;
        }
        #endregion private methods

    }
}