namespace backend_clinica.Domain;

public class Expediente
{
    public long Id { get; set; }
    public string? EnfermedadPrevia { get; set; }
    public string? Diagnostico { get; set; }
    public string? Antecedentes { get; set; }
    public string? PreguntaMagica { get; set; }
    public string? Deseo { get; set; }
    public string? Medicamentos { get; set; }
    public List<IntegranteHogar>? IntegranteHogar { get; set; }
    public List<FamiliarConfianza>? FamiliaresConfianza { get; set; }
    public string? MotivoConsulta { get; set; }
    public Paciente? Paciente { get; set; }
}
