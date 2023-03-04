using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using AggregationApp.Services.ServiceModels;
using Microsoft.Extensions.Configuration;
using AggregationApp.Services.Implementations;
using System.Security.Cryptography.X509Certificates;

namespace AggregationApp.Services.Helper
{
    public static class ApiServiceClient
    {
        public static async Task<IList<ElecticCityServiceModel>> RetriveData()
        {
            string url = "";
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("C:\\Users\\Saba\\source\\repos\\AggregationApp.Web\\AggregationApp.Services\\Configurations\\callurls.json", optional: true, reloadOnChange: true)
                .Build();
            url = configuration["FourthMonthData"];

            using var client = new HttpClient();
            HttpResponseMessage data = await client.GetAsync(url);
            var content = await data.Content.ReadAsStringAsync();

            List<String> FormatedDataList = content.Split('\n').ToList();
            List<ElecticCityServiceModel> DataModels = new List<ElecticCityServiceModel>();

            FormatedDataList.RemoveAt(0);
            foreach (var item in FormatedDataList)
            {
                if (!String.IsNullOrEmpty(item))
                {

                    Console.WriteLine(item);
                    ElecticCityServiceModel model = new ElecticCityServiceModel(item);
                    DataModels.Add(model);
                }
            }
            List<ElecticCityServiceModel> FilteredData = DataModels.Where(x => x.Obt_Pavadinimas == "Butas").ToList();
            return FilteredData.GroupBy(x => x.Tinklas)
                         .Select(group => new ElecticCityServiceModel
                         {
                             Tinklas = group.Key,
                             TotalPPlus = group.Sum(x => x.P_Plus),
                             TotalPMinus = group.Sum(x => x.P_Minus)
                         }).ToList();
        }
    }

}

