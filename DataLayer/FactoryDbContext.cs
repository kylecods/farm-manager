using DomainLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class FactoryDbContext :DbContext
    {
        public FactoryDbContext(DbContextOptions<FactoryDbContext> options) :base(options)
        {
        }

        public DbSet<Factory> Factories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Factory>()
                .Property(e => e.Weight)
                .HasPrecision(38,10);

            modelBuilder.Entity<Factory>()
                .Property(e => e.AmountPaid)
                .HasPrecision(38, 10);


            modelBuilder.Entity<Factory>().ToTable(nameof(Factory));
        }
    }

    public class Factory : FactoryModel
    {
        public Factory() { }

        public Factory(FactoryModel model)
        {
            Load(model);
        }

        public void Load(FactoryModel model)
        {
            Id = model.Id;
            FactoryName = model.FactoryName;
            AmountPaid = model.AmountPaid;
            Weight = model.Weight;
            PaidDate = model.PaidDate;
            CreatedDate = model.CreatedDate;
        }

        public Factory ToFactory()
        {
            return new Factory
            {
                Id = Id,
                FactoryName = FactoryName,
                AmountPaid = AmountPaid,
                Weight = Weight,
                PaidDate = PaidDate,
                CreatedDate = CreatedDate
            };
        }
    }
}
