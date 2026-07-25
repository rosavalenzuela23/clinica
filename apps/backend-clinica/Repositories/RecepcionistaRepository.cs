using backend_clinica.Domain;
using backend_clinica.Persistence;
using backend_clinica.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend_clinica.Repositories;

public sealed class RecepcionistaRepository(ClinicalDbContext db)
{
    public async Task<Recepcionista> AddAsync(Recepcionista recepcionista, CancellationToken cancellationToken = default)
    {
        var entity = recepcionista.ToEntity();
        db.Add(entity);
        await db.SaveChangesAsync(cancellationToken);
        return entity.ToDomain();
    }
    public async Task<Recepcionista?> GetAsync(long id, CancellationToken cancellationToken = default) => (await db.Set<RecepcionistaEntity>().AsNoTracking().SingleOrDefaultAsync(x => x.Id == id, cancellationToken))?.ToDomain();
    public async Task<Recepcionista> UpdateAsync(Recepcionista recepcionista, CancellationToken cancellationToken = default)
    {
        var entity = await db.Set<RecepcionistaEntity>().SingleOrDefaultAsync(x => x.Id == recepcionista.Id, cancellationToken) ?? throw new KeyNotFoundException("Recepcionista no encontrado.");
        entity.Usuario = recepcionista.Usuario;
        entity.Contrasenia = recepcionista.Contrasenia;
        await db.SaveChangesAsync(cancellationToken);
        return entity.ToDomain();
    }
    public async Task DeleteAsync(long id, CancellationToken cancellationToken = default)
    {
        var entity = await db.Set<RecepcionistaEntity>().SingleOrDefaultAsync(x => x.Id == id, cancellationToken) ?? throw new KeyNotFoundException("Recepcionista no encontrado.");
        db.Remove(entity);
        await db.SaveChangesAsync(cancellationToken);
    }
}
