using Letters.Domain.Models;
using Letters.Infrastructure.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Letters.Infrastructure.Repositories
{

    /// <summary>
    /// Repository for the Mail model
    /// </summary>
    public class MailRepository : RepositoryBase<Mail>, IMailRepository
    {
        public MailRepository(Context repositoryContext)
            : base(repositoryContext)
        {            
        }        

        /// <summary>
        /// Get all Mails
        /// </summary>
        /// <param name="trackChanges"></param>
        /// <returns>IEnumerable of Mails</returns>
        public async Task<IEnumerable<Mail>> GetAllMailsAsync(bool trackChanges = false)
        {
            var mails = await FindAll(trackChanges)
                .Include(e => e.Recipients)
                .Select(e => e)
                .ToListAsync();
                      
            return mails;
        }        

        /// <summary>
        /// Get an email by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="trackChanges"></param>
        /// <returns>Mail object</returns>
        public async Task<Mail> GetMailByIdAsync(int id, bool trackChanges = false)
        {
           return await FindByCondition(e => e.Id == id, trackChanges).Include(e => e.Recipients).FirstOrDefaultAsync();           
        }

        /// <summary>
        /// Create and email asynchronously
        /// </summary>
        /// <param name="mail"></param>
        public async Task CreateMailAsync(Mail mail)
        {
           await Create(mail);
        }

        // public void DeleteMail(mail mail)
        // {
        //     Delete(mail);
        // }

    }
}
