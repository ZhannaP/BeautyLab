using BLL.Requests;
using BLL.Responses;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IAppointmentService
    {
        Task<AppointmentResponse> GetByIdAsync(int appointmentId);

        Task<List<AppointmentResponse>> GetAllAsync();

        Task<List<AppointmentResponse>> GetByClientIdAsync(int clientId);

        Task<List<AppointmentResponse>> GetByMasterIdAsync(int masterId);

        Task<List<AppointmentResponse>> GetByStatusAsync(string status);

        Task<List<AppointmentResponse>> GetByDateAsync(DateTime date);

        Task<AppointmentResponse> CreateAsync(AppointmentRequest request);

        Task<AppointmentResponse> UpdateAsync(int appointmentId, AppointmentRequest request);

        Task<bool> DeleteAsync(int appointmentId);
    }
}
