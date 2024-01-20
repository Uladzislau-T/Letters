using System.ComponentModel.DataAnnotations;
using Letters.Domain.Enums;
using Letters.Models;


namespace Letters.Domain.Models
{
    public class Mail
    {
        /// <summary>
        /// Id of the Mail model
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Subject of the Mail model
        /// </summary>
        [Required(ErrorMessage = "Mail Subject is a required field.")]
        public string Subject { get; set; }

        /// <summary>
        /// Body of the Mail model
        /// </summary>
        [Required(ErrorMessage = "Mail Body is a required field.")]
        public string Body { get; set; }

        /// <summary>
        /// Date of the Mail model
        /// </summary>
        [Required(ErrorMessage = "Date is a required field.")]
        public DateTimeOffset Date { get; set; }

        /// <summary>
        /// Result of the Mail model
        /// </summary>
        [Required(ErrorMessage = "SubTopic is a required field.")]
        public MailStatusEnum Result { get; set; }  

        /// <summary>
        /// Faild Message of the Mail model
        /// </summary>
        public string FaildMessage { get; set; }   

        /// <summary>
        /// Recipients of the Mail model
        /// </summary>
        public ICollection<Recipient> Recipients {get; set;}        
    }
}
