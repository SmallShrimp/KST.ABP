namespace KST.ABP.Organizations
{
    public static class OrganizationsDbProperties
    {
        public static string DbTablePrefix { get; set; } = "Organizations";

        public static string DbSchema { get; set; } = null;

        public const string ConnectionStringName = "Kst";
    }
}
