﻿using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.Application;

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
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<OrganizationsApplicationModule>(validate: true);
            });
        }
    }
}
