using backend_clinica.Domain;
using backend_clinica.Persistence;
using Microsoft.EntityFrameworkCore;

namespace backend_clinica.Repositories;

public sealed class SesionRepository(ClinicalDbContext db)
{
    public async Task<Sesion> AddAsync(Sesion sesion, long expedienteId, long psicologoId, CancellationToken cancellationToken = default)
    {
        var entity = sesion.ToEntity();
        entity.ExpedienteId = expedienteId;
        entity.PsicologoId = psicologoId;
        foreach (var comentario in sesion.Comentarios ?? [])
            entity.Comentarios.Add(comentario.ToEntity());
        foreach (var problema in sesion.ProblemasSesion ?? [])
            entity.Problemas.Add(problema.ToEntity());
        db.Sesiones.Add(entity);
        await db.SaveChangesAsync(cancellationToken);
        return entity.ToDomain();
    }
    public async Task<IReadOnlyList<Sesion>> GetByExpedienteAsync(long expedienteId, CancellationToken cancellationToken = default)
    {
        var entities = await db.Sesiones.AsNoTracking()
            .Where(x => x.ExpedienteId == expedienteId)
            .ToListAsync(cancellationToken);
        return entities.Select(x => x.ToDomain()).ToList();
    }
}
