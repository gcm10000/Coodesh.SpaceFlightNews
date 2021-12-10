using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coodesh.SpaceFlightNews.DTO
{
    [Table("tb_launches")]
    public class Launch
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("provider")]
        public string Provider { get; set; }
        [Column("articlesfk")]
        [ForeignKey("articlesfk")]
        public Article Article { get; set; }
    }
}
