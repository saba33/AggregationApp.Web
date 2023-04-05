using AggregationApp.Data.Models;
using AggregationApp.Repository.Abstractions;
using AggregationApp.Repository.Implementations;
using AggregationApp.Services.Abstractions;
using AggregationApp.Services.AggregateEnums;
using AggregationApp.Services.Helper;
using AggregationApp.Services.ServiceModels;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<ElectricCityService> _logger;
        private readonly ILogger<DataProcessor> _dataProcessotLogger;
        private readonly IConfiguration _configuration;

        public ElectricCityService(
             IAggrageteRepository repo,
             IMapper mapper,
             ILogger<ElectricCityService> logger,
             IConfiguration configuration,
             IDataProcessor dataProcessor,
             ILogger<DataProcessor> dataProcessorLogger)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _dataProcessotLogger = dataProcessorLogger ?? throw new ArgumentNullException(nameof(dataProcessorLogger));
        }

        public async Task<IList<ElectricCityModel>> GetFilteredData()
        {
            try
            {
                var dataRetriever = new DataProcessor(_configuration, _dataProcessotLogger);
                var result = await dataRetriever.RetrieveDataForAllMonths();
                return _mapper.Map<List<ElectricCityModel>>(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving data.");
                throw;
            }
        }

        public async Task<AggregateDataResult> InsertFilteredData()
        {
            try
            {
                var data = await GetFilteredData();
                List<ElectricInsertDataModel> insetModel = _mapper.Map<List<ElectricInsertDataModel>>(data);
                await _repo.InsertAggregatedData(insetModel);
                return AggregateDataResult.Success;
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while inserting aggregated data.");
                return AggregateDataResult.Failure;
            }
        }
    }
}
