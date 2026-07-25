namespace backend_clinica.Domain;

public class MedicamentoDelExpediente
{
    public object? Id
    {
        get; set;
    }
    public Expediente? Expediente
    {
        get; set;
    }
    public Medicamento? Medicamento
    {
        get; set;
    }
    public string? Dosis
    {
        get; set;
    }
    public string? Frecuencia
    {
        get; set;
    }
}
