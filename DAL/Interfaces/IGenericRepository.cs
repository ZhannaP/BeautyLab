using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL.Entities;

namespace DAL.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity.BaseEntity
    {
        Task<List<T>> GetAllAsync();

        Task<T> GetByIdAsync(int id);

        Task AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(int id);

        Task<int> SaveChangesAsync();
    }
}
