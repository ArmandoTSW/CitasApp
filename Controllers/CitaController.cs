using Microsoft.AspNetCore.Mvc;
using CitasApp.Application.Services;
using CitasApp.ViewModels;

namespace CitasApp.Controllers
{
    public class CitaController : Controller
    {
        private readonly CitaService _citaService;
        private readonly PacienteService _pacienteService;
        private readonly MedicoService _medicoService;

        public CitaController(
            CitaService citaService,
            PacienteService pacienteService,
            MedicoService medicoService)
        {
            _citaService = citaService;
            _pacienteService = pacienteService;
            _medicoService = medicoService;
        }

        public IActionResult Index()
        {
            var citas = _citaService.ObtenerTodos().Select(c =>
            {
                var paciente = _pacienteService.ObtenerPorId(c.PacienteId);
                var medico = _medicoService.ObtenerPorId(c.MedicoId);

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
            var pacienteSeleccionado = _pacienteService.ObtenerPorId(pacienteId);

            if (pacienteSeleccionado == null)
            {
                return NotFound();
            }

            ViewBag.NombrePaciente = $"{pacienteSeleccionado.Nombre} {pacienteSeleccionado.Apellido}";

            var citas = _citaService.ObtenerPorPaciente(pacienteId).Select(c =>
            {
                var medico = _medicoService.ObtenerPorId(c.MedicoId);

                return new CitaViewModel
                {
                    Id = c.Id,
                    Fecha = c.Fecha,
                    Hora = c.Hora,
                    Motivo = c.Motivo,
                    Estado = c.Estado,
                    NombrePaciente = $"{pacienteSeleccionado.Nombre} {pacienteSeleccionado.Apellido}",
                    NombreMedico = medico != null ? $"{medico.Nombre} {medico.Apellido}" : "Médico no encontrado",
                    EspecialidadMedico = medico != null ? medico.Especialidad : "Sin especialidad"
                };
            }).ToList();

            return View(citas);
        }
    }
}