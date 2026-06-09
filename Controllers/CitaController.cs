using Microsoft.AspNetCore.Mvc;
using CitasApp.Domain.Interfaces;
using CitasApp.ViewModels;

namespace CitasApp.Controllers
{
    public class CitaController : Controller
    {
        private readonly ICitaRepository _citaRepository;
        private readonly IPacienteRepository _pacienteRepository;
        private readonly IMedicoRepository _medicoRepository;

        public CitaController(
            ICitaRepository citaRepository,
            IPacienteRepository pacienteRepository,
            IMedicoRepository medicoRepository)
        {
            _citaRepository = citaRepository;
            _pacienteRepository = pacienteRepository;
            _medicoRepository = medicoRepository;
        }

        public IActionResult Index()
        {
            var citas = _citaRepository.ObtenerTodas().Select(c =>
            {
                var paciente = _pacienteRepository.ObtenerPorId(c.PacienteId);
                var medico = _medicoRepository.ObtenerPorId(c.MedicoId);

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
            var pacienteSeleccionado = _pacienteRepository.ObtenerPorId(pacienteId);

            if (pacienteSeleccionado == null)
            {
                return NotFound();
            }

            ViewBag.NombrePaciente = $"{pacienteSeleccionado.Nombre} {pacienteSeleccionado.Apellido}";

            var citas = _citaRepository.ObtenerPorPaciente(pacienteId).Select(c =>
            {
                var medico = _medicoRepository.ObtenerPorId(c.MedicoId);

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