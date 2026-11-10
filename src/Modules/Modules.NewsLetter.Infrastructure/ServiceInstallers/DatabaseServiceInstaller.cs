using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Modules.NewsLetter.Domain;
using Modules.NewsLetter.Persistence;
using Modules.NewsLetter.Persistence.Constants;

namespace Modules.NewsLetter.Infrastructure.ServiceInstallers;

public class DatabaseServiceInstaller : IServiceInstaller
{
    /// inheritdoc />
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<NewsLetterDbContext>(options =>
        {
            options.UseNpgsql(
                configuration.GetConnectionString("Database"),
                npgsqlOptions =>
                {
                    npgsqlOptions.MigrationsAssembly(Persistence.AssemblyReference.Assembly.GetName().Name);
                    npgsqlOptions.MigrationsHistoryTable("__EFMigrationsHistory", Schemas.NewsLetter);
                });
        });

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<NewsLetterDbContext>());
    }   
}