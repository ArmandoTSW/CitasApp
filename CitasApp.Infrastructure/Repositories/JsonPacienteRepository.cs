using System.Text.Json;
using CitasApp.Domain.Interfaces;
using CitasApp.Domain.Models;

namespace CitasApp.Infrastructure.Repositories;

public class JsonPacienteRepository : IPacienteRepository
{
    private readonly string _rutaArchivo;

    public JsonPacienteRepository()
    {
        _rutaArchivo = Path.Combine(AppContext.BaseDirectory, "data", "pacientes.json");
    }

    public List<Paciente> ObtenerTodos()
    {
        if (!File.Exists(_rutaArchivo))
        {
            return new List<Paciente>();
        }

        var json = File.ReadAllText(_rutaArchivo);

        return JsonSerializer.Deserialize<List<Paciente>>(json, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        }) ?? new List<Paciente>();
    }

    public Paciente? ObtenerPorId(int id)
    {
        return ObtenerTodos().FirstOrDefault(p => p.Id == id);
    }
}