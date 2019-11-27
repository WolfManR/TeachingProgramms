using OrganizationEF.Models;
using System.Collections.Generic;
using System.Linq;

namespace OrganizationEF.Repos
{
    public class DepartmentRepo:BaseRepo<Department>
    {
        public override List<Department> GetAll() => Context.Departments.ToList();
    }
}
