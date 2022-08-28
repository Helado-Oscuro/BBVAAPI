using BBVA.DTO;
using BBVA.Models;

namespace BBVA.Repository
{
    public class OfficeRepository
    {
        private BankContext _context;

        public OfficeRepository(BankContext context)
        {
            _context = context;
        }
        public async Task<Office> SearchByLatitudeAndLongitude(string longitude, string latitude)
        {
            var office = _context.Office.FirstOrDefault(o => o.Longitude == longitude && o.Latitude == latitude);
            return office;
        }

        public async Task<StateDTO> GetState(string latitude, string longitude)
        {
            var office = _context.Office.FirstOrDefault(o => o.Longitude == longitude && o.Latitude == latitude);

            int? cantidadAfuera = office.CantidadAfuera;

            int? cantidadAdentro =  _context.Ticket.Where(t => t.Office == office && t.State == 1).ToList().Count;

            return new StateDTO(cantidadAfuera, cantidadAdentro);
        }
        public Office GetById(int OfficeId)
        {
            return _context.Office.SingleOrDefault(o => o.Id == OfficeId);
        }

    }
}
