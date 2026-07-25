using backend_clinica.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend_clinica.Persistence;

public sealed class ClinicalDbContext(DbContextOptions<ClinicalDbContext> options) : DbContext(options)
{
    public DbSet<PacienteEntity> Pacientes => Set<PacienteEntity>();
    public DbSet<ExpedienteEntity> Expedientes => Set<ExpedienteEntity>();
    public DbSet<EmpleadoEntity> Empleados => Set<EmpleadoEntity>();
    public DbSet<SesionEntity> Sesiones => Set<SesionEntity>();
    public DbSet<ComentarioSesionEntity> ComentariosSesion => Set<ComentarioSesionEntity>();
    public DbSet<ProblemaEntity> Problemas => Set<ProblemaEntity>();
    public DbSet<IntegranteHogarEntity> IntegrantesHogar => Set<IntegranteHogarEntity>();
    public DbSet<FamiliarConfianzaEntity> FamiliaresConfianza => Set<FamiliarConfianzaEntity>();
    public DbSet<MedicamentoEntity> Medicamentos => Set<MedicamentoEntity>();
    public DbSet<MedicamentoDelExpedienteEntity> MedicamentosDelExpediente => Set<MedicamentoDelExpedienteEntity>();
    public DbSet<CartaConcentimientoEntity> CartasConcentimiento => Set<CartaConcentimientoEntity>();
    public DbSet<InstrumentoEntity> Instrumentos => Set<InstrumentoEntity>();
    public DbSet<RespuestaEntity> Respuestas => Set<RespuestaEntity>();
    public DbSet<Examen1Entity> Examenes1 => Set<Examen1Entity>();
    public DbSet<ComentarioEntity> Comentarios => Set<ComentarioEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EmpleadoEntity>().ToTable("empleados").HasDiscriminator<string>("rol").HasValue<EmpleadoEntity>("empleado").HasValue<PsicologoEntity>("psicologo").HasValue<AdministradorEntity>("administrador").HasValue<RecepcionistaEntity>("recepcionista");
        modelBuilder.Entity<EmpleadoEntity>().HasIndex(x => x.Usuario).IsUnique();
        modelBuilder.Entity<PacienteEntity>().ToTable("pacientes");
        modelBuilder.Entity<ExpedienteEntity>().ToTable("expedientes").HasOne(x => x.Paciente).WithOne(x => x.Expediente).HasForeignKey<ExpedienteEntity>(x => x.PacienteId).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<CartaConcentimientoEntity>().ToTable("cartas_concentimiento").HasOne(x => x.Paciente).WithOne(x => x.Carta).HasForeignKey<CartaConcentimientoEntity>(x => x.PacienteId).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<PacienteEntity>().HasMany(x => x.Psicologos).WithMany(x => x.Pacientes).UsingEntity("pacientes_psicologos");
        modelBuilder.Entity<SesionEntity>().ToTable("sesiones").HasOne(x => x.Expediente).WithMany(x => x.Sesiones).HasForeignKey(x => x.ExpedienteId).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<SesionEntity>().HasOne(x => x.Psicologo).WithMany(x => x.Sesiones).HasForeignKey(x => x.PsicologoId).OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<ComentarioSesionEntity>().ToTable("comentarios_sesion").HasOne(x => x.Sesion).WithMany(x => x.Comentarios).HasForeignKey(x => x.SesionId).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<ProblemaEntity>().ToTable("problemas").HasOne(x => x.Sesion).WithMany(x => x.Problemas).HasForeignKey(x => x.SesionId).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<IntegranteHogarEntity>().ToTable("integrantes_hogar").HasOne(x => x.Expediente).WithMany(x => x.IntegrantesHogar).HasForeignKey(x => x.ExpedienteId).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<FamiliarConfianzaEntity>().ToTable("familiares_confianza").HasOne(x => x.Expediente).WithMany(x => x.FamiliaresConfianza).HasForeignKey(x => x.ExpedienteId).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<MedicamentoDelExpedienteEntity>().ToTable("medicamentos_expediente").HasOne(x => x.Expediente).WithMany(x => x.MedicamentosDelExpediente).HasForeignKey(x => x.ExpedienteId).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<MedicamentoDelExpedienteEntity>().HasOne(x => x.Medicamento).WithMany(x => x.Expedientes).HasForeignKey(x => x.MedicamentoId).OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<InstrumentoEntity>().ToTable("instrumentos").HasOne(x => x.Psicologo).WithMany(x => x.Instrumentos).HasForeignKey(x => x.PsicologoId).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<RespuestaEntity>().ToTable("respuestas");
        modelBuilder.Entity<Examen1Entity>().ToTable("examenes_1");
        modelBuilder.Entity<ComentarioEntity>().ToTable("comentarios");
    }
}
