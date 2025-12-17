using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL.Context;
using DAL.Entities;
using DAL.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class PaymentRepository : GenericRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(BeautyLabContext context) : base(context)
        {
        }

        public async Task<List<Payment>> GetPaymentsByAppointmentIdAsync(int appointmentId)
        {
            return await _dbSet
                .Where(p => p.AppointmentId == appointmentId)
                .Include(p => p.Appointment)
                    .ThenInclude(a => a.Client)
                        .ThenInclude(c => c.User)
                .Include(p => p.Appointment)
                    .ThenInclude(a => a.Master)
                        .ThenInclude(m => m.User)
                .Include(p => p.Appointment)
                    .ThenInclude(a => a.Service)
                .ToListAsync();
        }

        public async Task<List<Payment>> GetPaymentsByStatusAsync(string status)
        {
            return await _dbSet
                .Where(p => p.Status == status)
                .Include(p => p.Appointment)
                    .ThenInclude(a => a.Client)
                        .ThenInclude(c => c.User)
                .Include(p => p.Appointment)
                    .ThenInclude(a => a.Master)
                        .ThenInclude(m => m.User)
                .Include(p => p.Appointment)
                    .ThenInclude(a => a.Service)
                .ToListAsync();
        }

        public async Task<Payment> GetPaymentWithAppointmentAsync(int paymentId)
        {
            return await _dbSet
                .Include(p => p.Appointment)
                    .ThenInclude(a => a.Client)
                        .ThenInclude(c => c.User)
                .Include(p => p.Appointment)
                    .ThenInclude(a => a.Master)
                        .ThenInclude(m => m.User)
                .Include(p => p.Appointment)
                    .ThenInclude(a => a.Service)
                .FirstOrDefaultAsync(p => p.PaymentId == paymentId);
        }

        public async Task<double> GetTotalPaymentsByAppointmentIdAsync(int appointmentId)
        {
            return await _dbSet.Where(p => p.AppointmentId == appointmentId).SumAsync(p => p.Amount);
        }
    }
}
