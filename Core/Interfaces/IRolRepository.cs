using Sistema_tickets_api.Core.Entities;
using System.Collections.Generic;

namespace Sistema_tickets_api.Core.Interfaces
{
    public interface IRolRepository
    {
        IEnumerable<Rol> ObtenerTodos();
        Rol? ObtenerPorId(int id);
    }
}