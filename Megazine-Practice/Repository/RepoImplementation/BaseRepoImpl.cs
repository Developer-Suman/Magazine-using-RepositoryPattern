using Megazine_Practice.Data;
using Megazine_Practice.Repository.RepoInterface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Megazine_Practice.Repository.RepoImplementation
{
    public class BaseRepoImpl<T> : BaseIRepo<T> where T : class
    {
        private readonly AppDbContext _appdbcontext;
        protected readonly DbSet<T> _dbSet;
        public BaseRepoImpl(AppDbContext appdbcontext)
        {
            _appdbcontext = appdbcontext;
            _dbSet = appdbcontext.Set<T>();

        }
        public void AddRange(IEnumerable<T> entities)
        {
            _appdbcontext.Set<T>().AddRange(entities);
        }

        public void Attach(T entity)
        {
            _dbSet.Attach(entity);
        }

        public void delete(T entity)
        {
            _appdbcontext.Remove(entity);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _appdbcontext.Set<T>().Where(expression);
        }

        public List<T> getAll()
        {
            return _appdbcontext.Set<T>().ToList();
        }

        public void update(T entity)
        {
            _appdbcontext.Entry(entity).State = EntityState.Modified;
        }

        public T getById(int id)
        {
            return _appdbcontext.Set<T>().Find(id);
        }

        public IQueryable<T> getQueryable()
        {
            return _appdbcontext.Set<T>();
        }

        public void insert(T entity)
        {
            _dbSet.Add(entity);
        }

        public IQueryable<T> Queryable()
        {
            return _dbSet.AsQueryable();
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _appdbcontext.Set<T>().RemoveRange(entities);
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

      
    }
}
