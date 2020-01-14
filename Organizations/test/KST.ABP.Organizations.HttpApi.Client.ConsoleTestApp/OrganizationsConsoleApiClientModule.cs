using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace KST.ABP.Organizations
{
    [DependsOn(
        typeof(OrganizationsHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class OrganizationsConsoleApiClientModule : AbpModule
    {
        
    }
}
