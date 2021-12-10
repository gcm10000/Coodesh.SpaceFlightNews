using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Coodesh.SpaceFlightNews.ViewModel
{

    public class Article
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("featured")]
        [Required]
        public bool Featured { get; set; }
        [JsonPropertyName("title")]
        [Required]
        public string Title { get; set; }
        [JsonPropertyName("url")]
        public string Url { get; set; }
        [JsonPropertyName("imageUrl")]
        public string ImageUrl { get; set; }
        [JsonPropertyName("newsSite")]
        public string NewsSite { get; set; }
        [JsonPropertyName("summary")]
        public string Summary { get; set; }
        [JsonPropertyName("publishedAt")]
        public string PublishedAt { get; set; }
        [JsonPropertyName("launches")]
        public IEnumerable<Launch> Launches { get; set; }
        [JsonPropertyName("events")]
        public IEnumerable<Event> Events { get; set; }
    }
}
