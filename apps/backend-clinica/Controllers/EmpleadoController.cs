using backend_clinica.Domain;
using backend_clinica.Dtos;
using backend_clinica.Mappers;
using backend_clinica.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend_clinica.Controllers;

[ApiController]
[Route("empleado")]
public sealed class EmpleadoController(
    NegocioEmpleado empleados,
    NegocioPsicologo psicologos,
    NegocioAdministrador administradores,
    NegocioRecepcionista recepcionistas) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<Empleado>> Login(EmployeeLoginDto request, CancellationToken cancellationToken)
    {
        var empleado = await empleados.ObtenerEmpleadoAsync(request.ToDomain(), cancellationToken);
        if (empleado is null)
        {
            return Unauthorized(new { message = "Usuario o contraseña inválida." });
        }

        return Ok(empleado);
    }

    [HttpPost("recepcionista")]
    public async Task<ActionResult<Recepcionista>> RegisterRecepcionista(RecepcionistaDto request, CancellationToken cancellationToken)
    {
        var recepcionista = request.ToDomain();
        recepcionista.Estado = true;
        var response = await recepcionistas.RegistrarAsync(recepcionista, cancellationToken);
        return CreatedAtAction(nameof(GetAll), response);
    }

    [HttpPost("psicologo")]
    public async Task<ActionResult<Psicologo>> RegisterPsicologo(PsicologoDto request, CancellationToken cancellationToken)
    {
        var psicologo = request.ToDomain();
        psicologo.Estado = true;
        var response = await psicologos.RegistrarAsync(psicologo, cancellationToken);
        return CreatedAtAction(nameof(GetAllPsicologos), response);
    }

    [HttpPost("administrador")]
    public async Task<ActionResult<Administrador>> RegisterAdministrador(AdministradorDto request, CancellationToken cancellationToken)
    {
        var administrador = request.ToDomain();
        administrador.Estado = true;
        var response = await administradores.RegistrarAsync(administrador, cancellationToken);
        return CreatedAtAction(nameof(GetAll), response);
    }

    [HttpGet("all")]
    public async Task<ActionResult<IReadOnlyList<Empleado>>> GetAll(CancellationToken cancellationToken)
    {
        var response = await empleados.ObtenerEmpleadosAsync(cancellationToken);
        return Ok(response);
    }

    [HttpGet("obtener/todos/psicologo")]
    public async Task<ActionResult<IReadOnlyList<Psicologo>>> GetAllPsicologos(CancellationToken cancellationToken)
    {
        var response = await psicologos.ObtenerTodosAsync(cancellationToken);
        return Ok(response);
    }

    [HttpPut("actualizar/psicologo")]
    public async Task<ActionResult<Psicologo>> UpdatePsicologo(PsicologoDto request, CancellationToken cancellationToken)
    {
        var psicologo = request.ToDomain();
        var response = await psicologos.ActualizarAsync(psicologo, cancellationToken);
        return Ok(response);
    }

    [HttpPut("actualizar/administrador")]
    public async Task<ActionResult<Administrador>> UpdateAdministrador(AdministradorDto request, CancellationToken cancellationToken)
    {
        var administrador = request.ToDomain();
        var response = await administradores.ActualizarAsync(administrador, cancellationToken);
        return Ok(response);
    }

    [HttpPut("actualizar/recepcionista")]
    public async Task<ActionResult<Recepcionista>> UpdateRecepcionista(RecepcionistaDto request, CancellationToken cancellationToken)
    {
        var recepcionista = request.ToDomain();
        var response = await recepcionistas.ActualizarAsync(recepcionista, cancellationToken);
        return Ok(response);
    }

    [HttpPut("eliminar")]
    public async Task<ActionResult<Empleado>> Deactivate(EmpleadoIdDto request, CancellationToken cancellationToken)
    {
        var response = await empleados.EliminarEmpleadoAsync(request.ToDomain(), cancellationToken);
        return Ok(response);
    }
}
