using Sistema_tickets_api.Core.Entities;
using Sistema_tickets_api.Core.Interfaces;
using Sistema_tickets_api.Infraestructure.Data;
using System.Collections.Generic;
using System.Linq;

namespace Sistema_tickets_api.Infraestructure.Repositories
{
    public class RolRepository : IRolRepository
    {
        private readonly AppDbContext _context;

        public RolRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Rol> ObtenerTodos()
        {
            return _context.Roles.ToList();
        }

        public Rol? ObtenerPorId(int id)
        {
            return _context.Roles.FirstOrDefault(r => r.Id == id);
        }
    }
}