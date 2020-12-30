namespace QuickPuzzle.DomainObject
{
    public static class DomainObjectDbProperties
    {
        public static string DbTablePrefix { get; set; } = "DomainObject";

        public static string DbSchema { get; set; } = null;

        public const string ConnectionStringName = "DomainObject";
    }
}
