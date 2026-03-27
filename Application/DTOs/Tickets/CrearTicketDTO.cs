namespace Sistema_tickets_api.Application.DTOs.Tickets
{
    public class CrearTicketDTO
    {
        public string Titulo { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public int ResponsableId { get; set; }
    }
}