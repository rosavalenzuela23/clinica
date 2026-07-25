using backend_clinica.Domain;
using Microsoft.AspNetCore.Http;

namespace backend_clinica.Dtos;

public class PacienteDto
{
    public long Id { get; set; }
    public DateTime Fecha { get; set; }
    public string? TelefonoEmergencia { get; set; }
    public string? Telefono { get; set; }
    public string? Escolaridad { get; set; }
    public string? Nombre { get; set; }
    public string? ApellidoPaterno { get; set; }
    public string? ApellidoMaterno { get; set; }
    public EstadoCivil EstadoCivil { get; set; }
    public TipoVivienda TipoVivienda { get; set; }
}

public class ExpedienteDto
{
    public long Id { get; set; }
    public string? EnfermedadPrevia { get; set; }
    public string? Diagnostico { get; set; }
    public string? Antecedentes { get; set; }
    public string? PreguntaMagica { get; set; }
    public string? Deseo { get; set; }
    public string? Medicamentos { get; set; }
    public string? MotivoConsulta { get; set; }
    public List<IntegranteHogarDto>? IntegranteHogar { get; set; }
    public List<FamiliarConfianzaDto>? FamiliaresConfianza { get; set; }
}

public class IntegranteHogarDto
{
    public long Id { get; set; }
    public string? Ocupacion { get; set; }
    public string? Nombre { get; set; }
    public string? StatusRelacion { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public string? Parentesco { get; set; }
}

public class FamiliarConfianzaDto
{
    public long Id { get; set; }
    public string? Nombre { get; set; }
    public string? Parentesco { get; set; }
    public string? Telefono { get; set; }
}

public class SesionDto
{
    public long Id { get; set; }
    public DateTime Fecha { get; set; }
    public byte PuntuacionVestimenta { get; set; }
    public byte PuntuacionBienestar { get; set; }
    public byte PuntuacionArregloPersonal { get; set; }
    public byte PuntuacionPostura { get; set; }
    public byte PuntuacionContactoVisual { get; set; }
    public byte PuntuacionHabla { get; set; }
    public byte PuntuacionVelocidadHabla { get; set; }
    public byte PuntuacionVolumenHabla { get; set; }
    public byte PuntuacionArticulacion { get; set; }
    public byte PuntuacionCoherencia { get; set; }
    public byte PuntuacionEspontaneidad { get; set; }
    public string? ComentarioPsicologa { get; set; }
    public List<ComentarioSesionDto>? Comentarios { get; set; }
    public List<ProblemaDto>? ProblemasSesion { get; set; }
}

public class ComentarioSesionDto
{
    public long Id { get; set; }
    public int NumeroSesion { get; set; }
    public byte ValoracionFin { get; set; }
    public byte ValoracionInicio { get; set; }
    public string? AspectoAMedir { get; set; }
}

public class ProblemaDto
{
    public long Id { get; set; }
    public string? Descripcion { get; set; }
    public int Intensidad { get; set; }
    public string? Frecuencia { get; set; }
    public byte AfectacionFamiliar { get; set; }
    public byte AfectacionSalud { get; set; }
    public byte AfectacionPareja { get; set; }
    public byte AfectacionAmigos { get; set; }
    public byte AfectacionLaboral { get; set; }
    public byte AfectacionEspiritual { get; set; }
    public byte AfectacionEconomico { get; set; }
}

public class EmpleadoDto
{
    public long Id { get; set; }
    public string? Usuario { get; set; }
    public string? Contrasenia { get; set; }
    public bool Estado { get; set; }
}

public sealed class PsicologoDto : EmpleadoDto { }
public sealed class AdministradorDto : EmpleadoDto { }
public sealed class RecepcionistaDto : EmpleadoDto { }

public class EmployeeLoginDto
{
    public string Usuario { get; set; } = null!;
    public string Contrasenia { get; set; } = null!;
}

public class EmpleadoIdDto
{
    public long Id { get; set; }
}

public class ConsentimientoUploadDto
{
    public long PacienteId { get; set; }
    public IFormFile Archivo { get; set; } = null!;
}

public class ExpedienteRegistrationDto
{
    public PacienteDto Paciente { get; set; } = null!;
    public ExpedienteDto Expediente { get; set; } = null!;
    public long PsicologoId { get; set; }
}

public class ExpedienteUpdateDto
{
    public PacienteDto Paciente { get; set; } = null!;
    public ExpedienteDto Expediente { get; set; } = null!;
}

public class SesionRegistrationDto
{
    public SesionDto Sesion { get; set; } = null!;
    public long ExpedienteId { get; set; }
    public long PsicologoId { get; set; }
}
