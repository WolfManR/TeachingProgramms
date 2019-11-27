using OrganizationEF.Models;
using System.Collections.Generic;
using System.Linq;

namespace OrganizationEF.Repos
{
    public class EmployeeRepo:BaseRepo<Employee>
    {
        public override List<Employee> GetAll() => Context.Employees.ToList();
    }
}
