using Microsoft.EntityFrameworkCore;
using Sistema_tickets_api.Core.Entities;
using Sistema_tickets_api.Core.Interfaces;
using Sistema_tickets_api.Infraestructure.Data;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly AppDbContext _context;

    public UsuarioRepository(AppDbContext context)
    {
        _context = context;
    }

    public Usuario? ObtenerPorId(int id)
    {
        return _context.Usuarios
            .Include(u => u.Rol) 
            .FirstOrDefault(u => u.Id == id);
    }

    public Usuario? ObtenerPorEmail(string email)
    {
        return _context.Usuarios
            .Include(u => u.Rol) 
            .FirstOrDefault(u => u.Email == email);
    }

    public Usuario Crear(Usuario usuario)
    {
        _context.Usuarios.Add(usuario);
        _context.SaveChanges();
        return usuario;
    }

    public IEnumerable<Usuario> Listar()
    {
        return _context.Usuarios
            .Include(u => u.Rol) 
            .ToList();
    }
}