using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces.RepositoryInterfaces
{
    public interface ITestimonialRepository : IRepository<TestimonialEntity>
    {
        public Task<TestimonialEntity> SelectCompleteAsync(Guid id);
        public Task<IEnumerable<TestimonialEntity>> SelectByExpertAsync(Guid expertId);
    }
}
