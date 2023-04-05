using AggregationApp.Data.DbContexts;
using AggregationApp.Data.Models;
using AggregationApp.Repository.Abstractions; 
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AggregationApp.Repository.Implementations
{
    public class AggrageteRepository : IAggrageteRepository
    {
        private readonly DatabaseContext _context;
        public readonly DbSet<ElectricInsertDataModel> _dbSet;
        public AggrageteRepository(DatabaseContext context)
        {
            _context = context;
            _dbSet = _context.Set<ElectricInsertDataModel>();
        }

        public async Task<bool> InsertAggregatedData(List<ElectricInsertDataModel> models)
        {
            if (models == null)
                return await Task.FromResult(false);
            await _dbSet.AddRangeAsync(models);
            _context.SaveChanges();
            return true;
        }
    }
}
