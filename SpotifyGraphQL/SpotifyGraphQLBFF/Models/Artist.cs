using System.Text.Json.Serialization;

namespace SpotifyGraphQLBFF.Models
{
    public class Artist
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
    
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("genres")]
        public List<string> Genres { get; set; }
    
        [JsonPropertyName("images")]
        public List<Image> Images { get; set; }
        
    }
}