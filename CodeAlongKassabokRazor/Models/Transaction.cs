using System.Text.Json.Serialization;

namespace CodeAlongKassabokRazor.Models
{
    public class Transaction
    {

        [JsonPropertyName("id")]
        public int Id { get; set; }
        
        [JsonPropertyName("title")]
        public string Title { get; set; }
        
        [JsonPropertyName("amount")]
        public double Amount { get; set; }
        
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }
    }
}
