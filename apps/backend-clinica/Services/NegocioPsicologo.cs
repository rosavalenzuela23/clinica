using backend_clinica.Domain;
using backend_clinica.Repositories;

namespace backend_clinica.Services;

public sealed class NegocioPsicologo(PsicologoRepository psicologos)
{
    public Task<Psicologo> RegistrarAsync(Psicologo psicologo, CancellationToken cancellationToken = default)
    {
        // Role-specific persistence keeps psychologist discriminator data in the employee hierarchy.
        return psicologos.AddAsync(psicologo, cancellationToken);
    }

    public Task<Psicologo> ActualizarAsync(Psicologo psicologo, CancellationToken cancellationToken = default)
    {
        // The repository updates only the mutable employee fields for this role.
        return psicologos.UpdateAsync(psicologo, cancellationToken);
    }

    public Task<IReadOnlyList<Psicologo>> ObtenerTodosAsync(CancellationToken cancellationToken = default)
    {
        return psicologos.GetAllAsync(cancellationToken);
    }
}
