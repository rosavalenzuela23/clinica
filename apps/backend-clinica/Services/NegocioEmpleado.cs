using backend_clinica.Domain;
using backend_clinica.Repositories;

namespace backend_clinica.Services;

public sealed class NegocioEmpleado(EmpleadoRepository empleados)
{
    public Task<Empleado?> ObtenerEmpleadoAsync(Empleado credenciales, CancellationToken cancellationToken = default)
    {
        // Credentials arrive as a domain value after DTO mapping; only the repository queries persistence.
        return empleados.GetByCredentialsAsync(credenciales.Usuario!, credenciales.Contrasenia!, cancellationToken);
    }

    public Task<IReadOnlyList<Empleado>> ObtenerEmpleadosAsync(CancellationToken cancellationToken = default)
    {
        return empleados.GetAllAsync(cancellationToken);
    }

    public Task<Empleado> EliminarEmpleadoAsync(Empleado empleado, CancellationToken cancellationToken = default)
    {
        // Employee deletion is a soft delete, represented by setting Estado to false.
        return empleados.DeactivateAsync(empleado.Id, cancellationToken);
    }
}
