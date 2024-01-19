using System.Linq.Expressions;
using Letters.Infrastructure.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Letters.Infrastructure
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected Context projectContext;
        public RepositoryBase(Context repositoryContext)
        {
            projectContext = repositoryContext;
        }

        public IQueryable<T> FindAll(bool trackChanges)
        {
            return !trackChanges ? projectContext.Set<T>().AsNoTracking() : projectContext.Set<T>();
        }
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
        {
            return !trackChanges ?
                        projectContext.Set<T>()
                        .Where(expression)
                        .AsNoTracking() :
                        projectContext.Set<T>()
                        .Where(expression);
        }
        public void Update(T entity) => projectContext.Set<T>().Update(entity);
        public void Delete(T entity) => projectContext.Set<T>().Remove(entity);
        public async Task Create(T entity)
        {
            await projectContext.Set<T>().AddAsync(entity);
        }
    }
}
