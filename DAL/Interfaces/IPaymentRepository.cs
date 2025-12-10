using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL.Entities;

namespace DAL.Interfaces
{
    public interface IPaymentRepository : IGenericRepository<Payment>
    {
        Task<List<Payment>> GetPaymentsByAppointmentIdAsync(int appointmentId);

        Task<List<Payment>> GetPaymentsByStatusAsync(string status);

        Task<double> GetTotalPaymentsByAppointmentIdAsync(int appointmentId);

        Task<Payment> GetPaymentWithAppointmentAsync(int paymentId);
    }
}
