using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DemoHosting
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var host = new HostBuilder()
             .ConfigureServices((hostContext, services) =>
            {
                #region Spoil

                if (hostContext.HostingEnvironment.IsDevelopment())
                {
                    // Development service configuration
                }
                else
                {
                    // Non-development service configuration
                }

                #endregion

            })
            .Build();

            await host.RunAsync();
        }
    }
}
