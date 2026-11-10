using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions;

public interface IServiceInstaller
{
    void Install(IServiceCollection services, IConfiguration configuration);
}