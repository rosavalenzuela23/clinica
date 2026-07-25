using backend_clinica.Domain;
using backend_clinica.Repositories;

namespace backend_clinica.Services;

public sealed class NegocioAdministrador(AdministradorRepository administradores)
{
    public Task<Administrador> RegistrarAsync(Administrador administrador, CancellationToken cancellationToken = default)
    {
        // The role-specific repository persists the administrator discriminator in the employee table.
        return administradores.AddAsync(administrador, cancellationToken);
    }

    public Task<Administrador> ActualizarAsync(Administrador administrador, CancellationToken cancellationToken = default)
    {
        // Keep update rules in the repository so controllers never access EF entities.
        return administradores.UpdateAsync(administrador, cancellationToken);
    }
}
