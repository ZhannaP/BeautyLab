using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BLL.Requests;
using BLL.Responses;

namespace BLL.Services.Interfaces
{
    public interface IRoleService
    {
        Task<RoleResponse> GetByIdAsync(int roleId);

        Task<List<RoleResponse>> GetAllAsync();

        Task<RoleResponse> GetByNameAsync(string roleName);

        Task<RoleResponse> CreateAsync(RoleRequest request);
        Task<RoleResponse> UpdateAsync(int roleId, RoleRequest request);
        Task<bool> DeleteAsync(int roleId);
    }
}
