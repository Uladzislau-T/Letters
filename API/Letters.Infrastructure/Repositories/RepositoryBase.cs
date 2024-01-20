using System.Linq.Expressions;
using Letters.Infrastructure.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Letters.Infrastructure.Repositories
{
    /// <summary>
    /// Contains basic methods for working with data
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected Context projectContext;
        public RepositoryBase(Context repositoryContext)
        {
            projectContext = repositoryContext;
        }

        /// <summary>
        /// Get all instances of T through DbSet
        /// </summary>
        /// <param name="trackChanges"></param>
        /// <returns>Returns IQueryable of T</returns>
        public IQueryable<T> FindAll(bool trackChanges)
        {
            return !trackChanges ? projectContext.Set<T>().AsNoTracking() : projectContext.Set<T>();
        }

        /// <summary>
        /// Get all instances by expression
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="trackChanges"></param>
        /// <returns>IQueryable of T</returns>
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
        {
            return !trackChanges ?
                        projectContext.Set<T>()
                        .Where(expression)
                        .AsNoTracking() :
                        projectContext.Set<T>()
                        .Where(expression);
        }

        /// <summary>
        /// Begins tracking the given entity and entries reachable from the given entity
        /// </summary>
        /// <param name="entity"></param>
        public void Update(T entity) => projectContext.Set<T>().Update(entity);

        /// <summary>
        /// Begins tracking the given entity in the EntityState.Deleted state such that it will be removed from the database when DbContext.SaveChanges() is called.
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(T entity) => projectContext.Set<T>().Remove(entity);

        /// <summary>
        /// Begins tracking the given entity, and any other reachable entities that are not already being tracked, in the EntityState.Added state such that they will be inserted into the database when DbContext.SaveChanges() is called.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task Create(T entity)
        {
            await projectContext.Set<T>().AddAsync(entity);
        }
    }
}
