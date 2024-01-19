
namespace Letters.Infrastructure.Contracts
{
    public interface IEmailService
    {
      Task SendEmailAsync(EmailData data);      
    }
}