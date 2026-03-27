using Microsoft.AspNetCore.Mvc;
using Sistema_tickets_api.Application.DTOs.Rol;
using Sistema_tickets_api.Application.Services;
using System.Collections.Generic;

namespace Sistema_tickets_api.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolController : ControllerBase
    {
        private readonly RolService _rolService;

        public RolController(RolService rolService)
        {
            _rolService = rolService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<RolDTO>> GetRoles()
        {
            var roles = _rolService.ObtenerRoles();
            return Ok(roles);
        }

        [HttpGet("{id}")]
        public ActionResult<RolDTO> GetRol(int id)
        {
            var rol = _rolService.ObtenerRolPorId(id);

            if (rol == null)
                return NotFound();

            return Ok(rol);
        }
    }
}