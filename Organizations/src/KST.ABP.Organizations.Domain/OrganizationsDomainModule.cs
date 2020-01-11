using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace KST.ABP.Organizations
{
    [DependsOn(
        typeof(OrganizationsDomainSharedModule),
        typeof(AbpIdentityDomainModule)
        )]
    public class OrganizationsDomainModule : AbpModule
    {

    }
}
