namespace backend_clinica.Domain;

public class CartaConcentimiento
{
    public long Id
    {
        get; set;
    }
    public string? RutaArchivo
    {
        get; set;
    }
    public Paciente? Paciente
    {
        get; set;
    }
}
