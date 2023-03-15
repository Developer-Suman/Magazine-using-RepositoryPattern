using System.Linq.Expressions;

namespace Megazine_Practice.Repository.RepoInterface
{
    public interface BaseIRepo<T> where T : class
    {
        void Attach(T entity);
        IQueryable<T> Queryable();

        //Removes a record from the context
        void delete(T entity);

        //Add the new record to the context
        void insert(T entity);

        //Update the record to the the content
        void update(T entity);

        //Gets all the record
        List<T> getAll();

        //Gets the entity by Id
        T getById(int id);

        IQueryable<T> getQueryable();

        //Find a set of record that matches the passed expression
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);

        //Add a list of records
        void AddRange(IEnumerable<T> entities);

        //Removes a list of records
        void RemoveRange(IEnumerable<T> entities);

        void Save();
    }
}
