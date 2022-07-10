using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Entities;
using Entities.Models;

namespace Repositories.Mappers
{
    public class FactoryCollectionMapper : Profile
    {
        public FactoryCollectionMapper()
        {
            CreateMap<FactoryCollection, FactoryCollectionModel>();
        }

        public static FactoryCollection CreateFactory(FactoryCollectionModel model)
        {
            var factoryCollection = new FactoryCollection();

            factoryCollection.SetNewId();

            factoryCollection.FactoryId = model.FactoryId;

            factoryCollection.AmountPaid = model.AmountPaid;

            factoryCollection.PaidDate = model.PaidDate;

            factoryCollection.CreatedDate = DateTime.Now;

            return factoryCollection;
        }
    }
}
