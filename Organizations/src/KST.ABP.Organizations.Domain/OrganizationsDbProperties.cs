namespace KST.ABP.Organizations
{
    public static class OrganizationsDbProperties
    {
        public static string DbTablePrefix { get; set; } = "Kst";

        public static string DbSchema { get; set; } = null;

        public const string ConnectionStringName = "Organizations";
    }
}
