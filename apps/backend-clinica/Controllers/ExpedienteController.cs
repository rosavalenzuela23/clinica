using backend_clinica.Domain;
using backend_clinica.Dtos;
using backend_clinica.Mappers;
using backend_clinica.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend_clinica.Controllers;

[ApiController]
[Route("expediente")]
public sealed class ExpedienteController(NegocioExpediente expedientes) : ControllerBase
{
    [HttpGet("{idPsicologo:long}")]
    public async Task<ActionResult<IReadOnlyList<Expediente>>> GetByPsicologo(long idPsicologo, CancellationToken cancellationToken)
    {
        var response = await expedientes.BuscarExpedientesAsync(idPsicologo, cancellationToken);
        return Ok(response);
    }

    [HttpGet("paciente/{idPaciente:long}")]
    public async Task<ActionResult<Expediente>> GetByPaciente(long idPaciente, CancellationToken cancellationToken)
    {
        var response = await expedientes.ObtenerPorPacienteAsync(idPaciente, cancellationToken);
        return response is null ? NotFound() : Ok(response);
    }

    [HttpPost("registrar")]
    public async Task<ActionResult<Expediente>> Register(ExpedienteRegistrationDto request, CancellationToken cancellationToken)
    {
        var paciente = request.Paciente.ToDomain();
        var expediente = request.Expediente.ToDomain();
        var response = await expedientes.RegistrarAsync(paciente, expediente, request.PsicologoId, cancellationToken);
        return CreatedAtAction(nameof(GetByPaciente), new { idPaciente = paciente.Id }, response);
    }

    [HttpPut("actualizar")]
    public async Task<ActionResult<Expediente>> Update(ExpedienteUpdateDto request, CancellationToken cancellationToken)
    {
        var response = await expedientes.ActualizarAsync(request.Expediente.ToDomain(), request.Paciente.ToDomain(), cancellationToken);
        return Ok(response);
    }
}
