using Supermarket.API.Domain.Models;
using Supermarket.API.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Supermarket.API.Extensions;

namespace Supermarket.API.Mapping
{
    public class ModelToResourceProfile:Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Category, CategoryResource>();
            /*
             * This syntax tells Automapper to use the new extension method to convert our 
             * EUnitOfMeasurement value into a string containing its description
             */
            CreateMap<Product, ProductResource>()
                .ForMember(src => src.UnitOfMeasurement,
                           opt => opt.MapFrom(src => src.UnitOfMeasurement.ToDescriptionString()));
        }
    }
}
