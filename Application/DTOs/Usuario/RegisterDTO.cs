namespace Sistema_tickets_api.Application.DTOs.Usuario
{
    public class RegisterDTO
    {
        public string Nombre { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int RolId { get; set; } = 2;
    }
}