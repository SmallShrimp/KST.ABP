using System;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace KST.ABP.Organizations.EntityFrameworkCore
{
    public static class OrganizationsDbContextModelCreatingExtensions
    {
        public static void ConfigureOrganizations(
            this ModelBuilder builder,
            Action<OrganizationsModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new OrganizationsModelBuilderConfigurationOptions(
                OrganizationsDbProperties.DbTablePrefix,
                OrganizationsDbProperties.DbSchema
            );

            optionsAction?.Invoke(options);
            builder.Entity<OrganizationUnit>(b =>
            {
                b.ToTable(options.TablePrefix + "OrganizationUnit", options.Schema);
                b.Property(p => p.DisplayName).IsRequired();
                b.HasMany(p => p.Children)
                .WithOne(p => p.Parent)
                .HasForeignKey(p => p.ParentId);

                b.Property(p => p.Code).IsRequired();
                b.HasIndex(p => p.Code).IsUnique();
                b.ConfigureFullAuditedAggregateRoot();
                b.ConfigureMultiTenant();
            });
            builder.Entity<UserOrganizationUnit>(b =>
            {
                b.ToTable(options.TablePrefix + "UserOrganizationUnit", options.Schema);
                b.TryConfigureSoftDelete();
                b.TryConfigureCreationAudited();
                b.ConfigureMultiTenant();
            });

            builder.Entity<OrganizationUnitRole>(b =>
            {
                b.ToTable(options.TablePrefix + "OrganizationUnitRole", options.Schema);
                b.TryConfigureSoftDelete();
                b.TryConfigureCreationAudited();
                b.ConfigureMultiTenant();
            });
             
        }
    }
}