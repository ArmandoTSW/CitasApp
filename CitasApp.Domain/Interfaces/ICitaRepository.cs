using CitasApp.Domain.Models;

namespace CitasApp.Domain.Interfaces;

public interface ICitaRepository
{
    List<Cita> ObtenerTodas();
    Cita? ObtenerPorId(int id);
    List<Cita> ObtenerPorPaciente(int pacienteId);
}