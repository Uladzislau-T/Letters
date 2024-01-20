using MimeKit;

namespace Letters.Infrastructure.Services.EmailService
{
  /// <summary>
  ///  Class to set the data related to an email
  /// </summary>
  public class EmailData
  {
    /// <summary>
    /// To whome you want to send an email
    /// </summary>
    public List<MailboxAddress> To { get; set; }

    /// <summary>
    /// A subject of an email
    /// </summary>
    public string Subject { get; set; }

    /// <summary>
    /// A content of an email
    /// </summary>
    public string Content { get; set; } 

    public EmailData(IEnumerable<string> to, string subject, string content)
    {
        To = new List<MailboxAddress>();
        To.AddRange(to.Select(address => new MailboxAddress("LettersProject" , address)));
        Subject = subject;
        Content = content;        
    }
  }
}