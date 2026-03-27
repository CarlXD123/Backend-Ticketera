using Microsoft.EntityFrameworkCore;
using Sistema_tickets_api.Core.Entities;
using Sistema_tickets_api.Core.Interfaces;
using Sistema_tickets_api.Infraestructure.Data;

namespace Sistema_tickets_api.Infrastructure.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly AppDbContext _context;
        public TicketRepository(AppDbContext context) => _context = context;

        public IEnumerable<Ticket> ObtenerTodos(int page, int pageSize)
            => _context.Tickets
                       .Include(t => t.Responsable)
                       .Include(t => t.Comentarios)
                       .Skip((page - 1) * pageSize)
                       .Take(pageSize)
                       .ToList();

        public Ticket? ObtenerPorId(int id)
            => _context.Tickets
                       .Include(t => t.Responsable)
                       .Include(t => t.Comentarios)
                       .FirstOrDefault(t => t.Id == id);

        public Ticket Crear(Ticket ticket)
        {
            _context.Tickets.Add(ticket);
            _context.SaveChanges();
            return ticket;
        }

        public void Actualizar(Ticket ticket)
        {
            _context.Tickets.Update(ticket);
            _context.SaveChanges();
        }

        public void Eliminar(int id)
        {
            var ticket = _context.Tickets.Find(id);
            if (ticket != null)
            {
                _context.Tickets.Remove(ticket);
                _context.SaveChanges();
            }
        }
    }
}