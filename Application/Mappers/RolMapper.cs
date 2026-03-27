using Sistema_tickets_api.Application.DTOs.Rol;
using Sistema_tickets_api.Core.Entities;

namespace Sistema_tickets_api.Application.Mappers
{
    public static class RolMapper
    {
        public static RolDTO ToDTO(this Rol rol)
        {
            return new RolDTO
            {
                Id = rol.Id,
                Nombre = rol.Nombre
            };
        }
    }
}