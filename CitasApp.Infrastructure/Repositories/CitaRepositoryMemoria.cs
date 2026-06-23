using CitasApp.Domain.Interfaces;
using CitasApp.Domain.Models;

namespace CitasApp.Infrastructure.Repositories;

public class CitaRepositoryMemoria : ICitaRepository
{
    private static readonly List<Cita> _citas = new()
    {
        new Cita
        {
            Id = 1,
            PacienteId = 1,
            MedicoId = 1,
            Fecha = new DateOnly(2026, 6, 1),
            Hora = new TimeOnly(9, 0),
            Motivo = "Consulta general",
            Estado = "Confirmada"
        },
        new Cita
        {
            Id = 2,
            PacienteId = 2,
            MedicoId = 2,
            Fecha = new DateOnly(2026, 6, 1),
            Hora = new TimeOnly(10, 0),
            Motivo = "Revisión de resultados",
            Estado = "Pendiente"
        },
        new Cita
        {
            Id = 3,
            PacienteId = 3,
            MedicoId = 1,
            Fecha = new DateOnly(2026, 6, 3),
            Hora = new TimeOnly(11, 0),
            Motivo = "Primera consulta",
            Estado = "Pendiente"
        }
    };

    public List<Cita> ObtenerTodas()
    {
        return _citas;
    }

    public Cita? ObtenerPorId(int id)
    {
        return _citas.FirstOrDefault(c => c.Id == id);
    }

    public List<Cita> ObtenerPorPaciente(int pacienteId)
    {
        return _citas.Where(c => c.PacienteId == pacienteId).ToList();
    }
}