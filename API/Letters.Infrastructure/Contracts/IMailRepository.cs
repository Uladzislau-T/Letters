

using Letters.Domain.Models;

namespace Letters.Infrastructure.Contracts
{
    public interface IMailRepository
    {
        Task<IEnumerable<Mail>> GetAllMailsAsync(bool trackChanges); 
        Task<Mail> GetMailByIdAsync(int id, bool trackChanges = false);       
        Task CreateMailAsync(Mail mail);

        // Task DeleteMail(int id);
    }
}
