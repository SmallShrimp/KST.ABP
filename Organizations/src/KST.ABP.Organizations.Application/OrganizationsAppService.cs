using KST.ABP.Organizations.Localization;
using Volo.Abp.Application.Services;

namespace KST.ABP.Organizations
{
    public abstract class OrganizationsAppService : ApplicationService
    {
        protected OrganizationsAppService()
        {
            LocalizationResource = typeof(OrganizationsResource);
            ObjectMapperContext = typeof(OrganizationsApplicationModule);
        }
    }
}
