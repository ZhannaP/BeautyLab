using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    class UserRepository : GenericRepository<User>, IUserRepository
    {
        public Task<User> GetByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetUsersByRoleIdAsync(int roleId)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserWithRoleAsync(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
