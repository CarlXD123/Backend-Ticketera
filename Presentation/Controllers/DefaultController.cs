using Microsoft.AspNetCore.Mvc;

namespace Sistema_tickets_api.API.Controllers
{
    [ApiController]
    [Route("/")] 
    public class DefaultController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Content("Sistema de tickets corriendo", "text/plain");
        }
    }
}