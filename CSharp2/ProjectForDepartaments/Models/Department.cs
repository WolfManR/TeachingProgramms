using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ProjectForDepartaments.Models
{
    public class Department:INotifyPropertyChanged
    {
        private bool isSelected;
        public ObservableCollection<Employee> Employees { get; set; }
        public string Name { get; private set; }
        public bool IsSelected
        {
            get => isSelected; 
            set
            {
                if (isSelected == value) return;
                isSelected = value;
                OnPropertyChanged();
            }
        }
        public Department(string name)
        {
            Name = name;
            Employees = new ObservableCollection<Employee>();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
