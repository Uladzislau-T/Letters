using Letters.Domain.Dto;
using Letters.Domain.Models;
using Letters.Infrastructure.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Letters.Infrastructure
{
    public class MailRepository : RepositoryBase<Mail>, IMailRepository
    {
        public MailRepository(Context repositoryContext)
            : base(repositoryContext)
        {            
        }        

        public async Task<IEnumerable<Mail>> GetAllMailsAsync(bool trackChanges = false)
        {
            var mails = await FindAll(trackChanges)
                .Include(e => e.Recipients)
                .Select(e => e)
                .ToListAsync();
                      
            return mails;
        }        

        public async Task<Mail> GetMailByIdAsync(int id, bool trackChanges = false)
        {
           return await FindByCondition(e => e.Id == id, trackChanges).Include(e => e.Recipients).FirstOrDefaultAsync();           
        }

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
