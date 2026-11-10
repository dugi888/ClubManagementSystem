using Infrastructure.Extensions;

namespace App.ServiceInstallers;

public class TimeProviderInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<TimeProvider>(TimeProvider.System);
    }
}