
using Letters.Infrastructure.Contracts;
using Letters.Infrastructure.Repositories;

namespace Letters.Infrastructure
{
    /// <summary>
    /// Abstraction layer between the data access layer and the business logic layer of an application.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context _context;
        private IMailRepository mailRepository;

        /// <summary>
        /// Constructor for UnitOfWork class.
        /// </summary>
        public UnitOfWork(Context context)
        {
            _context = context;
        }
        /// <summary>
        /// This property can be used to query and save instances of Mail.
        /// </summary>
        public IMailRepository Mail
        {
            get
            {
                if (mailRepository == null)
                    mailRepository = new MailRepository(_context);
                return mailRepository;
            }
        }

        /// <summary>
        /// Saves all changes made in this context to the database.
        /// </summary>
        /// <exception cref="Microsoft.EntityFrameworkCore.DbUpdateException"></exception>
        /// <exception cref="Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException"></exception>
        /// <exception cref="OperationCanceledException"></exception>
        public Task SaveAsync() => _context.SaveChangesAsync();
    }
}