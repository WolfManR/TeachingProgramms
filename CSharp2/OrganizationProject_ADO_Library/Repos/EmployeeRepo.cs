using System.Data;
using System.Data.SqlClient;
using OrganizationProject_ADO_Library.ADO;

namespace OrganizationProject_ADO_Library.Repos
{
    public class EmployeeRepo : BaseRepo
    {
        public EmployeeRepo(ADOBase context) : base(context)
        {
            SelectAllCommand = new SqlCommand("Select Employee.Id,Employee.FirstName,Employee.LastName,Departments.Name From Employees Inner Join Departments On DepartmentId = Departments.Id", context.Connection);

            InsertCommand = new SqlCommand("Insert Into Employees (FirstName,LastName,DepartmentId) Values (@FirstName,@LastName,(Select Id From Departments Where Name = @Name)); Set @Id = @@IDENTITY;", context.Connection);
            InsertCommand.Parameters.Add("@FirstName", SqlDbType.NVarChar, 50, "FirstName");
            InsertCommand.Parameters.Add("@LastName", SqlDbType.NVarChar, 50, "LastName");
            InsertCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 50, "Name");
            InsertCommand.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int, -1, "Id") { Direction = ParameterDirection.Output });

            UpdateCommand = new SqlCommand(@"Update Employees Set FirstName = @FirstName, LastName = @LastName, DepartmentId = (Select Id From Departments Where Name = @Name) Where Id = @Id", context.Connection);
            UpdateCommand.Parameters.Add("@FirstName", SqlDbType.NVarChar, 50, "FirstName");
            UpdateCommand.Parameters.Add("@LastName", SqlDbType.NVarChar, 50, "LastName");
            UpdateCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 50, "Name");
            UpdateCommand.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int, -1, "Id") { SourceVersion = DataRowVersion.Original });

            DeleteCommand = new SqlCommand(@"Delete From Employees Where Id = @Id", context.Connection);
            DeleteCommand.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int, -1, "Id") { SourceVersion = DataRowVersion.Original });
        }
    }
}
