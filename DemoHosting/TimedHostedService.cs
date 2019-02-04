namespace DemoHosting
{
    #region Usings

    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;

    #endregion

    internal class TimedHostedService : IHostedService, IDisposable
    {
        #region Champs

        private readonly ILogger logger;

        private Timer timer;

        #endregion

        #region Constructeurs et destructeurs

        public TimedHostedService(ILogger<TimedHostedService> logger) => this.logger = logger;

        #endregion

        #region Méthodes publiques

        public void Dispose() => this.timer?.Dispose();

        public Task StartAsync(CancellationToken cancellationToken)
        {
            this.logger.LogInformation("Timed Background Service is starting.");

            this.timer = new Timer(this.DoWork, null, TimeSpan.Zero,
                                   TimeSpan.FromSeconds(5));

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            this.logger.LogInformation("Timed Background Service is stopping.");

            this.timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        #endregion

        #region Méthodes privées

        private void DoWork(object state) => this.logger.LogInformation("Timed Background Service is working.");

        #endregion
    }
}
