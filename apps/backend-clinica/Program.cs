
namespace backend_clinica;

using backend_clinica.Persistence;
using backend_clinica.Repositories;
using backend_clinica.Services;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Text.Json.Serialization;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var databaseConnection = new NpgsqlConnectionStringBuilder(
            builder.Configuration.GetConnectionString("ClinicalDatabase"));
        databaseConnection.Username = Environment.GetEnvironmentVariable("DB_USER") ?? databaseConnection.Username;
        databaseConnection.Password = Environment.GetEnvironmentVariable("DB_PASSWORD") ?? databaseConnection.Password;
        databaseConnection.Database = Environment.GetEnvironmentVariable("DB_NAME") ?? databaseConnection.Database;

        if (int.TryParse(Environment.GetEnvironmentVariable("PORT"), out var port))
        {
            builder.WebHost.UseUrls($"http://localhost:{port}");
        }

        // Add services to the container.

        builder.Services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("Frontend", policy =>
            {
                policy.WithOrigins("http://localhost:4200")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            });
        });
        builder.Services.AddDbContext<ClinicalDbContext>(options =>
            options.UseNpgsql(databaseConnection.ConnectionString));
        builder.Services.AddScoped<PacienteRepository>();
        builder.Services.AddScoped<ExpedienteRepository>();
        builder.Services.AddScoped<SesionRepository>();
        builder.Services.AddScoped<EmpleadoRepository>();
        builder.Services.AddScoped<PsicologoRepository>();
        builder.Services.AddScoped<AdministradorRepository>();
        builder.Services.AddScoped<RecepcionistaRepository>();
        builder.Services.AddScoped<CartaConsentimientoRepository>();
        builder.Services.AddScoped<NegocioPaciente>();
        builder.Services.AddScoped<NegocioExpediente>();
        builder.Services.AddScoped<NegocioSesion>();
        builder.Services.AddScoped<NegocioEmpleado>();
        builder.Services.AddScoped<NegocioPsicologo>();
        builder.Services.AddScoped<NegocioAdministrador>();
        builder.Services.AddScoped<NegocioRecepcionista>();
        builder.Services.AddScoped<NegocioFactory>();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseCors("Frontend");

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
