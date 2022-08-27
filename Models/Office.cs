namespace BBVA.Models
{
    public class Office
    {
        public int Id { get; set; }
        public int VentanillasTotalQuantity { get; set; }
        public int PlataformasTotalQuantity { get; set; }
        public string Latitude { get; set; }
        public string Length { get; set; }
        public int Capacity { get; set; }
        public DateTime CheckInTime { get; set; }
        public DateTime CheckOutTime { get; set; }
        public DateTime Place { get; set; }


    }
}
