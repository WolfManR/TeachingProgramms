using OrganizationEF.Models;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;

namespace OrganizationEF.EF
{
    public partial class GBOrganizationEntities: DbContext
    {
        public GBOrganizationEntities() : base("name=InAppFile")
        {
            var context = (this as IObjectContextAdapter).ObjectContext;
            context.ObjectMaterialized += OnObjectMaterialized;
        }

        protected override void Dispose(bool disposing) { }

        private void OnObjectMaterialized(object sender, ObjectMaterializedEventArgs e)
        {
            var model = (e.Entity as EntityBase);
            if (model != null) model.IsChanged = false;
        }

        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder){ }
    }
}
