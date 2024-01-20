namespace Letters.Domain.Dto
{
    public class MailDto
    {
        /// <summary>
        /// Id of an mailDto
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Subject of an mailDto
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Body of an mailDto
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Date of an mailDto
        /// </summary>
        public DateTimeOffset Date { get; set; }

        /// <summary>
        /// Result of an mailDto
        /// </summary>
        public string Result { get; set; }  

        /// <summary>
        /// FaildMessage of an mailDto
        /// </summary>
        public string FaildMessage { get; set; } 

        /// <summary>
        /// Recipients of an mailDto
        /// </summary>  
        public IEnumerable<string> Recipients {get; set;} 
    }
}