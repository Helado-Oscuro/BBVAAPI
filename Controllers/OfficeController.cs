using BBVA.DTO;
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
        [Route("id")]
        public Office GetById(int id)
        {
            return _officeRepo.GetById(id);
        }
        [HttpGet]
        [Route("state")]
        public async Task<StateDTO> GetState([FromQuery] string latitude, [FromQuery] string longitude)
        {
            return await _officeRepo.GetState(latitude, longitude);
        }
        [HttpGet]
        [Route("Latlon")]
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

        [HttpDelete] // by id
        public IActionResult Delete(int id)
        {
            var office = _context.Office.FirstOrDefault(x => x.Id == id);
            _context.Office.Remove(office);
            _context.SaveChanges();
            return Ok();
        }
        // Update attribute CantidadAfuera by Latitude and Longitude
        [HttpPut]
        public IActionResult Update([FromQuery] string latitude, [FromQuery] string longitude, [FromQuery] int cantidadAfuera)
        {
            var office = _officeRepo.SearchByLatitudeAndLongitude(longitude,latitude);
            office.Result.CantidadAfuera = cantidadAfuera;
            _context.Office.Update(office.Result);
            _context.SaveChanges();
            return Ok();
        }
        
    }
}
