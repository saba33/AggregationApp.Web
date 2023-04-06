using System;


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
