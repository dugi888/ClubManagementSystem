using Infrastructure.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Modules.NewsLetter.Infrastructure.ServiceInstallers;

public class MediatrServiceInstaller : IServiceInstaller
{

    /// inheritdoc />
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        Console.WriteLine("Installing MediatR for NewsLetter Module");
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Modules.NewsLetter.Application.AssemblyReference.Assembly));
    }
}