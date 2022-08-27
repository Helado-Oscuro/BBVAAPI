using Microsoft.EntityFrameworkCore;

namespace BBVA.Models
{
    public class BankContext:DbContext
    {
        public BankContext(DbContextOptions<BankContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Office> Offices { get; set; }
    }
}
