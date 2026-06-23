using CitasApp.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CitasApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacientesController : ControllerBase
    {
        private readonly PacienteService _pacienteService;

        public PacientesController(PacienteService pacienteService)
        {
            _pacienteService = pacienteService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var pacientes = _pacienteService.ObtenerTodos();
            return Ok(pacientes);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var paciente = _pacienteService.ObtenerPorId(id);

            if (paciente == null)
            {
                return NotFound();
            }

            return Ok(paciente);
        }
    }
}