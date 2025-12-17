using BLL.Requests;
using BLL.Responses;

using DAL.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IMasterService
    {
        Task<MasterResponse> GetByIdAsync(int masterId);
        
        Task<List<MasterResponse>> GetAllAsync();

        Task<MasterResponse> GetByUserIdAsync(int userId);
        
        Task<List<MasterResponse>> GetBySpecializationAsync(string specialization);
        
        Task<List<MasterResponse>> GetWithExperienceGreaterThanAsync(int years);

        Task<MasterResponse> CreateAsync(MasterRequest request);
        
        Task<MasterResponse> UpdateAsync(int masterId, MasterRequest request);
        
        Task<bool> DeleteAsync(int masterId);
    }
}
