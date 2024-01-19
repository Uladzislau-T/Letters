
namespace Letters.Infrastructure.Contracts
{
    public interface IUnitOfWork
    {
        IMailRepository Mail { get; }
        Task SaveAsync();
    }
}
