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
        public decimal P_Plus{ get; set; }
        public string Pl_T { get; set; }
        public decimal P_Minus { get; set; }
        public decimal TotalPPlus { get; set; }
        public decimal TotalPMinus { get; set; }
    }
}
