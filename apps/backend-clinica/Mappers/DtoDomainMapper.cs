using backend_clinica.Domain;
using backend_clinica.Dtos;

namespace backend_clinica.Mappers;

public static class DtoDomainMapper
{
    public static Paciente ToDomain(this PacienteDto source)
    {
        return new Paciente
        {
            Id = source.Id,
            Fecha = source.Fecha,
            TelefonoEmergencia = source.TelefonoEmergencia,
            Telefono = source.Telefono,
            Escolaridad = source.Escolaridad,
            Nombre = source.Nombre,
            ApellidoPaterno = source.ApellidoPaterno,
            ApellidoMaterno = source.ApellidoMaterno,
            EstadoCivil = source.EstadoCivil,
            TipoVivienda = source.TipoVivienda
        };
    }

    public static Expediente ToDomain(this ExpedienteDto source)
    {
        return new Expediente
        {
            Id = source.Id,
            EnfermedadPrevia = source.EnfermedadPrevia,
            Diagnostico = source.Diagnostico,
            Antecedentes = source.Antecedentes,
            PreguntaMagica = source.PreguntaMagica,
            Deseo = source.Deseo,
            Medicamentos = source.Medicamentos,
            MotivoConsulta = source.MotivoConsulta,
            IntegranteHogar = source.IntegranteHogar?.Select(item => item.ToDomain()).ToList(),
            FamiliaresConfianza = source.FamiliaresConfianza?.Select(item => item.ToDomain()).ToList()
        };
    }

    public static IntegranteHogar ToDomain(this IntegranteHogarDto source)
    {
        return new IntegranteHogar
        {
            Id = source.Id,
            Ocupacion = source.Ocupacion,
            Nombre = source.Nombre,
            StatusRelacion = source.StatusRelacion,
            FechaNacimiento = source.FechaNacimiento,
            Parentesco = source.Parentesco
        };
    }

    public static FamiliarConfianza ToDomain(this FamiliarConfianzaDto source)
    {
        return new FamiliarConfianza
        {
            Id = source.Id,
            Nombre = source.Nombre,
            Parentesco = source.Parentesco,
            Telefono = source.Telefono
        };
    }

    public static Sesion ToDomain(this SesionDto source)
    {
        return new Sesion
        {
            Id = source.Id,
            Fecha = source.Fecha,
            PuntuacionVestimenta = source.PuntuacionVestimenta,
            PuntuacionBienestar = source.PuntuacionBienestar,
            PuntuacionArregloPersonal = source.PuntuacionArregloPersonal,
            PuntuacionPostura = source.PuntuacionPostura,
            PuntuacionContactoVisual = source.PuntuacionContactoVisual,
            PuntuacionHabla = source.PuntuacionHabla,
            PuntuacionVelocidadHabla = source.PuntuacionVelocidadHabla,
            PuntuacionVolumenHabla = source.PuntuacionVolumenHabla,
            PuntuacionArticulacion = source.PuntuacionArticulacion,
            PuntuacionCoherencia = source.PuntuacionCoherencia,
            PuntuacionEspontaneidad = source.PuntuacionEspontaneidad,
            ComentarioPsicologa = source.ComentarioPsicologa,
            Comentarios = source.Comentarios?.Select(item => item.ToDomain()).ToList(),
            ProblemasSesion = source.ProblemasSesion?.Select(item => item.ToDomain()).ToList()
        };
    }

    public static ComentarioSesion ToDomain(this ComentarioSesionDto source)
    {
        return new ComentarioSesion
        {
            Id = source.Id,
            NumeroSesion = source.NumeroSesion,
            ValoracionFin = source.ValoracionFin,
            ValoracionInicio = source.ValoracionInicio,
            AspectoAMedir = source.AspectoAMedir
        };
    }

    public static Problema ToDomain(this ProblemaDto source)
    {
        return new Problema
        {
            Id = source.Id,
            Descripcion = source.Descripcion,
            Intensidad = source.Intensidad,
            Frecuencia = source.Frecuencia,
            AfectacionFamiliar = source.AfectacionFamiliar,
            AfectacionSalud = source.AfectacionSalud,
            AfectacionPareja = source.AfectacionPareja,
            AfectacionAmigos = source.AfectacionAmigos,
            AfectacionLaboral = source.AfectacionLaboral,
            AfectacionEspiritual = source.AfectacionEspiritual,
            AfectacionEconomico = source.AfectacionEconomico
        };
    }

    public static Empleado ToDomain(this EmpleadoDto source)
    {
        return new Empleado
        {
            Id = source.Id,
            Usuario = source.Usuario,
            Contrasenia = source.Contrasenia,
            Estado = source.Estado
        };
    }

    public static Psicologo ToDomain(this PsicologoDto source)
    {
        return new Psicologo
        {
            Id = source.Id,
            Usuario = source.Usuario,
            Contrasenia = source.Contrasenia,
            Estado = source.Estado
        };
    }

    public static Administrador ToDomain(this AdministradorDto source)
    {
        return new Administrador
        {
            Id = source.Id,
            Usuario = source.Usuario,
            Contrasenia = source.Contrasenia,
            Estado = source.Estado
        };
    }

    public static Recepcionista ToDomain(this RecepcionistaDto source)
    {
        return new Recepcionista
        {
            Id = source.Id,
            Usuario = source.Usuario,
            Contrasenia = source.Contrasenia,
            Estado = source.Estado
        };
    }

    public static Empleado ToDomain(this EmployeeLoginDto source)
    {
        return new Empleado
        {
            Usuario = source.Usuario,
            Contrasenia = source.Contrasenia
        };
    }

    public static Empleado ToDomain(this EmpleadoIdDto source)
    {
        return new Empleado { Id = source.Id };
    }

    public static CartaConcentimiento ToDomain(this ConsentimientoUploadDto source, string rutaArchivo)
    {
        return new CartaConcentimiento { RutaArchivo = rutaArchivo };
    }
}
