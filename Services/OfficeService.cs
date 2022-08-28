using BBVA.Repository;

namespace BBVA.Services
{
    public class OfficeService
    {
        private readonly OfficeRepository _officeRepository;
        public OfficeService(BankContext _context)
        {
            _officeRepository = new OfficeRepository(_context);
        }
        public void AumentarCantidadAfuera(int officeId)
        {
            var office = _officeRepository.GetById(officeId);

            office.CantidadAfuera++;
        }
        public void DisminuirCantidadAdentro(int officeId)
        {
            var office = _officeRepository.GetById(officeId);

            office.CantidadAdentro--;
        }
    }
}
