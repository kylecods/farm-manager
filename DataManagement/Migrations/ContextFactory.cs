using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Repositories;

namespace DataManagement.Migrations
{
    public class ContextFactory : IDesignTimeDbContextFactory<FarmDbContext>
    {
        public FarmDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<FarmDbContext>();
            optionsBuilder.UseSqlServer("Data Source=(local);Initial Catalog=DataManagement;Integrated Security=True");

            return new FarmDbContext(optionsBuilder.Options);
        }
    }

}
