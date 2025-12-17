using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL.Entities;

namespace DAL.Interfaces
{
    public interface IMasterRepository : IGenericRepository<Master>
    {
        Task<Master> GetByUserIdAsync(int userId);

        Task<List<Master>> GetMastersBySpecializationAsync(string specialization);

        Task<List<Master>> GetMastersWithExperienceGreaterThanAsync(int years);

        Task<Master> GetMasterWithUserAsync(int masterId);

        Task<List<Master>> GetAllWithUserAsync();

        Task<Master> GetByIdWithUserAsync(int masterId);
    }
}
