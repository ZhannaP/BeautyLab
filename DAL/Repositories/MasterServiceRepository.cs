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
    public class MasterServiceRepository : GenericRepository<MasterService>, IMasterServiceRepository
    {
        public MasterServiceRepository(BeautyLabContext context) : base(context)
        {
        }

        public async Task<MasterService> GetByMasterAndServiceAsync(int masterId, int serviceId)
        {
            return await _dbSet
                .Include(ms => ms.Master)
                    .ThenInclude(m => m.User)
                .Include(ms => ms.Service)
                .FirstOrDefaultAsync(ms => ms.MasterId == masterId && ms.ServiceId == serviceId);
        }

        public async Task<List<MasterService>> GetMastersByServiceIdAsync(int serviceId)
        {
            return await _dbSet
                .Where(ms => ms.ServiceId == serviceId)
                .Include(ms => ms.Master)
                    .ThenInclude(m => m.User)
                .Include(ms => ms.Service)
                .ToListAsync();
        }

        public async Task<List<MasterService>> GetServicesByMasterIdAsync(int masterId)
        {
            return await _dbSet
                .Where(ms => ms.MasterId == masterId)
                .Include(ms => ms.Master)
                    .ThenInclude(m => m.User)
                .Include(ms => ms.Service)
                .ToListAsync();
        }

        public async Task<List<MasterService>> GetMasterServicesWithDetailsAsync()
        {
            return await _dbSet
                .Include(ms => ms.Master)
                    .ThenInclude(m => m.User)
                .Include(ms => ms.Service)
                .ToListAsync();
        }

        public async Task<MasterService> GetWithDetailsAsync(int masterServiceId)
        {
            return await _dbSet
                .Include(ms => ms.Master)
                    .ThenInclude(m => m.User)
                .Include(ms => ms.Service)
                .FirstOrDefaultAsync(ms => ms.MasterServiceId == masterServiceId);
        }
    }
}
