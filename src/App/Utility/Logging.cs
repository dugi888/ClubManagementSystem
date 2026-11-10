using Serilog;
using Serilog.Events;
namespace App.Utility;

public static class Logging
{
   public static int Run(Action app)
   {
      // Alive only until host builds and UseSerilog is called.
      Log.Logger = new LoggerConfiguration()
         .MinimumLevel.Debug()
         .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
         .Enrich.FromLogContext()
         .WriteTo.Console()
         .CreateLogger();

      try
      {
         Log.Information("Starting APP!");
         app();
         return 0;
      }
      catch (Exception ex) when (ex is not OperationCanceledException or HostAbortedException)
      {
         Log.Fatal(ex, "APP terminated unexpectedly!");
         return 1;
      }
      finally
      {
         Log.CloseAndFlush();
      }
      
   }
}