using OrganizationEF.EF;
using OrganizationEF.Models;
using OrganizationEF.Repos;
using System;

namespace OrganizationEF_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome");
            using(var context = new GBOrganizationEntities())
            {
                foreach (Department item in context.Departments) Console.WriteLine($"department: {item.Name}, id: {item.Id}");
            }
            Console.WriteLine("\n\nRepos");
            Console.WriteLine("Department repo");
            using(var depRepo= new DepartmentRepo())
            {
                foreach(Department item in depRepo.GetAll()) Console.WriteLine($"department: {item.Name,24}, id: {item.Id}");
            }
            Console.WriteLine("\n\nEmployee repo");
            using (var emplRepo = new EmployeeRepo())
            {
                foreach (Employee item in emplRepo.GetAll()) Console.WriteLine($"Employee: {item.FullName, 30}, id: {item.Id}, in department: {item.DepartmentId} {item.Department.Name}");
            }

            Console.ReadLine();
        }
    }
}
