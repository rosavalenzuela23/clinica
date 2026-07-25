using backend_clinica.Domain;
using backend_clinica.Persistence;
using Microsoft.EntityFrameworkCore;

namespace backend_clinica.Repositories;

public sealed class PacienteRepository(ClinicalDbContext db)
{
    public async Task<Paciente> AddAsync(Paciente paciente, CancellationToken cancellationToken = default)
    {
        var entity = paciente.ToEntity();
        db.Pacientes.Add(entity);
        await db.SaveChangesAsync(cancellationToken);
        return entity.ToDomain();
    }
    public async Task<Paciente?> GetAsync(long id, CancellationToken cancellationToken = default)
    {
        var entity = await db.Pacientes.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
        return entity?.ToDomain();
    }

    public async Task<IReadOnlyList<Paciente>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var entities = await db.Pacientes.AsNoTracking().ToListAsync(cancellationToken);
        return entities.Select(x => x.ToDomain()).ToList();
    }

    public async Task<IReadOnlyList<Paciente>> GetByPsicologoAsync(long psicologoId, CancellationToken cancellationToken = default)
    {
        var entities = await db.Pacientes.AsNoTracking()
            .Where(x => x.Psicologos.Any(p => p.Id == psicologoId))
            .ToListAsync(cancellationToken);
        return entities.Select(x => x.ToDomain()).ToList();
    }
    public async Task<Paciente> UpdateAsync(Paciente paciente, CancellationToken cancellationToken = default)
    {
        var entity = await db.Pacientes.SingleOrDefaultAsync(x => x.Id == paciente.Id, cancellationToken) ?? throw new KeyNotFoundException("Paciente no encontrado.");
        db.Entry(entity).CurrentValues.SetValues(paciente.ToEntity());
        await db.SaveChangesAsync(cancellationToken);
        return entity.ToDomain();
    }
}
