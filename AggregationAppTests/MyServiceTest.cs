using AggregationApp.Data.DbContexts;
using AggregationApp.Data.Models;
using AggregationApp.Repository.Abstractions;
using AggregationApp.Repository.Implementations;
using AggregationApp.Services.Abstractions;
using AggregationApp.Services.Implementations;
using AggregationApp.Services.ServiceModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace AggregationAppTests
{

    [TestClass]
    public class MyServiceTest
    {
        private readonly IElectricCityService _service;
        private readonly IConfiguration configuration;
        public MyServiceTest(IConfiguration configuration)
        {
            this.configuration = configuration;
            var services = new ServiceCollection();
            services.AddScoped<IAggrageteRepository, AggrageteRepository>();
            services.AddScoped<IElectricCityService, ElectricCityService>();
            var serviceProvider = services.BuildServiceProvider();
            _service = serviceProvider.GetService<IElectricCityService>();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DatabaseContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("connectionString")));
        }



        [TestMethod]
        public async Task RetriveData()
        {

            var expectedData = new List<ElecticCityServiceModel>
            {
            new ElecticCityServiceModel { Id = 1,Tinklas = "Klaipėdos regiono tinklas",Obt_Pavadinimas = null,Obj_Gv_Tipas = null,Obj_Numeris = 0,P_Plus = 0,Pl_T = null,P_Minus = 0,TotalPPlus = 7430.58060000009, TotalPMinus = 7430.58060000009 },
            new ElecticCityServiceModel { Id = 2,Tinklas = "Alytaus regiono tinklas",Obt_Pavadinimas = null,Obj_Gv_Tipas = null,Obj_Numeris = 0,P_Plus = 0,Pl_T = null,P_Minus = 0, TotalPPlus = 3659.5143, TotalPMinus = 3659.5143 },
            new ElecticCityServiceModel { Id = 3 ,Tinklas = "Panevėžio regiono tinklas",Obt_Pavadinimas = null,Obj_Gv_Tipas = null,Obj_Numeris = 0,P_Plus = 0,Pl_T = null,P_Minus = 0, TotalPPlus = 467.096799999999, TotalPMinus = 467.096799999999 },
            new ElecticCityServiceModel { Id = 4 ,Tinklas = "Kauno regiono tinklas",Obt_Pavadinimas = null,Obj_Gv_Tipas = null,Obj_Numeris = 0,P_Plus = 0,Pl_T = null,P_Minus = 0, TotalPPlus = 7372.66329999995, TotalPMinus = 7372.66329999995 },
            new ElecticCityServiceModel { Id = 5 ,Tinklas = "Vilniaus regiono tinklas", Obt_Pavadinimas = null,Obj_Gv_Tipas = null,Obj_Numeris = 0,P_Plus = 0,Pl_T = null,P_Minus = 0,TotalPPlus = 29857.0099330002, TotalPMinus = 29857.0099330002 },
            new ElecticCityServiceModel { Id = 6,Tinklas = "Šiaulių regiono tinklas", Obt_Pavadinimas = null,Obj_Gv_Tipas = null,Obj_Numeris = 0,P_Plus = 0,Pl_T = null,P_Minus = 0,TotalPPlus = 5323.7982, TotalPMinus = 5323.7982 },
            new ElecticCityServiceModel { Id = 7, Tinklas = "Utenos regiono tinklas",Obt_Pavadinimas = null,Obj_Gv_Tipas = null,Obj_Numeris = 0,P_Plus = 0,Pl_T = null,P_Minus = 0, TotalPPlus = 314.6309, TotalPMinus = 314.6309 }
            };


            var data = await _service.GetFiltteredData();
            List<ElecticCityServiceModel> actualData = data.ToList();

            Microsoft.VisualStudio.TestTools.UnitTesting.CollectionAssert.AreEqual(expectedData, actualData);
        }


    }


}