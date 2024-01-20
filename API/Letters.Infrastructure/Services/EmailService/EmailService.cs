
using Letters.Infrastructure.Contracts;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Logging;
using MimeKit;

namespace Letters.Infrastructure.Services.EmailService
{
  /// <summary>
  /// Class that helps to create email
  /// </summary>
  public class EmailService : IEmailService
  {
    private readonly ILogger<EmailService> _logger;    
    private readonly EmailConfiguration _emailConfiguration;

    public EmailService(EmailConfiguration emailConfiguration, ILogger<EmailService> logger)
    {
      _logger = logger;
      _emailConfiguration = emailConfiguration;
    }

    /// <summary>
    /// Asynchronously send an email specified in the EmailData.
    /// </summary>
    /// <param name="data">Contains all necessary information to send an email</param>
    /// <returns></returns>
    public async Task SendEmailAsync(EmailData data)
    {
      var emailMessage = CreateEmailMessage(data);
      await SendAsync(emailMessage);
    }

    private MimeMessage CreateEmailMessage(EmailData data)
    {
        var emailMessage = new MimeMessage();
        emailMessage.From.Add(new MailboxAddress("LettersProject",_emailConfiguration.From));
        emailMessage.To.AddRange(data.To);
        emailMessage.Subject = data.Subject;
        emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = data.Content };
        return emailMessage;
    }

    private async Task SendAsync(MimeMessage mailMessage)
    {
      using (var client = new SmtpClient())
      {
        try
        {
            await client.ConnectAsync(_emailConfiguration.SmtpServer, _emailConfiguration.Port, true);
            client.AuthenticationMechanisms.Remove("XOAUTH2");
            await client.AuthenticateAsync(_emailConfiguration.UserName, _emailConfiguration.Password);
            await client.SendAsync(mailMessage);
        }
        catch(Exception ex)
        {
            _logger.LogError($"{ex.Message}");
            throw;
        }
        finally
        {
            client.Disconnect(true);
            client.Dispose();
        }
      }
    }
  }
}