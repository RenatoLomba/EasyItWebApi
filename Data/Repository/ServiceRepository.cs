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
    public class ServiceRepository : BaseRepository<ServiceEntity>, IServiceRepository
    {
        private readonly DbSet<ServiceEntity> _dataset;
        public ServiceRepository(MyContext context) : base(context)
        {
            _dataset = context.Set<ServiceEntity>();
        }

        public async Task<ServiceEntity> SelectAsync(string codigo)
        {
            try
            {
                var result = await _dataset.FirstOrDefaultAsync(s => s.Code.Equals(codigo));
                return result;
            } catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ServiceEntity> SelectComplete(Guid id)
        {
            try
            {
                var result = await _dataset.Include(s => s.Expert).FirstOrDefaultAsync(s => s.Id.Equals(id));
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
