using System.Text.Json;
using CitasApp.Domain.Interfaces;
using CitasApp.Domain.Models;

namespace CitasApp.Infrastructure.Repositories;

public class JsonCitaRepository : ICitaRepository
{
    private readonly string _rutaArchivo;

    public JsonCitaRepository()
    {
        _rutaArchivo = Path.Combine(AppContext.BaseDirectory, "data", "citas.json");
    }

    public List<Cita> ObtenerTodas()
    {
        if (!File.Exists(_rutaArchivo))
        {
            return new List<Cita>();
        }

        var json = File.ReadAllText(_rutaArchivo);

        return JsonSerializer.Deserialize<List<Cita>>(json, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        }) ?? new List<Cita>();
    }

    public Cita? ObtenerPorId(int id)
    {
        return ObtenerTodas().FirstOrDefault(c => c.Id == id);
    }

    public List<Cita> ObtenerPorPaciente(int pacienteId)
    {
        return ObtenerTodas().Where(c => c.PacienteId == pacienteId).ToList();
    }
}