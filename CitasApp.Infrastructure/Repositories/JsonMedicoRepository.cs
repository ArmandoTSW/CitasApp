using System.Text.Json;
using CitasApp.Domain.Interfaces;
using CitasApp.Domain.Models;

namespace CitasApp.Infrastructure.Repositories;

public class JsonMedicoRepository : IMedicoRepository
{
    private readonly string _rutaArchivo;

    public JsonMedicoRepository()
    {
        _rutaArchivo = Path.Combine(AppContext.BaseDirectory, "data", "medicos.json");
    }

    public List<Medico> ObtenerTodos()
    {
        if (!File.Exists(_rutaArchivo))
        {
            return new List<Medico>();
        }

        var json = File.ReadAllText(_rutaArchivo);

        return JsonSerializer.Deserialize<List<Medico>>(json, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        }) ?? new List<Medico>();
    }

    public Medico? ObtenerPorId(int id)
    {
        return ObtenerTodos().FirstOrDefault(m => m.Id == id);
    }
}