using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Context;
using Domain.Entities;
using Domain.Interfaces.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class TestimonialRepository : BaseRepository<TestimonialEntity>, ITestimonialRepository
    {
        private readonly DbSet<TestimonialEntity> _dataSet;

        public TestimonialRepository(MyContext context) : base(context)
        {
            _dataSet = context.Set<TestimonialEntity>();
        }

        public async Task<IEnumerable<TestimonialEntity>> SelectByExpertAsync(Guid expertId)
        {
            try
            {
                var result = await _dataSet.Where(t => t.ExpertId.Equals(expertId)).ToListAsync();
                return result;
            } catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TestimonialEntity> SelectCompleteAsync(Guid id)
        {
            try
            {
                var result = await _dataSet
                    .Include(t => t.Expert)
                    .Include(t => t.User)
                    .FirstOrDefaultAsync(t => t.Id.Equals(id));
                return result;
            } catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
