using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    class PaymentRepository : GenericRepository<Payment>, IPaymentRepository
    {
        public Task<List<Payment>> GetPaymentsByAppointmentIdAsync(int appointmentId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Payment>> GetPaymentsByStatusAsync(string status)
        {
            throw new NotImplementedException();
        }

        public Task<Payment> GetPaymentWithAppointmentAsync(int paymentId)
        {
            throw new NotImplementedException();
        }

        public Task<double> GetTotalPaymentsByAppointmentIdAsync(int appointmentId)
        {
            throw new NotImplementedException();
        }
    }
}
