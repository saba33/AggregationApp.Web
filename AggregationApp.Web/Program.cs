using AggregationApp.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using AggregationApp.Repository.Abstractions;
using AggregationApp.Repository.Implementations;
using AggregationApp.Services.Abstractions;
using AggregationApp.Services.Implementations;
using Microsoft.Extensions.DependencyInjection.Extensions;
using AggregationApp.Web.Middleware;
using AggregationApp.Services.Helper;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("http://0.0.0.0:5000");


builder.Services.AddControllers();
builder.Services.AddDbContext<DatabaseContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("connectionString")));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IElectricCityService, ElectricCityService>();
builder.Services.AddScoped(typeof(IAggrageteRepository<>), typeof(AggrageteRepository<>));
builder.Services.AddScoped<IDataProcessor, DataProcessor>();
IConfiguration Serviceconfiguration = new ConfigurationBuilder()
       .SetBasePath(Directory.GetCurrentDirectory())
       .AddJsonFile("callurls.json", optional: true, reloadOnChange: true)
       .Build();
builder.Services.AddSingleton(Serviceconfiguration);

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();
var logDirectory = configuration.GetValue<string>("LogDirectory");

Log.Logger = new LoggerConfiguration()
    .WriteTo.File
    (
    path: logDirectory,
    outputTemplate: "{Timestap: yyyy-mm-dd hh:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}",
    rollingInterval: RollingInterval.Day
    ).CreateLogger();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
Log.Information("Application Is Starting");
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<AggregateExceptionMiddleware>();

app.Run();
