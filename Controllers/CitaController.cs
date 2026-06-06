using Microsoft.AspNetCore.Mvc;
using CitasApp.Data;

namespace CitasApp.Controllers
{
    public class CitaController : Controller
    {
        public IActionResult Index()
        {
            var citas = DatosMemoria.Citas.Select(c => new
            {
                c.Id,
                c.Fecha,
                c.Hora,
                c.Motivo,
                c.Estado,
                Paciente = DatosMemoria.Pacientes.FirstOrDefault(p => p.Id == c.PacienteId),
                Medico = DatosMemoria.Medicos.FirstOrDefault(m => m.Id == c.MedicoId)
            }).ToList();

            return View(citas);
        }

        public IActionResult PorPaciente(int pacienteId)
        {
            var citas = DatosMemoria.Citas
                .Where(c => c.PacienteId == pacienteId)
                .Select(c => new
                {
                    c.Id,
                    c.Fecha,
                    c.Hora,
                    c.Motivo,
                    c.Estado,
                    Paciente = DatosMemoria.Pacientes.FirstOrDefault(p => p.Id == c.PacienteId),
                    Medico = DatosMemoria.Medicos.FirstOrDefault(m => m.Id == c.MedicoId)
                }).ToList();

            return View(citas);
        }
    }
}