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
    }
}
