namespace backend_clinica.Domain;

public class Medicamento
{
    public long Id { get; set; }
    public string? Nombre { get; set; }
    public string? Descripcion { get; set; }
    public List<MedicamentoDelExpediente>? Expedientes { get; set; }
}
