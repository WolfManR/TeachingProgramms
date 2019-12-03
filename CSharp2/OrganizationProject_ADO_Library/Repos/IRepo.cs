using OrganizationProject_ADO_Library.ADO;
using System.Data;
using System.Data.SqlClient;

namespace OrganizationProject_ADO_Library.Repos
{
    public interface IRepo
    {
        ADOBase Context { get; set; }
        SqlCommand SelectAllCommand { get; set; }
        SqlCommand SelectOneById { get; set; }
        SqlCommand UpdateCommand { get; set; }
        SqlCommand InsertCommand { get; set; }
        SqlCommand DeleteCommand { get; set; }

        void GetAll(DataTable table);
        void GetOneById(int id);
        void Insert(DataTable table);
        void Update(DataTable table);
        void Delete(DataTable table);
    }
}
