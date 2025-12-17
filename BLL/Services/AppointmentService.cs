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
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _repository;
        private readonly IMapper _mapper;

        public AppointmentService(IAppointmentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<AppointmentResponse> CreateAsync(AppointmentRequest request)
        {
            var entity = _mapper.Map<Appointment>(request);
            await _repository.AddAsync(entity);
            return _mapper.Map<AppointmentResponse>(entity);
        }

        public async Task<bool> DeleteAsync(int appointmentId)
        {
            var entity = await _repository.GetByIdAsync(appointmentId);
            if (entity == null)
                return false;

            await _repository.DeleteAsync(appointmentId);
            return true;
        }

        public async Task<List<AppointmentResponse>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<List<AppointmentResponse>>(entities);
        }

        public async Task<AppointmentResponse> GetByIdAsync(int appointmentId)
        {
            var entity = await _repository.GetAppointmentWithDetailsAsync(appointmentId);
            return _mapper.Map<AppointmentResponse>(entity);
        }

        public async Task<List<AppointmentResponse>> GetByClientIdAsync(int clientId)
        {
            var entities = await _repository.GetAppointmentsByClientIdAsync(clientId);
            return _mapper.Map<List<AppointmentResponse>>(entities);
        }

        public async Task<List<AppointmentResponse>> GetByMasterIdAsync(int masterId)
        {
            var entities = await _repository.GetAppointmentsByMasterIdAsync(masterId);
            return _mapper.Map<List<AppointmentResponse>>(entities);
        }

        public async Task<List<AppointmentResponse>> GetByStatusAsync(string status)
        {
            var entities = await _repository.GetAppointmentsByStatusAsync(status);
            return _mapper.Map<List<AppointmentResponse>>(entities);
        }

        public async Task<List<AppointmentResponse>> GetByDateAsync(DateTime date)
        {
            var entities = await _repository.GetAppointmentsByDateAsync(date);
            return _mapper.Map<List<AppointmentResponse>>(entities);
        }

        public async Task<AppointmentResponse> UpdateAsync(int appointmentId, AppointmentRequest request)
        {
            var entity = await _repository.GetByIdAsync(appointmentId);
            if (entity == null)
                return null;

            _mapper.Map(request, entity);
            await _repository.UpdateAsync(entity);
            return _mapper.Map<AppointmentResponse>(entity);
        }
    }
}
