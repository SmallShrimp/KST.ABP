﻿using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using KST.ABP.Organizations.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace KST.ABP.Organizations.Web.Pages
{
    /* Inherit your UI Pages from this class. To do that, add this line to your Pages (.cshtml files under the Page folder):
     * @inherits KST.ABP.Organizations.Web.Pages.OrganizationsPage
     */
    public abstract class OrganizationsPage : AbpPage
    {
        [RazorInject]
        public IHtmlLocalizer<OrganizationsResource> L { get; set; }
    }
}
