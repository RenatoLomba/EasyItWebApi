using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces.RepositoryInterfaces
{
    public interface IServiceRepository : IRepository<ServiceEntity>
    {
        public Task<ServiceEntity> SelectAsync(string codigo);
        public Task<ServiceEntity> SelectComplete(Guid id);
    }
}
