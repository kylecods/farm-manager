using DataManagement.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;
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

            var maxMigrationAttempts = 10;

            for(var i = 1; i<= maxMigrationAttempts; i++)
            {
                try {
                    databaseContext.Database.Migrate();
                    identityDbContext.Database.Migrate();
                    break;
                }catch(Exception e)
                {
                    //TODO logger
                    throw;
                }
            }
            
        }

        public virtual Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(0);
        }
    }
}
