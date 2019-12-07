using System.Data.SqlClient;

namespace OrganizationProject_ADO_Library.ADO
{
    public class ADOBase
    {
        public SqlConnection Connection { get; set; }
        public SqlDataAdapter Adapter { get; set; } = new SqlDataAdapter();
        public ADOBase(string connectionString)
        {
            Connection = new SqlConnection(connectionString);
        }
    }
}
