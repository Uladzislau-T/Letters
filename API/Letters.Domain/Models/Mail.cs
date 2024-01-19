using System.ComponentModel.DataAnnotations;
using Letters.Domain.Enums;
using Letters.Models;


namespace Letters.Domain.Models
{
    public class Mail
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Mail Subject is a required field.")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Mail Body is a required field.")]
        public int Body { get; set; }

        [Required(ErrorMessage = "Date is a required field.")]
        public DateTimeOffset Date { get; set; }

        [Required(ErrorMessage = "SubTopic is a required field.")]
        public MailResultEnum Result { get; set; }  
        public string FaildMessage { get; set; }   

        public ICollection<Recipient> Recipients {get; set;}        
    }
}
