
using System.Text.Json;

namespace Letters.Domain.ErrorModels
{
    public class ErrorDetails
    {
        public string StatusCode { get; set; }
        public ICollection<string> Errors { get; set; }

        public override string ToString() => JsonSerializer.Serialize(this);
        
    }
}
