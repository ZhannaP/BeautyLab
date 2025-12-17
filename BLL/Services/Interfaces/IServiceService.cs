using BLL.Requests;
using BLL.Responses;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IServiceService
    {
        Task<ServiceResponse> GetByIdAsync(int serviceId);

        Task<List<ServiceResponse>> GetAllAsync();

        Task<ServiceResponse> GetByNameAsync(string name);

        Task<List<ServiceResponse>> GetByMaxDurationAsync(int maxDuration);

        Task<ServiceResponse> CreateAsync(ServiceRequest request);

        Task<ServiceResponse> UpdateAsync(int serviceId, ServiceRequest request);

        Task<bool> DeleteAsync(int serviceId);
    }
}
