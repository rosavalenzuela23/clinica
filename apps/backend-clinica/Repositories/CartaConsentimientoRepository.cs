using backend_clinica.Domain;
using backend_clinica.Persistence;
using Microsoft.EntityFrameworkCore;

namespace backend_clinica.Repositories;

public sealed class CartaConsentimientoRepository(ClinicalDbContext db)
{
    public async Task<IReadOnlyList<Paciente>> GetPacientesSinCartaAsync(CancellationToken cancellationToken = default) => (await db.Pacientes.AsNoTracking().Where(x => x.Carta == null).ToListAsync(cancellationToken)).Select(x => x.ToDomain()).ToList();
    public async Task<CartaConcentimiento?> GetAsync(long id, CancellationToken cancellationToken = default) => (await db.CartasConcentimiento.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id, cancellationToken))?.ToDomain();
    public async Task<CartaConcentimiento> AddAsync(long pacienteId, CartaConcentimiento carta, CancellationToken cancellationToken = default)
    {
        var entity = carta.ToEntity();
        entity.PacienteId = pacienteId;
        db.CartasConcentimiento.Add(entity);
        await db.SaveChangesAsync(cancellationToken);
        return entity.ToDomain();
    }
}
