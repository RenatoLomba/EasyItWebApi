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
    public class ExpertRepository : BaseRepository<ExpertEntity>, IExpertRepository
    {
        private readonly DbSet<ExpertEntity> _dataset;
        public ExpertRepository(MyContext context) : base(context)
        {
            _dataset = context.Set<ExpertEntity>();
        }

        public async Task<IEnumerable<ExpertEntity>> SelectAsync(string location)
        {
            try
            {
                var result = await _dataset.Where(e =>
                    EF.Functions.Like(e.Location, string.Format("%{0}%", location))).ToListAsync();
                return result;
            } catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ExpertEntity> SelectCompleteAsync(Guid id)
        {
            try
            {
                var result = await _dataset
                    .Include(e => e.Services)
                    .Include(e => e.Photos)
                    .Include(e => e.Testimonials).ThenInclude(t => t.User)
                    .Include(e => e.AvailableDates).ThenInclude(t => t.AvailableHours)
                    .Include(e => e.Appointments)
                    .FirstOrDefaultAsync(e => e.Id.Equals(id));
                return result;
            } catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
