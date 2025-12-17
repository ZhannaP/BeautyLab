using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL.Entities;

namespace DAL.Interfaces
{
    public interface IClientRepository : IGenericRepository<Client>
    {
        Task<Client> GetByUserIdAsync(int userId);

        Task<List<Client>> GetClientsWithNotesAsync();

        Task<Client> GetClientWithUserAsync(int clientId);
    }
}
