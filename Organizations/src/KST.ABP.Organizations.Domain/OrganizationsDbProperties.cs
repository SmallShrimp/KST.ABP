namespace KST.ABP.Organizations
{
    public static class OrganizationsDbProperties
    {
        public static string DbTablePrefix { get; set; } = "KST";

        public static string DbSchema { get; set; } = null;

        public const string ConnectionStringName = "Organizations";
    }
}
