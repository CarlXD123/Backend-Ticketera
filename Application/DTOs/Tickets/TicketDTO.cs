namespace Sistema_tickets_api.Application.DTOs.Tickets
{
    public class TicketDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public int ResponsableId { get; set; }
        public string ResponsableNombre { get; set; } = string.Empty;
        public int Estado { get; set; }
    }
}