using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AggregationApp.Services.AggregationEcceptions
{
    public class AggregationException: Exception
    {
        public AggregationException(string message) : base(message)
        {
        }

        public AggregationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
