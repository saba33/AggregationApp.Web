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
        public decimal P_Plus { get; set; }
        public string Pl_T { get; set; }
        public decimal P_Minus { get; set; }
        public decimal TotalPPlus{ get; set; }
        public decimal TotalPMinus{ get; set; }


        public ElecticCityServiceModel(string apiResponse) 
        {
            string[] values = apiResponse.Split(',');

            Tinklas = values[0];
            Obt_Pavadinimas = values[1];
            Obj_Gv_Tipas = values[2];
            Obj_Numeris = int.Parse(values[3]);
            P_Plus = Decimal.Parse(values[4]);
            Pl_T = values[5].ToString();
            P_Minus = Decimal.Parse(values[6]);
        }
    }
}
