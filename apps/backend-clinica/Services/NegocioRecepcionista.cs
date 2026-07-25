using backend_clinica.Domain;
using backend_clinica.Repositories;

namespace backend_clinica.Services;

public sealed class NegocioRecepcionista(RecepcionistaRepository recepcionistas)
{
    public Task<Recepcionista> RegistrarAsync(Recepcionista recepcionista, CancellationToken cancellationToken = default)
    {
        // The repository stores this employee using the recepcionista role discriminator.
        return recepcionistas.AddAsync(recepcionista, cancellationToken);
    }

    public Task<Recepcionista> ActualizarAsync(Recepcionista recepcionista, CancellationToken cancellationToken = default)
    {
        // Role updates remain in the repository to preserve the service/repository boundary.
        return recepcionistas.UpdateAsync(recepcionista, cancellationToken);
    }
}
