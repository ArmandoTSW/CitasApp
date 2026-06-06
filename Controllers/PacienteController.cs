using Microsoft.AspNetCore.Mvc;
using CitasApp.Data;

namespace CitasApp.Controllers
{
    public class PacienteController : Controller
    {
        public IActionResult Index()
        {
            var pacientes = DatosMemoria.Pacientes;
            return View(pacientes);
        }

        public IActionResult Detalle(int id)
        {
            var paciente = DatosMemoria.Pacientes.FirstOrDefault(p => p.Id == id);

            if (paciente == null)
            {
                return NotFound();
            }

            return View(paciente);
        }
    }
}