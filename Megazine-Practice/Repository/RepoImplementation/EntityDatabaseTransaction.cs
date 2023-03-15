using Megazine_Practice.Data;
using Microsoft.EntityFrameworkCore.Storage;

namespace Megazine_Practice.Repository.RepoImplementation
{
    public class EntityDatabaseTransaction : IDisposable
    {

        private IDbContextTransaction _transaction;
        public EntityDatabaseTransaction(AppDbContext appdbcontet)
        {
            _transaction = appdbcontet.Database.BeginTransaction();

        }

        public void Commit()
        {
            _transaction.Commit();
        }
        public void Rollback()
        {
            _transaction.Rollback();
        }
        public void Dispose()
        {
            _transaction.Dispose();
        }
    }
}
