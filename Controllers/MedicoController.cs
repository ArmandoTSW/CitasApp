using Microsoft.AspNetCore.Mvc;
using CitasApp.Domain.Interfaces;

namespace CitasApp.Controllers
{
    public class MedicoController : Controller
    {
        private readonly IMedicoRepository _medicoRepository;

        public MedicoController(IMedicoRepository medicoRepository)
        {
            _medicoRepository = medicoRepository;
        }

        public IActionResult Index()
        {
            var medicos = _medicoRepository.ObtenerTodos();
            return View(medicos);
        }

        public IActionResult Detalle(int id)
        {
            var medico = _medicoRepository.ObtenerPorId(id);

            if (medico == null)
            {
                return NotFound();
            }

            return View(medico);
        }
    }
}