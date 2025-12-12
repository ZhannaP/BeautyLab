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
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _repository;
        private readonly IMapper _mapper;

        public PaymentService(IPaymentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PaymentResponse> CreateAsync(PaymentRequest request)
        {
            var entity = _mapper.Map<Payment>(request);

            await _repository.AddAsync(entity);

            var fullEntity = await _repository.GetPaymentWithAppointmentAsync(entity.PaymentId);

            return _mapper.Map<PaymentResponse>(fullEntity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                return false;

            await _repository.DeleteAsync(id);
            return true;
        }

        public async Task<List<PaymentResponse>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();

            var result = new List<PaymentResponse>();

            foreach (var p in entities)
            {
                var full = await _repository.GetPaymentWithAppointmentAsync(p.PaymentId);
                result.Add(_mapper.Map<PaymentResponse>(full));
            }

            return result;
        }

        public async Task<PaymentResponse> GetByIdAsync(int id)
        {
            var entity = await _repository.GetPaymentWithAppointmentAsync(id);
            return _mapper.Map<PaymentResponse>(entity);
        }

        public async Task<List<PaymentResponse>> GetByAppointmentIdAsync(int appointmentId)
        {
            var entities = await _repository.GetPaymentsByAppointmentIdAsync(appointmentId);
            return _mapper.Map<List<PaymentResponse>>(entities);
        }

        public async Task<List<PaymentResponse>> GetByStatusAsync(string status)
        {
            var entities = await _repository.GetPaymentsByStatusAsync(status);
            return _mapper.Map<List<PaymentResponse>>(entities);
        }

        public async Task<double> GetTotalPaymentsByAppointmentIdAsync(int appointmentId)
        {
            return await _repository.GetTotalPaymentsByAppointmentIdAsync(appointmentId);
        }

        public async Task<PaymentResponse> UpdateAsync(int id, PaymentRequest request)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                return null;

            _mapper.Map(request, entity);

            await _repository.UpdateAsync(entity);

            var fullEntity = await _repository.GetPaymentWithAppointmentAsync(entity.PaymentId);

            return _mapper.Map<PaymentResponse>(fullEntity);
        }
    }

}

