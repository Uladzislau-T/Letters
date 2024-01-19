namespace Letters.Domain.Dto
{
    public class MailDto
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTimeOffset Date { get; set; }
        public string Result { get; set; }  
        public string FaildMessage { get; set; }   
        public IEnumerable<string> Recipients {get; set;} 
    }
}