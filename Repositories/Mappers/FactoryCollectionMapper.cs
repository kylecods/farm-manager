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

        public static FactoryCollection CreateFactoryCollection(FactoryCollectionModel model)
        {
            var factoryCollection = new FactoryCollection();

            factoryCollection.SetNewId();

            factoryCollection.FactoryId = model.FactoryId;

            factoryCollection.Weight = model.Weight;

            factoryCollection.AmountPaid = model.AmountPaid;

            factoryCollection.PaidDate = model.PaidDate;

            factoryCollection.CreatedDate = DateTime.Now;

            return factoryCollection;
        }
    }
}
