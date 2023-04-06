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
    public class AggrageteRepository<T> : IAggrageteRepository<T> where T : class
    {
        private readonly DatabaseContext _context;
        private readonly DbSet<T> _dbSet;
        public AggrageteRepository(DatabaseContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<bool> InsertAggregatedData(T models)
        {
            if (models == null) return false;

            await _dbSet.AddRangeAsync(models);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
