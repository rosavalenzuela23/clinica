using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace backend_clinica.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "comentarios",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comentarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "empleados",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Usuario = table.Column<string>(type: "text", nullable: true),
                    Contrasenia = table.Column<string>(type: "text", nullable: true),
                    Estado = table.Column<bool>(type: "boolean", nullable: false),
                    rol = table.Column<string>(type: "character varying(13)", maxLength: 13, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_empleados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "examenes_1",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PuntuacionVestimenta = table.Column<byte>(type: "smallint", nullable: false),
                    PuntuacionBienestar = table.Column<byte>(type: "smallint", nullable: false),
                    PuntuacionArregloPersonal = table.Column<byte>(type: "smallint", nullable: false),
                    PuntuacionPostura = table.Column<byte>(type: "smallint", nullable: false),
                    PuntuacionContactoVisual = table.Column<byte>(type: "smallint", nullable: false),
                    PuntuacionHabla = table.Column<byte>(type: "smallint", nullable: false),
                    PuntuacionVelocidadHabla = table.Column<byte>(type: "smallint", nullable: false),
                    PuntuacionVolumenHabla = table.Column<byte>(type: "smallint", nullable: false),
                    PuntuacionArticulacion = table.Column<byte>(type: "smallint", nullable: false),
                    PuntuacionCoherencia = table.Column<byte>(type: "smallint", nullable: false),
                    PuntuacionEspontaneidad = table.Column<byte>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_examenes_1", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medicamentos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: true),
                    Descripcion = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicamentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "pacientes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TelefonoEmergencia = table.Column<string>(type: "text", nullable: true),
                    Telefono = table.Column<string>(type: "text", nullable: true),
                    Escolaridad = table.Column<string>(type: "text", nullable: true),
                    Nombre = table.Column<string>(type: "text", nullable: true),
                    ApellidoPaterno = table.Column<string>(type: "text", nullable: true),
                    ApellidoMaterno = table.Column<string>(type: "text", nullable: true),
                    EstadoCivil = table.Column<string>(type: "text", nullable: false),
                    TipoVivienda = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pacientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "respuestas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Valoracion = table.Column<string>(type: "text", nullable: true),
                    RutaArchivo = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_respuestas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "instrumentos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PsicologoId = table.Column<long>(type: "bigint", nullable: false),
                    NombreInstrumento = table.Column<string>(type: "text", nullable: true),
                    RutaArchivo = table.Column<string>(type: "text", nullable: true),
                    TextoArchivo = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_instrumentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_instrumentos_empleados_PsicologoId",
                        column: x => x.PsicologoId,
                        principalTable: "empleados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cartas_concentimiento",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PacienteId = table.Column<long>(type: "bigint", nullable: false),
                    RutaArchivo = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cartas_concentimiento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cartas_concentimiento_pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "expedientes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PacienteId = table.Column<long>(type: "bigint", nullable: false),
                    EnfermedadPrevia = table.Column<string>(type: "text", nullable: true),
                    Diagnostico = table.Column<string>(type: "text", nullable: true),
                    Antecedentes = table.Column<string>(type: "text", nullable: true),
                    PreguntaMagica = table.Column<string>(type: "text", nullable: true),
                    Deseo = table.Column<string>(type: "text", nullable: true),
                    Medicamentos = table.Column<string>(type: "text", nullable: true),
                    MotivoConsulta = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_expedientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_expedientes_pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pacientes_psicologos",
                columns: table => new
                {
                    PacientesId = table.Column<long>(type: "bigint", nullable: false),
                    PsicologosId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pacientes_psicologos", x => new { x.PacientesId, x.PsicologosId });
                    table.ForeignKey(
                        name: "FK_pacientes_psicologos_empleados_PsicologosId",
                        column: x => x.PsicologosId,
                        principalTable: "empleados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pacientes_psicologos_pacientes_PacientesId",
                        column: x => x.PacientesId,
                        principalTable: "pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "familiares_confianza",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ExpedienteId = table.Column<long>(type: "bigint", nullable: false),
                    Nombre = table.Column<string>(type: "text", nullable: true),
                    Parentesco = table.Column<string>(type: "text", nullable: true),
                    Telefono = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_familiares_confianza", x => x.Id);
                    table.ForeignKey(
                        name: "FK_familiares_confianza_expedientes_ExpedienteId",
                        column: x => x.ExpedienteId,
                        principalTable: "expedientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "integrantes_hogar",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ExpedienteId = table.Column<long>(type: "bigint", nullable: false),
                    Ocupacion = table.Column<string>(type: "text", nullable: true),
                    Nombre = table.Column<string>(type: "text", nullable: true),
                    StatusRelacion = table.Column<string>(type: "text", nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Parentesco = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_integrantes_hogar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_integrantes_hogar_expedientes_ExpedienteId",
                        column: x => x.ExpedienteId,
                        principalTable: "expedientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "medicamentos_expediente",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ExpedienteId = table.Column<long>(type: "bigint", nullable: false),
                    MedicamentoId = table.Column<long>(type: "bigint", nullable: false),
                    Dosis = table.Column<string>(type: "text", nullable: true),
                    Frecuencia = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicamentos_expediente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_medicamentos_expediente_Medicamentos_MedicamentoId",
                        column: x => x.MedicamentoId,
                        principalTable: "Medicamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_medicamentos_expediente_expedientes_ExpedienteId",
                        column: x => x.ExpedienteId,
                        principalTable: "expedientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sesiones",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ExpedienteId = table.Column<long>(type: "bigint", nullable: false),
                    PsicologoId = table.Column<long>(type: "bigint", nullable: false),
                    Fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PuntuacionVestimenta = table.Column<byte>(type: "smallint", nullable: false),
                    PuntuacionBienestar = table.Column<byte>(type: "smallint", nullable: false),
                    PuntuacionArregloPersonal = table.Column<byte>(type: "smallint", nullable: false),
                    PuntuacionPostura = table.Column<byte>(type: "smallint", nullable: false),
                    PuntuacionContactoVisual = table.Column<byte>(type: "smallint", nullable: false),
                    PuntuacionHabla = table.Column<byte>(type: "smallint", nullable: false),
                    PuntuacionVelocidadHabla = table.Column<byte>(type: "smallint", nullable: false),
                    PuntuacionVolumenHabla = table.Column<byte>(type: "smallint", nullable: false),
                    PuntuacionArticulacion = table.Column<byte>(type: "smallint", nullable: false),
                    PuntuacionCoherencia = table.Column<byte>(type: "smallint", nullable: false),
                    PuntuacionEspontaneidad = table.Column<byte>(type: "smallint", nullable: false),
                    ComentarioPsicologa = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sesiones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_sesiones_empleados_PsicologoId",
                        column: x => x.PsicologoId,
                        principalTable: "empleados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_sesiones_expedientes_ExpedienteId",
                        column: x => x.ExpedienteId,
                        principalTable: "expedientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "comentarios_sesion",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SesionId = table.Column<long>(type: "bigint", nullable: false),
                    NumeroSesion = table.Column<int>(type: "integer", nullable: false),
                    ValoracionFin = table.Column<byte>(type: "smallint", nullable: false),
                    ValoracionInicio = table.Column<byte>(type: "smallint", nullable: false),
                    AspectoAMedir = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comentarios_sesion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_comentarios_sesion_sesiones_SesionId",
                        column: x => x.SesionId,
                        principalTable: "sesiones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "problemas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SesionId = table.Column<long>(type: "bigint", nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: true),
                    Intensidad = table.Column<int>(type: "integer", nullable: false),
                    Frecuencia = table.Column<string>(type: "text", nullable: true),
                    AfectacionFamiliar = table.Column<byte>(type: "smallint", nullable: false),
                    AfectacionSalud = table.Column<byte>(type: "smallint", nullable: false),
                    AfectacionPareja = table.Column<byte>(type: "smallint", nullable: false),
                    AfectacionAmigos = table.Column<byte>(type: "smallint", nullable: false),
                    AfectacionLaboral = table.Column<byte>(type: "smallint", nullable: false),
                    AfectacionEspiritual = table.Column<byte>(type: "smallint", nullable: false),
                    AfectacionEconomico = table.Column<byte>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_problemas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_problemas_sesiones_SesionId",
                        column: x => x.SesionId,
                        principalTable: "sesiones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cartas_concentimiento_PacienteId",
                table: "cartas_concentimiento",
                column: "PacienteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_comentarios_sesion_SesionId",
                table: "comentarios_sesion",
                column: "SesionId");

            migrationBuilder.CreateIndex(
                name: "IX_empleados_Usuario",
                table: "empleados",
                column: "Usuario",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_expedientes_PacienteId",
                table: "expedientes",
                column: "PacienteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_familiares_confianza_ExpedienteId",
                table: "familiares_confianza",
                column: "ExpedienteId");

            migrationBuilder.CreateIndex(
                name: "IX_instrumentos_PsicologoId",
                table: "instrumentos",
                column: "PsicologoId");

            migrationBuilder.CreateIndex(
                name: "IX_integrantes_hogar_ExpedienteId",
                table: "integrantes_hogar",
                column: "ExpedienteId");

            migrationBuilder.CreateIndex(
                name: "IX_medicamentos_expediente_ExpedienteId",
                table: "medicamentos_expediente",
                column: "ExpedienteId");

            migrationBuilder.CreateIndex(
                name: "IX_medicamentos_expediente_MedicamentoId",
                table: "medicamentos_expediente",
                column: "MedicamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_pacientes_psicologos_PsicologosId",
                table: "pacientes_psicologos",
                column: "PsicologosId");

            migrationBuilder.CreateIndex(
                name: "IX_problemas_SesionId",
                table: "problemas",
                column: "SesionId");

            migrationBuilder.CreateIndex(
                name: "IX_sesiones_ExpedienteId",
                table: "sesiones",
                column: "ExpedienteId");

            migrationBuilder.CreateIndex(
                name: "IX_sesiones_PsicologoId",
                table: "sesiones",
                column: "PsicologoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cartas_concentimiento");

            migrationBuilder.DropTable(
                name: "comentarios");

            migrationBuilder.DropTable(
                name: "comentarios_sesion");

            migrationBuilder.DropTable(
                name: "examenes_1");

            migrationBuilder.DropTable(
                name: "familiares_confianza");

            migrationBuilder.DropTable(
                name: "instrumentos");

            migrationBuilder.DropTable(
                name: "integrantes_hogar");

            migrationBuilder.DropTable(
                name: "medicamentos_expediente");

            migrationBuilder.DropTable(
                name: "pacientes_psicologos");

            migrationBuilder.DropTable(
                name: "problemas");

            migrationBuilder.DropTable(
                name: "respuestas");

            migrationBuilder.DropTable(
                name: "Medicamentos");

            migrationBuilder.DropTable(
                name: "sesiones");

            migrationBuilder.DropTable(
                name: "empleados");

            migrationBuilder.DropTable(
                name: "expedientes");

            migrationBuilder.DropTable(
                name: "pacientes");
        }
    }
}
