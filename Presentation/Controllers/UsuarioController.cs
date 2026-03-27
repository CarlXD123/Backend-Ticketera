using Microsoft.AspNetCore.Mvc;
using Sistema_tickets_api.Application.DTOs.Usuario;
using Sistema_tickets_api.Application.Mappers;
using Sistema_tickets_api.Application.Services;
using Sistema_tickets_api.Core.Entities;

namespace Sistema_tickets_api.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _service;

        public UsuarioController(UsuarioService service)
        {
            _service = service;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterDTO dto)
        {
            try
            {
                var usuario = _service.Registrar(dto.Nombre, dto.Email, dto.Password, dto.RolId);

                return Ok(usuario.ToDTO());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDTO dto)
        {
            var token = _service.Login(dto.Email, dto.Password);

            if (token == null)
                return Unauthorized();

            return Ok(new { token });
        }

       
        [HttpGet("list")]
        public IActionResult ListarUsuarios()
        {
            var usuarios = _service.ListarTodos(); 
            var usuariosDTO = usuarios.Select(u => u.ToDTO());
            return Ok(usuariosDTO);
        }

        // OBTENER USUARIO POR ID
        [HttpGet("{id:int}")]
        public IActionResult ObtenerPorId(int id)
        {
            var usuario = _service.ObtenerPorId(id);
            if (usuario == null) return NotFound();
            return Ok(usuario.ToDTO());
        }

        // OBTENER USUARIO POR EMAIL
        [HttpGet("email/{email}")]
        public IActionResult ObtenerPorEmail(string email)
        {
            var usuario = _service.ObtenerPorEmail(email);
            if (usuario == null) return NotFound();
            return Ok(usuario.ToDTO());
        }
    }
}