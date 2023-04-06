using AggregationApp.Data.Models;
using Microsoft.EntityFrameworkCore;


namespace AggregationApp.Data.DbContexts
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }


        public DbSet<ElectricInsertDataModel> ElectricInsertDataModels { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {

        }
    }
}
