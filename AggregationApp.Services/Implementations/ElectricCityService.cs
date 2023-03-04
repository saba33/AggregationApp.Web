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

        public async Task<bool> InsertDilteredData()
        {
            try
            {
                var data = await GetFiltteredData();
                List<ElectricCityModel> model = _mapper.Map<List<ElectricCityModel>>(data);
                List<ElectricInsertDataModel> insetModel=  _mapper.Map<List<ElectricInsertDataModel>>(model);
                await _repo.InsertAggregatedData(insetModel);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
