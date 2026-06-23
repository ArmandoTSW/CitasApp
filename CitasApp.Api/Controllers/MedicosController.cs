using CitasApp.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CitasApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicosController : ControllerBase
    {
        private readonly MedicoService _medicoService;

        public MedicosController(MedicoService medicoService)
        {
            _medicoService = medicoService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var medicos = _medicoService.ObtenerTodos();
            return Ok(medicos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var medico = _medicoService.ObtenerPorId(id);

            if (medico == null)
            {
                return NotFound();
            }

            return Ok(medico);
        }
    }
}