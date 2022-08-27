using BBVA.Interfaces;
using BBVA.Models;

namespace BBVA.Repository
{
    public class TicketRepository : ITicket
    {
        private readonly BankContext _bankContext;
        public TicketRepository(BankContext bankContext)
        {
            _bankContext = bankContext;
        }

        public Ticket Add(Ticket item)
        {
            throw new NotImplementedException();
        }

        public Ticket Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ticket> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(Ticket ticket)
        {
            _bankContext.Add(ticket);
        }

        public bool Update(Ticket item)
        {
            throw new NotImplementedException();
        }
    }
}
