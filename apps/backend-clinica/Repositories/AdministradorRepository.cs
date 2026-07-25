using backend_clinica.Domain;
using backend_clinica.Persistence;
using backend_clinica.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend_clinica.Repositories;

public sealed class AdministradorRepository(ClinicalDbContext db)
{
    public async Task<Administrador> AddAsync(Administrador administrador, CancellationToken cancellationToken = default)
    {
        var entity = administrador.ToEntity();
        db.Add(entity);
        await db.SaveChangesAsync(cancellationToken);
        return entity.ToDomain();
    }
    public async Task<Administrador?> GetAsync(long id, CancellationToken cancellationToken = default) => (await db.Set<AdministradorEntity>().AsNoTracking().SingleOrDefaultAsync(x => x.Id == id, cancellationToken))?.ToDomain();
    public async Task<Administrador> UpdateAsync(Administrador administrador, CancellationToken cancellationToken = default)
    {
        var entity = await db.Set<AdministradorEntity>().SingleOrDefaultAsync(x => x.Id == administrador.Id, cancellationToken) ?? throw new KeyNotFoundException("Administrador no encontrado.");
        entity.Usuario = administrador.Usuario;
        entity.Contrasenia = administrador.Contrasenia;
        await db.SaveChangesAsync(cancellationToken);
        return entity.ToDomain();
    }
}
