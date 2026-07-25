using Microsoft.Extensions.DependencyInjection;

namespace backend_clinica.Services;

public sealed class NegocioFactory(IServiceProvider serviceProvider)
{
    public NegocioPaciente CreatePaciente()
    {
        // Resolve scoped services from DI instead of manually constructing dependencies.
        return serviceProvider.GetRequiredService<NegocioPaciente>();
    }

    public NegocioExpediente CreateExpediente()
    {
        // Each resolved service receives the same request-scoped DbContext and repositories.
        return serviceProvider.GetRequiredService<NegocioExpediente>();
    }

    public NegocioSesion CreateSesion()
    {
        // This retains the factory entry point while allowing ASP.NET Core to manage lifetimes.
        return serviceProvider.GetRequiredService<NegocioSesion>();
    }
}
