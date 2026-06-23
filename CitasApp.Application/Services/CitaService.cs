using CitasApp.Domain.Interfaces;
using CitasApp.Domain.Models;

namespace CitasApp.Application.Services;

public class CitaService
{
    private readonly ICitaRepository _citaRepository;

    public CitaService(ICitaRepository citaRepository)
    {
        _citaRepository = citaRepository;
    }

    public List<Cita> ObtenerTodos()
    {
        return _citaRepository.ObtenerTodas();
    }

    public Cita? ObtenerPorId(int id)
    {
        return _citaRepository.ObtenerPorId(id);
    }

    public List<Cita> ObtenerPorPaciente(int pacienteId)
    {
        return _citaRepository.ObtenerPorPaciente(pacienteId);
    }
}