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
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        public RoleRepository(BeautyLabContext context) : base(context)
        {
        }

        public async Task<Role> GetByNameAsync(string roleName)
        {
            return await _dbSet.FirstOrDefaultAsync(r => r.RoleName == roleName);
        }
    }
}
