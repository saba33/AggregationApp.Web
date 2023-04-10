using AggregationApp.Services.AggregateEnums;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AggregationApp.Web.Middleware
{
    public class AggregateExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<AggregateExceptionMiddleware> _logger;

        public AggregateExceptionMiddleware(RequestDelegate next, ILogger<AggregateExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                AggregateDataResult dataResult = AggregateDataResult.Failure;

                if (ex is AggregateException aggregateEx)
                {
                    if (aggregateEx.InnerException is TimeoutException)
                    {
                        _logger.LogError(aggregateEx, "Occured Timeout Exception");
                        dataResult = AggregateDataResult.Timeout;
                    }
                    else if (aggregateEx.InnerException is ArgumentException)
                    {
                        _logger.LogError(aggregateEx, "Occured validation Exception");
                        dataResult = AggregateDataResult.ValidationError;
                    }
                    else
                    {
                        _logger.LogError(aggregateEx, "Occured Timeout Exception");
                        dataResult = AggregateDataResult.Failure;
                    }
                  
                    _logger.LogError(ex, "An aggregate exception occurred.");
                }
                else
                {
                    dataResult = AggregateDataResult.Failure;
                    _logger.LogError(ex, "An Unknown exception occurred.");
                }

                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonConvert.SerializeObject(new
                {
                    message = ex.Message,
                    dataResult = dataResult.ToString(),
                }));
            }
        }
    }
}