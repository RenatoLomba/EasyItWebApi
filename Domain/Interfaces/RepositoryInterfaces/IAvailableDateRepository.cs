using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces.RepositoryInterfaces
{
    public interface IAvailableDateRepository : IRepository<AvailableDateEntity>
    {
        public Task<AvailableDateEntity> SelectCompleteAsync(Guid id);
    }
}
