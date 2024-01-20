
namespace Letters.Infrastructure.Contracts
{
    /// <summary>
    /// Defines a contract that represents the Unit of Work 
    /// </summary>
    public interface IUnitOfWork
    {
        IMailRepository Mail { get; }
        Task SaveAsync();
    }
}
