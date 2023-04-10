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
        public DataAggragationController(IElectricCityService cityService, ILogger<DataAggragationController> logger)
        {
            _cityService = cityService ?? throw new ArgumentNullException(nameof(cityService));
        }

        [HttpGet]
        public async Task<IActionResult> InsertAggragatedData()
        {
            try
            {
                var result = await _cityService.InsertFilteredData();
                return Ok(result);
            }
            catch (Exception e)
            {
                throw;
            }
            
        }

    }
}
