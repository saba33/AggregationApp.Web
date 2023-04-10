using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AggregationApp.Services.AggregateEnums
{
    public enum AggregateDataResult
    {
        Unknown = 0,
        Success = 1,
        PartialSuccess = 2,
        Failure = 3,
        Timeout = 4,
        ValidationError = 5
    }
}
