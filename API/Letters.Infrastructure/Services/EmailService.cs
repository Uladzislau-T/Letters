using EventPlanning.API.Contracts;
using EventPlanning.API.Data;
using EventPlanning.Configuration;
using MailKit.Net.Smtp;
using MimeKit;

namespace Letters.Infrastructure.Services
{
  public class EmailService : IEmailService
  {
    private readonly ILogger<EmailService> _logger;    
    private readonly EmailConfiguration _emailConfiguration;

    public EmailService(EmailConfiguration emailConfiguration, ILogger<EmailService> logger)
    {
      _logger = logger;
      _emailConfiguration = emailConfiguration;
    }

    public async Task SendEmailAsync(EmailData data)
    {
      var emailMessage = CreateEmailMessage(data);
      await SendAsync(emailMessage);
    }

    private MimeMessage CreateEmailMessage(EmailData data)
    {
        var emailMessage = new MimeMessage();
        emailMessage.From.Add(new MailboxAddress("EventPlanning",_emailConfiguration.From));
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