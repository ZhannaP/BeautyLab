using BLL.Requests;
using BLL.Responses;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IMasterServiceService
    {
        Task<MasterServiceResponse> CreateAsync(MasterServiceRequest request);

        Task<MasterServiceResponse> GetByIdAsync(int masterServiceId);

        Task<List<MasterServiceResponse>> GetAllAsync();

        Task<List<MasterServiceResponse>> GetByMasterIdAsync(int masterId);

        Task<List<MasterServiceResponse>> GetByServiceIdAsync(int serviceId);

        Task<MasterServiceResponse> UpdateAsync(int masterServiceId, MasterServiceRequest request);

        Task<bool> DeleteAsync(int masterServiceId);
    }
}
