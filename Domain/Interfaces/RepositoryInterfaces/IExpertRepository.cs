using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces.RepositoryInterfaces
{
    public interface IExpertRepository : IRepository<ExpertEntity>
    {
        public Task<IEnumerable<ExpertEntity>> SelectAsync(string location);
        public Task<ExpertEntity> SelectCompleteAsync(Guid id);
    }
}
