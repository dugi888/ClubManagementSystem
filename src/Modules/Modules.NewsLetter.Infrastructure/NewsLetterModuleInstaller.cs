
using Infrastructure.Configuration;
using Infrastructure.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Modules.NewsLetter.Infrastructure;
using Modules.NewsLetter.Infrastructure;

namespace Modules.NewsLetter.Infrastructure;

/// <summary>
/// Represents the users module installer.
/// </summary>
public sealed class NewsLetterModuleInstaller : IModuleInstaller
{
    /// <inheritdoc />
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        // Log.Information("Installing NewsLetter Module");
        Console.WriteLine("Installing NewsLetter Module");
        services
            .InstallServicesFromAssemblies(configuration, AssemblyReference.Assembly)
            .AddTransientAsMatchingInterface(AssemblyReference.Assembly)
            .AddTransientAsMatchingInterface(Persistence.AssemblyReference.Assembly)
            .AddScopedAsMatchingInterface(AssemblyReference.Assembly)
            .AddScopedAsMatchingInterface(Persistence.AssemblyReference.Assembly);
    }
}