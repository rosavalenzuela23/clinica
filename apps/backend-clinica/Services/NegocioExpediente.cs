using backend_clinica.Domain;
using backend_clinica.Persistence;
using backend_clinica.Persistence.Entities;
using backend_clinica.Repositories;
using Microsoft.EntityFrameworkCore;

namespace backend_clinica.Services;

public sealed class NegocioExpediente(ClinicalDbContext db, ExpedienteRepository expedientes, PacienteRepository pacientes)
{
    public Task<IReadOnlyList<Expediente>> BuscarExpedientesAsync(long psicologoId, CancellationToken cancellationToken = default)
    {
        return expedientes.GetByPsicologoAsync(psicologoId, cancellationToken);
    }

    public Task<Expediente?> ObtenerPorPacienteAsync(long pacienteId, CancellationToken cancellationToken = default)
    {
        return expedientes.GetByPacienteAsync(pacienteId, cancellationToken);
    }

    public async Task<Expediente> RegistrarAsync(Paciente paciente, Expediente expediente, long psicologoId, CancellationToken cancellationToken = default)
    {
        // Validate the referenced psychologist before creating the patient/chart aggregate.
        var psicologoExists = await db.Set<PsicologoEntity>().AnyAsync(x => x.Id == psicologoId, cancellationToken);
        if (!psicologoExists)
        {
            throw new KeyNotFoundException("Psicologo no encontrado.");
        }

        // Attach only an existing psychologist key; EF must not insert a duplicate psychologist.
        var pacienteEntity = paciente.ToEntity();
        var psicologo = new PsicologoEntity { Id = psicologoId };
        pacienteEntity.Psicologos.Add(psicologo);
        db.Attach(psicologo);

        // Build the new aggregate explicitly because mappers intentionally exclude navigation properties.
        var expedienteEntity = expediente.ToEntity();
        expedienteEntity.Paciente = pacienteEntity;

        foreach (var integrante in expediente.IntegranteHogar ?? [])
        {
            // Adding children through the aggregate makes EF assign the chart foreign key on save.
            expedienteEntity.IntegrantesHogar.Add(integrante.ToEntity());
        }

        foreach (var familiar in expediente.FamiliaresConfianza ?? [])
        {
            expedienteEntity.FamiliaresConfianza.Add(familiar.ToEntity());
        }

        db.Expedientes.Add(expedienteEntity);
        await db.SaveChangesAsync(cancellationToken);
        return expedienteEntity.ToDomain();
    }

    public async Task<Expediente> ActualizarAsync(Expediente expediente, Paciente paciente, CancellationToken cancellationToken = default)
    {
        // Patient and chart are separate aggregates and therefore use their own repository updates.
        await pacientes.UpdateAsync(paciente, cancellationToken);
        return await expedientes.UpdateAsync(expediente, cancellationToken);
    }
}
