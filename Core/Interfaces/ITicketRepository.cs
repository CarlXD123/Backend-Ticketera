using Sistema_tickets_api.Core.Entities;

namespace Sistema_tickets_api.Core.Interfaces
{
    public interface ITicketRepository
    {
        IEnumerable<Ticket> ObtenerTodos(int page, int pageSize);
        Ticket? ObtenerPorId(int id);
        Ticket Crear(Ticket ticket);
        void Actualizar(Ticket ticket);
        void Eliminar(int id);
    }
}
