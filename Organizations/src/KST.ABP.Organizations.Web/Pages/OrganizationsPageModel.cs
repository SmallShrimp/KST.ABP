using KST.ABP.Organizations.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace KST.ABP.Organizations.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class OrganizationsPageModel : AbpPageModel
    {
        protected OrganizationsPageModel()
        {
            LocalizationResourceType = typeof(OrganizationsResource);
            ObjectMapperContext = typeof(OrganizationsWebModule);
        }
    }
}