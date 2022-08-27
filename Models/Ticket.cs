namespace BBVA.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public int State { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }
        public User User { get; set; }
        public Office Office { get; set; }
    }
}
