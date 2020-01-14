using MongoDB.Driver;
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
        IMongoCollection<OrganizationUnit> OrganizationUnits { get; }
        IMongoCollection<OrganizationUnitRole> OrganizationUnitRoles { get; }
        IMongoCollection<UserOrganizationUnit> UserOrganizationUnits { get; }
    }
}
