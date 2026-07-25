using backend_clinica.Domain;
using backend_clinica.Dtos;
using backend_clinica.Mappers;
using backend_clinica.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend_clinica.Controllers;

[ApiController]
[Route("paciente")]
public sealed class PacienteController(NegocioPaciente pacientes) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<Paciente>>> GetByPsicologo([FromQuery] long id, CancellationToken cancellationToken)
    {
        var response = await pacientes.GetPacientesPsicologoAsync(id, cancellationToken);
        return Ok(response);
    }

    [HttpGet("todos")]
    public async Task<ActionResult<IReadOnlyList<Paciente>>> GetAll(CancellationToken cancellationToken)
    {
        var response = await pacientes.ObtenerTodosAsync(cancellationToken);
        return Ok(response);
    }

    [HttpGet("carta")]
    public async Task<ActionResult<IReadOnlyList<Paciente>>> GetWithoutConsent(CancellationToken cancellationToken)
    {
        var response = await pacientes.ObtenerPacientesSinCartaAsync(cancellationToken);
        return Ok(response);
    }

    [HttpPost("carta")]
    [Consumes("multipart/form-data")]
    public async Task<ActionResult<CartaConcentimiento>> UploadConsent(
        [FromForm] ConsentimientoUploadDto request,
        CancellationToken cancellationToken)
    {
        if (request.Archivo.Length == 0)
        {
            return BadRequest("El archivo de consentimiento es obligatorio.");
        }

        var directory = Path.Combine(AppContext.BaseDirectory, "expedientes");
        Directory.CreateDirectory(directory);
        var path = Path.Combine(directory, $"{request.PacienteId}.pdf");

        await using var stream = System.IO.File.Create(path);
        await request.Archivo.CopyToAsync(stream, cancellationToken);

        var carta = request.ToDomain(path);
        var response = await pacientes.AgregarCartaConsentimientoAsync(request.PacienteId, carta, cancellationToken);
        return CreatedAtAction(nameof(GetWithoutConsent), new { id = response.Id }, response);
    }
}
