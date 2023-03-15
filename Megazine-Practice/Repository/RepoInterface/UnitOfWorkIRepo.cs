using Megazine_Practice.Repository.RepoImplementation;

namespace Megazine_Practice.Repository.RepoInterface
{
    public interface UnitOfWorkIRepoImpl : IDisposable
    {
        int Commit();

        //int ExecWithStoreProcedure(string query, params object[] parameters);
        EntityDatabaseTransaction BeginTransaction();
    }
}
