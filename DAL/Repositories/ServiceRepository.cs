using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    class ServiceRepository : GenericRepository<Service>, IServiceRepository
    {
        public Task<Service> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<List<Service>> GetServicesByMaxDurationAsync(int maxDuration)
        {
            throw new NotImplementedException();
        }
    }
}
