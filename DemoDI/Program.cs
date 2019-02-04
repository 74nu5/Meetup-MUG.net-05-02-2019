namespace DemoDI
{
    #region Usings

    using System.Threading.Tasks;

    using Microsoft.Extensions.Hosting;

    #endregion

    internal class Program
    {
        #region Méthodes privées

        private static async Task Main(string[] args)
        {
            var host = new HostBuilder()
                       .ConfigureServices((hostContext, services) => { })
                       .Build();

            await host.RunAsync();
        }

        #endregion
    }
}
