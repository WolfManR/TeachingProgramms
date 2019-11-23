using System.Collections.ObjectModel;

namespace ProjectForDepartaments.Models
{
    public class Organization
    {
        public ObservableCollection<Department> Departments { get; set; }
        public string Name { get; set; }
        public Organization(string name)
        {
            Name = name;
            Departments = new ObservableCollection<Department>();
        }
    }
}
