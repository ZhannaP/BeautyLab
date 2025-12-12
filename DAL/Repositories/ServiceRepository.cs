using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL.Context;
using DAL.Entities;
using DAL.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class ServiceRepository : GenericRepository<Service>, IServiceRepository
    {
        public ServiceRepository(BeautyLabContext context) : base(context)
        {
        }

        public async Task<Service> GetByNameAsync(string name)
        {
            return await _dbSet.FirstOrDefaultAsync(s => s.Name == name);
        }

        public async Task<List<Service>> GetServicesByMaxDurationAsync(int maxDuration)
        {
            return await _dbSet.Where(s => s.Duration <= maxDuration).ToListAsync();
        }
    }
}
