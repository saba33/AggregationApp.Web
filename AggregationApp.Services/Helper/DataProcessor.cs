using System.Collections.Generic;
using System.Threading.Tasks;
using AggregationApp.Services.Abstractions;
using AggregationApp.Services.ServiceModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace AggregationApp.Services.Helper
{
    public class DataProcessor: IDataProcessor
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<DataProcessor> _logger;

        public DataProcessor(IConfiguration configuration, ILogger<DataProcessor> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<IList<ElecticCityServiceModel>> RetrieveDataForAllMonths()
        {
            var allData = new List<ElecticCityServiceModel>();
            var monthKeys = new[] { "FirstMonthData", "SecondMonthData", "ThirdMonthData", "FourthMonthData" };
            foreach (var monthKey in monthKeys)
            {
                
                var monthUrl = _configuration.GetSection("ApiUrls").GetValue<string>(monthKey);
                //var monthUrl = apiUrls.GetValue<string>(monthKey);
                _logger.LogInformation($"Retrieving data from {monthUrl}");
                var monthData = await ApiServiceClient.RetriveData(monthUrl);
                _logger.LogInformation($"Retrieved {monthData.Count} records for {monthKey}");

                allData.AddRange(monthData);
            }

            return allData;
        }
    }
}
