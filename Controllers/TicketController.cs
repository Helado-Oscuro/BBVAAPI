using BBVA.Models;
using Microsoft.AspNetCore.Mvc;

namespace BBVA.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketController : ControllerBase
    {
        private BankContext _context;

        public TicketController(BankContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IList<Ticket> GetAll()
        {
            return _context.Ticket.ToList();
        }

        [HttpPost]
        public IActionResult Create([FromBody] Ticket ticket)
        {
            _context.Ticket.Add(ticket);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut] // by id
        public IActionResult Update([FromBody] Ticket ticket)
        {
            _context.Ticket.Update(ticket);
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete] // by id
        public IActionResult Delete(int id)
        {
            var ticket = _context.User.FirstOrDefault(x => x.Id == id);
            _context.User.Remove(ticket);
            _context.SaveChanges();
            return Ok();
        }
    }
}
