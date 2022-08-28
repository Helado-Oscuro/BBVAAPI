namespace BBVA.src.user.domain
{
    public class User
    {
        public int? Id { get; set; }
        public string? DNI { get; set; }
        public string? Name { get; set; }
        public bool? IsCliente { get; set; }

        public User() { }

        public User(string dni, string name, bool isCliente)
        {
            DNI = dni;
            Name = name;
            IsCliente = isCliente;
        }
    }
}
