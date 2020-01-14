using KST.ABP.Organizations.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace KST.ABP.Organizations.Authorization
{
    public class OrganizationsPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var moduleGroup = context.AddGroup(OrganizationsPermissions.GroupName, L("Permission:OrganizationUnits"));
            moduleGroup.AddPermission(OrganizationsPermissions.ManageOrganizationTree, L("Permission:OrganizationUnits:ManageOrganizationTree"));
            moduleGroup.AddPermission(OrganizationsPermissions.ManageMembers, L("Permission:OrganizationUnits:ManageMembers"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<OrganizationsResource>(name);
        }
    }
}