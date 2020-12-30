using System.Threading.Tasks;

namespace QuickPuzzle.Test.Data
{
    public interface ITestDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
