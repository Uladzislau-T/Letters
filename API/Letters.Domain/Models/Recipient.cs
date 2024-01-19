using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Letters.Domain.Models;

namespace Letters.Models
{
    public class Recipient
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [JsonIgnore]
        public IEnumerable<Mail> Mails { get; set; }
    }
}