using BBVA.src.user.domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BBVA.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public int State { get; set; } // 0 = Atendido, 1 = En espera, 2 = Cancelado
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }
        public int CanalAtencion { get; set; } // 0 = Plataforma, 1 = Ventanilla
        public Office Office { get; set; }
        public User User { get; set; }
    }
}