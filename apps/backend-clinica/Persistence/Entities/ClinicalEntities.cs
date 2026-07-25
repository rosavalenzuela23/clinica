namespace backend_clinica.Persistence.Entities;

public class PacienteEntity
{
    public long Id
    {
        get; set;
    }
    public DateTime Fecha
    {
        get; set;
    }
    public string? TelefonoEmergencia
    {
        get; set;
    }
    public string? Telefono
    {
        get; set;
    }
    public string? Escolaridad
    {
        get; set;
    }
    public string? Nombre
    {
        get; set;
    }
    public string? ApellidoPaterno
    {
        get; set;
    }
    public string? ApellidoMaterno
    {
        get; set;
    }
    public string EstadoCivil { get; set; } = null!;
    public string TipoVivienda { get; set; } = null!;
    public ExpedienteEntity? Expediente
    {
        get; set;
    }
    public CartaConcentimientoEntity? Carta
    {
        get; set;
    }
    public ICollection<PsicologoEntity> Psicologos { get; set; } = new List<PsicologoEntity>();
}

public class ExpedienteEntity
{
    public long Id
    {
        get; set;
    }
    public long PacienteId
    {
        get; set;
    }
    public string? EnfermedadPrevia
    {
        get; set;
    }
    public string? Diagnostico
    {
        get; set;
    }
    public string? Antecedentes
    {
        get; set;
    }
    public string? PreguntaMagica
    {
        get; set;
    }
    public string? Deseo
    {
        get; set;
    }
    public string? Medicamentos
    {
        get; set;
    }
    public string? MotivoConsulta
    {
        get; set;
    }
    public PacienteEntity Paciente { get; set; } = null!;
    public ICollection<IntegranteHogarEntity> IntegrantesHogar { get; set; } = new List<IntegranteHogarEntity>();
    public ICollection<FamiliarConfianzaEntity> FamiliaresConfianza { get; set; } = new List<FamiliarConfianzaEntity>();
    public ICollection<SesionEntity> Sesiones { get; set; } = new List<SesionEntity>();
    public ICollection<MedicamentoDelExpedienteEntity> MedicamentosDelExpediente { get; set; } = new List<MedicamentoDelExpedienteEntity>();
}

public class EmpleadoEntity
{
    public long Id
    {
        get; set;
    }
    public string? Usuario
    {
        get; set;
    }
    public string? Contrasenia
    {
        get; set;
    }
    public bool Estado
    {
        get; set;
    }
}

public sealed class PsicologoEntity : EmpleadoEntity
{
    public ICollection<PacienteEntity> Pacientes { get; set; } = new List<PacienteEntity>();
    public ICollection<SesionEntity> Sesiones { get; set; } = new List<SesionEntity>();
    public ICollection<InstrumentoEntity> Instrumentos { get; set; } = new List<InstrumentoEntity>();
}

public sealed class AdministradorEntity : EmpleadoEntity
{
}
public sealed class RecepcionistaEntity : EmpleadoEntity
{
}

public class SesionEntity
{
    public long Id
    {
        get; set;
    }
    public long ExpedienteId
    {
        get; set;
    }
    public long PsicologoId
    {
        get; set;
    }
    public DateTime Fecha
    {
        get; set;
    }
    public byte PuntuacionVestimenta
    {
        get; set;
    }
    public byte PuntuacionBienestar
    {
        get; set;
    }
    public byte PuntuacionArregloPersonal
    {
        get; set;
    }
    public byte PuntuacionPostura
    {
        get; set;
    }
    public byte PuntuacionContactoVisual
    {
        get; set;
    }
    public byte PuntuacionHabla
    {
        get; set;
    }
    public byte PuntuacionVelocidadHabla
    {
        get; set;
    }
    public byte PuntuacionVolumenHabla
    {
        get; set;
    }
    public byte PuntuacionArticulacion
    {
        get; set;
    }
    public byte PuntuacionCoherencia
    {
        get; set;
    }
    public byte PuntuacionEspontaneidad
    {
        get; set;
    }
    public string? ComentarioPsicologa
    {
        get; set;
    }
    public ExpedienteEntity Expediente { get; set; } = null!;
    public PsicologoEntity Psicologo { get; set; } = null!;
    public ICollection<ComentarioSesionEntity> Comentarios { get; set; } = new List<ComentarioSesionEntity>();
    public ICollection<ProblemaEntity> Problemas { get; set; } = new List<ProblemaEntity>();
}

public class ComentarioSesionEntity
{
    public long Id
    {
        get; set;
    }
    public long SesionId
    {
        get; set;
    }
    public int NumeroSesion
    {
        get; set;
    }
    public byte ValoracionFin
    {
        get; set;
    }
    public byte ValoracionInicio
    {
        get; set;
    }
    public string? AspectoAMedir
    {
        get; set;
    }
    public SesionEntity Sesion { get; set; } = null!;
}
public class ProblemaEntity
{
    public long Id
    {
        get; set;
    }
    public long SesionId
    {
        get; set;
    }
    public string? Descripcion
    {
        get; set;
    }
    public int Intensidad
    {
        get; set;
    }
    public string? Frecuencia
    {
        get; set;
    }
    public byte AfectacionFamiliar
    {
        get; set;
    }
    public byte AfectacionSalud
    {
        get; set;
    }
    public byte AfectacionPareja
    {
        get; set;
    }
    public byte AfectacionAmigos
    {
        get; set;
    }
    public byte AfectacionLaboral
    {
        get; set;
    }
    public byte AfectacionEspiritual
    {
        get; set;
    }
    public byte AfectacionEconomico
    {
        get; set;
    }
    public SesionEntity Sesion { get; set; } = null!;
}
public class IntegranteHogarEntity
{
    public long Id
    {
        get; set;
    }
    public long ExpedienteId
    {
        get; set;
    }
    public string? Ocupacion
    {
        get; set;
    }
    public string? Nombre
    {
        get; set;
    }
    public string? StatusRelacion
    {
        get; set;
    }
    public DateTime FechaNacimiento
    {
        get; set;
    }
    public string? Parentesco
    {
        get; set;
    }
    public ExpedienteEntity Expediente { get; set; } = null!;
}
public class FamiliarConfianzaEntity
{
    public long Id
    {
        get; set;
    }
    public long ExpedienteId
    {
        get; set;
    }
    public string? Nombre
    {
        get; set;
    }
    public string? Parentesco
    {
        get; set;
    }
    public string? Telefono
    {
        get; set;
    }
    public ExpedienteEntity Expediente { get; set; } = null!;
}
public class MedicamentoEntity
{
    public long Id
    {
        get; set;
    }
    public string? Nombre
    {
        get; set;
    }
    public string? Descripcion
    {
        get; set;
    }
    public ICollection<MedicamentoDelExpedienteEntity> Expedientes { get; set; } = new List<MedicamentoDelExpedienteEntity>();
}
public class MedicamentoDelExpedienteEntity
{
    public long Id
    {
        get; set;
    }
    public long ExpedienteId
    {
        get; set;
    }
    public long MedicamentoId
    {
        get; set;
    }
    public string? Dosis
    {
        get; set;
    }
    public string? Frecuencia
    {
        get; set;
    }
    public ExpedienteEntity Expediente { get; set; } = null!; public MedicamentoEntity Medicamento { get; set; } = null!;
}
public class CartaConcentimientoEntity
{
    public long Id
    {
        get; set;
    }
    public long PacienteId
    {
        get; set;
    }
    public string? RutaArchivo
    {
        get; set;
    }
    public PacienteEntity Paciente { get; set; } = null!;
}
public class InstrumentoEntity
{
    public long Id
    {
        get; set;
    }
    public long PsicologoId
    {
        get; set;
    }
    public string? NombreInstrumento
    {
        get; set;
    }
    public string? RutaArchivo
    {
        get; set;
    }
    public string? TextoArchivo
    {
        get; set;
    }
    public PsicologoEntity Psicologo { get; set; } = null!;
}
public class RespuestaEntity
{
    public long Id
    {
        get; set;
    }
    public string? Valoracion
    {
        get; set;
    }
    public string? RutaArchivo
    {
        get; set;
    }
}
public class Examen1Entity
{
    public long Id
    {
        get; set;
    }
    public byte PuntuacionVestimenta
    {
        get; set;
    }
    public byte PuntuacionBienestar
    {
        get; set;
    }
    public byte PuntuacionArregloPersonal
    {
        get; set;
    }
    public byte PuntuacionPostura
    {
        get; set;
    }
    public byte PuntuacionContactoVisual
    {
        get; set;
    }
    public byte PuntuacionHabla
    {
        get; set;
    }
    public byte PuntuacionVelocidadHabla
    {
        get; set;
    }
    public byte PuntuacionVolumenHabla
    {
        get; set;
    }
    public byte PuntuacionArticulacion
    {
        get; set;
    }
    public byte PuntuacionCoherencia
    {
        get; set;
    }
    public byte PuntuacionEspontaneidad
    {
        get; set;
    }
}
public class ComentarioEntity
{
    public long Id
    {
        get; set;
    }
}
