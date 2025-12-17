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
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _repository;
        private readonly IMapper _mapper;

        public ServiceService(IServiceRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse> CreateAsync(ServiceRequest request)
        {
            var entity = _mapper.Map<Service>(request);
            await _repository.AddAsync(entity);
            return _mapper.Map<ServiceResponse>(entity);
        }

        public async Task<bool> DeleteAsync(int serviceId)
        {
            var entity = await _repository.GetByIdAsync(serviceId);
            if (entity == null)
                return false;

            await _repository.DeleteAsync(serviceId);
            return true;
        }

        public async Task<List<ServiceResponse>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<List<ServiceResponse>>(entities);
        }

        public async Task<ServiceResponse> GetByIdAsync(int serviceId)
        {
            var entity = await _repository.GetByIdAsync(serviceId);
            return _mapper.Map<ServiceResponse>(entity);
        }

        public async Task<ServiceResponse> GetByNameAsync(string name)
        {
            var entity = await _repository.GetByNameAsync(name);
            return _mapper.Map<ServiceResponse>(entity);
        }

        public async Task<List<ServiceResponse>> GetByMaxDurationAsync(int maxDuration)
        {
            var entities = await _repository.GetServicesByMaxDurationAsync(maxDuration);
            return _mapper.Map<List<ServiceResponse>>(entities);
        }

        public async Task<ServiceResponse> UpdateAsync(int serviceId, ServiceRequest request)
        {
            var entity = await _repository.GetByIdAsync(serviceId);
            if (entity == null)
                return null;

            _mapper.Map(request, entity);
            await _repository.UpdateAsync(entity);
            return _mapper.Map<ServiceResponse>(entity);
        }
    }
}
