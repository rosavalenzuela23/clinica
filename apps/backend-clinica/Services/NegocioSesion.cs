using backend_clinica.Domain;
using backend_clinica.Repositories;

namespace backend_clinica.Services;

public sealed class NegocioSesion(SesionRepository sesiones)
{
    public Task<Sesion> RegistrarAsync(Sesion sesion, long expedienteId, long psicologoId, CancellationToken cancellationToken = default)
    {
        // The repository assigns the chart and psychologist foreign keys while persisting session children.
        return sesiones.AddAsync(sesion, expedienteId, psicologoId, cancellationToken);
    }

    public Task<IReadOnlyList<Sesion>> ObtenerPorExpedienteAsync(long expedienteId, CancellationToken cancellationToken = default)
    {
        return sesiones.GetByExpedienteAsync(expedienteId, cancellationToken);
    }
}
