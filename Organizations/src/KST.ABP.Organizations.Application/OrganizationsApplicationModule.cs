using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.Application;
using Volo.Abp.VirtualFileSystem;
using Microsoft.Extensions.DependencyInjection;

namespace KST.ABP.Organizations
{
    [DependsOn(
        typeof(OrganizationsDomainModule),
        typeof(OrganizationsApplicationContractsModule),
        typeof(AbpDddApplicationModule),
        typeof(AbpAutoMapperModule)
        )]
    public class OrganizationsApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<OrganizationsApplicationModule>();
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<OrganizationsApplicationModule>(validate: true);
            });

            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<OrganizationsApplicationModule>();
            });
        }
    }
}
