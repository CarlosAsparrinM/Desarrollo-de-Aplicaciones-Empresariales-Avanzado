using Lab14_Semana16.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lab14_Semana16.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        [Authorize]
        [HttpGet("authenticated", Name = "Get")]
        public IActionResult Get()
        {
            List<PersonResponse> personas = new List<PersonResponse>();
            for (int i = 1; i <= 100; i++)
            {
                PersonResponse persona = new PersonResponse();
                persona.FirstName = "Persona " + i;
                persona.LastName = "Apellido " + i;
                personas.Add(persona);
            }
            return Ok(new { Mensaje = "Hola usuarios generales", Data = personas });
        }

        [Authorize("Administrador")]
        [HttpGet("admin", Name = "Get2")]
        public IActionResult Get2()
        {
            List<PersonResponse> personas = new List<PersonResponse>();
            for (int i = 1; i <= 100; i++)
            {
                PersonResponse persona = new PersonResponse();
                persona.FirstName = "Persona " + i;
                persona.LastName = "Apellido " + i;
                personas.Add(persona);
            }
            return Ok(new { Mensaje = "Hola administrador", Data = personas });
        }

        [Authorize("Vendedor")]
        [HttpGet("vendedor", Name = "Get3")]
        public IActionResult Get3()
        {
            List<PersonResponse> personas = new List<PersonResponse>();
            for (int i = 1; i <= 100; i++)
            {
                PersonResponse persona = new PersonResponse();
                persona.FirstName = "Persona " + i;
                persona.LastName = "Apellido " + i;
                personas.Add(persona);
            }
            return Ok(new { Mensaje = "Hola vendedor", Data = personas });
        }
    }
}
