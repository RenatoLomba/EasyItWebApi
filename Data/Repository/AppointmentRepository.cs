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
    public class AppointmentRepository : BaseRepository<AppointmentEntity>, IAppointmentRepository
    {
        private readonly DbSet<AppointmentEntity> _dataSet;

        public AppointmentRepository(MyContext context) : base(context)
        {
            _dataSet = context.Set<AppointmentEntity>();
        }

        public async Task<AppointmentEntity> SelectCompleteAsync(Guid id)
        {
            var result = await _dataSet
                .Include(a => a.Expert)
                .Include(a => a.Service)
                .FirstOrDefaultAsync(a => a.Id.Equals(id));
            return result;
        }
    }
}
