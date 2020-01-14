using KST.ABP.Organizations.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Modularity;

namespace KST.ABP.Organizations
{
    public abstract class OrganizationUnitExtendedTestBase<TStartupModule> : OrganizationsTestBase<TStartupModule>
        where TStartupModule : IAbpModule
    {

        protected virtual OrganizationUnit GetByCode(string code)
        {
            var org = UsingDbContext(context => context.OrganizationUnits.FirstOrDefault(m => m.Code == code));
            if (org == null)
            {
                throw new EntityNotFoundException();
            }
            return org;
        }

        protected virtual OrganizationUnit Find(string code)
        {
            return UsingDbContext(context => context.OrganizationUnits.FirstOrDefault(m => m.Code == code)); ;
        }

        protected virtual T UsingDbContext<T>(Func<IOrganizationsDbContext, T> action)
        {
            using (var dbContext = GetRequiredService<IOrganizationsDbContext>())
            {
                return action.Invoke(dbContext);
            }
        }
    }
}
