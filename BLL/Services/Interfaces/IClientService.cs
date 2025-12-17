using BLL.Requests;
using BLL.Responses;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IClientService
    {
        Task<ClientResponse> GetByIdAsync(int clientId);

        Task<List<ClientResponse>> GetAllAsync();

        Task<ClientResponse> GetByUserIdAsync(int userId);

        Task<List<ClientResponse>> GetClientsWithNotesAsync();

        Task<ClientResponse> CreateAsync(ClientRequest request);

        Task<ClientResponse> UpdateAsync(int clientId, ClientRequest request);

        Task<bool> DeleteAsync(int clientId);
    }
}
