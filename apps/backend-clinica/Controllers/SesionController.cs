using backend_clinica.Domain;
using backend_clinica.Dtos;
using backend_clinica.Mappers;
using backend_clinica.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend_clinica.Controllers;

[ApiController]
[Route("sesion")]
public sealed class SesionController(NegocioSesion sesiones) : ControllerBase
{
    [HttpPost("registrar")]
    public async Task<ActionResult<Sesion>> Register(SesionRegistrationDto request, CancellationToken cancellationToken)
    {
        var response = await sesiones.RegistrarAsync(request.Sesion.ToDomain(), request.ExpedienteId, request.PsicologoId, cancellationToken);
        return CreatedAtAction(nameof(GetByExpediente), new { idExpediente = request.ExpedienteId }, response);
    }

    [HttpGet("obtenerSesionesExpediente/{idExpediente:long}")]
    public async Task<ActionResult<IReadOnlyList<Sesion>>> GetByExpediente(long idExpediente, CancellationToken cancellationToken)
    {
        var response = await sesiones.ObtenerPorExpedienteAsync(idExpediente, cancellationToken);
        return Ok(response);
    }
}
