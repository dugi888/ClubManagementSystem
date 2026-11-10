using Infrastructure.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Modules.NewsLetter.Infrastructure.ServiceInstallers;

internal sealed class EndpointServiceInstaller : IServiceInstaller
{
    /// inheritdoc />
    
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        Console.WriteLine("Installing Endpoints for NewsLetter Module");
        //throw new NotImplementedException();
         services.AddControllers();
             //.AddApplicationPart(Endpoints.AssemblyReference.Assembly);
    }
}