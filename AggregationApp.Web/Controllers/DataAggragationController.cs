using AggregationApp.Services.Abstractions;
using AggregationApp.Services.Implementations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AggregationApp.Web.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DataAggragationController : ControllerBase
    {
        private readonly IElectricCityService _cityService;
        private readonly ILogger<DataAggragationController> _logger;
        public DataAggragationController(IElectricCityService cityService, ILogger<DataAggragationController> logger)
        {
            _cityService = cityService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> InsertAggragatedData()
        {
            try
            {
                _logger.LogInformation("Accessed InsertData EndPoint");
                return await Task.FromResult(Ok(_cityService.InsertDilteredData()));
            }
            catch (Exception e)
            {
                _logger.LogTrace(e.Message, e.StackTrace);
                throw;
            }
            
        }

    }
}
