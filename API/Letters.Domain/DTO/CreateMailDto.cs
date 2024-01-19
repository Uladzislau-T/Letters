

using System.ComponentModel.DataAnnotations;

namespace Letters.Domain.Dto
{
    public class CreateMailDto
    {

        [Required(ErrorMessage = "Subject is required")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Body is required")]
        public string Body { get; set; }

        [Required(ErrorMessage = "Recipients are required"), MinLength(1, ErrorMessage = "At least 1 recipient is required")]
        public string[] Recipients { get; set; }
    }
}