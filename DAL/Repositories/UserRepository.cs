using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL.Context;
using DAL.Entities;
using DAL.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(BeautyLabContext context) : base(context)
        {
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _dbSet.Include(u => u.Role).FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<List<User>> GetUsersByRoleIdAsync(int roleId)
        {
            return await _dbSet.Where(u => u.RoleId == roleId).Include(u => u.Role).ToListAsync();
        }

        public async Task<User> GetUserWithRoleAsync(int userId)
        {
            return await _dbSet.Include(u => u.Role).FirstOrDefaultAsync(u => u.UserId == userId);
        }
    }
}
