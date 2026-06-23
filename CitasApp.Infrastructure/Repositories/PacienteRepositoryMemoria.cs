using CitasApp.Domain.Interfaces;
using CitasApp.Domain.Models;

namespace CitasApp.Infrastructure.Repositories;

public class PacienteRepositoryMemoria : IPacienteRepository
{
    private static readonly List<Paciente> _pacientes = new()
    {
        new Paciente
        {
            Id = 1,
            Nombre = "Ana",
            Apellido = "García",
            Email = "ana@mail.com",
            Telefono = "555-0001"
        },
        new Paciente
        {
            Id = 2,
            Nombre = "Luis",
            Apellido = "Martínez",
            Email = "luis@mail.com",
            Telefono = "555-0002"
        },
        new Paciente
        {
            Id = 3,
            Nombre = "María",
            Apellido = "López",
            Email = "maria@mail.com",
            Telefono = "555-0003"
        }
    };

    public List<Paciente> ObtenerTodos()
    {
        return _pacientes;
    }

    public Paciente? ObtenerPorId(int id)
    {
        return _pacientes.FirstOrDefault(p => p.Id == id);
    }
}