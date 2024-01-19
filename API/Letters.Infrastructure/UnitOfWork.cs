
using Letters.Infrastructure.Contracts;

namespace Letters.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context _context;
        private IMailRepository mailRepository;
        public UnitOfWork(Context context)
        {
            _context = context;
        }
        public IMailRepository Mail
        {
            get
            {
                if (mailRepository == null)
                    mailRepository = new MailRepository(_context);
                return mailRepository;
            }
        }
        public Task SaveAsync() => _context.SaveChangesAsync();
    }
}
