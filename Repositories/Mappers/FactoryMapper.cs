using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Entities.Models;
using AutoMapper;

namespace Repositories.Mappers
{
    public class FactoryMapper : Profile
    {
        public FactoryMapper()
        {
            CreateMap<Factory, FactoryModel>();
        }

        public static Factory CreateFactory(FactoryModel model)
        {
            var factory = new Factory();
            
            factory.SetNewId();

            factory.FactoryName = model.FactoryName;

            factory.PhoneNumber = model.PhoneNumber;

            factory.Location = model.Location;

            factory.CreatedDate = DateTime.Now;

            return factory;
        }
    }
}
