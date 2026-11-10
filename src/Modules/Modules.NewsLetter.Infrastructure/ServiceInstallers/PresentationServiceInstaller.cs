using Infrastructure.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Modules.NewsLetter.Infrastructure.ServiceInstallers;

internal sealed class PresentationServiceInstaller : IServiceInstaller
{
    /// inheritdoc />
    
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        Console.WriteLine("Installing Endpoints for NewsLetter Module");
         services.AddControllers()
             .AddApplicationPart(Presentation.AssemblyReference.Assembly);
    }
}