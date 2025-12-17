using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using BLL.Requests;
using BLL.Responses;
using BLL.Services.Interfaces;

using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _repository;
        private readonly IMapper _mapper;

        public ClientService(IClientRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ClientResponse> CreateAsync(ClientRequest request)
        {
            var entity = _mapper.Map<Client>(request);
            await _repository.AddAsync(entity);
            return _mapper.Map<ClientResponse>(entity);
        }

        public async Task<bool> DeleteAsync(int clientId)
        {
            var entity = await _repository.GetByIdAsync(clientId);
            if (entity == null)
                return false;

            await _repository.DeleteAsync(clientId);
            return true;
        }

        public async Task<List<ClientResponse>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<List<ClientResponse>>(entities);
        }

        public async Task<ClientResponse> GetByIdAsync(int clientId)
        {
            var entity = await _repository.GetByIdAsync(clientId);
            return _mapper.Map<ClientResponse>(entity);
        }

        public async Task<ClientResponse> GetByUserIdAsync(int userId)
        {
            var entity = await _repository.GetByUserIdAsync(userId);
            return _mapper.Map<ClientResponse>(entity);
        }

        public async Task<List<ClientResponse>> GetClientsWithNotesAsync()
        {
            var entities = await _repository.GetClientsWithNotesAsync();
            return _mapper.Map<List<ClientResponse>>(entities);
        }

        public async Task<ClientResponse> UpdateAsync(int clientId, ClientRequest request)
        {
            var entity = await _repository.GetByIdAsync(clientId);
            if (entity == null)
                return null;

            _mapper.Map(request, entity); 
            await _repository.UpdateAsync(entity);
            return _mapper.Map<ClientResponse>(entity);
        }
    }
}
