using System.Text.Json.Serialization;

namespace CodeAlongPersonGallery.Models
{
    public class Person
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("birthYear")]
        public int BirthYear { get; set; }


    }
}
