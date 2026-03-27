using Sistema_tickets_api.Core.Interfaces;
using Sistema_tickets_api.Application.DTOs.Rol;
using Sistema_tickets_api.Application.Mappers;
using System.Collections.Generic;

namespace Sistema_tickets_api.Application.Services
{
    public class RolService
    {
        private readonly IRolRepository _rolRepo;

        public RolService(IRolRepository rolRepo)
        {
            _rolRepo = rolRepo;
        }

        // Obtener todos los roles
        public IEnumerable<RolDTO> ObtenerRoles()
        {
            var roles = _rolRepo.ObtenerTodos();
            return roles.Select(r => r.ToDTO());
        }

        // Obtener un rol por Id
        public RolDTO? ObtenerRolPorId(int id)
        {
            var rol = _rolRepo.ObtenerPorId(id);
            return rol?.ToDTO();
        }
    }
}