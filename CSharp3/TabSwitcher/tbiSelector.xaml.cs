using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TabSwitcher
{
    /// <summary>
    /// Логика взаимодействия для tbiSelector.xaml
    /// </summary>
    public partial class tbiSelector : UserControl
    {
        private string title;
        private IEnumerable items;

        public tbiSelector()
        {
            InitializeComponent();
        }

        public string Title { get => title; set => title = value; }

        public IEnumerable Items { get => items; set => items = value; }
        public string ComboDisplayMemberPath {  set => cbSelecter.DisplayMemberPath = value; }
        public string ComboSelectedValuePath {  set => cbSelecter.SelectedValuePath = value; }
        public string ComboText { get => cbSelecter.Text; }
        public object ComboSelectedValue { get => cbSelecter.SelectedValue; }

        public event RoutedEventHandler AddClick;
        public event RoutedEventHandler EditClick;
        public event RoutedEventHandler DeleteClick;

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddClick?.Invoke(sender, e);
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            EditClick?.Invoke(sender, e);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            DeleteClick?.Invoke(sender, e);
        }
    }
}
