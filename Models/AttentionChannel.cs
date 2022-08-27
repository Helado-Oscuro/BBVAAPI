using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BBVA.Models
{
    public class AttentionChannel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public bool IsVentanilla { get; set; } // In other case is Platform
        public string DutyManagerName { get; set; }
        [ForeignKey("IdOffice")]
        public virtual Office Office { get; set; }
    }
}
