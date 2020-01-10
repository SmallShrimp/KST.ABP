using KST.ABP.Organizations.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace KST.ABP.Organizations.Authorization
{
    public class OrganizationsPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            //var moduleGroup = context.AddGroup(OrganizationsPermissions.GroupName, L("Permission:Organizations"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<OrganizationsResource>(name);
        }
    }
}