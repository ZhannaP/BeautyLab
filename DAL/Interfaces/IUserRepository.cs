using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL.Entities;

namespace DAL.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetByEmailAsync(string email);

        Task<List<User>> GetUsersByRoleIdAsync(int roleId);

        Task<User> GetUserWithRoleAsync(int userId);
    }
}
