using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class FarmDbContext :DbContext
    {
        public FarmDbContext(DbContextOptions<FarmDbContext> options) :base(options)
        {
        }

        public DbSet<Factory> Factories { get; set; }

        public DbSet<Worker> Workers { get; set; }

        public DbSet<FactoryCollection> FactoryCollections { get; set; }

        public DbSet<WorkerTracker> WorkerTrackers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<FactoryCollection>()
                .Property(e => e.Weight)
                .HasPrecision(38,10);

            modelBuilder.Entity<FactoryCollection>()
                .Property(e => e.AmountPaid)
                .HasPrecision(38, 10);

            modelBuilder.Entity<WorkerTracker>()
                .Property(e => e.KiloGramsPicked)
                .HasPrecision(38, 10);


            modelBuilder.Entity<Factory>().ToTable("Factory");
            modelBuilder.Entity<Worker>().ToTable("Worker");
            modelBuilder.Entity<FactoryCollection>().ToTable("FactoryCollection");
            modelBuilder.Entity<WorkerTracker>().ToTable("WorkerTracker");
        }
    }
}
