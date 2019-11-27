using System.Data.Entity;

namespace OrganizationEF.EF
{
    public class DBInitializer: DropCreateDatabaseAlways<GBOrganizationEntities>
    {
        protected override void Seed(GBOrganizationEntities context)
        {
            base.Seed(context);
        }
    }
}
