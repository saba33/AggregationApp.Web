using AggregationApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AggregationApp.Repository.Abstractions
{
    public interface IAggrageteRepository
    {
        Task<bool> InsertAggregatedData(List<ElectricInsertDataModel> models);
    }
}
