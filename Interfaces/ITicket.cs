using BBVA.Models;

namespace BBVA.Interfaces
{
    public interface ITicket
    {
        IEnumerable<Ticket> GetAll();
        Ticket Get(int id);
        Ticket Add(Ticket item);
        void Remove(int id);
        bool Update(Ticket item);
    }
}
