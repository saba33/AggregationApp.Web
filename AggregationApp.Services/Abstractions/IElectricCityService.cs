using AggregationApp.Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AggregationApp.Services.Abstractions
{
    public interface IElectricCityService
    {
        Task<IList<ElecticCityServiceModel>> GetFiltteredData();
        Task<bool> InsertDilteredData();

    }
}
