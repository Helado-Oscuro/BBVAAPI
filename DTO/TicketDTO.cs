namespace BBVA.DTO
{
    public class TicketDTO
    {
        public int? Id { get; set; }
        public int? State { get; set; } // 0 = Atendido, 1 = En espera, 2 = Cancelado
        public DateTime? CreatedTime { get; set; }
        public DateTime? UpdatedTime { get; set; }
        public int? CanalAtencion { get; set; } // 0 = Plataforma, 1 = Ventanilla
        public int OfficeId { get; set; }
        public int UserId { get; set; }
    }
}
