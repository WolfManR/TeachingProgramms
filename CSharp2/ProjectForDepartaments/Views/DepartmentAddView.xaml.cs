using System.Windows;

namespace ProjectForDepartaments.Views
{
    /// <summary>
    /// Логика взаимодействия для DepartmentAddView.xaml
    /// </summary>
    public partial class DepartmentAddView : Window
    {
        public string DepartmentName { get; set; }
        public DepartmentAddView()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            DepartmentName = tbResult.Text;
            this.DialogResult = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
