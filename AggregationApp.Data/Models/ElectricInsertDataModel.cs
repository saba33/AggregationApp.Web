using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace AggregationApp.Data.Models
{
    public class ElectricInsertDataModel
    {
        public int Id { get; set; }
        public string Tinklas { get; set; }
        public double TotalPPlus { get; set; }
        public double TotalPMinus { get; set; }
    }
}
