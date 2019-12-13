using System.Windows;
using System.Windows.Controls;

namespace MyControlsLibrary
{
    /// <summary>
    /// Логика взаимодействия для TextBoxWithHeader.xaml
    /// </summary>
    public partial class TextBoxWithHeader : UserControl
    {
        public TextBoxWithHeader()
        {
            InitializeComponent();
        }
        public string Header { get => HeaderControl.Text; set => HeaderControl.Text = value; }
        public string Text { get => TextBox.Text; set => TextBox.Text = value; }
    }
}
