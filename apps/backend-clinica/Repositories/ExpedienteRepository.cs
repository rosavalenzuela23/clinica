using backend_clinica.Domain;
using backend_clinica.Persistence;
using Microsoft.EntityFrameworkCore;

namespace backend_clinica.Repositories;

public sealed class ExpedienteRepository(ClinicalDbContext db)
{
    public async Task<IReadOnlyList<Expediente>> GetByPsicologoAsync(long psicologoId, CancellationToken cancellationToken = default)
    {
        var entities = await db.Expedientes.AsNoTracking()
            .Where(x => x.Paciente.Psicologos.Any(p => p.Id == psicologoId))
            .ToListAsync(cancellationToken);
        return entities.Select(x => x.ToDomain()).ToList();
    }

    public async Task<Expediente?> GetAsync(long id, CancellationToken cancellationToken = default)
    {
        var entity = await db.Expedientes.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
        return entity?.ToDomain();
    }

    public async Task<Expediente?> GetByPacienteAsync(long pacienteId, CancellationToken cancellationToken = default)
    {
        var entity = await db.Expedientes.AsNoTracking().SingleOrDefaultAsync(x => x.PacienteId == pacienteId, cancellationToken);
        return entity?.ToDomain();
    }
    public async Task<Expediente> UpdateAsync(Expediente expediente, CancellationToken cancellationToken = default)
    {
        var entity = await db.Expedientes.SingleOrDefaultAsync(x => x.Id == expediente.Id, cancellationToken) ?? throw new KeyNotFoundException("Expediente no encontrado.");
        db.Entry(entity).CurrentValues.SetValues(expediente.ToEntity());
        await db.SaveChangesAsync(cancellationToken);
        return entity.ToDomain();
    }
}
