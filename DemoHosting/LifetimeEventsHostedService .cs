namespace DemoHosting
{
    #region Usings

    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;

    #endregion

    internal class LifetimeEventsHostedService : IHostedService
    {
        #region Champs

        private readonly IApplicationLifetime _appLifetime;

        private readonly ILogger _logger;

        #endregion

        #region Constructeurs et destructeurs

        public LifetimeEventsHostedService(ILogger<LifetimeEventsHostedService> logger, IApplicationLifetime appLifetime)
        {
            this._logger = logger;
            this._appLifetime = appLifetime;
        }

        #endregion

        #region Méthodes publiques

        public Task StartAsync(CancellationToken cancellationToken)
        {
            this._appLifetime.ApplicationStarted.Register(this.OnStarted);
            this._appLifetime.ApplicationStopping.Register(this.OnStopping);
            this._appLifetime.ApplicationStopped.Register(this.OnStopped);

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
            => Task.CompletedTask;

        #endregion

        #region Méthodes privées

        private void OnStarted()
        {
            this._logger.LogInformation("OnStarted has been called.");
        }

        private void OnStopped()
        {
            this._logger.LogInformation("OnStopped has been called.");
        }

        private void OnStopping()
        {
            this._logger.LogInformation("OnStopping has been called.");
        }

        #endregion
    }
}
