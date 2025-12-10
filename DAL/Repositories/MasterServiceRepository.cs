using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    class MasterServiceRepository : GenericRepository<MasterService>, IMasterServiceRepository
    {
        public Task<MasterService> GetByMasterAndServiceAsync(int masterId, int serviceId)
        {
            throw new NotImplementedException();
        }

        public Task<List<MasterService>> GetMastersByServiceIdAsync(int serviceId)
        {
            throw new NotImplementedException();
        }

        public Task<List<MasterService>> GetMasterServicesWithDetailsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<MasterService>> GetServicesByMasterIdAsync(int masterId)
        {
            throw new NotImplementedException();
        }
    }
}
