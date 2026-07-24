namespace backend_clinica.Domain;

public class FamiliarConfianza
{
    public long Id { get; set; }
    public string? Nombre { get; set; }
    public string? Parentesco { get; set; }
    public string? Telefono { get; set; }
    public Expediente? Expediente { get; set; }
}
