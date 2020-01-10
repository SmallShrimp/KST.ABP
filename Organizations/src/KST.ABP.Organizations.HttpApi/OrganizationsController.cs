using KST.ABP.Organizations.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace KST.ABP.Organizations
{
    public abstract class OrganizationsController : AbpController
    {
        protected OrganizationsController()
        {
            LocalizationResource = typeof(OrganizationsResource);
        }
    }
}
