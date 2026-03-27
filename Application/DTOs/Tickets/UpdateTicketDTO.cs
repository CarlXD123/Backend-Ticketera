using Sistema_tickets_api.Core.Entities;

namespace Sistema_tickets_api.Application.DTOs.Tickets
{
    public class UpdateTicketDTO
    {
        public string Titulo { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public int ResponsableId { get; set; }
        public EstadoTicket Estado { get; set; }
    }
}
