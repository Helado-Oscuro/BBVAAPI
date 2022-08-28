using BBVA.Models;
using BBVA.src.user.domain;
using Microsoft.EntityFrameworkCore;

namespace BBVA
{
    public class BankContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public BankContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to postgres with connection string from app settings
            options.UseNpgsql(Configuration.GetConnectionString("DatabaseConnection"));
        }

        public DbSet<User> User { get; set; }
        public DbSet<Ticket> Ticket { get; set; }
        public DbSet<Office> Office { get; set; }
    }
}