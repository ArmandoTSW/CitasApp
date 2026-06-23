using CitasApp.Domain.Interfaces;

namespace CitasApp.Infrastructure.Repositories;

public static class RepositoryFactory
{
    public static IPacienteRepository CrearPacienteRepository(string entorno)
    {
        if (entorno == "Production")
        {
            return new PacienteRepositoryMemoria();
        }

        return new JsonPacienteRepository();
    }
}