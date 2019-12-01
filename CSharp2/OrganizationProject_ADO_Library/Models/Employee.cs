namespace OrganizationProject_ADO_Library.Models
{
    public class Employee:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
