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
        public FactoryDbContext(DbContextOptions options) :base(options)
        {
        }

        public DbSet<Factory> Factories { get; set; }

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
