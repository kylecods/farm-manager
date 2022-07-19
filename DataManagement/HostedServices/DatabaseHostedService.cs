using System;
using System.Threading;
using System.Threading.Tasks;
using DataManagement.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Repositories;

namespace DataManagement.HostedServices
{
    public class DatabaseHostedService : IHostedService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        
        //TODO:Logs

        public DatabaseHostedService(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
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
            catch (Exception)
            {
                //TODO logger
                throw;
            }

        }

        public virtual Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(0);
        }
    }
}
