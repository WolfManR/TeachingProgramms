using ProjectForDepartaments.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ProjectForDepartaments.ViewModels
{        //Незнаю как реализовать и нужно ли
    public class DepartmentViewModel : INotifyPropertyChanged
    {
        private Employee selectedEmployee;

        public Employee SelectedEmployee
        {
            get => selectedEmployee; 
            set
            {
                if (selectedEmployee == value) return;
                selectedEmployee.IsSelected = false;
                value.IsSelected = true;
                selectedEmployee = value;
                OnPropertyChanged();
            }
        }
        public Department Department { get; set; }

        public DepartmentViewModel(Department department)
        {
            Department = department;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
