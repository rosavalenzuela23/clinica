using backend_clinica.Domain;
using backend_clinica.Persistence;
using backend_clinica.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend_clinica.Repositories;

public sealed class PsicologoRepository(ClinicalDbContext db)
{
    public async Task<Psicologo> AddAsync(Psicologo psicologo, CancellationToken cancellationToken = default)
    {
        var entity = psicologo.ToEntity();
        db.Add(entity);
        await db.SaveChangesAsync(cancellationToken);
        return entity.ToDomain();
    }
    public async Task<Psicologo?> GetAsync(long id, CancellationToken cancellationToken = default) => (await db.Set<PsicologoEntity>().AsNoTracking().SingleOrDefaultAsync(x => x.Id == id, cancellationToken))?.ToDomain();
    public async Task<IReadOnlyList<Psicologo>> GetAllAsync(CancellationToken cancellationToken = default) => (await db.Set<PsicologoEntity>().AsNoTracking().ToListAsync(cancellationToken)).Select(x => x.ToDomain()).ToList();
    public async Task<Psicologo> UpdateAsync(Psicologo psicologo, CancellationToken cancellationToken = default)
    {
        var entity = await db.Set<PsicologoEntity>().SingleOrDefaultAsync(x => x.Id == psicologo.Id, cancellationToken) ?? throw new KeyNotFoundException("Psicologo no encontrado.");
        entity.Usuario = psicologo.Usuario;
        entity.Contrasenia = psicologo.Contrasenia;
        await db.SaveChangesAsync(cancellationToken);
        return entity.ToDomain();
    }
    public async Task DeleteAsync(long id, CancellationToken cancellationToken = default)
    {
        var entity = await db.Set<PsicologoEntity>().SingleOrDefaultAsync(x => x.Id == id, cancellationToken) ?? throw new KeyNotFoundException("Psicologo no encontrado.");
        db.Remove(entity);
        await db.SaveChangesAsync(cancellationToken);
    }
}
