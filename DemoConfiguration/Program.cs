namespace DemoConfiguration
{
    #region Usings

    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;

    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    #endregion

    internal static class Program
    {
        #region Champs et constantes statiques

        public static Dictionary<string, string> arrayDict = new Dictionary<string, string>
        {
            { "0", "value0" },
            { "1", "value1" },
            { "2", "value2" },
            { "4", "value4" },
            { "5", "value5" }
        };

        #endregion

        #region Méthodes privées

        private static async Task Main(string[] args)
        {
            var host = new HostBuilder()
                       .ConfigureHostConfiguration(configHost =>
                       {
                           configHost.SetBasePath(Directory.GetCurrentDirectory());
                           configHost.AddJsonFile("hostsettings.json", true);
                           configHost.AddEnvironmentVariables("PREFIX_");
                           configHost.AddCommandLine(args);
                       })
                       .ConfigureAppConfiguration((hostContext, configApp) =>
                       {
                           configApp.SetBasePath(Directory.GetCurrentDirectory());
                           configApp.AddInMemoryCollection(arrayDict);
                           configApp.AddJsonFile("appsettings.json", true);
                           configApp.AddJsonFile(
                               $"appsettings.{hostContext.HostingEnvironment.EnvironmentName}.json",
                               true);
                           configApp.AddEnvironmentVariables("PREFIX_");
                           configApp.AddCommandLine(args);
                       })
                       .Build();

            var sections = host.Services.GetService<IConfiguration>().GetChildren();

            await host.RunAsync();
        }

        #endregion
    }
}
