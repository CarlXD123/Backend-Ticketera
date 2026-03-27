using Sistema_tickets_api.Core.Entities;
using Sistema_tickets_api.Core.Interfaces;

namespace Sistema_tickets_api.Application.Services
{
    public class TicketService
    {
        private readonly ITicketRepository _repository;
        public TicketService(ITicketRepository repository) => _repository = repository;

        public IEnumerable<Ticket> ObtenerTickets(int page = 1, int pageSize = 10)
            => _repository.ObtenerTodos(page, pageSize);

        public Ticket? ObtenerTicketPorId(int id) => _repository.ObtenerPorId(id);

        public Ticket CrearTicket(Ticket ticket) => _repository.Crear(ticket);

        public void ActualizarTicket(Ticket ticket) => _repository.Actualizar(ticket);

        public void EliminarTicket(int id) => _repository.Eliminar(id);
    }
}