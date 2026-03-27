using Sistema_tickets_api.Application.DTOs.Tickets;
using Sistema_tickets_api.Core.Entities;

namespace Sistema_tickets_api.Application.Mappers
{
    public static class TicketMapper
    {
        // De CrearTicketDTO → Ticket 
        public static Ticket ToEntity(this CrearTicketDTO dto, int responsableId)
        {
            return new Ticket
            {
                Titulo = dto.Titulo,
                Descripcion = dto.Descripcion,
                ResponsableId = responsableId,
                Estado = EstadoTicket.Nuevo
            };
        }

        // De Ticket → TicketDTO 
        public static TicketDTO ToDTO(this Ticket ticket)
        {
            return new TicketDTO
            {
                Id = ticket.Id,
                Titulo = ticket.Titulo,
                Descripcion = ticket.Descripcion,
                ResponsableId = ticket.ResponsableId,
                ResponsableNombre = ticket.Responsable?.Nombre ?? string.Empty,
                Estado = (int)ticket.Estado
            };
        }

        // Lista de Ticket → Lista de TicketDTO
        public static IEnumerable<TicketDTO> ToDTOs(this IEnumerable<Ticket> tickets)
        {
            return tickets.Select(t => t.ToDTO());
        }
    }
}