namespace backend_clinica.Domain;

public class Instrumento
{
    public long Id { get; set; }
    public string? NombreInstrumento { get; set; }
    public string? RutaArchivo { get; set; }
    public string? TextoArchivo { get; set; }
    public Psicologo? Psicologo { get; set; }
}
