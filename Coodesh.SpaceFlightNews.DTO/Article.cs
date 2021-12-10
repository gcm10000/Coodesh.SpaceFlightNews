using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coodesh.SpaceFlightNews.DTO
{
    [Table("tb_articles")]
    public class Article
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("idfromapi")]
        public int IdAPI { get; set; }
        [Column("featured")]
        public bool Featured { get; set; }
        [Column("title")]
        public string Title { get; set; }
        [Column("url")]
        public string Url { get; set; }
        [Column("imageurl")]
        public string ImageUrl { get; set; }
        [Column("newssite")]
        public string NewsSite { get; set; }
        [Column("summary")]
        public string Summary { get; set; }
        [Column("publishedat")]
        public string PublishedAt { get; set; }
        public virtual IEnumerable<Launch> Launches { get; set; }
        public virtual IEnumerable<Event> Events { get; set; }
    }
}
