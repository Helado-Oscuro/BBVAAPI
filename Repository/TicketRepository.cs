using BBVA.DTO;
using BBVA.Models;

namespace BBVA.Repository
{
    public class TicketRepository
    {
        private BankContext _context;

        public TicketRepository(BankContext context)
        {
            _context = context;
        }

        public void Save(TicketDTO ticketDto)
        {
            var office = _context.Office.FirstOrDefault(x => x.Id == ticketDto.OfficeId);
            var user = _context.User.FirstOrDefault(x => x.Id == ticketDto.UserId);

            Ticket ticket = new Ticket();
            ticket.CanalAtencion = ticketDto.CanalAtencion;
            ticket.CreatedTime = ticketDto.CreatedTime;
            ticket.State = ticketDto.State;
            ticket.UpdatedTime = ticketDto.UpdatedTime;
            ticket.Office = office;
            ticket.User = user;

            _context.Ticket.Add(ticket);

            _context.SaveChanges();
        }

        public List<Ticket> GetTickets()
        {
            return _context.Ticket.ToList();
        }

        public Ticket GetLast()
        {
            // order by created time desc
            // _context.Ticket
            return _context.Ticket.OrderByDescending(x => x.CreatedTime).FirstOrDefault();
        }
    }
}