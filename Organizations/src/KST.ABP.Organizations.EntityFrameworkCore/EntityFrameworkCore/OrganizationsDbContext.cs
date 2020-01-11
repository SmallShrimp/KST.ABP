using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Identity.EntityFrameworkCore;

namespace KST.ABP.Organizations.EntityFrameworkCore
{
    [ConnectionStringName(OrganizationsDbProperties.ConnectionStringName)]
    public class OrganizationsDbContext : AbpDbContext<OrganizationsDbContext>, IOrganizationsDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * public DbSet<Question> Questions { get; set; }
         */

        public OrganizationsDbContext(DbContextOptions<OrganizationsDbContext> options) 
            : base(options)
        {

        }

        public virtual DbSet<OrganizationUnit> OrganizationUnits { get; set; }

        public virtual DbSet<UserOrganizationUnit> UserOrganizationUnits { get; set; }

        public virtual DbSet<OrganizationUnitRole> OrganizationUnitRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureIdentity();
            builder.ConfigureOrganizations();
        }
    }
}