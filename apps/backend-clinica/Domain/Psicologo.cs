namespace backend_clinica.Domain;

public class Psicologo : Empleado
{
    public List<Paciente>? Pacientes { get; set; }
    public List<Sesion>? Sesiones { get; set; }
}
