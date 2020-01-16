using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;
using Volo.Abp.Users.EntityFrameworkCore;

namespace KST.ABP.Organizations.EntityFrameworkCore
{
    [DependsOn(
        typeof(OrganizationsDomainModule),
        typeof(AbpEntityFrameworkCoreModule),
        typeof(AbpUsersEntityFrameworkCoreModule)
    )]
    public class OrganizationsEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<OrganizationsDbContext>(options =>
            {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, EfCoreQuestionRepository>();
                 */
                options.AddDefaultRepositories(true);
            });
        }
    }
}