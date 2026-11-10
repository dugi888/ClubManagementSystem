using System.Reflection;
using Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions;

public static class InstallerExtensions
{
    public static IServiceCollection InstallServicesFromAssemblies(
        this IServiceCollection services,
        IConfiguration configuration,
        params Assembly[] assemblies) =>
        Run<IServiceInstaller>(
            services,
            assemblies,
            installer => installer.Install(services, configuration));

    public static IServiceCollection InstallModulesFromAssemblies(
        this IServiceCollection services,
        IConfiguration configuration,
        params Assembly[] assemblies) =>
        Run<IModuleInstaller>(
            services,
            assemblies,
            installer => installer.Install(services, configuration));

    private static IServiceCollection Run<T>(
        IServiceCollection services,
        Assembly[] assemblies,
        Action<T> action)
    {
        var installers = assemblies
            .SelectMany(a => a.DefinedTypes)
            .Where(t => typeof(T).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
            .Select(t => (T)Activator.CreateInstance(t)!);

        foreach (var installer in installers)
            action(installer);

        return services;
    }
}