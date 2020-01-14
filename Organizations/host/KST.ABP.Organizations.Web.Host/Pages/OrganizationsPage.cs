using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using KST.ABP.Organizations.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace KST.ABP.Organizations.Pages
{
    public abstract class OrganizationsPage : AbpPage
    {
        [RazorInject]
        public IHtmlLocalizer<OrganizationsResource> L { get; set; }
    }
}
