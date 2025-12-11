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
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _repository;
        private readonly IMapper _mapper;

        public RoleService(IRoleRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<RoleResponse> CreateAsync(RoleRequest request)
        {
            var entity = _mapper.Map<Role>(request);
            await _repository.AddAsync(entity);
            return _mapper.Map<RoleResponse>(entity);
        }

        public async Task<bool> DeleteAsync(int roleId)
        {
            var entity = await _repository.GetByIdAsync(roleId);
            if (entity == null)
                return false;

            await _repository.DeleteAsync(roleId);
            return true;
        }

        public async Task<List<RoleResponse>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<List<RoleResponse>>(entities);
        }

        public async Task<RoleResponse> GetByIdAsync(int roleId)
        {
            var entity = await _repository.GetByIdAsync(roleId);
            return _mapper.Map<RoleResponse>(entity);
        }

        public async Task<RoleResponse> GetByNameAsync(string roleName)
        {
            var entity = await _repository.GetByNameAsync(roleName);
            return _mapper.Map<RoleResponse>(entity);
        }

        public async Task<RoleResponse> UpdateAsync(int roleId, RoleRequest request)
        {
            var entity = await _repository.GetByIdAsync(roleId);
            if (entity == null)
                return null;

            _mapper.Map(request, entity);
            await _repository.UpdateAsync(entity);
            return _mapper.Map<RoleResponse>(entity);
        }
    }
}
