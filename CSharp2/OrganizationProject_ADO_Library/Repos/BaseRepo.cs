using System;
using System.Data.SqlClient;
using OrganizationProject_ADO_Library.ADO;

namespace OrganizationProject_ADO_Library.Repos
{
    public class BaseRepo : IRepo
    {
        public BaseRepo(ADOBase context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public ADOBase Context { get; set; }
        public SqlCommand SelectAllCommand { get; set; }
        public SqlCommand SelectOneById { get; set; }
        public SqlCommand UpdateCommand { get; set; }
        public SqlCommand InsertCommand { get; set; }
        public SqlCommand DeleteCommand { get; set; }

        public virtual void Init()
        {
            Context.Adapter.SelectCommand = SelectAllCommand ?? throw new ArgumentNullException("there no one Select Command");
            Context.Adapter.InsertCommand = InsertCommand ?? throw new ArgumentNullException("there no Insert Command");
            Context.Adapter.UpdateCommand = UpdateCommand ?? throw new ArgumentNullException("there no Update Command");
            Context.Adapter.DeleteCommand = DeleteCommand ?? throw new ArgumentNullException("there no Delete Command");
        }
    }
}
