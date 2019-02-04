using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DemoDI
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var host = new HostBuilder()
             .ConfigureServices((hostContext, services) =>
            {
                
            })
            .Build();

            await host.RunAsync();
        }
    }
}
