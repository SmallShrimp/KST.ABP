using Volo.Abp.Modularity;

namespace KST.ABP.Organizations
{
    [DependsOn(
        typeof(OrganizationsApplicationModule),
        typeof(OrganizationsDomainTestModule)
        )]
    public class OrganizationsApplicationTestModule : AbpModule
    {

    }
}
