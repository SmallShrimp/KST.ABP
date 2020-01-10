using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace KST.ABP.Organizations.EntityFrameworkCore
{
    public class OrganizationsModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
    {
        public OrganizationsModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = "",
            [CanBeNull] string schema = null)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}