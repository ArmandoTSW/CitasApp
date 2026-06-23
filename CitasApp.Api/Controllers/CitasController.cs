using CitasApp.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CitasApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CitasController : ControllerBase
    {
        private readonly CitaService _citaService;

        public CitasController(CitaService citaService)
        {
            _citaService = citaService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var citas = _citaService.ObtenerTodos();
            return Ok(citas);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var cita = _citaService.ObtenerPorId(id);

            if (cita == null)
            {
                return NotFound();
            }

            return Ok(cita);
        }

        [HttpGet("porpaciente/{pacienteId}")]
        public IActionResult PorPaciente(int pacienteId)
        {
            var citas = _citaService.ObtenerPorPaciente(pacienteId);

            if (citas.Count == 0)
            {
                return NotFound();
            }

            return Ok(citas);
        }
    }
}