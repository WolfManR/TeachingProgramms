using OrganizationProject_ADO_Library.ADO;
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
        void Init();
    }
}
