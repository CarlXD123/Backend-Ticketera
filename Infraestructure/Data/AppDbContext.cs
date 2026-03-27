using Microsoft.EntityFrameworkCore;
using Sistema_tickets_api.Core.Entities;
using System.Collections.Generic;

namespace Sistema_tickets_api.Infraestructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios => Set<Usuario>();
        public DbSet<Ticket> Tickets => Set<Ticket>();
        public DbSet<Comentario> Comentarios => Set<Comentario>();

        public DbSet<Rol> Roles => Set<Rol>();
    }
}
