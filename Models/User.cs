using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BBVA.Models
{
    public class User
    {
        public int Id { get; set; }
        public int DNI { get; set; }
        public string Name { get; set; }
        public bool IsCliente { get; set; }
    }
}
