using DAL.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IMasterServiceRepository : IGenericRepository<MasterService>
    {
        Task<MasterService> GetByMasterAndServiceAsync(int masterId, int serviceId);

        Task<List<MasterService>> GetMastersByServiceIdAsync(int serviceId);

        Task<List<MasterService>> GetServicesByMasterIdAsync(int masterId);

        Task<List<MasterService>> GetMasterServicesWithDetailsAsync();

        Task<MasterService> GetWithDetailsAsync(int masterServiceId);
    }

}
