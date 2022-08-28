using BBVA.Models;
using BBVA.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BBVA.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OfficeController : ControllerBase
    {
        private BankContext _context;
        private OfficeRepository _officeRepo;

        public OfficeController(BankContext context)
        {
            _context = context;
            _officeRepo = new OfficeRepository(_context);
        }

        [HttpGet]
        public IList<Office> GetAll()
        {
            return _context.Office.ToList();
        }
        [HttpGet]
        [Route("lalo")]
        public async Task<Office> GetByLatiAndLong([FromQuery] string latitude, [FromQuery] string longitude)
        {
            return await _officeRepo.SearchByLatitudeAndLongitude(longitude,latitude);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Office office)
        {
            _context.Office.Add(office);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut] // by id
        public IActionResult Update([FromBody] Office office)
        {
            _context.Office.Update(office);
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete] // by id
        public IActionResult Delete(int id)
        {
            var office = _context.Office.FirstOrDefault(x => x.Id == id);
            _context.Office.Remove(office);
            _context.SaveChanges();
            return Ok();
        }
    }
}
