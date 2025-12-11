using BLL.Requests;
using BLL.Responses;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserResponse> GetByIdAsync(int userId);

        Task<List<UserResponse>> GetAllAsync();

        Task<UserResponse> GetByEmailAsync(string email);

        Task<List<UserResponse>> GetByRoleIdAsync(int roleId);

        Task<UserResponse> CreateAsync(UserRequest request);

        Task<UserResponse> UpdateAsync(int userId, UserRequest request);
        Task<bool> DeleteAsync(int userId);
    }
}
