
using System.Text.Json;

namespace Letters.Domain.ErrorModels
{
    /// <summary>
    /// Custom error details class
    /// </summary>
    public class ErrorDetails
    {
        public string StatusCode { get; set; }
        public ICollection<string> Errors { get; set; }

        public override string ToString() => JsonSerializer.Serialize(this);
        
    }
}
