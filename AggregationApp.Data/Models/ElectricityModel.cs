using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AggregationApp.Data.Models
{
    public class ElectricCityModel
    {
        public int? Id { get; set; }
        public string Tinklas { get; set; }
        public string Obt_Pavadinimas{ get; set; }
        public string Obj_Gv_Tipas{ get; set; }
        public int Obj_Numeris{ get; set; }
        public double P_Plus{ get; set; }
        public string Pl_T { get; set; }
        public double P_Minus { get; set; }
        public double TotalPPlus { get; set; }
        public double TotalPMinus { get; set; }
        public ElectricCityModel()
        {

        }
    }
}
