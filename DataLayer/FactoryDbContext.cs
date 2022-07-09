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

        public DbSet<FactoryModel> Factories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<FactoryModel>()
                .Property(e => e.Weight)
                .HasPrecision(38,10);

            modelBuilder.Entity<FactoryModel>()
                .Property(e => e.AmountPaid)
                .HasPrecision(38, 10);


            modelBuilder.Entity<FactoryModel>().ToTable("Factory");
        }
    }

    public class FactoryHelper
    {
        public static FactoryModel GenerateNewFactoryModel(FactoryModel item)
        {
            var factory = new FactoryModel();

            factory.Id = Guid.NewGuid();
            factory.Weight = item.Weight;
            factory.FactoryName = item.FactoryName;
            factory.PaidDate = item.PaidDate;
            factory.AmountPaid = item.AmountPaid;
            factory.CreatedDate = DateTime.Now;

            return factory;
        }

        public static FactoryModel CopyFactoryModel(FactoryModel item)
        {
            return new FactoryModel()
            {
                Id = item.Id,
                Weight = item.Weight,
                FactoryName = item.FactoryName,
                PaidDate = item.PaidDate,
                AmountPaid = item.AmountPaid,
                CreatedDate = item.CreatedDate
            };
        }
    }

}
