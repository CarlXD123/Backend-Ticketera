using Sistema_tickets_api.Core.Entities;

namespace Sistema_tickets_api.Core.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuario? ObtenerPorId(int id);
        Usuario? ObtenerPorEmail(string email);
        Usuario Crear(Usuario usuario);
        IEnumerable<Usuario> Listar();
    }
}
