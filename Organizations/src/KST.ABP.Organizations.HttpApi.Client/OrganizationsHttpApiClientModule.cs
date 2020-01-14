using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace KST.ABP.Organizations
{
    [DependsOn(
        typeof(OrganizationsApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class OrganizationsHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "Organizations";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(OrganizationsApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
