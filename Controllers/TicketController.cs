using BBVA.DTO;
using BBVA.Models;
using BBVA.Repository;
using BBVA.Services;
using Microsoft.AspNetCore.Mvc;

namespace BBVA.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketController : ControllerBase
    {
        private readonly BankContext _context;
        private readonly TicketRepository _ticketRepository;
        private readonly OfficeService _officeService;

        public TicketController(BankContext context)
        {
            _context = context;
            _ticketRepository = new TicketRepository(_context);
            _officeService = new OfficeService(_context);
        }

        [HttpGet]
        public IList<Ticket> GetAll()
        {
            return _ticketRepository.GetTickets();
        }
        [HttpGet]
        [Route("last")]
        public Ticket GetLast()
        {
            return  _ticketRepository.GetLast();
        }

        [HttpPost]
        public IActionResult Create([FromBody] TicketDTO ticketDTO)
        {
            _ticketRepository.Save(ticketDTO);
            _officeService.AumentarCantidadAfuera(ticketDTO.OfficeId);
            _officeService.DisminuirCantidadAdentro(ticketDTO.OfficeId);

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
