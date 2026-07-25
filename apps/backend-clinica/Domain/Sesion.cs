namespace backend_clinica.Domain;

public class Sesion
{
    public long Id
    {
        get; set;
    }
    public List<ComentarioSesion>? Comentarios
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
    public List<Problema>? ProblemasSesion
    {
        get; set;
    }
    public Expediente? Expediente
    {
        get; set;
    }
    public Psicologo? Psicologo
    {
        get; set;
    }
}
