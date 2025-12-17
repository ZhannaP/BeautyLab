using DAL.Context;
using DAL.Entities;
using DAL.Interfaces;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ClientRepository : GenericRepository<Client>, IClientRepository
    {
        public ClientRepository(BeautyLabContext context) : base(context)
        {
        }

        public async Task<Client> GetByUserIdAsync(int userId)
        {
            return await _dbSet.Include(c => c.User).FirstOrDefaultAsync(c => c.UserId == userId);
        }

        public async Task<List<Client>> GetClientsWithNotesAsync()
        {
            return await _dbSet.Where(c => !string.IsNullOrEmpty(c.Notes)).Include(c => c.User).ToListAsync();
        }

        public async Task<Client> GetClientWithUserAsync(int clientId)
        {
            return await _dbSet.Include(c => c.User).FirstOrDefaultAsync(c => c.ClientId == clientId);
        }
    }
}
