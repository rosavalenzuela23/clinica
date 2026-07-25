namespace backend_clinica.Domain;

public class Empleado
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
