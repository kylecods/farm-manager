using System;
using System.Threading;
using System.Threading.Tasks;
using DataManagement.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Repositories;
using Microsoft.Extensions.Logging;

namespace DataManagement.HostedServices
{
    public class DatabaseHostedService : IHostedService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        private readonly ILogger<DatabaseHostedService> _logger;
        public DatabaseHostedService(IServiceScopeFactory serviceScopeFactory,ILogger<DatabaseHostedService> logger)
        {
            _serviceScopeFactory = serviceScopeFactory;

            _logger = logger;
        }

        public virtual async Task StartAsync(CancellationToken cancellationToken)
        {
            using var scope = _serviceScopeFactory.CreateScope();

            var databaseContext = scope.ServiceProvider.GetRequiredService<FarmDbContext>();
            var identityDbContext = scope.ServiceProvider.GetRequiredService<DataManagementContext>();

            await Task.Delay(1000, cancellationToken);

            try
            {
                await databaseContext.Database.MigrateAsync(cancellationToken);

                await identityDbContext.Database.MigrateAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError("Database failed to migrate", ex);
                throw;
            }

        }

        public virtual Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(0);
        }
    }
}
