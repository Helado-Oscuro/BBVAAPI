using BBVA.DTO;
using BBVA.Models;
using BBVA.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BBVA.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketController : ControllerBase
    {
        private BankContext _context;
        private TicketRepository _ticketRepository;

        public TicketController(BankContext context)
        {
            _context = context;
            _ticketRepository = new TicketRepository(_context);
        }

        [HttpGet]
        public IList<Ticket> GetAll()
        {
            return _context.Ticket.ToList();
        }

        [HttpPost]
        public IActionResult Create([FromBody] TicketDTO ticketDTO)
        {
            _ticketRepository.Save(ticketDTO);
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
