using OrganizationEF.EF;
using OrganizationEF.Models;
using System.Collections.Generic;
using System.Linq;

namespace OrganizationEF.Repos
{
    public class EmployeeRepo:BaseRepo<Employee>
    {
        public EmployeeRepo(GBOrganizationEntities context) : base(context)
        {

        }
        public override List<Employee> GetAll() => Context.Employees.ToList();
    }
}
