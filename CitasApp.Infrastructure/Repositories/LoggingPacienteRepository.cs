using CitasApp.Domain.Interfaces;
using CitasApp.Domain.Models;

namespace CitasApp.Infrastructure.Repositories;

public class LoggingPacienteRepository : IPacienteRepository
{
    private readonly IPacienteRepository _inner;

    public LoggingPacienteRepository(IPacienteRepository inner)
    {
        _inner = inner;
    }

    public List<Paciente> ObtenerTodos()
    {
        Console.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] ObtenerTodos - inicio");

        var resultado = _inner.ObtenerTodos();

        Console.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] ObtenerTodos - {resultado.Count} registros");

        return resultado;
    }

    public Paciente? ObtenerPorId(int id)
    {
        Console.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] ObtenerPorId({id}) - inicio");

        var resultado = _inner.ObtenerPorId(id);

        if (resultado == null)
        {
            Console.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] ObtenerPorId({id}) - no encontrado");
        }
        else
        {
            Console.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] ObtenerPorId({id}) - encontrado");
        }

        return resultado;
    }
}