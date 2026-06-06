using Microsoft.AspNetCore.Mvc;
using CitasApp.Data;

namespace CitasApp.Controllers
{
    public class MedicoController : Controller
    {
        public IActionResult Index()
        {
            var medicos = DatosMemoria.Medicos;
            return View(medicos);
        }

        public IActionResult Detalle(int id)
        {
            var medico = DatosMemoria.Medicos.FirstOrDefault(m => m.Id == id);

            if (medico == null)
            {
                return NotFound();
            }

            return View(medico);
        }
    }
}