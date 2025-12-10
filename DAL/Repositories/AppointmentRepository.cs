using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
    {
        public Task<List<Appointment>> GetAppointmentsByClientIdAsync(int clientId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Appointment>> GetAppointmentsByDateAsync(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Task<List<Appointment>> GetAppointmentsByMasterIdAsync(int masterId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Appointment>> GetAppointmentsByStatusAsync(string status)
        {
            throw new NotImplementedException();
        }

        public Task<Appointment> GetAppointmentWithDetailsAsync(int appointmentId)
        {
            throw new NotImplementedException();
        }
    }
}
