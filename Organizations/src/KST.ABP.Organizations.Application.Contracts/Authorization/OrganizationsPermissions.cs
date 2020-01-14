using Volo.Abp.Reflection;

namespace KST.ABP.Organizations.Authorization
{
    public class OrganizationsPermissions
    {
        public const string GroupName = "OrganizationUnits";
        public const string ManageOrganizationTree = "OrganizationUnits.ManageOrganizationTree";
        public const string ManageMembers = "OrganizationUnits.ManageMembers";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(OrganizationsPermissions));
        }
    }
}