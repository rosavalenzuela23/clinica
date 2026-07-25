namespace backend_clinica.Domain;

public class ComentarioSesion
{
    public long Id
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
    public Sesion? Sesion
    {
        get; set;
    }
}
