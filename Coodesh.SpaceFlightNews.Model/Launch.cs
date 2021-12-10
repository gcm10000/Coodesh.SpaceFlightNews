using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Coodesh.SpaceFlightNews.ViewModel
{
    public class Launch
    {
        [JsonPropertyName("id")]
        [NotMapped]
        public string Id { get; set; }
        [JsonPropertyName("provider")]
        [Required]
        public string Provider { get; set; }
    }
}
