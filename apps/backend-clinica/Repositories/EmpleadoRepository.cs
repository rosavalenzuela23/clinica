using backend_clinica.Domain;
using backend_clinica.Persistence;
using Microsoft.EntityFrameworkCore;

namespace backend_clinica.Repositories;

public sealed class EmpleadoRepository(ClinicalDbContext db)
{
    public async Task<Empleado?> GetAsync(long id, CancellationToken cancellationToken = default)
    {
        var entity = await db.Empleados.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
        return entity?.ToDomain();
    }

    public async Task<Empleado?> GetByCredentialsAsync(string usuario, string contrasenia, CancellationToken cancellationToken = default)
    {
        var entity = await db.Empleados.AsNoTracking()
            .SingleOrDefaultAsync(x => x.Usuario == usuario && x.Contrasenia == contrasenia, cancellationToken);
        return entity?.ToDomain();
    }

    public async Task<IReadOnlyList<Empleado>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var entities = await db.Empleados.AsNoTracking().ToListAsync(cancellationToken);
        return entities.Select(x => x.ToDomain()).ToList();
    }
    public async Task<Empleado> DeactivateAsync(long id, CancellationToken cancellationToken = default)
    {
        var entity = await db.Empleados.SingleOrDefaultAsync(x => x.Id == id, cancellationToken) ?? throw new KeyNotFoundException("Empleado no encontrado.");
        entity.Estado = false;
        await db.SaveChangesAsync(cancellationToken);
        return entity.ToDomain();
    }
}
