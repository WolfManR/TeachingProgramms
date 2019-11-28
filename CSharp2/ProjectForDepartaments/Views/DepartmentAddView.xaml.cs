using OrganizationEF.Models;
using System.Windows;

namespace ProjectForDepartaments.Views
{
    /// <summary>
    /// Логика взаимодействия для DepartmentAddView.xaml
    /// </summary>
    public partial class DepartmentAddView : Window
    {
        public Department Department { get; set; } = new Department();
        public DepartmentAddView()
        {
            InitializeComponent();
            this.DataContext = Department;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
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
