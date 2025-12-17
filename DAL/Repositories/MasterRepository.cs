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
    public class MasterRepository : GenericRepository<Master>, IMasterRepository
    {
        public MasterRepository(BeautyLabContext context) : base(context)
        {
        }

        public async Task<Master> GetByUserIdAsync(int userId)
        {
            return await _dbSet.Include(m => m.User).FirstOrDefaultAsync(m => m.UserId == userId);
        }

        public async Task<List<Master>> GetMastersBySpecializationAsync(string specialization)
        {
            return await _dbSet.Where(m => m.Specialization == specialization).Include(m => m.User).ToListAsync();
        }

        public async Task<List<Master>> GetMastersWithExperienceGreaterThanAsync(int years)
        {
            return await _dbSet.Where(m => m.ExperienceYears > years).Include(m => m.User).ToListAsync();
        }

        public async Task<Master> GetMasterWithUserAsync(int masterId)
        {
            return await _dbSet.Include(m => m.User).FirstOrDefaultAsync(m => m.MasterId == masterId);
        }
    }
}
