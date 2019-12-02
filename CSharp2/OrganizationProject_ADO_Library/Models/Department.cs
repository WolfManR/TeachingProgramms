using System.Collections.ObjectModel;

namespace OrganizationProject_ADO_Library.Models
{
    public class Department:BaseEntity
    {
        public string Name { get; set; }
        public ObservableCollection<Employee> Employees { get; set; }
    }
}
