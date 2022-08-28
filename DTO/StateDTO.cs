namespace BBVA.DTO
{
    public class StateDTO
    {
        public int? CantidadAfuera { get; set; }
        public int? CantidadAdentro { get; set; }

        public StateDTO(int? cantidadAfuera, int? cantidadAdentro)
        {
            CantidadAdentro = cantidadAdentro;
            CantidadAfuera = cantidadAfuera;
        }
    }
}
