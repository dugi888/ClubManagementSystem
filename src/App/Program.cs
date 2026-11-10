using App.Utility;
using Infrastructure.Extensions;
using Serilog;
    


Logging.Run(() =>
{
    WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

    builder.Services
        .InstallServicesFromAssemblies(
            builder.Configuration,
            App.AssemblyReference.Assembly,
            Persistence.AssemblyReference.Assembly)
        .InstallModulesFromAssemblies(
            builder.Configuration,
            Modules.NewsLetter.Infrastructure.AssemblyReference.Assembly
        );
 //builder.Host.UseSerilogWithConfiguration();
    builder.Services.AddSwaggerGen();

    builder.Host.UseSerilog((context, services, configuration) =>
    {
        configuration.ReadFrom
            .Configuration(context.Configuration)
            .ReadFrom.Services(services)
            .Enrich.FromLogContext()
            .WriteTo.Console();
    });

    WebApplication app = builder.Build();
    
     
 //    .UseAuthentication();
   
 if (app.Environment.IsDevelopment())
 {
     app.UseSwagger(); // Enable Swagger middleware
     app.UseSwaggerUI(); // Enable Swagger UI
 }
 
 app.UseSerilogRequestLogging()
     .UseHttpsRedirection();
 
    app.UseCors(policyBuilder =>
            policyBuilder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());


    app.MapControllers();
    app.Run();
});