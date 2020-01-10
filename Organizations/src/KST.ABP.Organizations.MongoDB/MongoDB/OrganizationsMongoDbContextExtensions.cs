using System;
using Volo.Abp;
using Volo.Abp.MongoDB;

namespace KST.ABP.Organizations.MongoDB
{
    public static class OrganizationsMongoDbContextExtensions
    {
        public static void ConfigureOrganizations(
            this IMongoModelBuilder builder,
            Action<AbpMongoModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new OrganizationsMongoModelBuilderConfigurationOptions(
                OrganizationsDbProperties.DbTablePrefix
            );

            optionsAction?.Invoke(options);
        }
    }
}