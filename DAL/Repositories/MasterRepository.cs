using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    class MasterRepository : GenericRepository<Master>, IMasterRepository
    {
        public Task<Master> GetByUserIdAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Master>> GetMastersBySpecializationAsync(string specialization)
        {
            throw new NotImplementedException();
        }

        public Task<List<Master>> GetMastersWithExperienceGreaterThanAsync(int years)
        {
            throw new NotImplementedException();
        }

        public Task<Master> GetMasterWithUserAsync(int masterId)
        {
            throw new NotImplementedException();
        }
    }
}
