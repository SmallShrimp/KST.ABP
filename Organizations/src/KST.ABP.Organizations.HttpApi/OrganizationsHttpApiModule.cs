using Localization.Resources.AbpUi;
using KST.ABP.Organizations.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace KST.ABP.Organizations
{
    [DependsOn(
        typeof(OrganizationsApplicationContractsModule),
        typeof(AbpAspNetCoreMvcModule))]
    public class OrganizationsHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(OrganizationsHttpApiModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<OrganizationsResource>()
                    .AddBaseTypes(typeof(AbpUiResource));
            });
        }
    }
}
