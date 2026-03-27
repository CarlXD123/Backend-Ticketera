using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sistema_tickets_api.Application.DTOs.Tickets;
using Sistema_tickets_api.Application.Mappers;
using Sistema_tickets_api.Application.Services;
using Sistema_tickets_api.Core.Entities;
using System.Security.Claims;

namespace Sistema_tickets_api.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] 
    public class TicketController : ControllerBase
    {
        private readonly TicketService _service;

        public TicketController(TicketService service)
        {
            _service = service;
        }

        
        [HttpGet]
        public IActionResult GetAll([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var tickets = _service.ObtenerTickets(page, pageSize);
            return Ok(tickets.ToDTOs());
        }

     
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var ticket = _service.ObtenerTicketPorId(id);
            if (ticket == null)
                return NotFound();

            return Ok(ticket);
        }

        
        [HttpPost]
        public IActionResult Create([FromBody] CrearTicketDTO dto)
        {
            var ticket = new Ticket
            {
                Titulo = dto.Titulo,
                Descripcion = dto.Descripcion,
                ResponsableId = dto.ResponsableId 
            };

            var creado = _service.CrearTicket(ticket);

            return CreatedAtAction(nameof(GetById), new { id = creado.Id }, creado.ToDTO());
        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateTicketDTO dto)
        {
            var existente = _service.ObtenerTicketPorId(id);
            if (existente == null)
                return NotFound(new { message = "Ticket no encontrado" });

            existente.Titulo = dto.Titulo;
            existente.Descripcion = dto.Descripcion;
            existente.ResponsableId = dto.ResponsableId;
            existente.Estado = dto.Estado; 

            _service.ActualizarTicket(existente);

           
            return Ok(existente.ToDTO());
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existente = _service.ObtenerTicketPorId(id);
            if (existente == null)
                return NotFound(new { message = "Ticket no encontrado" });

            _service.EliminarTicket(id);

         
            return Ok(new { message = "Ticket eliminado correctamente", ticket = existente.ToDTO() });
        }
    }
}