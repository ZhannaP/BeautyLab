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
    public class MasterServiceService : IMasterServiceService
    {
        private readonly IMasterServiceRepository _repository;
        private readonly IMapper _mapper;

        public MasterServiceService(IMasterServiceRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<MasterServiceResponse> CreateAsync(MasterServiceRequest request)
        {
            var entity = _mapper.Map<DAL.Entities.MasterService>(request);
            await _repository.AddAsync(entity);

            entity = await _repository.GetWithDetailsAsync(entity.MasterServiceId);

            return _mapper.Map<MasterServiceResponse>(entity);
        }

        public async Task<bool> DeleteAsync(int masterServiceId)
        {
            var entity = await _repository.GetByIdAsync(masterServiceId);
            if (entity == null)
                return false;

            await _repository.DeleteAsync(masterServiceId);
            return true;
        }

        public async Task<List<MasterServiceResponse>> GetAllAsync()
        {
            var entities = await _repository.GetMasterServicesWithDetailsAsync();
            return _mapper.Map<List<MasterServiceResponse>>(entities);
        }

        public async Task<MasterServiceResponse> GetByIdAsync(int masterServiceId)
        {
            var entity = await _repository.GetWithDetailsAsync(masterServiceId);
            return _mapper.Map<MasterServiceResponse>(entity);
        }

        public async Task<List<MasterServiceResponse>> GetByMasterIdAsync(int masterId)
        {
            var entities = await _repository.GetServicesByMasterIdAsync(masterId);
            return _mapper.Map<List<MasterServiceResponse>>(entities);
        }

        public async Task<List<MasterServiceResponse>> GetByServiceIdAsync(int serviceId)
        {
            var entities = await _repository.GetMastersByServiceIdAsync(serviceId);
            return _mapper.Map<List<MasterServiceResponse>>(entities);
        }

        public async Task<MasterServiceResponse> UpdateAsync(int masterServiceId, MasterServiceRequest request)
        {
            var entity = await _repository.GetByIdAsync(masterServiceId);
            if (entity == null)
                return null;

            _mapper.Map(request, entity);
            await _repository.UpdateAsync(entity);

            entity = await _repository.GetWithDetailsAsync(masterServiceId);

            return _mapper.Map<MasterServiceResponse>(entity);
        }
    }


}
