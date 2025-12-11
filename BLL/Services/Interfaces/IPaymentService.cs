using BLL.Requests;
using BLL.Responses;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IPaymentService
    {
        Task<MasterServiceResponse> GetByIdAsync(int id);

        Task<List<MasterServiceResponse>> GetAllAsync();

        Task<MasterServiceResponse> GetByMasterAndServiceAsync(int masterId, int serviceId);

        Task<List<MasterServiceResponse>> GetByMasterIdAsync(int masterId);

        Task<List<MasterServiceResponse>> GetByServiceIdAsync(int serviceId);

        Task<MasterServiceResponse> CreateAsync(MasterServiceRequest request);

        Task<MasterServiceResponse> UpdateAsync(int id, MasterServiceRequest request);

        Task<bool> DeleteAsync(int id);
    }
}
