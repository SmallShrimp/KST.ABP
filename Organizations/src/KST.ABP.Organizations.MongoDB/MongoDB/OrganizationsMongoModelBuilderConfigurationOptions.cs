using JetBrains.Annotations;
using Volo.Abp.MongoDB;

namespace KST.ABP.Organizations.MongoDB
{
    public class OrganizationsMongoModelBuilderConfigurationOptions : AbpMongoModelBuilderConfigurationOptions
    {
        public OrganizationsMongoModelBuilderConfigurationOptions(
            [NotNull] string collectionPrefix = "")
            : base(collectionPrefix)
        {
        }
    }
}