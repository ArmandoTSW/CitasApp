using Microsoft.AspNetCore.Mvc;
using CitasApp.Application.Services;

namespace CitasApp.Controllers
{
    public class MedicoController : Controller
    {
        private readonly MedicoService _medicoService;

        public MedicoController(MedicoService medicoService)
        {
            _medicoService = medicoService;
        }

        public IActionResult Index()
        {
            var medicos = _medicoService.ObtenerTodos();
            return View(medicos);
        }

        public IActionResult Detalle(int id)
        {
            var medico = _medicoService.ObtenerPorId(id);

            if (medico == null)
            {
                return NotFound();
            }

            return View(medico);
        }
    }
}