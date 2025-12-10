using DAL.Entities;
using DAL.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    class ClientRepository : GenericRepository<Client>, IClientRepository
    {
        public Task<Client> GetByUserIdAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Client>> GetClientsWithNotesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Client> GetClientWithUserAsync(int clientId)
        {
            throw new NotImplementedException();
        }
    }
}
