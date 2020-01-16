using KST.ABP.Organizations.User;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.Users.EntityFrameworkCore;

namespace KST.ABP.Organizations.EntityFrameworkCore
{
    [ConnectionStringName(OrganizationsDbProperties.ConnectionStringName)]
    public class OrganizationsDbContext : AbpDbContext<OrganizationsDbContext>, IOrganizationsDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * public DbSet<Question> Questions { get; set; }
         */
        public virtual DbSet<OrganizationUnit> OrganizationUnits { get; set; }

        public virtual DbSet<UserOrganizationUnit> UserOrganizationUnits { get; set; }

        public virtual DbSet<OrganizationUnitRole> OrganizationUnitRoles { get; set; }
        public virtual DbSet<OrganizationUnitUser> Users { get; set; }
        public OrganizationsDbContext(DbContextOptions<OrganizationsDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<OrganizationUnitUser>(b =>
            {
                b.ToTable("AbpUsers"); //Sharing the same table "AbpUsers" with the IdentityUser
                b.ConfigureByConvention();
                b.ConfigureAbpUser();
            });
            builder.ConfigureOrganizations();
        }
    }
}