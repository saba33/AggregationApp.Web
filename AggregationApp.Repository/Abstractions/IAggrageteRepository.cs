using AggregationApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AggregationApp.Repository.Abstractions
{
    public interface IAggrageteRepository<T> where T : class
    {
        Task<bool> InsertAggregatedData(T models);
    }
}
