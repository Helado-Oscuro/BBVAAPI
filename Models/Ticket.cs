using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BBVA.Models
{
    public class Ticket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int State { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }
        [ForeignKey("IdUser")] public virtual User User { get; set; }
        [ForeignKey("IdAttentionChannel")] public virtual AttentionChannel AttentionChannel { get; set; }
    }
}