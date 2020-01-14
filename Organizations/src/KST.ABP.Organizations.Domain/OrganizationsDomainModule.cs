using Volo.Abp.Modularity;

namespace KST.ABP.Organizations
{
    [DependsOn(
        typeof(OrganizationsDomainSharedModule)
        )]
    public class OrganizationsDomainModule : AbpModule
    {

    }
}
