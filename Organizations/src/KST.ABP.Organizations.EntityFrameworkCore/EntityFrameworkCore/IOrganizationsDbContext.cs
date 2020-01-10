using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace KST.ABP.Organizations.EntityFrameworkCore
{
    [ConnectionStringName(OrganizationsDbProperties.ConnectionStringName)]
    public interface IOrganizationsDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
    }
}