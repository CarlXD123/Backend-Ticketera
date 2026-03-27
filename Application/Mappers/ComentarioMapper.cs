using Sistema_tickets_api.Application.DTOs.Comentario;
using Sistema_tickets_api.Core.Entities;

namespace Sistema_tickets_api.Application.Mappers
{
    public static class ComentarioMapper
    {
        // De DTO a entidad
        public static Comentario ToEntity(this ComentarioDTO dto)
        {
            return new Comentario
            {
                Id = dto.Id ?? 0,          
                Texto = dto.Texto,
                TicketId = dto.TicketId,
                UsuarioId = dto.UsuarioId,
                FechaCreacion = DateTime.Now
            };
        }

        // De entidad a DTO
        public static ComentarioDTO ToDTO(this Comentario comentario)
        {
            return new ComentarioDTO
            {
                Id = comentario.Id,
                Texto = comentario.Texto,
                TicketId = comentario.TicketId,
                UsuarioId = comentario.UsuarioId
            };
        }

        // Lista de entidades a lista de DTOs
        public static IEnumerable<ComentarioDTO> ToDTOs(this IEnumerable<Comentario> comentarios)
        {
            return comentarios.Select(c => c.ToDTO());
        }
    }
}