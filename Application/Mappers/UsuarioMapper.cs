using Sistema_tickets_api.Core.Entities;
using Sistema_tickets_api.Application.DTOs.Usuario;

namespace Sistema_tickets_api.Application.Mappers
{
    public static class UsuarioMapper
    {
        // De entidad Usuario → DTO
        public static UsuarioDTO ToDTO(this Usuario usuario)
        {
            var dto = new UsuarioDTO
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Email = usuario.Email,
                RolId = usuario.RolId,
                RolNombre = usuario.Rol?.Nombre ?? string.Empty
            };
            return dto;
        }

        // De RegisterDTO → Usuario
        public static Usuario ToEntity(this RegisterDTO dto)
        {
            return new Usuario
            {
                Nombre = dto.Nombre,
                Email = dto.Email,
                PasswordHash = dto.Password,
                RolId = dto.RolId
            };
        }
    }
}