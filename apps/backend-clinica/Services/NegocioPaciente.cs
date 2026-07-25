using backend_clinica.Domain;
using backend_clinica.Repositories;

namespace backend_clinica.Services;

public sealed class NegocioPaciente(PacienteRepository pacientes, CartaConsentimientoRepository cartas)
{
    public Task<IReadOnlyList<Paciente>> GetPacientesPsicologoAsync(long psicologoId, CancellationToken cancellationToken = default)
    {
        // The repository resolves the many-to-many psychologist/patient relationship.
        return pacientes.GetByPsicologoAsync(psicologoId, cancellationToken);
    }

    public Task<IReadOnlyList<Paciente>> ObtenerTodosAsync(CancellationToken cancellationToken = default)
    {
        return pacientes.GetAllAsync(cancellationToken);
    }

    public Task<IReadOnlyList<Paciente>> ObtenerPacientesSinCartaAsync(CancellationToken cancellationToken = default)
    {
        // Consent records are stored separately from patients, so this query belongs to its repository.
        return cartas.GetPacientesSinCartaAsync(cancellationToken);
    }

    public Task<CartaConcentimiento> AgregarCartaConsentimientoAsync(long pacienteId, CartaConcentimiento carta, CancellationToken cancellationToken = default)
    {
        // The patient identifier is passed separately to avoid mapping a navigation graph from the request.
        return cartas.AddAsync(pacienteId, carta, cancellationToken);
    }
}
