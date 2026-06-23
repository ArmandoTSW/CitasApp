using CitasApp.Domain.Interfaces;
using CitasApp.Domain.Models;

namespace CitasApp.Infrastructure.Repositories;

public class MedicoRepositoryMemoria : IMedicoRepository
{
    private static readonly List<Medico> _medicos = new()
    {
        new Medico
        {
            Id = 1,
            Nombre = "Carlos",
            Apellido = "Reyes",
            Especialidad = "Medicina General",
            NumeroLicencia = "MG-10421"
        },
        new Medico
        {
            Id = 2,
            Nombre = "Patricia",
            Apellido = "Vega",
            Especialidad = "Pediatría",
            NumeroLicencia = "PD-20835"
        },
        new Medico
        {
            Id = 3,
            Nombre = "Roberto",
            Apellido = "Sánchez",
            Especialidad = "Cardiología",
            NumeroLicencia = "CA-30117"
        }
    };

    public List<Medico> ObtenerTodos()
    {
        return _medicos;
    }

    public Medico? ObtenerPorId(int id)
    {
        return _medicos.FirstOrDefault(m => m.Id == id);
    }
}