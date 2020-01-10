using Volo.Abp.Modularity;
using Volo.Abp.Localization;
using KST.ABP.Organizations.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Localization.Resources.AbpValidation;
using Volo.Abp.VirtualFileSystem;

namespace KST.ABP.Organizations
{
    [DependsOn(
        typeof(AbpLocalizationModule)
    )]
    public class OrganizationsDomainSharedModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<OrganizationsDomainSharedModule>("KST.ABP.Organizations");
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<OrganizationsResource>("en")
                    .AddBaseTypes(typeof(AbpValidationResource))
                    .AddVirtualJson("/Localization/Organizations");
            });

            Configure<AbpExceptionLocalizationOptions>(options =>
            {
                options.MapCodeNamespace("Organizations", typeof(OrganizationsResource));
            });
        }
    }
}
