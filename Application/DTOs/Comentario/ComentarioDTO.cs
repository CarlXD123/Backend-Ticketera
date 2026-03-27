namespace Sistema_tickets_api.Application.DTOs.Comentario
{
    public class ComentarioDTO
    {
        public int? Id { get; set; }

        public string Texto { get; set; } = string.Empty;

        public int TicketId { get; set; }

        public int UsuarioId { get; set; }
    }
}