using Microsoft.AspNetCore.Mvc;
using CitasApp.Data;
using CitasApp.ViewModels;

namespace CitasApp.Controllers
{
    public class CitaController : Controller
    {
        public IActionResult Index()
        {
            var citas = DatosMemoria.Citas.Select(c =>
            {
                var paciente = DatosMemoria.Pacientes.FirstOrDefault(p => p.Id == c.PacienteId);
                var medico = DatosMemoria.Medicos.FirstOrDefault(m => m.Id == c.MedicoId);

                return new CitaViewModel
                {
                    Id = c.Id,
                    Fecha = c.Fecha,
                    Hora = c.Hora,
                    Motivo = c.Motivo,
                    Estado = c.Estado,
                    NombrePaciente = paciente != null ? $"{paciente.Nombre} {paciente.Apellido}" : "Paciente no encontrado",
                    NombreMedico = medico != null ? $"{medico.Nombre} {medico.Apellido}" : "Médico no encontrado",
                    EspecialidadMedico = medico != null ? medico.Especialidad : "Sin especialidad"
                };
            }).ToList();

            return View(citas);
        }

        public IActionResult PorPaciente(int pacienteId)
        {
            var pacienteSeleccionado = DatosMemoria.Pacientes.FirstOrDefault(p => p.Id == pacienteId);

            if (pacienteSeleccionado == null)
            {
                return NotFound();
            }

            ViewBag.NombrePaciente = $"{pacienteSeleccionado.Nombre} {pacienteSeleccionado.Apellido}";

            var citas = DatosMemoria.Citas
                .Where(c => c.PacienteId == pacienteId)
                .Select(c =>
                {
                    var paciente = DatosMemoria.Pacientes.FirstOrDefault(p => p.Id == c.PacienteId);
                    var medico = DatosMemoria.Medicos.FirstOrDefault(m => m.Id == c.MedicoId);

                    return new CitaViewModel
                    {
                        Id = c.Id,
                        Fecha = c.Fecha,
                        Hora = c.Hora,
                        Motivo = c.Motivo,
                        Estado = c.Estado,
                        NombrePaciente = paciente != null ? $"{paciente.Nombre} {paciente.Apellido}" : "Paciente no encontrado",
                        NombreMedico = medico != null ? $"{medico.Nombre} {medico.Apellido}" : "Médico no encontrado",
                        EspecialidadMedico = medico != null ? medico.Especialidad : "Sin especialidad"
                    };
                }).ToList();

            return View(citas);
        }
    }
}