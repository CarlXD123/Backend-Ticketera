namespace Sistema_tickets_api.Core.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;

        public int RolId { get; set; } = 2; // 1 = Admin, 2 = Usuario

        public Rol? Rol { get; set; }

        public ICollection<Ticket> TicketsAsignados { get; set; } = new List<Ticket>();
        public ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();
    }
}
