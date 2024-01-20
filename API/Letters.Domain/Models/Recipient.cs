using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Letters.Domain.Models;

namespace Letters.Models
{
    public class Recipient
    {
        /// <summary>
        /// Id of the Recipient model
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the Recipient model
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Mails of the Recipient model
        /// </summary>
        [JsonIgnore]
        public IEnumerable<Mail> Mails { get; set; }
    }
}