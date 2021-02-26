using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Data.Context;
using Domain.Entities;
using Domain.Interfaces.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class AvailableDateRepository : BaseRepository<AvailableDateEntity>, IAvailableDateRepository
    {
        private readonly DbSet<AvailableDateEntity> _dataSet;

        public AvailableDateRepository(MyContext context) : base(context)
        {
            _dataSet = context.Set<AvailableDateEntity>();
        }

        public async Task<AvailableDateEntity> SelectCompleteAsync(Guid id)
        {
            try
            {
                var result = await _dataSet
                    .Include(a => a.AvailableHours)
                    .Include(a => a.Expert)
                    .FirstOrDefaultAsync(a => a.Id.Equals(id));
                return result;
            } catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
