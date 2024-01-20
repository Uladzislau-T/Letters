

using System.ComponentModel.DataAnnotations;

namespace Letters.Domain.Dto
{
    /// <summary>
    /// Dto for mail creation
    /// </summary>
    public class CreateMailDto
    {
        /// <summary>
        /// Subject of an email
        /// </summary>
        [Required(ErrorMessage = "Subject is required")]
        public string Subject { get; set; }

        /// <summary>
        /// Body of an email
        /// </summary>
        [Required(ErrorMessage = "Body is required")]
        public string Body { get; set; }

        /// <summary>
        /// Recipients of an email
        /// </summary>
        [Required(ErrorMessage = "Recipients are required"), MinLength(1, ErrorMessage = "At least 1 recipient is required")]
        public string[] Recipients { get; set; }
    }
}