using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        public Task<Role> GetByNameAsync(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}
