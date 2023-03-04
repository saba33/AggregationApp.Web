using AggregationApp.Data.Models;
using AggregationApp.Services.ServiceModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AggregationApp.Services.Helper
{
    public class MappingInitializer : Profile
    {
        public MappingInitializer()
        {
            CreateMap<ElecticCityServiceModel, ElectricCityModel>().ReverseMap();
            CreateMap<ElectricInsertDataModel, ElectricCityModel>().ReverseMap();
        }
    }
}
