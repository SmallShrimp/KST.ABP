using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace KST.ABP.Organizations.MongoDB
{
    [ConnectionStringName(OrganizationsDbProperties.ConnectionStringName)]
    public interface IOrganizationsMongoDbContext : IAbpMongoDbContext
    {
        /* Define mongo collections here. Example:
         * IMongoCollection<Question> Questions { get; }
         */
    }
}
