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
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UserResponse> CreateAsync(UserRequest request)
        {
            var entity = _mapper.Map<User>(request);
            await _repository.AddAsync(entity);
            return _mapper.Map<UserResponse>(entity);
        }

        public async Task<bool> DeleteAsync(int userId)
        {
            var entity = await _repository.GetByIdAsync(userId);
            if (entity == null)
                return false;

            await _repository.DeleteAsync(userId);
            return true;
        }

        public async Task<List<UserResponse>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<List<UserResponse>>(entities);
        }

        public async Task<UserResponse> GetByIdAsync(int userId)
        {
            var entity = await _repository.GetUserWithRoleAsync(userId);
            return _mapper.Map<UserResponse>(entity);
        }

        public async Task<UserResponse> GetByEmailAsync(string email)
        {
            var entity = await _repository.GetByEmailAsync(email);
            return _mapper.Map<UserResponse>(entity);
        }

        public async Task<List<UserResponse>> GetByRoleIdAsync(int roleId)
        {
            var entities = await _repository.GetUsersByRoleIdAsync(roleId);
            return _mapper.Map<List<UserResponse>>(entities);
        }

        public async Task<UserResponse> UpdateAsync(int userId, UserRequest request)
        {
            var entity = await _repository.GetByIdAsync(userId);
            if (entity == null)
                return null;

            _mapper.Map(request, entity);
            await _repository.UpdateAsync(entity);
            return _mapper.Map<UserResponse>(entity);
        }
    }
}
