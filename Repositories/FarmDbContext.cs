using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class FarmDbContext : DbContext
    {
        public FarmDbContext(DbContextOptions<FarmDbContext> options) : base(options)
        {
        }

        public DbSet<Factory> Factories { get; set; }

        public DbSet<Worker> Workers { get; set; }

        public DbSet<FactoryCollection> FactoryCollections { get; set; }

        public DbSet<WorkerTracker> WorkerTrackers { get; set; }

        public DbSet<Accounts> Accounts { get; set; }

        public DbSet<Register> Registers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<FactoryCollection>()
                .Property(e => e.Weight)
                .HasPrecision(38, 10);

            modelBuilder.Entity<FactoryCollection>()
                .Property(e => e.AmountPaid)
                .HasPrecision(38, 10);

            modelBuilder.Entity<WorkerTracker>()
                .Property(e => e.KiloGramsPicked)
                .HasPrecision(38, 10);
            
            modelBuilder.Entity<WorkerTracker>()
                .Property(e => e.AmountPaid)
                .HasPrecision(38, 10);

            modelBuilder.Entity<Register>()
                .Property(e => e.Amount)
                .HasPrecision(38, 10);

            modelBuilder.Entity<Accounts>()
                .Property(e => e.StartAmount)
                .HasPrecision(38, 10);

            modelBuilder.Entity<Factory>().ToTable("Factory");
            modelBuilder.Entity<Worker>().ToTable("Worker");
            modelBuilder.Entity<FactoryCollection>().ToTable("FactoryCollection");
            modelBuilder.Entity<WorkerTracker>().ToTable("WorkerTracker");
            modelBuilder.Entity<Accounts>().ToTable("Accounts");
            modelBuilder.Entity<Register>().ToTable("Register");
        }
    }
}
