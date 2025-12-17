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
    public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(BeautyLabContext context) : base(context)
        {
        }

        public async Task<List<Appointment>> GetAppointmentsByClientIdAsync(int clientId)
        {
            return await _dbSet
                .Where(a => a.ClientId == clientId)
                .Include(a => a.Client)
                    .ThenInclude(c => c.User)
                .Include(a => a.Master)
                    .ThenInclude(m => m.User)
                .Include(a => a.Service)
                .ToListAsync();
        }

        public async Task<List<Appointment>> GetAppointmentsByMasterIdAsync(int masterId)
        {
            return await _dbSet
                .Where(a => a.MasterId == masterId)
                .Include(a => a.Client)
                    .ThenInclude(c => c.User)
                .Include(a => a.Master)
                    .ThenInclude(m => m.User)
                .Include(a => a.Service)
                .ToListAsync();
        }

        public async Task<List<Appointment>> GetAppointmentsByDateAsync(DateTime date)
        {
            return await _dbSet
                .Where(a => a.StartTime.Date == date.Date)
                .Include(a => a.Client)
                    .ThenInclude(c => c.User)
                .Include(a => a.Master)
                    .ThenInclude(m => m.User)
                .Include(a => a.Service)
                .ToListAsync();
        }

        public async Task<List<Appointment>> GetAppointmentsByStatusAsync(string status)
        {
            return await _dbSet
                .Where(a => a.Status == status)
                .Include(a => a.Client)
                    .ThenInclude(c => c.User)
                .Include(a => a.Master)
                    .ThenInclude(m => m.User)
                .Include(a => a.Service)
                .ToListAsync();
        }

        public async Task<Appointment> GetAppointmentWithDetailsAsync(int appointmentId)
        {
            return await _dbSet
                .Include(a => a.Client)
                    .ThenInclude(c => c.User)
                .Include(a => a.Master)
                    .ThenInclude(m => m.User)
                .Include(a => a.Service)
                .FirstOrDefaultAsync(a => a.AppointmentId == appointmentId);
        }
    }
}
