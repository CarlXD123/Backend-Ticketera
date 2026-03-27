using Microsoft.AspNetCore.Mvc;
using Sistema_tickets_api.Application.Mappers;
using Sistema_tickets_api.Application.Services;
using Sistema_tickets_api.Core.Entities;
using Sistema_tickets_api.Core.Interfaces;

namespace Sistema_tickets_api.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComentariosController : ControllerBase
    {
        private readonly ComentarioService _service;

        public ComentariosController(ComentarioService service)
        {
            _service = service;
        }

       
        [HttpGet]
        public IActionResult GetAll()
        {
            var comentarios = _service.ObtenerTodos();
            return Ok(comentarios.ToDTOs());
        }

        
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var comentario = _service.ObtenerPorId(id);
            if (comentario == null)
                return NotFound(new { message = "Comentario no encontrado" });

            return Ok(comentario.ToDTO());
        }

       
        [HttpPost]
        public IActionResult Create([FromBody] Comentario comentario)
        {
            comentario.FechaCreacion = DateTime.Now;
            _service.Crear(comentario);
            return Ok(new { message = "Comentario creado correctamente", comentario = comentario.ToDTO() });
        }

       
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Comentario comentarioDto)
        {
            var existente = _service.ObtenerPorId(id);
            if (existente == null)
                return NotFound(new { message = "Comentario no encontrado" });

            existente.Texto = comentarioDto.Texto;
            _service.Actualizar(existente);

            return Ok(new { message = "Comentario actualizado correctamente", comentario = existente.ToDTO() });
        }

       
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existente = _service.ObtenerPorId(id);
            if (existente == null)
                return NotFound(new { message = "Comentario no encontrado" });

            _service.Eliminar(id);
            return Ok(new { message = "Comentario eliminado correctamente" });
        }
    }
}