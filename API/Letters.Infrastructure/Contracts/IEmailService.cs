
using Letters.Infrastructure.Services.EmailService;

namespace Letters.Infrastructure.Contracts
{
    /// <summary>
    /// Defines a contract that represents the Email Service
    /// </summary>
    public interface IEmailService
    {
      Task SendEmailAsync(EmailData data);      
    }
}