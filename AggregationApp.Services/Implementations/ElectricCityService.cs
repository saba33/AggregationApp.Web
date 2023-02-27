using AggregationApp.Data.Models;
using AggregationApp.Repository.Abstractions;
using AggregationApp.Repository.Implementations;
using AggregationApp.Services.Abstractions;
using AggregationApp.Services.Helper;
using AggregationApp.Services.ServiceModels;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AggregationApp.Services.Implementations
{
    public class ElectricCityService : IElectricCityService
    {
        private readonly IAggrageteRepository _repo;
        private readonly IMapper _mapper;
        public ElectricCityService(IAggrageteRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IList<ElecticCityServiceModel>> GetFiltteredData()
           => await ApiServiceClient.RetriveData();

        public Task<bool> InsertDilteredData()
        {
            try
            {
                var data = GetFiltteredData();
                List<ElectricCityModel> model = _mapper.Map<List<ElectricCityModel>>(data);
                _repo.InsertAggregatedData(model);
                return Task.FromResult(true);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
