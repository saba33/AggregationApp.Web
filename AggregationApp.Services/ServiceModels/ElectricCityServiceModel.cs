using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AggregationApp.Services.ServiceModels
{
    public class ElecticCityServiceModel
    {
        public int? Id { get; set; }
        public string Tinklas { get; set; }
        public string Obt_Pavadinimas { get; set; }
        public string Obj_Gv_Tipas { get; set; }
        public int Obj_Numeris { get; set; }
        public double P_Plus { get; set; }
        public string Pl_T { get; set; }
        public double P_Minus { get; set; }
        public double TotalPPlus{ get; set; }
        public double TotalPMinus{ get; set; }

        public ElecticCityServiceModel()
        {

        }
        public ElecticCityServiceModel(string apiResponse) 
        {
            string[] values = apiResponse.Split(',');

            Tinklas = values[0];
            Obt_Pavadinimas = values[1];
            Obj_Gv_Tipas = values[2];
            Obj_Numeris = int.Parse(values[3]);

            if(Double.TryParse(values[4], out double result))
                    P_Plus = result;
            else
                P_Plus = 0.00;
            Pl_T = values[5].ToString();

            if (Double.TryParse(values[4], out double res))
                P_Minus = result;
            else
                P_Minus = 0.00;
        }
    }
}
