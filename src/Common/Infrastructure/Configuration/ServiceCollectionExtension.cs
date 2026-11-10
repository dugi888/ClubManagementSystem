

using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure;

namespace Infrastructure.Configuration;

public static class ServiceCollectionExtensions
{
    // 1. Transient Registration
    public static IServiceCollection AddTransientAsMatchingInterface(
        this IServiceCollection services, 
        Assembly assembly)
    {
        return services.AddServicesAsMatchingInterface(assembly, ServiceLifetime.Transient);
    }

    // 2. Scoped Registration
    public static IServiceCollection AddScopedAsMatchingInterface(
        this IServiceCollection services, 
        Assembly assembly)
    {
        return services.AddServicesAsMatchingInterface(assembly, ServiceLifetime.Scoped);
    }

    // 3. The Shared Logic (Private)
    private static IServiceCollection AddServicesAsMatchingInterface(
        this IServiceCollection services,
        Assembly assembly,
        ServiceLifetime lifetime)
    {
        // Get all public, non-abstract classes
        var implementationTypes = assembly.GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract && !t.IsGenericTypeDefinition);

        foreach (var implementationType in implementationTypes)
        {
            // We look for an interface where the name is "I" + className (e.g., NewsLetterService -> INewsLetterService)
            var interfaceType = implementationType.GetInterfaces()
                .FirstOrDefault(i => i.Name == $"I{implementationType.Name}");

            if (interfaceType != null)
            {
                // Register the service based on the specified lifetime
                services.Add(new ServiceDescriptor(interfaceType, implementationType, lifetime));
            }
        }

        return services;
    }
}