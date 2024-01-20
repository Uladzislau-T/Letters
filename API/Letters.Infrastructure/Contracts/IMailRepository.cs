

using Letters.Domain.Models;

namespace Letters.Infrastructure.Contracts
{
    /// <summary>
    /// Defines a contract that represents Mail Repository
    /// </summary>
    public interface IMailRepository
    {
        Task<IEnumerable<Mail>> GetAllMailsAsync(bool trackChanges); 
        Task<Mail> GetMailByIdAsync(int id, bool trackChanges = false);       
        Task CreateMailAsync(Mail mail);

        // Task DeleteMail(int id);
    }
}
