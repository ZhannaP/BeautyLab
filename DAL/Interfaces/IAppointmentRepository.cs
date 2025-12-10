using DAL.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IAppointmentRepository : IGenericRepository<Appointment>
    {
        Task<List<Appointment>> GetAppointmentsByClientIdAsync(int clientId);

        Task<List<Appointment>> GetAppointmentsByMasterIdAsync(int masterId);

        Task<List<Appointment>> GetAppointmentsByDateAsync(DateTime date);

        Task<List<Appointment>> GetAppointmentsByStatusAsync(string status);

        Task<Appointment> GetAppointmentWithDetailsAsync(int appointmentId);
    }
}
