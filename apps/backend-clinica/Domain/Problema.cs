namespace backend_clinica.Domain;

public class Problema
{
    public long Id
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
    public Sesion? Sesion
    {
        get; set;
    }
}
