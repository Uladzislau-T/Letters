using System.Linq.Expressions;

namespace Letters.Infrastructure.Contracts
{
    /// <summary>
    /// Defines a contract that represents the base repository for T model
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll(bool trackChanges);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression,
        bool trackChanges);
        Task Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }

}
