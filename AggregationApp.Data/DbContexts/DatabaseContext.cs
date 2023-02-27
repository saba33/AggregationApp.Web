using AggregationApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AggregationApp.Data.DbContexts
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options) { }


        public DbSet<ElectricCityModel> ElectricityModels { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {

        }
    }
}
