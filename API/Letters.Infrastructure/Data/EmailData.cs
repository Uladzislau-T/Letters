using MimeKit;

namespace EventPlanning.API.Data
{
  public class EmailData
  {
    public List<MailboxAddress> To { get; set; }
    public string Subject { get; set; }
    public string Content { get; set; } 

    public EmailData(IEnumerable<string> to, string subject, string content)
    {
        To = new List<MailboxAddress>();
        To.AddRange(to.Select(address => new MailboxAddress("EventPlanning" , address)));
        Subject = subject;
        Content = content;        
    }
  }
}