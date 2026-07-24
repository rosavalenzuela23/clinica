namespace backend_clinica.Domain;

public class Paciente
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
    public List<Psicologo>? Psicologos { get; set; }
    public Expediente? Expediente { get; set; }
    public CartaConcentimiento? Carta { get; set; }
}
