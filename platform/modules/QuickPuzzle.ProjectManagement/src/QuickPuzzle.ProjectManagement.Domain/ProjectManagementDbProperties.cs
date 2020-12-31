namespace QuickPuzzle.ProjectManagement
{
    public static class ProjectManagementDbProperties
    {
        public static string DbTablePrefix { get; set; } = "";

        public static string DbSchema { get; set; } = null;

        public const string ConnectionStringName = "ProjectManagement";
    }
}
