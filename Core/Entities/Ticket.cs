namespace Sistema_tickets_api.Core.Entities
{
    public enum EstadoTicket
    {
        Nuevo,
        EnProceso,
        Resuelto,
        Cancelado
    }

    public class Ticket
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public EstadoTicket Estado { get; set; } = EstadoTicket.Nuevo;

        public int ResponsableId { get; set; }
        public Usuario? Responsable { get; set; }

        public ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();
    }
}
