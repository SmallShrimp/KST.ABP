using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Components;
using Volo.Abp.DependencyInjection;

namespace KST.ABP.Organizations
{
    [Dependency(ReplaceServices = true)]
    public class OrganizationsBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "Organizations";
    }
}
