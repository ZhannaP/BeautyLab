using BLL.Requests;
using BLL.Responses;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IPaymentService
    {
        Task<PaymentResponse> GetByIdAsync(int id);

        Task<List<PaymentResponse>> GetAllAsync();

        Task<List<PaymentResponse>> GetByAppointmentIdAsync(int appointmentId);

        Task<List<PaymentResponse>> GetByStatusAsync(string status);

        Task<double> GetTotalPaymentsByAppointmentIdAsync(int appointmentId);

        Task<PaymentResponse> CreateAsync(PaymentRequest request);

        Task<PaymentResponse> UpdateAsync(int id, PaymentRequest request);

        Task<bool> DeleteAsync(int id);
    }
}
