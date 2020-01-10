using Volo.Abp.Reflection;

namespace KST.ABP.Organizations.Authorization
{
    public class OrganizationsPermissions
    {
        public const string GroupName = "Organizations";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(OrganizationsPermissions));
        }
    }
}