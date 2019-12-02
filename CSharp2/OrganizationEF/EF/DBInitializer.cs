using OrganizationEF.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace OrganizationEF.EF
{
    public class DBInitializer: DropCreateDatabaseAlways<GBOrganizationEntities>
    {
        protected override void Seed(GBOrganizationEntities context)
        {
            var departments = new List<Department>
            {
                new Department{ Name="C# Programmers"},
                new Department{ Name="Java group"},
                new Department{ Name="Archetecture"}
            };
            departments.ForEach(depart => context.Departments.AddOrUpdate(a => new { a.Name }, depart));

            var employees = new List<Employee>
            {
                new Employee{FirstName="Dave",LastName="Moris",Department=departments[0]},
                new Employee{FirstName="Chloe",LastName="Sylvine",Department=departments[2]},
                new Employee{FirstName="Emily",LastName="Lork",Department=departments[1]},
                new Employee{FirstName="Mark",LastName="Corson",Department=departments[2]},
                new Employee{FirstName="Chet",LastName="Salar",Department=departments[0]},
                new Employee{FirstName="Norman",LastName="Nozaf",Department=departments[0]},
                new Employee{FirstName="Alerat",LastName="Asazor",Department=departments[1]},
                new Employee{FirstName="Tesne",LastName="Suder",Department=departments[0]},
                new Employee{FirstName="Arkin",LastName="Satabar",Department=departments[1]},
                new Employee{FirstName="Khadar",LastName="Moris",Department=departments[2]},
                new Employee{FirstName="Dave",LastName="Corson",Department=departments[0]},
            };
            context.Employees.AddOrUpdate(x => new { x.FirstName, x.LastName,x.DepartmentId }, employees.ToArray());
        }
    }
}
