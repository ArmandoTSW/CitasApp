using CitasApp.Domain.Interfaces;
using CitasApp.Domain.Models;

namespace CitasApp.Application.Services;

public class PacienteService
{
    private readonly IPacienteRepository _pacienteRepository;

    public PacienteService(IPacienteRepository pacienteRepository)
    {
        _pacienteRepository = pacienteRepository;
    }

    public List<Paciente> ObtenerTodos()
    {
        return _pacienteRepository.ObtenerTodos();
    }

    public Paciente? ObtenerPorId(int id)
    {
        return _pacienteRepository.ObtenerPorId(id);
    }
}