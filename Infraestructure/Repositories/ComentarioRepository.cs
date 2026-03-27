using Sistema_tickets_api.Core.Entities;
using Sistema_tickets_api.Core.Interfaces;
using Sistema_tickets_api.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Sistema_tickets_api.Infraestructure.Repositories
{
    public class ComentarioRepository : IComentarioRepository
    {
        private readonly AppDbContext _context;

        public ComentarioRepository(AppDbContext context)
        {
            _context = context;
        }

        // Obtener todos los comentarios
        public async Task<IEnumerable<Comentario>> ObtenerTodosAsync()
        {
            return await _context.Comentarios
                                 .Include(c => c.Usuario)
                                 .Include(c => c.Ticket)
                                 .OrderBy(c => c.FechaCreacion)
                                 .ToListAsync();
        }

        // Obtener comentario por Id
        public async Task<Comentario?> ObtenerPorIdAsync(int id)
        {
            return await _context.Comentarios
                                 .Include(c => c.Usuario)
                                 .Include(c => c.Ticket)
                                 .FirstOrDefaultAsync(c => c.Id == id);
        }

        // Obtener comentarios por TicketId
        public async Task<IEnumerable<Comentario>> ObtenerPorTicketIdAsync(int ticketId)
        {
            return await _context.Comentarios
                                 .Where(c => c.TicketId == ticketId)
                                 .Include(c => c.Usuario)  
                                 .OrderBy(c => c.FechaCreacion)
                                 .ToListAsync();
        }

        // Crear un comentario
        public async Task CrearAsync(Comentario comentario)
        {
            await _context.Comentarios.AddAsync(comentario);
            await _context.SaveChangesAsync();
        }

        // Actualizar un comentario
        public async Task ActualizarAsync(Comentario comentario)
        {
            _context.Comentarios.Update(comentario);
            await _context.SaveChangesAsync();
        }

        // Eliminar un comentario
        public async Task EliminarAsync(int id)
        {
            var comentario = await _context.Comentarios.FindAsync(id);
            if (comentario != null)
            {
                _context.Comentarios.Remove(comentario);
                await _context.SaveChangesAsync();
            }
        }
    }
}