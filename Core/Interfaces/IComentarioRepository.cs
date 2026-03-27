using Sistema_tickets_api.Core.Entities;

namespace Sistema_tickets_api.Core.Interfaces
{
    public interface IComentarioRepository
    {
        Task<IEnumerable<Comentario>> ObtenerTodosAsync();
        Task<IEnumerable<Comentario>> ObtenerPorTicketIdAsync(int ticketId);
        Task<Comentario?> ObtenerPorIdAsync(int id);
        Task CrearAsync(Comentario comentario);
        Task ActualizarAsync(Comentario comentario);
        Task EliminarAsync(int id);
    }
}