using KST.ABP.Organizations.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace KST.ABP.Organizations.Pages
{
    public abstract class OrganizationsPageModel : AbpPageModel
    {
        protected OrganizationsPageModel()
        {
            LocalizationResourceType = typeof(OrganizationsResource);
        }
    }
}