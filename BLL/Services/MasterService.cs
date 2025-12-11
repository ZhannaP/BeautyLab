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
    public class MasterService : IMasterService
    {
        private readonly IMasterRepository _repository;
        private readonly IMapper _mapper;

        public MasterService(IMasterRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<MasterResponse> CreateAsync(MasterRequest request)
        {
            var entity = _mapper.Map<Master>(request);
            await _repository.AddAsync(entity);
            return _mapper.Map<MasterResponse>(entity);
        }

        public async Task<bool> DeleteAsync(int masterId)
        {
            var entity = await _repository.GetByIdAsync(masterId);
            if (entity == null)
                return false;

            await _repository.DeleteAsync(masterId);
            return true;
        }

        public async Task<List<MasterResponse>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<List<MasterResponse>>(entities);
        }

        public async Task<MasterResponse> GetByIdAsync(int masterId)
        {
            var entity = await _repository.GetMasterWithUserAsync(masterId);
            return _mapper.Map<MasterResponse>(entity);
        }

        public async Task<MasterResponse> GetByUserIdAsync(int userId)
        {
            var entity = await _repository.GetByUserIdAsync(userId);
            return _mapper.Map<MasterResponse>(entity);
        }

        public async Task<List<MasterResponse>> GetBySpecializationAsync(string specialization)
        {
            var entities = await _repository.GetMastersBySpecializationAsync(specialization);
            return _mapper.Map<List<MasterResponse>>(entities);
        }

        public async Task<List<MasterResponse>> GetWithExperienceGreaterThanAsync(int years)
        {
            var entities = await _repository.GetMastersWithExperienceGreaterThanAsync(years);
            return _mapper.Map<List<MasterResponse>>(entities);
        }

        public async Task<MasterResponse> UpdateAsync(int masterId, MasterRequest request)
        {
            var entity = await _repository.GetByIdAsync(masterId);
            if (entity == null)
                return null;

            _mapper.Map(request, entity);
            await _repository.UpdateAsync(entity);
            return _mapper.Map<MasterResponse>(entity);
        }
    }
}
