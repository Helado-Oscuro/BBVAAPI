using BBVA.Models;
using BBVA.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BBVA.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TicketController : Controller
    {
        private readonly TicketRepository _ticketRepository;
        public TicketController(TicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        // GET: api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/values
        public void Post([FromBody] Ticket ticket)
        {
            _ticketRepository.Add(ticket);
        }

        // PUT: api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/values/5
        public void Delete(int id)
        {
        }
    }
}
