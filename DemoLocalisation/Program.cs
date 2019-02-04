namespace DemoLocalisation
{
    #region Usings

    using System;
    using System.Threading.Tasks;

    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Localization;

    #endregion

    internal class Program
    {
        #region Méthodes privées

        private static async Task Main(string[] args)
        {
            //Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");

            var host = new HostBuilder()
                       .ConfigureServices((hostContext, services) => { services.AddLocalization(options => options.ResourcesPath = "Resources"); })
                       .Build();

            var locator = host.Services.GetService<IStringLocalizer<Program>>();

            var listStr = locator.GetAllStrings();

            foreach (var s in listStr)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine(locator["Bonjour"]);

            await host.RunAsync();
        }

        #endregion
    }
}
