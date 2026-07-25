namespace backend_clinica.Domain;

public class IntegranteHogar
{
    public long Id
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
    public Expediente? Expediente
    {
        get; set;
    }
}
