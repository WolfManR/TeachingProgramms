using ProjectForDepartaments.Models;
using System.Windows;

namespace ProjectForDepartaments.Views
{
    /// <summary>
    /// Логика взаимодействия для DepartmentAddView.xaml
    /// </summary>
    public partial class DepartmentAddView : Window
    {
        public Department Department { get; set; }
        public DepartmentAddView(Organization organization)
        {
            InitializeComponent();
            Department = new Department() { Organization = organization };
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
