using Megazine_Practice.Data;
using Megazine_Practice.Repository.RepoInterface;

namespace Megazine_Practice.Repository.RepoImplementation
{
    public class UnitOfWorkRepoImpl : UnitOfWorkIRepoImpl, IDisposable
    {
        private AppDbContext entities = null;
        public UnitOfWorkRepoImpl(AppDbContext appdbcontext)
        {
            entities = appdbcontext;
        }


        public Dictionary<Type, object> repositories  = new Dictionary<Type, object>();

        public BaseIRepo<T> Repository<T>() where T : class
        {
            if (repositories.Keys.Contains(typeof(T)) == true)
            {
                return repositories[typeof(T)] as BaseIRepo<T>;

            }
            BaseIRepo<T> repo = new BaseRepoImpl<T>(entities);
            repositories.Add(typeof(T), repo);
            return repo;
        }

        public EntityDatabaseTransaction BeginTransaction()
        {
            return new EntityDatabaseTransaction(entities);
        }

        public int Commit()
        {
            return entities.SaveChanges();
        }

        private bool disposed = false;

        public void Dispose(bool disposing)
        {
            if(!this.disposed)
            {
                entities.Dispose();
            }
            this.disposed= true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
