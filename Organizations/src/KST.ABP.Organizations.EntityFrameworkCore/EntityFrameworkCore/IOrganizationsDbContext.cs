using Microsoft.EntityFrameworkCore;
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
        DbSet<OrganizationUnit> OrganizationUnits { get; }
        DbSet<UserOrganizationUnit> UserOrganizationUnits { get; }
        DbSet<OrganizationUnitRole> OrganizationUnitRoles { get; }
    }
}