using System.Collections.Generic;
using System.Linq;
using Entity;
using Logica;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebIPS.Models;

namespace WebIPS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController: ControllerBase
    {
        private readonly PersonaService _personaService;
        public IConfiguration Configuration { get; }
        public PersonaController(IConfiguration configuration)
        {
            Configuration = configuration;
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            _personaService = new PersonaService(connectionString);
        }
        // GET: api/Persona
        [HttpGet]
        public IEnumerable<PersonaViewModel> Gets()
        {
            var personas = _personaService.ConsultarTodos().Select(p=> new PersonaViewModel(p));
            return personas;
        }
     

        // POST: api/Persona
        [HttpPost]
        public ActionResult<PersonaViewModel> Post(PersonaInputModel personaInput)
        {
            Persona persona = MapearPersona(personaInput);
            var response = _personaService.Guardar(persona);
            if (response.Error) 
            {
                return BadRequest(response.Mensaje);
            }
            return Ok(response.Persona);
        }
      

        private Persona MapearPersona(PersonaInputModel personaInput)
{
            var persona = new Persona
            {
                Identificacion = personaInput.Identificacion,
                ValorHospitalizacion = personaInput.ValorHospitalizacion,
                Salario = personaInput.Salario,
                
            };
            return persona;
        }
        
    }
}